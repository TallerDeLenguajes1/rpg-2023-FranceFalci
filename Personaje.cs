namespace EspacioPersonaje;

public class Personaje{

    string? tipo;
    string? nombre;
    // string? apodo;
    DateTime fechaNac;
    int edad;
    int velocidad;
    int destreza;
    int fuerza;
    int nivel;
    int armadura;
    int salud;

    public string? Tipo { get => tipo; set => tipo = value; }
    public string? Nombre { get => nombre; set => nombre = value; }
    // public string? Apodo { get => apodo; set => apodo = value; }
    public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }
    public int Edad { get => edad; set => edad = value; }
    public int Velocidad { get => velocidad; set => velocidad = value; }
    public int Destreza { get => destreza; set => destreza = value; }
    public int Fuerza { get => fuerza; set => fuerza = value; }
    public int Nivel { get => nivel; set => nivel = value; }
    public int Armadura { get => armadura; set => armadura = value; }
    public int Salud { get => salud; set => salud = value; }
}



public class FabricaDePersonajes{
     
    string[] nombres = {"Liu Kang","Escorpion","Goro", "Subzero", "Raiden"};
    string[] tipos = {"vivo","muerto"};

    Random random = new Random();


    public Personaje crearPersonaje(){
        int anio = random.Next(1900, 2024);
        int mes = random.Next(1, 13);
        int dia = random.Next(1, DateTime.DaysInMonth(anio, mes) + 1);
        DateTime hoy =   DateTime.Today;
        Personaje nuevoPersonaje = new();
        nuevoPersonaje.Tipo = tipos[random.Next(0,1)];// revisar
        nuevoPersonaje.Nombre = nombres[random.Next(0,5)];
        nuevoPersonaje.Armadura = random.Next(1,11);
        nuevoPersonaje.Fuerza = random.Next(1,11);
        nuevoPersonaje.Destreza = random.Next(1,6);
        nuevoPersonaje.Nivel = random.Next(1,11);
        nuevoPersonaje.Velocidad = random.Next(1,11);
        nuevoPersonaje.FechaNac =new DateTime(anio, mes, dia);
        nuevoPersonaje.Edad= DateTime.Today.Subtract(nuevoPersonaje.FechaNac).Days / 365;
        nuevoPersonaje.Salud = 100;


        return nuevoPersonaje;
        
    }
}