// See https://aka.ms/new-console-template for more information
using DeltaFlows.Core;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddDeltaFlows(flows => flows
        .Add("product"));

using IHost host = builder.Build();


await host.RunAsync();