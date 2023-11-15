using Autofac;
using Autofac.Extensions.DependencyInjection;
using SME.ErrorHandling;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => DependencyContainer.ConfigureContainer(builder));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(c =>
    {
        c.RouteTemplate = "crm/swagger/{documentName}/swagger.json";
    });

    //specifying the Swagger JSON endpoint.
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/crm/swagger/v1/swagger.json", "crm");
        c.RoutePrefix = "crm/swagger";
    });
}

app.ConfigureCustomExceptionMiddleware();

// app.UseHttpsRedirection();

// app.UseAuthorization();

app.MapControllers();

app.Run();
