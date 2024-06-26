﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.Entidades;

namespace Tienda.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioEncargado : IRepositorio<Encargado>
    {
        public Encargado FindByEmail(string email);
        public void Login(string email, string clave);
    }
}
