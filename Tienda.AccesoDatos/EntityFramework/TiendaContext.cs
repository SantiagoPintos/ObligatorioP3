using Microsoft.EntityFrameworkCore;
using Tienda.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.AccesoDatos.EntityFramework
{
    public class TiendaContext : DbContext
    {
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Encargado> Encargado { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }
        public DbSet<TipoMovimiento> TiposMovimiento { get; set; }
        public DbSet<Setting> Settings { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"SERVER=(localdb)\MsSqlLocalDb;DATABASE=PapeleriaBDDM3C;Integrated Security=true;");
        }


    }
}
