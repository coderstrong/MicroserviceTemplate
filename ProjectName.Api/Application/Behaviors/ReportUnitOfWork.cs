using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using ProjectName.Infrastructure.Database;
using System;
using System.Threading.Tasks;

namespace ProjectName.Api.Application.Behaviors
{
    public class ReportUnitOfWorkAttribute : TypeFilterAttribute
    {
        public ReportUnitOfWorkAttribute(bool useTransaction = false) : base(typeof(ReportUnitOfWorkAsync))
        {
            Arguments = new object[] { useTransaction };
        }

        private class ReportUnitOfWorkAsync : IAsyncActionFilter
        {
            private readonly ILogger _logger;
            private readonly PortalContext _context;
            private readonly bool _isTransaction;

            public ReportUnitOfWorkAsync(PortalContext context, ILogger<ReportUnitOfWorkAttribute> logger, bool isTransaction)
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
                    using (var transaction = _context.Database.BeginTransaction())
                    {
                        // next() calls the action method.
                        var resultContext = await next();
                        //Do something after the action executes.
                        if (resultContext.Exception == null)
                        {
                            try
                            {
                                _context.SaveChanges();
                                transaction.Commit();
                            }
                            catch (Exception ex)
                            {
                                _logger.LogError(ex, "context commit false");
                                transaction.Rollback();
                            }
                        }
                    }
                }
                else
                {
                    // next() calls the action method.
                    var resultContext = await next();
                    //Do something after the action executes.
                    if (resultContext.Exception == null)
                    {
                        _context.SaveChanges();
                    }
                }

            }
        }
    }
}
