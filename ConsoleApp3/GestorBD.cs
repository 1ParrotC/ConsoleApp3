using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace ConsoleApp3
{
    public class GestorBD
    {
        private MySqlConnection conexion;

        public GestorBD()
        {
            var csb = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                UserID = "root",
                Password = "",
                Database = "bibliotech"
            };

            conexion = new MySqlConnection(csb.ConnectionString);
        }

        public void Insertar(Libro l)
        {
            conexion.Open();
            try
            {
                using var cmd = conexion.CreateCommand();
                cmd.CommandText = "INSERT INTO libros (Titulo, Autor, Anyo, Disponible) VALUES (@titulo, @autor, @anyo, @disponible)";
                cmd.Parameters.AddWithValue("@titulo", l.Titulo);
                cmd.Parameters.AddWithValue("@autor", l.Autor);
                cmd.Parameters.AddWithValue("@anyo", l.Anyo);
                cmd.Parameters.AddWithValue("@disponible", l.Disponible);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conexion.Close();
            }
        }

        public List<Libro> ObtenerTodos()
        {
            var lista = new List<Libro>();
            conexion.Open();
            try
            {
                using var cmd = conexion.CreateCommand();
                cmd.CommandText = "SELECT Titulo, Autor, Anyo, Disponible FROM libros";
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var titulo = dr["Titulo"]?.ToString() ?? string.Empty;
                    var autor = dr["Autor"]?.ToString() ?? string.Empty;
                    var anyo = Convert.ToInt32(dr["Anyo"]);
                    var disponible = Convert.ToBoolean(dr["Disponible"]);
                    lista.Add(new Libro(titulo, autor, anyo, disponible));
                }
            }
            finally
            {
                conexion.Close();
            }

            return lista;
        }
    }
}
