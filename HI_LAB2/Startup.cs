using HI_LAB2.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HI_LAB2
{
	public class Startup
	{
		private IConfiguration Configuration { get; set; }

		public Startup(IConfiguration config)
		{
			Configuration = config;
		}
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews();
			services.AddControllersWithViews().AddNewtonsoftJson();
			services.AddDbContext<ProductContext>(opts =>
		   {
			   opts.UseSqlServer(Configuration["ConnectionStrings:ProdConnStr"]);
		   });
			services.AddScoped<IProductRepository, EFProductRepository>();
			services.AddScoped<ICategoryRepository, EFCategoryRepository>();
			services.AddSwaggerGen();
		}


		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseDeveloperExceptionPage();
			app.UseStaticFiles();
			app.UseStatusCodePages();
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product/Category API V1");
			});
			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapDefaultControllerRoute();
			});
			InitialData.EnsurePopulated(app);
		}
	}
}
