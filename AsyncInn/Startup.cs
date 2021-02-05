using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using AsyncInn.Models.Interfaces.Services;
using Swashbuckle.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AsyncInn.Models;
using Microsoft.AspNetCore.Identity;
using AsyncInn.Models.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;


namespace AsyncInn
{
  public class Startup
  {
    public IConfiguration Configuration { get; }
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<AsyncInnDbContext>(options =>
      {     
        
        // Our DATABASE_URL from js days
        string connectionString = Configuration.GetConnectionString("DefaultConnection");
        options.UseSqlServer(connectionString);
      });
      services.AddIdentity<ApplicationUser, IdentityRole>(options =>
      {
        options.User.RequireUniqueEmail = true;
      })
        .AddEntityFrameworkStores<AsyncInnDbContext>();

      //JWT Registration
      services.AddScoped<JwtTokenService>();
      services.AddAuthentication(options =>
      {
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      })
        .AddJwtBearer(options =>
        {
          options.TokenValidationParameters = JwtTokenService.GetValidationParameters(Configuration);
        });

      
      services.AddTransient<IUserService, IdentityUserService>();
      services.AddTransient<IRoom, RoomRepository>();
      services.AddTransient<IHotel, HotelRepository>();
      services.AddTransient<IAmenity, AmenityRepository>();
      services.AddTransient<IHotelRoom, HotelRoomRepository>();
      services.AddMvc();

      
      
      //Swagger 
      services.AddSwaggerGen(options => options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo() {
        Title = "Async Inn",
        Version = "v1",
      }));
      services.AddControllers().AddNewtonsoftJson(options =>
      options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);           
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
      app.UseEndpoints(endpoints =>
      {        
        endpoints.MapControllers();
      });
      app.UseSwagger(options =>
      {
        options.RouteTemplate = "/api/{documentName}/swagger.json";
      });
      app.UseSwaggerUI(options =>
      {
        options.SwaggerEndpoint("api/v1/swagger.json", "Async Inn");
        options.RoutePrefix = "";
      });
    }


  }
}
