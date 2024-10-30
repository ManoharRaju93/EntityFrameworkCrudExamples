using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.Threading.Tasks;

namespace UserName_PasswordApplication.CustomMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LoginMiddleware
    {
        private readonly RequestDelegate _next;

        public LoginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path == "/" && httpContext.Request.Method == "POST")
            {
                StreamReader reader = new StreamReader(httpContext.Request.Body);
                string body = await reader.ReadToEndAsync();

                //Parse the request body from string into Dictionary
                Dictionary<string, StringValues> dictData = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);
                string? email = null;
                string? password = null;

                //read the UserName
                if (dictData.ContainsKey("email"))
                {
                    email = Convert.ToString(dictData["email"][0]);
                }
                else
                {
                    httpContext.Response.StatusCode = 400;
                    await httpContext.Response.WriteAsync("Invalid input for 'email'\n");
                }

                // read the PWD
                if (dictData.ContainsKey("password"))
                {
                    password = Convert.ToString(dictData["password"][0]);
                }
                else
                {
                    httpContext.Response.StatusCode = 400;
                    await httpContext.Response.WriteAsync("Invalid input for 'email'\n");
                }

                // if both email & password has passed
                if (string.IsNullOrEmpty(email) == false && string.IsNullOrEmpty(password) == false)
                {
                    string validEmail = "admin@example.com", validPassword = "admin1234";
                    bool isValidLogin = false;
                    //await httpContext.Response.WriteAsync($"<p> the email is {email}</p>");
                    //await httpContext.Response.WriteAsync($"<p> the email is {password}</p>");
                    //await httpContext.Response.WriteAsync($"<p> the email is {validEmail}</p>");
                    //await httpContext.Response.WriteAsync($"<p> the email is {validPassword}</p>");
                    if (email == validEmail && password == validPassword)
                    {
                        isValidLogin = true;
                    }
                    else
                    {
                        isValidLogin = false;
                    }

                    if (isValidLogin)
                    {
                        await httpContext.Response.WriteAsync("Successful login\n");
                    }
                    else
                    {
                        await httpContext.Response.WriteAsync("Invalid login\n");
                    }                
            } //end of string.IsNullOrEmpty Method
        }//end of "if method == POST"
    
            else {
                await _next(httpContext);
    }
}
}

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LoginMiddlewareExtensions
{
    public static IApplicationBuilder UseLoginMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<LoginMiddleware>();
    }
}
}
