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

namespace Tienda.LogicaAplicacion.CasosDeUso.MovimientoStock
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
            this._repositorioMovimiento = repositorioMovimiento;
            this.repositorioArticulo = repositorioArticulo;
            this.repositorioUsuario = repositorioUsuario;
            this.repositorioSettings = repositorioSettings;
            this.repositorioTipoMovimiento = repositorioTipoMovimiento;
        }
        public void CreateMovimientoStock(MovimientoDTO movimiento)
        {
            if (this.repositorioArticulo.EncontrarPorId(movimiento.Articulo.Id) == null) throw new MovimientoNoValidoException("El articulo no existe");
            if (this.repositorioUsuario.EncontrarPorEmail(movimiento.Usuario) == null) throw new MovimientoNoValidoException("El usuario no existe");
            if (this.repositorioSettings.GetSettingValueByName("TOPEMOVIMIENTOS") > movimiento.Cantidad) throw new MovimientoNoValidoException("La cantidad supera el tope de movimientos");
            if (this.repositorioTipoMovimiento.FindByName(movimiento.TipoMovimiento.Nombre) == null) throw new MovimientoNoValidoException("El tipo de movimiento no existe");
            //si es una salida de stock 
            if (movimiento.TipoMovimiento.Signo == LogicaNegocio.Enums.SignoTipoMovimiento.Reduccion) movimiento.Cantidad *= -1;
            //Por letra se debe usar fecha del sistema aunque se reciba desde el front
            movimiento.Fecha = DateTime.Now;

            this._repositorioMovimiento.Add(MovimientoStockMapperDTO.FromDto(movimiento));
        }
    }
}
