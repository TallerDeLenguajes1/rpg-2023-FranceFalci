

using EspacioLogicaJuego;
using EspacioPersonaje;
using EspacioMenu;
using System.Media;
using System.Threading;

internal class Program
{
    public static void Main(string[] args)
    {

        var controladorJuego = new LogicaJuego();
        var path = @"C:\\Users\\franc\\OneDrive\\Escritorio\\RPG\\RPG-taller1\\RPG-taller1\\personaje.json";

        var listaPersonajes = controladorJuego.ObtenerPersonajes(path);
        controladorJuego.resetearPersonajesSeleccionadosYColores(listaPersonajes, path);
        int tipoCombate = controladorJuego.RunMenuPricipal(listaPersonajes);

        if (tipoCombate == 1)
        {
            var jugador1 = controladorJuego.SeleccionarPersonajeYColor(listaPersonajes, path, 1);
            var jugador2 = controladorJuego.SeleccionarPersonajeYColor(listaPersonajes, path, 2);
            controladorJuego.dibujarEscena(jugador1, jugador2);
            Personaje ganador = controladorJuego.combate(jugador1, jugador2);
            controladorJuego.mostrarGanador(ganador);
            Main(args);
            Console.ReadKey(true);

        }
        if (tipoCombate == 2)
        {
            var jugador = controladorJuego.SeleccionarPersonajeYColor(listaPersonajes, path, 0);
            controladorJuego.torneo(listaPersonajes, path, jugador);
            Main(args);
            Console.ReadKey(true);

        }





    }
}