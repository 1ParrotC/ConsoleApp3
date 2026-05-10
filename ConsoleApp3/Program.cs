// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.IO;
using ConsoleApp3;

// Apartado 2.1 a) Crear lista e insertar tres libros
var lista = new List<Libro>();
lista.Add(new Libro("1984", "George Orwell", 1949, true));
lista.Add(new Libro("El Quijote", "Miguel de Cervantes", 1605, false));
lista.Add(new Libro("Rebelión en la granja", "George Orwell", 1945, true));

// b) Mostrar todos los libros con foreach y ToString()
Console.WriteLine("Todos los libros:");
foreach (var libro in lista)
{
    Console.WriteLine(libro.ToString());
}

// c) Mostrar solo los libros cuyo autor contenga "Orwell"
Console.WriteLine("\nLibros cuyo autor contiene 'Orwell':");
foreach (var libro in lista)
{
    if (libro.Autor.Contains("Orwell"))
    {
        Console.WriteLine(libro.ToString());
    }
}

// Apartado 2.2 Mostrar fecha actual en formato corto
Console.WriteLine($"\nFecha actual: {DateTime.Now.ToShortDateString()}");

// Apartado 2.3 Guardar en fichero
var ruta = "libros.txt";
guardarLibros(lista, ruta);
Console.WriteLine($"\nLibros guardados en: {ruta}");

static void guardarLibros(List<Libro> lista, string ruta)
{
    var sw = File.CreateText(ruta);
    foreach (var libro in lista)
    {
        sw.WriteLine($"{libro.Titulo};{libro.Autor};{libro.Anyo};{libro.Disponible}");
    }
    sw.Close();
}
