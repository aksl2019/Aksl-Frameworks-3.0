using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;

using Contoso.Infrastructure.Data.Context;

//Add-Migration init -Contex  ContosoContext
//Remove-Migration   -Contex  ContosoContext
//Update-Database init  -Contex  ContosoContext

namespace Contoso.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ContosoContext>(dbContextOptionsBuilder =>
            {
                //string sqliteConnectionString = Configuration.GetConnectionString("ContosoSqlite");
                //dbContextOptionsBuilder.UseSqlite(sqliteConnectionString);

                ////将EF迁移文件生成到当前应用程序的程序集下
                //dbContextOptionsBuilder.UseSqlite(sqliteConnectionString, b => b.MigrationsAssembly("Contoso.Api"));

                string sqlServerConnectionString = Configuration.GetConnectionString("ContosoSqlServer");
                dbContextOptionsBuilder.UseSqlServer(sqlServerConnectionString, sqlServerDbContextOptionsBuilder => sqlServerDbContextOptionsBuilder.UseNetTopologySuite());

                // 将EF迁移文件生成到当前应用程序的程序集下
                dbContextOptionsBuilder.UseSqlServer(sqlServerConnectionString, b => b.MigrationsAssembly("Contoso.Api"));

                //Coordinate:坐标 longitude:经度  latitude:纬度  Geometry:几何形状
                var geometryFactory = NetTopologySuite.NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
                var currentLocation = geometryFactory.CreatePoint(new NetTopologySuite.Geometries.Coordinate(   -122.121512, 47.6739882));// X :经度， Y :纬度
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
