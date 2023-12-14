namespace MiddlewarePractice.MiddleWares
{
    public class MyMiddleware : IMiddleware
    {
        static int i = 0;
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            context.Response.Headers[i++.ToString()] = i++.ToString();
            await next(context);
            context.Response.Headers[i++.ToString()] = i++.ToString();
        }
    }
    public static class MyMiddlewareExtenxions
    {
        public static IApplicationBuilder MyMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyMiddleware>();
        }
    }
}