using SUS.HTTP;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMvcApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IHttpServer server = new HttpServer();
            
            server.AddRoute("/", HomePage);

            server.AddRoute("/favicon.ico", Favicon);

            server.AddRoute("/about", About);

            server.AddRoute("/users/login", Login);

            await server.StartAsync();
        }

        private static HttpResponse Favicon(HttpRequest request)
        {
            var fileBytes = File.ReadAllBytes("wwwroot/favicon.ico");
            var response = new HttpResponse("image/vnd.microsoft.icon", fileBytes);
            return response;
        }

        static HttpResponse HomePage(HttpRequest request)
        {
            var responseHtml = "<h1>welcome back, mr.anderson </h1>" +
                        request.Headers.FirstOrDefault(x => x.Name == "user-agent")?.Value;
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);
           
            return response;
        }
        static HttpResponse About(HttpRequest request)
        {
            var responseHtml = "<h1>About us... </h1>" +
                        request.Headers.FirstOrDefault(x => x.Name == "user-agent")?.Value;
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);
           
            return response;
        }
        static HttpResponse Login(HttpRequest request)
        {
            var responseHtml = "<h1>Log In </h1>" +
                        request.Headers.FirstOrDefault(x => x.Name == "user-agent")?.Value;
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }
    }
}
