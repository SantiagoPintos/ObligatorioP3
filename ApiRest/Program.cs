using Tienda.AccesoDatos.EntityFramework.Repositorios;
using Tienda.LogicaAplicacion.CasosDeUso.Articulo;
using Tienda.LogicaAplicacion.CasosDeUso.Cliente;
using Tienda.LogicaAplicacion.CasosDeUso.MovimientoStock;
using Tienda.LogicaAplicacion.CasosDeUso.Pedido;
using Tienda.LogicaAplicacion.CasosDeUso.Settings;
using Tienda.LogicaAplicacion.CasosDeUso.TipoMovimiento;
using Tienda.LogicaAplicacion.CasosDeUso.Usuario;
using Tienda.LogicaAplicacion.CasosDeUso.Encargado;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Articulo;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Cliente;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Movimiento;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Pedido;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Settings;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.TipoMovimiento;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Usuario;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Encargado;
using Tienda.LogicaNegocio.InterfacesRepositorio;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Swashbuckle.AspNetCore.Filters;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Encargado;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Token;
using Tienda.LogicaAplicacion.CasosDeUso.Movimiento;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var Clave = "ZWRpw6fDo28gZW0gY29tcHV0YWRvcmE=";


builder.Services.AddAuthentication(aut =>
{
    aut.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

    aut.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(aut =>
    {
        aut.RequireHttpsMetadata = false;
        aut.SaveToken = true;
        aut.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Clave)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

var ruta = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ApiRest.xml");
builder.Services.AddSwaggerGen(
        opciones =>
        {
            opciones.AddSecurityDefinition("oauth2", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
            {
                Description = "Autorización estándar mediante esquema Bearer",
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });
            opciones.OperationFilter<SecurityRequirementsOperationFilter>();
            opciones.IncludeXmlComments(ruta);
            opciones.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "Tienda",
                Description = "Aplicacion para gestionar stock.",
                Contact = new Microsoft.OpenApi.Models.OpenApiContact
                {
                    Email = "email@email.com"
                },
                Version = "v1"
            });
        }
    );


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddScoped<IRepositorioArticulo, RepositorioArticuloEF>();
builder.Services.AddScoped<IRepositorioPedido, RepositorioPedidoEF>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuarioEF>();
builder.Services.AddScoped<IRepositorioCliente, RepositorioClienteEF>();
builder.Services.AddScoped<IRepositorioTipoMovimiento, RepositorioTipoMovimientoEF>();
builder.Services.AddScoped<IRepositorioSettings, RepositorioSettingsEF>();
builder.Services.AddScoped<IRepositorioMovimiento, RepositorioMovimientoEF>();
builder.Services.AddScoped<IRepositorioEncargado, RepositorioEncargadoEF>();

//casos de uso
builder.Services.AddScoped<ICreateUsuario, CrearUsuarioCU>();
builder.Services.AddScoped<ILoginUsuario, LoginUsuarioCU>();
builder.Services.AddScoped<ICreateCliente, CrearClienteCU>();
builder.Services.AddScoped<IObtenerClientes, ObtenerClientesCU>();
builder.Services.AddScoped<IListarUsuario, ListarUsuarioCU>();
builder.Services.AddScoped<IObtenerUsuarioPorID, ObtenerUsuarioPorIDCU>();
builder.Services.AddScoped<IEditarUsuario, EditarUsuarioCU>();
builder.Services.AddScoped<IEliminarUsuario, EliminarUsuarioCU>();
builder.Services.AddScoped<ICrearArticulo, CrearArticuloCU>();
builder.Services.AddScoped<IListarArticulo, ListarArticuloCU>();
builder.Services.AddScoped<IListarAlfabeticamente, ListarAlfabeticamenteCU>();
builder.Services.AddScoped<IEliminarArticulo, EliminarArticuloCU>();
builder.Services.AddScoped<IObtenerArticuloPorId, ObtenerArticuloPorIdCU>();
builder.Services.AddScoped<IEditarArticulo, EditarArticuloCU>();
builder.Services.AddScoped<IObtenerClientePorNombreApellido, ObtenerClientePorNombreApellidoCU>();
builder.Services.AddScoped<IBuscarClientePorMontoPedido, BuscarClientePorMontoPedidoCU>();
builder.Services.AddScoped<IListarPedidos, ListarPedidosCU>();
builder.Services.AddScoped<ICrearPedido, CrearPedidoCU>();
builder.Services.AddScoped<IObtenerClientePorId, ObtenerClientePorIdCU>();
builder.Services.AddScoped<ICalcularStock, CalcularStockCU>();
builder.Services.AddScoped<IListarPedidosNoEntregados, ListarPedidosNoEntregadosCU>();
builder.Services.AddScoped<IAnularPedido, AnularPedidoCU>();
builder.Services.AddScoped<IListarPedidosAnulados, ListarPedidosAnuladosCU>();
builder.Services.AddScoped<IListarTipoMovimiento, ListarTipoMovimientoCU>();
builder.Services.AddScoped<ICreateTipoMovimiento, CrearTipoMovimientoCU>();
builder.Services.AddScoped<IEliminarTipoMovimiento, EliminarTipoMovimientoCU>();
builder.Services.AddScoped<IEditarTipoMovimiento, EditarTipoMovimientoCU>();
builder.Services.AddScoped<IEncontrarPorNombreTipoMovimiento, EncontrarPorNombreTipoMovimientoCU>();
builder.Services.AddScoped<IActualizarSetting, ActualizarSettingCU>();
builder.Services.AddScoped<ICreateMovimientoStock, CrearMovimientoStockCU>();
builder.Services.AddScoped<IObtenerEncargadoPorEmail, ObtenerEncargadoPorEmailCU>();
builder.Services.AddScoped<ILoginEncargado, LoginEncargadoCU>();
builder.Services.AddScoped<IObtenerMovimientosSobreArticulo, ObtenerMovimientosStobreArticuloCU>();
builder.Services.AddScoped<IObtenerArticulosConMovimientosEntreFechas, ObtenerArticulosConMovimientosEntreFechasCU>();
builder.Services.AddScoped<IObtenerResumenCantidadesMovidas, ObtenerResumenCandidadesMovidasCU>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
