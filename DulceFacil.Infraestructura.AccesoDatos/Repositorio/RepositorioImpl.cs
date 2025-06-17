using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DulceFacil.Dominio.Modelo.Abstracciones;
using Microsoft.EntityFrameworkCore;

namespace DulceFacil.Infraestructura.AccesoDatos.Repositorio
{
    public class RepositorioImpl<T> : IRepositorio<T> where T : class
    {
        private readonly DulceFacilDBContext _dBContext;
        private readonly DbSet<T> _dBSet;
        public RepositorioImpl(DulceFacilDBContext dBContext) 
        {
            _dBContext = dBContext;
            _dBSet = _dBContext.Set<T>();
        }
        public async Task AddAsync(T entidad)
        {
            try
            {
                await _dBSet.AddAsync(entidad);// configuracion de insert para todas las tablas
                await _dBContext.SaveChangesAsync();
            }
            catch(Exception ex) 
            {
                throw new Exception("Error:No se pudo insertar Datos"+ ex.Message);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {   
                var entidad = await GetByIdAsync(id);
                _dBSet.Remove(entidad);// Eliminar datos
                await _dBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error:No se pudo eliminar Datos" + ex.Message);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
               return await _dBSet.ToListAsync();// Listar todas las tablas
            }
            catch (Exception ex)
            {
                throw new Exception("Error:No se pudo recuperar Datos" + ex.Message);
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                return await _dBSet.FindAsync(id);// Buscar todas las tablas por id  
            }
            catch (Exception ex)
            {
                throw new Exception("Error:No se pudo encontrar ID" + ex.Message);
            }
        }

        public async Task UpdateAsync(T entidad)
        {
            try
            {
                _dBSet.Update(entidad);// Actualizar datos para todas las tablas
                await _dBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error:No se pudo actualizar Datos" + ex.Message);
            }
        }
    }
}
