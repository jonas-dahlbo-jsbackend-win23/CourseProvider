using CourseProvider.Infrastructure.Data.Contexts;
using CourseProvider.Infrastructure.GraphQL;
using CourseProvider.Infrastructure.GraphQL.Mutations;
using CourseProvider.Infrastructure.GraphQL.ObjectTypes;
using CourseProvider.Infrastructure.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
.ConfigureFunctionsWebApplication()
.ConfigureServices(services =>
{
    services.AddApplicationInsightsTelemetryWorkerService();
    services.ConfigureFunctionsApplicationInsights();

    services.AddPooledDbContextFactory<DataContext>(x =>
    {
        x.UseCosmos(Environment.GetEnvironmentVariable("Cosmos_URI")!, Environment.GetEnvironmentVariable("Cosmos_DB")!)
        .UseLazyLoadingProxies();
    });


    services.AddScoped<ICourseService, CourseService>();

    services.AddGraphQLFunction()
            .AddQueryType<Query>()
            .AddMutationType<CourseMutation>()
            .AddType<CourseType>();



    var serviceProvider = services.BuildServiceProvider();
    using var scope = serviceProvider.CreateScope();
    var dbContextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<DataContext>>();
    using var context = dbContextFactory.CreateDbContext();
    context.Database.EnsureCreated();
})
.Build();

host.Run();
