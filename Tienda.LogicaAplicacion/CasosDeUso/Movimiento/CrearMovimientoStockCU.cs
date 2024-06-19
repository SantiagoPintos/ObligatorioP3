using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Movimiento;
using Tienda.LogicaAplicacion.Mappers;
using Tienda.LogicaNegocio.Excepciones.Movimiento;
using Tienda.LogicaNegocio.InterfacesRepositorio;
using Tienda.LogicaNegocio.Entidades;

namespace Tienda.LogicaAplicacion.CasosDeUso.Movimiento
{
    public class CrearMovimientoStockCU : ICreateMovimientoStock
    {
        private IRepositorioMovimiento _repositorioMovimiento;
        private IRepositorioArticulo repositorioArticulo;
        private IRepositorioUsuario repositorioUsuario;
        private IRepositorioSettings repositorioSettings;
        private IRepositorioTipoMovimiento repositorioTipoMovimiento;
        public CrearMovimientoStockCU(IRepositorioMovimiento repositorioMovimiento,
                                      IRepositorioArticulo repositorioArticulo,
                                      IRepositorioUsuario repositorioUsuario,
                                      IRepositorioSettings repositorioSettings,
                                      IRepositorioTipoMovimiento repositorioTipoMovimiento)
        {
            _repositorioMovimiento = repositorioMovimiento;
            this.repositorioArticulo = repositorioArticulo;
            this.repositorioUsuario = repositorioUsuario;
            this.repositorioSettings = repositorioSettings;
            this.repositorioTipoMovimiento = repositorioTipoMovimiento;
        }
        public void CreateMovimientoStock(MovimientoDTO movimiento)
        {
            if (repositorioArticulo.EncontrarPorId(movimiento.Articulo.Id) == null) throw new MovimientoNoValidoException("El articulo no existe");
            if (repositorioUsuario.EncontrarPorEmail(movimiento.Usuario) == null) throw new MovimientoNoValidoException("El usuario no existe");
            if (repositorioSettings.GetSettingValueByName("TOPEMOVIMIENTOS") < movimiento.Cantidad) throw new MovimientoNoValidoException("La cantidad supera el tope de movimientos");
            if (repositorioTipoMovimiento.FindByName(movimiento.TipoMovimiento.Nombre) == null) throw new MovimientoNoValidoException("El tipo de movimiento no existe");
            LogicaNegocio.Entidades.Movimiento movimientoEntidad = MovimientoStockMapperDTO.FromDto(movimiento);
            movimientoEntidad.EsValido();
            //si es una salida de stock 
            if (movimientoEntidad.TipoMovimiento.Signo == LogicaNegocio.Enums.SignoTipoMovimiento.Reduccion) movimientoEntidad.Cantidad *= -1;
            //Por letra se debe usar fecha del sistema aunque se reciba desde el front
            movimiento.Fecha = DateTime.Now;

            _repositorioMovimiento.Add(movimientoEntidad);
        }
    }
}
