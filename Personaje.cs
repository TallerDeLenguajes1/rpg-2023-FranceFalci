using System;
using System.Text.Json;
using System.Net;
using System.Text.Json.Serialization;


namespace EspacioPersonaje;

public class Personaje

{
    string? tipo;
    string? nombre;
    string? asci;
    // string? apodo;
    DateTime fechaNac;
    int edad;
    int velocidad;
    int destreza;
    int fuerza;
    int nivel;
    int armadura;
    int salud;
    bool seleccionado;
    string? color;

    public string? Tipo { get => tipo; set => tipo = value; }
    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Asci { get => asci; set => asci = value; }
    // public string? Apodo { get => apodo; set => apodo = value; }
    public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }
    public int Edad { get => edad; set => edad = value; }
    public int Velocidad { get => velocidad; set => velocidad = value; }
    public int Destreza { get => destreza; set => destreza = value; }
    public int Fuerza { get => fuerza; set => fuerza = value; }
    public int Nivel { get => nivel; set => nivel = value; }
    public int Armadura { get => armadura; set => armadura = value; }
    public int Salud { get => salud; set => salud = (value < 0) ? 0 : value; }
    public bool Seleccionado { get => seleccionado; set => seleccionado = value; }
    public string? Color { get => color; set => color = value; }



}



public class FabricaDePersonajes
{

    string[] nombres = { "Perro", "Gato", "Caballo", "Conejo", "Oso", "Mono" };

    Random random = new Random();


    public Personaje crearPersonaje()
    {
        var consumirAPI = new ConsumoAPI();
        var asciArt = new ASCIIArt();

        int anio = random.Next(1900, 2024);
        int mes = random.Next(1, 13);
        int dia = random.Next(1, DateTime.DaysInMonth(anio, mes) + 1);
        DateTime hoy = DateTime.Today;
        Personaje nuevoPersonaje = new();
        nuevoPersonaje.Tipo = nombres[random.Next(0, 5)];
        nuevoPersonaje.Nombre = consumirAPI.GetNombre();

        while (nuevoPersonaje.Nombre == null)
        {
            nuevoPersonaje.Nombre = consumirAPI.GetNombre(); // Intenta obtener un nuevo nombre si es null
        }
        nuevoPersonaje.Armadura = random.Next(1, 11);
        nuevoPersonaje.Fuerza = random.Next(1, 11);
        nuevoPersonaje.Destreza = random.Next(1, 6);
        nuevoPersonaje.Nivel = random.Next(1, 11);
        nuevoPersonaje.Velocidad = random.Next(1, 11);
        nuevoPersonaje.FechaNac = new DateTime(anio, mes, dia);
        nuevoPersonaje.Edad = DateTime.Today.Subtract(nuevoPersonaje.FechaNac).Days / 365;
        nuevoPersonaje.Salud = 100;
        nuevoPersonaje.Asci = asciArt.obtenerAsciiPersonaje(nuevoPersonaje.Tipo);
        nuevoPersonaje.Seleccionado = false;
        nuevoPersonaje.Color = "White";



        return nuevoPersonaje;

    }
}

public class ASCIIArt
{

    public string obtenerAsciiPersonaje(string Nombre)
    {
        switch (Nombre)
        {
            case "Caballo":
                string Caballo = @"
  ._.-.___.' (`\
 //(        ( `'
'/ )\ ).__. ) 
' <' `\ ._/'\
   `   \     \";
                return Caballo;
            case "Gato":
                string Gato = @"
         _._     _,-'""""`-._
(,-.`._,'(       |\`-/|
    `-.-' \ )-`( , o o)
          `-    \`_`""'-";
                return Gato;

            case "Perro":
                string Perro = @"
           __
      (___()'`;
      /,    /`
      \\""--\\";
                return Perro;

            case "Mono":
                string Mono = @"
          __
     w  c(..)o   (
      \__(-)    __)
          /\   (
         /(_)___)
         w /|
          | \
          m  m";
                return Mono;

            case "Conejo":
                string Conejo = @"
             ,\
             \\\,_
              \` ,\
         __,.-"" =__)
       .""        )
    ,_/   ,    \/\_
    \_|    )_-\ \_-`
      `-----` `--`";
                return Conejo;
            case "Oso":
                string Oso = @"
  __         __
/  \.-""""""-./ 
\    -   -    /
 |   o   o   |
 \  .-'''-.  /
  '-\__Y__/-'
     `---`";
                return Oso;

        }

        return "h";
    }



