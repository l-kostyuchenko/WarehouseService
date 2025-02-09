using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Serilog;
using System.Reflection;
using Warehouse.Application.Extensions;
using Warehouse.Persistence.Extensions;
using Warehouse.WebApi.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
	var basePath = AppContext.BaseDirectory;
	var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
	var xmlPath = Path.Combine(basePath, xmlFile);
	options.IncludeXmlComments(xmlPath);
});

builder.Services.AddApplication();
builder.Services.AddPersistence();
builder.Services.AddContextExtension(builder.Configuration);

builder.Services.AddApiVersioning(options =>
{
	options.ReportApiVersions = true;
	options.DefaultApiVersion = new ApiVersion(1, 0);
	options.AssumeDefaultVersionWhenUnspecified = true;
	options.ApiVersionReader = new UrlSegmentApiVersionReader();
})
.AddApiExplorer(options =>
{
	options.GroupNameFormat = "'v'VVV";
	options.SubstituteApiVersionInUrl = true;
});

builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

builder.Host.UseSerilog((context, configuration) =>
	configuration.ReadFrom.Configuration(context.Configuration)
		.Enrich.FromLogContext());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(options =>
	{
		var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
		foreach (var description in provider.ApiVersionDescriptions)
		{
			options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
		}
	});
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Services.UseDBMigration();

app.Run();
