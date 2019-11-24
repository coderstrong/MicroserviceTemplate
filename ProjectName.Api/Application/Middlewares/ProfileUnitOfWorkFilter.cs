using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using ProjectName.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectName.Api.Application.Middlewares
{
    public class ProfileUnitOfWorkFilter : IActionFilter
    {
        private readonly ILogger _logger;
        private readonly IContext _context;
        public ProfileUnitOfWorkFilter(ProfileContext context, ILogger<ProfileUnitOfWorkFilterAttribute> logger)
        {
            _context = context;
            _logger = logger;
        }
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception == null)
            {
                try
                {
                    _context.Commit();
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex, "context commit false");
                    _context.Rollback();
                }
            }
                
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _logger.LogInformation(_context.OperationId.ToString());
            _context.BeginTransaction();
        }
    }

    public class ProfileUnitOfWorkFilterAttribute : TypeFilterAttribute
    {
        public ProfileUnitOfWorkFilterAttribute() : base(typeof(ProfileUnitOfWorkFilter))
        {
        }
    }
}
