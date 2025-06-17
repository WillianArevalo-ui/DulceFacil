using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DulceFacil.Dominio.Modelo.Abstracciones;

namespace DulceFacil.Infraestructura.AccesoDatos.Repositorio
{
    public class DetallePedidoRepositorioImpl : RepositorioImpl<DetallePedido>, IDetallePedidoRepositorio
    {
        public DetallePedidoRepositorioImpl(DulceFacilDBContext dBContext) : base(dBContext)
        {
        }
    }
}
