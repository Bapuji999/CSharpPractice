using System.Text;

namespace MiddlewarePractice.MiddleWares
{
    public class AuthHandler
    {
        private readonly RequestDelegate _next;
        private readonly string _realm;
        public AuthHandler(RequestDelegate next, string realm) 
        { 
            this._next = next;
            this._realm = realm;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.ContainsKey("Authorization"))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("UnAuthorized");
                return;
            }
            var header = context.Request.Headers["Authorization"].ToString();
            var encodedCreds = header.Substring(6);
            var cred = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCreds));
            string[] uidPwd = cred.Split(':');
            var uid = uidPwd[0];
            var password = uidPwd[1];
            if (uid != "John" || password != "Password")
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("UnAuthorized");
                return;
            }
            await _next(context);
        }
    }
}
