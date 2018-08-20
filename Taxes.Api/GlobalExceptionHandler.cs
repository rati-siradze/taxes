using System.Web.Http.ExceptionHandling;

namespace Taxes.Api
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            context.Result = new InternalErrorResult("Unexpected error occured");
            base.Handle(context);
        }

        public override bool ShouldHandle(ExceptionHandlerContext context)
        {
            return true;
        }
    }
}