using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.Entidades;
using Tienda.LogicaNegocio.InterfacesRepositorio;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tienda.AccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioMovimientoEF : IRepositorioMovimiento
    {
        private TiendaContext _context;
        public RepositorioMovimientoEF()
        {
            this._context = new TiendaContext();
        }
        public bool Add(Movimiento aAgregar)
        {
            try
            {
                aAgregar.EsValido();
                aAgregar.TipoMovimiento.EsValido();
                this._context.Entry(aAgregar.TipoMovimiento).State = EntityState.Unchanged;
                this._context.Entry(aAgregar.Articulo).State = EntityState.Unchanged;
                this._context.Set<Movimiento>().Add(aAgregar);
                this._context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Movimiento> FindAll()
        {
            return this._context.Movimientos
                .Include(m => m.TipoMovimiento)
                .Include(m => m.Articulo)
                .ToList();
        }

        public Movimiento FindByID(int id)
        {
            throw new NotImplementedException();
        }

        //Dado un rango de fechas, seleccionar los artículos que hayan tenido movimientos (al menos uno) entre esas fechas inclusive.
        public IEnumerable<Articulo> ObtenerArticulosConMovimientosEntreFechas(DateTime fchInicial, DateTime fchFinal, int numPag, int size)
        {
            try
            {
                IEnumerable<Articulo> movimientos = this._context.Movimientos
                                                    .Include(m => m.Articulo)
                                                    .Where(m => m.Fecha >= fchInicial && m.Fecha <= fchFinal)
                                                    .ToList()
                                                    .Select(m => m.Articulo)
                                                     .Distinct()
                                                    //Paginado
                                                    .Skip((numPag - 1) * size)

                                                    .Take(size);
                //Distinct ignora los duplicados, mismo funcionamiento que sql
                return movimientos;
                    
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Dado un id de artículo y un tipo de movimiento, devuelve una lista de movimientos
        //realizados sobre ese artículo, ordenados descendentemente por fecha y en
        //forma ascendente por la cantidad de unidades involucradas en el movimiento Se
        //muestran todos los datos del movimiento, incluyendo todos los datos de su tipo.
        public IEnumerable<Movimiento> ObtenerMovimientos(int idArticulo, string tipoMovimiento, int pagina, int size)
        {
            try
            {
                return this._context.Movimientos
                    .Include(m => m.TipoMovimiento)
                    .Include(m => m.Articulo)
                    .Where(m => m.Articulo.Id == idArticulo && m.TipoMovimiento.Nombre == tipoMovimiento)
                    .OrderByDescending(m => m.Fecha)
                    .ThenBy(m => m.Cantidad)
                    //Paginado
                    .Skip((pagina - 1 ) * size )
                    .Take(size)
                    .ToList();
            }
            catch (Exception e)
            {
                throw e;
            }   
        }

        public bool Remove(Movimiento aBorrar)
        {
            throw new NotImplementedException();
        }

        public bool Update(Movimiento aModificar)
        {
            throw new NotImplementedException();
        }
    }
}
