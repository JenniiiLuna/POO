using System;
using System.Collections.Generic;

class Camara
{
    public string Modelo { get; set; }
    public decimal Precio { get; set; }
    public string Marca { get; set; }

    public Camara(string modelo, decimal precio, string marca)
    {
        Modelo = modelo;
        Precio = precio;
        Marca = marca;
    }

    public virtual void MostrarInformacion()
    {
        Console.WriteLine($"Modelo: {Modelo}, Precio: {Precio:C}, Marca: {Marca}");
    }
}

class Program
{
    static List<Camara> camaras = new List<Camara>();

    static void Main(string[] args)
    {
        // Agregar algunas cámaras predefinidas
        camaras.Add(new Camara("EOS Rebel T7", 499.99m, "Canon"));
        camaras.Add(new Camara("D3500", 399.99m, "Nikon"));
        camaras.Add(new Camara("Alpha A6000", 599.99m, "Sony"));

        bool continuar = true;
        while (continuar)
        {
            Console.WriteLine("\n1. Mostrar todas las cámaras");
            Console.WriteLine("2. Agregar cámara");
            Console.WriteLine("3. Editar cámara");
            Console.WriteLine("4. Salir");
            Console.Write("\nSeleccione una opción: ");

            int opcion;
            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        MostrarTodasCamaras();
                        break;
                    case 2:
                        AgregarCamara();
                        break;
                    case 3:
                        EditarCamara();
                        break;
                    case 4:
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese un número.");
            }
        }
    }

    static void MostrarTodasCamaras()
    {
        Console.WriteLine("\nListado de todas las cámaras:");
        foreach (var camara in camaras)
        {
            camara.MostrarInformacion();
        }
    }

    static void AgregarCamara()
    {
        Console.Write("\nIngrese el modelo de la cámara: ");
        string modelo = Console.ReadLine();
        Console.Write("Ingrese el precio de la cámara: ");
        decimal precio;
        while (!decimal.TryParse(Console.ReadLine(), out precio))
        {
            Console.Write("Precio no válido. Ingrese un valor numérico: ");
        }
        Console.Write("Ingrese la marca de la cámara: ");
        string marca = Console.ReadLine();

        camaras.Add(new Camara(modelo, precio, marca));
        Console.WriteLine("Cámara agregada correctamente.");
    }

    static void EditarCamara()
    {
        Console.Write("\nIngrese el modelo de la cámara que desea editar: ");
        string modelo = Console.ReadLine();
        Camara camara = BuscarCamara(modelo);
        if (camara != null)
        {
            Console.WriteLine($"Modelo actual: {camara.Modelo}");
            Console.Write("Ingrese el nuevo modelo de la cámara (deje vacío para mantener el actual): ");
            string nuevoModelo = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoModelo))
            {
                camara.Modelo = nuevoModelo;
            }

            Console.WriteLine($"Precio actual: {camara.Precio:C}");
            Console.Write("Ingrese el nuevo precio de la cámara (deje vacío para mantener el actual): ");
            string precioStr = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(precioStr))
            {
                decimal nuevoPrecio;
                while (!decimal.TryParse(precioStr, out nuevoPrecio))
                {
                    Console.Write("Precio no válido. Ingrese un valor numérico: ");
                    precioStr = Console.ReadLine();
                }
                camara.Precio = nuevoPrecio;
            }

            Console.WriteLine($"Marca actual: {camara.Marca}");
            Console.Write("Ingrese la nueva marca de la cámara (deje vacío para mantener el actual): ");
            string nuevaMarca = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevaMarca))
            {
                camara.Marca = nuevaMarca;
            }

            Console.WriteLine("Cámara editada correctamente.");
        }
        else
        {
            Console.WriteLine("Cámara no encontrada.");
        }
    }

    static Camara BuscarCamara(string modelo)
    {
        foreach (var camara in camaras)
        {
            if (camara.Modelo.Equals(modelo, StringComparison.OrdinalIgnoreCase))
            {
                return camara;
            }
        }
        return null;
    }
}
