using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DulceFacil.Dominio.Modelo.Abstracciones;

namespace DulceFacil.Infraestructura.AccesoDatos.Repositorio
{
    public class RutaRepositorioImpl : RepositorioImpl<Ruta>, IRutaRepositorio
    {
        public RutaRepositorioImpl(DulceFacilDBContext dBContext) : base(dBContext)
        {
        }
    }
}
