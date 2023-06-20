using EspacioPersonaje;
using EspacioPersonajeJSON;

internal class Program
{
    private static void Main(string[] args)
    {

        List<Personaje> listaPersonajes;
        listaPersonajes = InicioJuego("personajes.txt");
        MostrarPersonajes(listaPersonajes);



    } 

// 1) Verificar al comienzo del Juego si existe el archivo de personajes:
// A. Si existe y tiene datos cargar los personajes desde el archivo existente.
// B. Si no existe generar 10 personajes utilizando la clase FabricaDePersonajes y
// guárdelos en el archivo de personajes usando la clase PersonajesJson.
    static public List<Personaje> InicioJuego(string path){
        List<Personaje> listaPersonajes = new();
        var personajeJson = new PersonajeJson();
        int cantidadPersonajes = 4;

        if(personajeJson.ExisteArchivo(path)){
           listaPersonajes = personajeJson.LeerPersonajes(path);
        }else{
            var FabricarPersonajes = new FabricaDePersonajes();
            for (int i = 0; i < cantidadPersonajes; i++)
            {
                var nuevoPersonaje = FabricarPersonajes.crearPersonaje();
                listaPersonajes.Add(nuevoPersonaje);

            } 
            personajeJson.GuardarPersonajes(listaPersonajes,path);
        }
        return listaPersonajes;
    }
// 2) Muestre por pantalla los datos y características de los personajes cargados.

static public void MostrarPersonajes(List<Personaje> listaPersonajes){
    foreach (var personaje in listaPersonajes)
    {
        Console.WriteLine("Nombre: " + personaje.Nombre);
        Console.WriteLine("Nivel: " +personaje.Nivel);
        Console.WriteLine("Destreza: " +personaje.Destreza);
        Console.WriteLine("------------");



    }
}
}