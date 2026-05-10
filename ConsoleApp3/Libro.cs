namespace ConsoleApp3
{
    public class Libro
    {
        private string titulo;
        private string autor;
        private int anyo;
        private bool disponible;

        public Libro(string titulo, string autor, int anyo, bool disponible)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.anyo = anyo;
            this.disponible = disponible;
        }

        public string Titulo => titulo;
        public string Autor => autor;
        public int Anyo => anyo;
        public bool Disponible => disponible;

        public override string ToString()
        {
            return $"{titulo} - {autor} ({anyo})";
        }
    }
}
