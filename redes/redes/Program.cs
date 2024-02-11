using System;
using System.Collections.Generic;

// Clase base para representar un usuario de redes sociales
public class Usuario
{
    public string Nombre { get; set; }
    public List<string> RedesSociales { get; set; }

    public Usuario(string nombre)
    {
        Nombre = nombre;
        RedesSociales = new List<string>();
    }

    public void AgregarRedSocial(string redSocial)
    {
        RedesSociales.Add(redSocial);
    }

    public void EliminarRedSocial(string redSocial)
    {
        RedesSociales.Remove(redSocial);
    }

    public override string ToString()
    {
        return $"{Nombre}: {string.Join(", ", RedesSociales)}";
    }
}

// Clase derivada para manejar usuarios de Facebook
public class UsuarioFacebook : Usuario
{
    public UsuarioFacebook(string nombre) : base(nombre)
    {
    }
}

// Clase derivada para manejar usuarios de Twitter
public class UsuarioTwitter : Usuario
{
    public UsuarioTwitter(string nombre) : base(nombre)
    {
    }
}

// Clase derivada para manejar usuarios de Instagram
public class UsuarioInstagram : Usuario
{
    public UsuarioInstagram(string nombre) : base(nombre)
    {
    }
}

// Clase principal del programa
class Program
{
    static List<Usuario> usuarios = new List<Usuario>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1. Mostrar todos los usuarios");
            Console.WriteLine("2. Mostrar usuarios por red social");
            Console.WriteLine("3. Agregar usuario");
            Console.WriteLine("4. Editar usuario");
            Console.WriteLine("5. Eliminar usuario");
            Console.WriteLine("6. Salir");
            Console.WriteLine("Ingrese su opción:");

            if (int.TryParse(Console.ReadLine(), out int opcion))
            {
                switch (opcion)
                {
                    case 1:
                        MostrarTodosUsuarios();
                        break;
                    case 2:
                        MostrarUsuariosPorRedSocial();
                        break;
                    case 3:
                        AgregarUsuario();
                        break;
                    case 4:
                        EditarUsuario();
                        break;
                    case 5:
                        EliminarUsuario();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, ingrese una opción válida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opción inválida. Por favor, ingrese una opción válida.");
            }
        }
    }

    static void MostrarTodosUsuarios()
    {
        Console.WriteLine("Listado de todos los usuarios:");
        foreach (var usuario in usuarios)
        {
            Console.WriteLine(usuario);
        }
    }

    static void MostrarUsuariosPorRedSocial()
    {
        Console.WriteLine("Ingrese la red social:");
        string redSocial = Console.ReadLine();
        Console.WriteLine($"Listado de usuarios en {redSocial}:");
        foreach (var usuario in usuarios)
        {
            if (usuario.RedesSociales.Contains(redSocial))
            {
                Console.WriteLine(usuario);
            }
        }
    }

    static void AgregarUsuario()
    {
        Console.WriteLine("Ingrese el nombre del usuario:");
        string nombre = Console.ReadLine();
        Usuario usuario = new Usuario(nombre);
        Console.WriteLine("Ingrese la cantidad de redes sociales que posee:");
        if (int.TryParse(Console.ReadLine(), out int cantidadRedes))
        {
            for (int i = 0; i < cantidadRedes; i++)
            {
                Console.WriteLine($"Ingrese el nombre de la red social {i + 1}:");
                string redSocial = Console.ReadLine();
                usuario.AgregarRedSocial(redSocial);
            }
            usuarios.Add(usuario);
            Console.WriteLine("Usuario agregado correctamente.");
        }
        else
        {
            Console.WriteLine("Cantidad inválida.");
        }
    }

    static void EditarUsuario()
    {
        Console.WriteLine("Ingrese el nombre del usuario a editar:");
        string nombre = Console.ReadLine();
        Usuario usuario = usuarios.Find(u => u.Nombre == nombre);
        if (usuario != null)
        {
            Console.WriteLine($"Redes sociales actuales de {usuario.Nombre}: {string.Join(", ", usuario.RedesSociales)}");
            Console.WriteLine("Ingrese la cantidad de redes sociales que desea editar:");
            if (int.TryParse(Console.ReadLine(), out int cantidadRedes))
            {
                usuario.RedesSociales.Clear();
                for (int i = 0; i < cantidadRedes; i++)
                {
                    Console.WriteLine($"Ingrese el nombre de la red social {i + 1}:");
                    string redSocial = Console.ReadLine();
                    usuario.AgregarRedSocial(redSocial);
                }
                Console.WriteLine("Usuario editado correctamente.");
            }
            else
            {
                Console.WriteLine("Cantidad inválida.");
            }
        }
        else
        {
            Console.WriteLine("Usuario no encontrado.");
        }
    }

    static void EliminarUsuario()
    {
        Console.WriteLine("Ingrese el nombre del usuario a eliminar:");
        string nombre = Console.ReadLine();
        Usuario usuario = usuarios.Find(u => u.Nombre == nombre);
        if (usuario != null)
        {
            usuarios.Remove(usuario);
            Console.WriteLine("Usuario eliminado correctamente.");
        }
        else
        {
            Console.WriteLine("Usuario no encontrado.");
        }
    }
}