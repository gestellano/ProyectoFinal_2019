using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PedidoServer.Services
{
    public class UsuarioService
    {
        private ModeloBDContainer _repositorio = new ModeloBDContainer();

        internal IEnumerable<Usuario> ListarUsuarios() => _repositorio.UsuarioSet.ToList();

        internal IEnumerable<Vendedor> ListarVendedores() => _repositorio.UsuarioSet
                                                                .Where(usuario => usuario is Vendedor)
                                                                .ToList()
                                                                .Select(usuario => (Vendedor)usuario);


        internal void Agregar(Vendedor vendedor) {

            
            using (_repositorio)
            {
                _repositorio.UsuarioSet.Add(vendedor);
                _repositorio.SaveChanges();
            }


            //Usuario oUsuario = new Vendedor();
            //oUsuario.nombre = "Joanna Apellido";
            //oUsuario.passcode = "xxxxxx";
            //oUsuario.nickName = "jowi";
            //oUsuario.email = "test@test.com";
            //oUsuario.celular = "09999999";
        }

        internal void Remover(int numEmpleado)
        {

            //Usuario oUsuario = new Vendedor();
            //oUsuario.nombre = "Joanna Apellido";
            //oUsuario.passcode = "xxxxxx";
            //oUsuario.nickName = "jowi";
            //oUsuario.email = "test@test.com";
            //oUsuario.celular = "09999999";

            var usuario=_repositorio.UsuarioSet.Single(u => u.numEmpleado == numEmpleado);
            _repositorio.UsuarioSet.Remove(usuario);
            _repositorio.SaveChanges();
        }
    }
}