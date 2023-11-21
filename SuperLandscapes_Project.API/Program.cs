
using Microsoft.OpenApi.Models;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using SuperLandscapes_Project.DAL.GenericRepository.Interface;
using SuperLandscapes_Project.DAL.GenericRepository;
using SuperLandscapes_Project.DAL.UnitOfWork.Interface;
using SuperLandscapes_Project.DAL.UnitOfWork;
using SuperLandscapes_Project.SuperLandscapes_Project.BLL.Services;
using SuperLandscapes_Project.SuperLandscapes_Project.BLL.Services.Interfaces;
using AutoMapper;
using SuperLandscapes_Project.BLL.AutoMapper;

namespace SuperLandscapes_Project.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Swagger!"
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                /*options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));*/
            });

            builder.Services.AddScoped<SqlConnection>(configurations => new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IDbTransaction>(configurations =>
            {
                SqlConnection connection = configurations.GetRequiredService<SqlConnection>();
                connection.Open();
                return connection.BeginTransaction();
            });

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IProjectService, ProjectService>();
            builder.Services.AddScoped(options => new MapperConfiguration(configurations =>
            {
                configurations.AddProfile<BaseProfile>();
                configurations.AddProfile<CountryProfile>();
                configurations.AddProfile<ParagraphProfile>();
                configurations.AddProfile<PictureProfile>();
                configurations.AddProfile<ProjectProfile>();
                configurations.AddProfile<TechnologyProfile>();
            }).CreateMapper());

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}