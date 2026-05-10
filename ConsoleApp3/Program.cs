// See https://aka.ms/new-console-template for more information
using System;
using ConsoleApp3;

var libro = new Libro("Cien años de soledad", "Gabriel García Márquez", 1967, true);
Console.WriteLine(libro.ToString());
Console.WriteLine($"Disponible: {(libro.Disponible ? "Sí" : "No")}");
