var builder = DistributedApplication.CreateBuilder(args);

var sqlServer = builder.AddSqlServer("SqlServer")
    .WithLifetime(ContainerLifetime.Persistent);
var db = sqlServer.AddDatabase("BlogDb", "blog");

builder.AddProject<Projects.HybridCacheExample_ApiService>("ApiService")
    .WithReference(db)
    .WithExternalHttpEndpoints();

builder.Build().Run();