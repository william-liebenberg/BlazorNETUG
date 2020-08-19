using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Markdig;
using Markdig.SyntaxHighlighting;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace BlazorNETUG
{
	public static class Program
	{
		public static async Task Main(string[] args)
		{
			WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("app");

			// builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
			builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:7071") });

			// Create Serilog logger with BrowserConsole sink
			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Debug()
				.WriteTo.BrowserConsole()
				.CreateLogger();

			Log.Information("Hello, browser!!");

			builder.Services.AddLogging(builder => builder
				.SetMinimumLevel(LogLevel.Trace)
			);

    		// Install 2x NuGet packages
			// "Markdig" and "Markdig.SyntaxHighlighting"
			builder.Services
				.AddSingleton<MarkdownPipeline>(
					sp => new MarkdownPipelineBuilder()
						.UseAdvancedExtensions()
						.UseSyntaxHighlighting()
						.Build());

			await builder.Build().RunAsync();
		}
	}
}
