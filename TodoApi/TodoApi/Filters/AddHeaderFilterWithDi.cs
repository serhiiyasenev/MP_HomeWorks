using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace TodoApi.Filters
{
    public class AddHeaderFilterWithDi : IResultFilter
    {
        private readonly ILogger _logger;
        public AddHeaderFilterWithDi(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<AddHeaderFilterWithDi>();
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            var headerName = "OnResultExecuting";
            context.HttpContext.Response.Headers.Add(
                headerName, new string[] { "ResultExecutingSuccessfully" });
            _logger.LogInformation($"Header added: {headerName}");
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            // Can't add to headers here because response has already begun.
        }
    }
}