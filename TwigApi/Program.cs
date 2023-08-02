using Microsoft.AspNetCore.Mvc;
using TwigApi;
using TwigEnvironment = Twig.Environment;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTwig();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/", (HttpContext context, [FromServices] TwigEnvironment twig) =>
{
    var template = twig.load("index.html.twig");

    var dictionary = new Dictionary<string, object>
    {
        { "Title", "It Works!" }
    };

    context.Response.ContentType = "text/html";

    return template.Render(dictionary);
});

app.Run();
