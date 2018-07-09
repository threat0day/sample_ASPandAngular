using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.SpaServices.Webpack;
using test2Metanit.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace test2Metanit
{
	//public class Startup
	//{
	//	public void ConfigureServices(IServiceCollection services)
	//	{
	//		string connectionString = "Data Source=localhost;Initial Catalog=MyShop2;Integrated Security=True";
	//	   services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));

	//		services.AddMvc();
	//	}

	//	public void Configure(IApplicationBuilder app, IHostingEnvironment env)
	//	{
	//		if (env.IsDevelopment())
	//		{
	//			app.UseDeveloperExceptionPage();

	//			// добавляем сборку через webpack
	//			app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
	//			{
	//				HotModuleReplacement = true
	//			});
	//		}

	//		//app.UseDefaultFiles();
	//		app.UseStaticFiles();
	//		app.UseMvc(routes =>
	//		{
	//			routes.MapRoute(
	//				name: "default",
	//				template: "{controller=Home}/{action=Index}/{id?}");
	//			routes.MapSpaFallbackRoute("angular-fallback",
	//				new
	//				{
	//					controller = "Home",
	//					action = "Index"
	//				});
	//		});

	//		//app.Run(async (context) =>
	//		//{
	//		//	context.Response.ContentType = "text/html";
	//		//	await context.Response.SendFileAsync(Path.Combine(env.WebRootPath, "index.html"));
	//		//});

	//		//app.UseMvc(routes =>
	//		//{
	//		//	routes.MapRoute(
	//		//		name: "default",
	//		//		template: "{controller=Home}/{action=Index}/{id?}");

	//		//	routes.MapSpaFallbackRoute("angular-fallback",
	//		//		new
	//		//		{
	//		//			controller = "Home",
	//		//			action = "Index"
	//		//		});
	//		//});
	//	}
	//}

	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			string connectionString = "Data Source=localhost;Initial Catalog=MyShop2;Integrated Security=True";
			services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));

			services.AddMvc();
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
				{
					HotModuleReplacement = true
				});
			}

			app.UseDefaultFiles();
			app.UseStaticFiles();
			app.UseMvc();
			app.Run(async (context) =>
			{
				context.Response.ContentType = "text/html";
				await context.Response.SendFileAsync(Path.Combine(env.WebRootPath, "index.html"));
			});
		}
	}
}
