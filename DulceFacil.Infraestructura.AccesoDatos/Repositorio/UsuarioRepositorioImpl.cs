using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DulceFacil.Dominio.Modelo.Abstracciones;

namespace DulceFacil.Infraestructura.AccesoDatos.Repositorio
{
    public class UsuarioRepositorioImpl : RepositorioImpl<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorioImpl(DulceFacilDBContext dBContext) : base(dBContext)
        {
        }
    }
}
