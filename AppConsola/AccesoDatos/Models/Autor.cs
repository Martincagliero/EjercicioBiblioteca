namespace AccesoDatos.Models
{
    public class Autor
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public List<Libro> Libros { get; set; } = new(); //lista de libros para crear instancias prox

    }
}
