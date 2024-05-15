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
builder.Services.AddScoped<IObtenerUsuarioPorID, ObtenerUsuarioPorID>();
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Usuario}/{action=Index}/{id?}");

app.Run();
