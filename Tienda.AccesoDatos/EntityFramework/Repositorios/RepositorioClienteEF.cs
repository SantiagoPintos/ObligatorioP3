﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.AccesoDatos.CrifradoClave;
using Tienda.LogicaNegocio.Entidades;
using Tienda.LogicaNegocio.InterfacesRepositorio;

namespace Tienda.AccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioClienteEF:IRepositorioCliente
    {
        private TiendaContext _context;
        public RepositorioClienteEF()
        {
            this._context = new TiendaContext();
        }

        public bool Add(Cliente aAgregar)
        {
            try
            {
                if (this.ExisteCliente(aAgregar.Rut)) throw new Exception("El cliente ya existe");                
                aAgregar.EsValido();             
                this._context.Clientes.Add(aAgregar);
                this._context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public bool ExisteCliente(string rut)
        {
            return this._context.Clientes.Where(cliente => cliente.Rut == rut).Any();
        }

        public IEnumerable<Cliente> FindAll()
        {
            return this._context.Clientes;
        }

        public Cliente FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Cliente aModificar)
        {
            throw new NotImplementedException();
        }
    }
}
