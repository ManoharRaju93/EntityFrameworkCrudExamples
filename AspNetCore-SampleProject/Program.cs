using Microsoft.Extensions.Primitives;
using System.IO;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("hello Manohar");
});

app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("hello Harsha");
});

//app.MapGet("/", () => "Hello World!");
//app.Run(async (HttpContext context) =>
//{
//context.Response.Headers["Content-type"] = "text/html";
//if (context.Request.Method == "GET")
//{
//    if (context.Request.Query.ContainsKey("id"))
//    {
//        string id = context.Request.Query["id"];
//        await context.Response.WriteAsync($"<p> {id} </p>");
//    }
//}
//if (context.Request.Headers.ContainsKey("AuthorizationKey"))
//{
//    string authKey = context.Request.Headers["AuthorizationKey"];
//    await context.Response.WriteAsync($"<p> {authKey} </p>");
//}

//StreamReader reader = new StreamReader(context.Request.Body);
//string body = await reader.ReadToEndAsync();
//float result;
//Dictionary<string, StringValues> querydict = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);
//if (context.Request.Method == "GET" && context.Request.Path == "/")
//{
//    if (querydict.ContainsKey("operation"))
//    {
//        string operationValue = querydict["operation"].ToString().ToUpper();
//        if (operationValue == "ADD" || operationValue == "+")
//        {
//            int firstNumber = Convert.ToInt32(querydict["firstNumber"][0]);
//            int secondNumber = Convert.ToInt32(querydict["secondNumber"][0]);
//            result = firstNumber + secondNumber;

//            await context.Response.WriteAsync($"<h1> The Addtion Result is {result} </h1>");

//        }
//        else if (operationValue == "SUB" || operationValue == "-")
//        {
//            int firstNumber = Convert.ToInt32(querydict["firstNumber"][0]);
//            int secondNumber = Convert.ToInt32(querydict["secondNumber"][0]);
//            result = firstNumber - secondNumber;

//            await context.Response.WriteAsync($"<h1> The Subtract Result is {result} </h1>");

//        }
//        else if (operationValue == "MUL" || operationValue == "*")
//        {
//            int firstNumber = Convert.ToInt32(querydict["firstNumber"][0]);
//            int secondNumber = Convert.ToInt32(querydict["secondNumber"][0]);
//            result = firstNumber * secondNumber;

//            await context.Response.WriteAsync($"<h1> The Multiple Result is {result} </h1>");

//        }
//        else if (operationValue == "DIV" || operationValue == "/")
//        {
//            int firstNumber = Convert.ToInt32(querydict["firstNumber"][0]);
//            int secondNumber = Convert.ToInt32(querydict["secondNumber"][0]);
//            result = firstNumber / secondNumber;

//            await context.Response.WriteAsync($"<h1> The Divide Result is {result} </h1>");

//        }
//    }
//}

//});

app.Run();
