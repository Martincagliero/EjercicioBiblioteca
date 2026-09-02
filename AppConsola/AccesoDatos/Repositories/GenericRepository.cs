using AccesoDatos.Data;
using Microsoft.EntityFrameworkCore;
using AccesoDatos.Models;

namespace AccesoDatos.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository()
        {
            _context = new ApplicationDbContext();
        }

        // 1. LECTURA (SELECT *)
        public List<T> ObtenerTodos()
        {
            return _context.Set<T>().AsNoTracking().ToList();
        }

        // 2. ALTA (INSERT), es decir, se agrega un registro en la tabla de la base de datos.
        public void Agregar(T entidad)
        {
            try
            {
                // Si la entidad es un Libro, asegurarse de que Autor y Categoria existan
                if (entidad is Libro libro)
                {
                    // Buscar Autor por Id; si no existe, crear uno provisional
                    var autor = _context.Set<Autor>().Find(libro.AutorId);
                    if (autor == null)
                    {
                        autor = new Autor { Id = libro.AutorId, Name = "AutorProvisorio" };
                        _context.Set<Autor>().Add(autor);
                    }

                    // Buscar Categoria por Id; si no existe, crear una provisional
                    var categoria = _context.Set<Categoria>().Find(libro.CategoriaId);
                    if (categoria == null)
                    {
                        categoria = new Categoria { Id = libro.CategoriaId, Nombre = "CategoriaProvisoria" };
                        _context.Set<Categoria>().Add(categoria);
                    }
                }

                _context.Set<T>().Add(entidad);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException($"Error al agregar la entidad: {ex.InnerException?.Message ?? ex.Message}", ex);
            }
        }

        // 3. BAJA (DELETE) - Busca por ID y elimina.
        public void Eliminar(object id)
        {
            var entidad = _context.Set<T>().Find(id);
            if (entidad != null)
            {
                _context.Set<T>().Remove(entidad);
                _context.SaveChanges();
            }
        }

        // 4. MODIFICACIÓN (UPDATE) - Actualiza la entidad completa.
        public void Modificar(T entidad)
        {
            _context.Set<T>().Update(entidad);
            _context.SaveChanges();
        }

        // 5. BÚSQUEDA POR ID
        public T ObtenerPorId(int id)
        {
            // Busca directamente en el conjunto de datos del tipo T correspondientes
            return _context.Set<T>().Find(id);
        }
        public List<T> ObtenerTodosCon(string propiedadRelacionada)
        {
            return _context.Set<T>()
                .Include(propiedadRelacionada)
                .AsNoTracking()
                .ToList();
        }

    }
}
