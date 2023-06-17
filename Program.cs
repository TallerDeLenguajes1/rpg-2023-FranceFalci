using EspacioPersonaje;
internal class Program
{
    private static void Main(string[] args)
    {
        Personaje nuevo;
        nuevo = new FabricaDePersonajes().crearPersonaje();
        Console.WriteLine(nuevo.Edad);
        Console.WriteLine(nuevo.Nombre);
        Console.WriteLine(nuevo.Tipo);


    } 
}