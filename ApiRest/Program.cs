using Tienda.AccesoDatos.EntityFramework.Repositorios;
using Tienda.LogicaAplicacion.CasosDeUso.Articulo;
using Tienda.LogicaAplicacion.CasosDeUso.Cliente;
using Tienda.LogicaAplicacion.CasosDeUso.Pedido;
using Tienda.LogicaAplicacion.CasosDeUso.Usuario;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Articulo;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Cliente;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Pedido;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Usuario;
using Tienda.LogicaNegocio.InterfacesRepositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddScoped<IRepositorioArticulo, RepositorioArticuloEF>();
builder.Services.AddScoped<IRepositorioPedido, RepositorioPedidoEF>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuarioEF>();
builder.Services.AddScoped<IRepositorioCliente, RepositorioClienteEF>();
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


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
