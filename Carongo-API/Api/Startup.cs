using Dominio.Handlers.Commands.Instituicoes;
using Dominio.Handlers.Commands.Usuarios;
using Dominio.Repositorios;
using Infra.Contextos;
using Infra.Repositorios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });

            services.AddDbContext<CarongoContexto>(o => o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Carongo API", Version = "v1" });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "Carongo",
                        ValidAudience = "Carongo",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Carongo-b71e507ae8f44b4396530166279942af"))
                    };
                });

            #region Injeção de dependência Usuario

            services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddTransient<CadastrarUsuarioCommandHandler, CadastrarUsuarioCommandHandler>();
            services.AddTransient<LogarCommandHandler, LogarCommandHandler>();
            services.AddTransient<AlterarUsuarioCommandHandler, AlterarUsuarioCommandHandler>();
            services.AddTransient<AlterarSenhaCommandHandler, AlterarSenhaCommandHandler>();
            services.AddTransient<SolicitarNovaSenhaCommandHandler, SolicitarNovaSenhaCommandHandler>();
            services.AddTransient<RedefinirSenhaCommandHandler, RedefinirSenhaCommandHandler>();
            services.AddTransient<DeletarContaCommandHandler, DeletarContaCommandHandler>();

            #endregion

            #region Injeção de depndência Instituição

            services.AddTransient<IInstituicaoRepositorio, InstituicaoRepositorio>();
            services.AddTransient<CriarInstituicaoCommandHandler, CriarInstituicaoCommandHandler>();
            services.AddTransient<EntrarNaInstituicaoCommandHandler, EntrarNaInstituicaoCommandHandler>();

            #endregion
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(s => s.SwaggerEndpoint("/swagger/v1/swagger.json", "Carongo API"));
            }

            //app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors(c => c.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}