using Ecommercetask.Data.Model;
using Newtonsoft.Json;
using System.Net;

namespace Ecommercetask.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        public RequestDelegate _requestDelegate;
        public ExceptionHandlingMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context, ILogger<ExceptionHandlingMiddleware> logger)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex, logger);
            }
        }

        private static Task HandleException(HttpContext context, Exception ex, ILogger<ExceptionHandlingMiddleware> logger)
        {
            //logger.LogError(ex.ToString());
            var statusCode = (int)HttpStatusCode.BadRequest;

            var errorMessageObject = new Error { Message = ex.Message, Code = statusCode.ToString().Trim(), Path = ex.StackTrace };
            switch (ex)
            {
                case InvalidException:
                    errorMessageObject.Code = "M001";
                    statusCode = (int)HttpStatusCode.BadRequest;
                    break;
            }
            var errorMessage = JsonConvert.SerializeObject(errorMessageObject);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            logger.LogError(errorMessage.ToString());
            return context.Response.WriteAsync(errorMessage);
        }

        public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args).ConfigureLogging(logging =>
        {
            logging.AddLog4Net(new Log4NetProviderOptions("log4net.config"));
        })
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Program>();
        });

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
    }
}