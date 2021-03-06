using Dominio.Handlers.Commands.Alunos;
using Dominio.Handlers.Commands.Instituicoes;
using Dominio.Handlers.Commands.Turmas;
using Dominio.Handlers.Commands.Usuarios;
using Dominio.Handlers.Queries.Alunos;
using Dominio.Handlers.Queries.Instituicoes;
using Dominio.Handlers.Queries.Turmas;
using Dominio.Handlers.Queries.Usuarios;
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

            #region Inje��o de depend�ncia Usuario

            services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddTransient<CadastrarUsuarioCommandHandler, CadastrarUsuarioCommandHandler>();
            services.AddTransient<LogarCommandHandler, LogarCommandHandler>();
            services.AddTransient<AlterarUsuarioCommandHandler, AlterarUsuarioCommandHandler>();
            services.AddTransient<AlterarSenhaCommandHandler, AlterarSenhaCommandHandler>();
            services.AddTransient<SolicitarNovaSenhaCommandHandler, SolicitarNovaSenhaCommandHandler>();
            services.AddTransient<RedefinirSenhaCommandHandler, RedefinirSenhaCommandHandler>();
            services.AddTransient<DeletarContaCommandHandler, DeletarContaCommandHandler>();

            services.AddTransient<ListarMeuPerfilQueryHandler, ListarMeuPerfilQueryHandler>();
            services.AddTransient<ListarPessoasDaInstituicaoQueryHandler, ListarPessoasDaInstituicaoQueryHandler>();

            #endregion

            #region Inje��o de depend�ncia Institui��o

            services.AddTransient<IInstituicaoRepositorio, InstituicaoRepositorio>();
            services.AddTransient<CriarInstituicaoCommandHandler, CriarInstituicaoCommandHandler>();
            services.AddTransient<EntrarNaInstituicaoCommandHandler, EntrarNaInstituicaoCommandHandler>();
            services.AddTransient<AdicionarAdministradorCommandHandler, AdicionarAdministradorCommandHandler>();
            services.AddTransient<SairDaInstituicaoCommandHandler, SairDaInstituicaoCommandHandler>();
            services.AddTransient<AdicionarTurmaCommandHandler, AdicionarTurmaCommandHandler>();
            services.AddTransient<ExpulsarColaboradorCommandHandler, ExpulsarColaboradorCommandHandler>();
            services.AddTransient<AlterarInstituicaoCommandHandler, AlterarInstituicaoCommandHandler>();
            services.AddTransient<DeletarInstituicaoCommandHandler, DeletarInstituicaoCommandHandler>();

            services.AddTransient<ListarMinhasInstituicoesQueryHandler, ListarMinhasInstituicoesQueryHandler>();
            services.AddTransient<ListarDetalhesDaInstituicaoQueryHandler, ListarDetalhesDaInstituicaoQueryHandler>();

            #endregion

            #region Inje��o de depend�ncia Turma

            services.AddTransient<ITurmaRepositorio, TurmaRepositorio>();
            services.AddTransient<AdicionarAlunoCommandHandler, AdicionarAlunoCommandHandler>();
            services.AddTransient<AlterarTurmaCommandHandler, AlterarTurmaCommandHandler>();
            services.AddTransient<DeletarTurmaCommandHandler, DeletarTurmaCommandHandler>();

            services.AddTransient<ListarDetalhesTurmaQueryHandler, ListarDetalhesTurmaQueryHandler>();

            #endregion

            #region Inje��o de depend�ncia Aluno

            services.AddTransient<IAlunoRepositorio, AlunoRepositorio>();
            services.AddTransient<AlterarAlunoCommandHandler, AlterarAlunoCommandHandler>();
            services.AddTransient<DeletarAlunoCommandHandler, DeletarAlunoCommandHandler>();
            services.AddTransient<ListarAlunoPorIdQueryHandler, ListarAlunoPorIdQueryHandler>();
            
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