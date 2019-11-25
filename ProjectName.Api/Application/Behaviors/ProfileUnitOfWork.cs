using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using ProjectName.Infrastructure.Database;
using System;
using System.Threading.Tasks;

namespace ProjectName.Api.Application.Behaviors
{
    public class ProfileUnitOfWorkAttribute : TypeFilterAttribute
    {
        public ProfileUnitOfWorkAttribute(bool isTransaction = false) : base(typeof(ProfileUnitOfWorkAsync))
        {
            Arguments = new object[] { isTransaction };
        }

        private class ProfileUnitOfWorkAsync : IAsyncActionFilter
        {
            private readonly ILogger _logger;
            private readonly IContext _context;
            private readonly bool _isTransaction;

            public ProfileUnitOfWorkAsync(ProfileContext context, ILogger<ProfileUnitOfWorkAttribute> logger, bool isTransaction)
            {
                _context = context;
                _logger = logger;
                _isTransaction = isTransaction;
            }

            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                // Do something before the action executes.
                _logger.LogInformation(_context.OperationId().ToString());
                if (_isTransaction)
                {
                    _context.BeginTransaction();
                }
                // next() calls the action method.
                var resultContext = await next();
                //Do something after the action executes.
                if (resultContext.Exception == null)
                {
                    if (_isTransaction)
                    {
                        try
                        {
                            _context.Commit();
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex, "context commit false");
                            _context.Rollback();
                        }
                    }
                    else
                    {
                        _context.SaveChanges();
                    }
                }
            }
        }
    }
}