using EspacioPersonaje;
using EspacioPersonajeJSON;
using EspacioMenu;
using System;
namespace EspacioLogicaJuego;

public class LogicaJuego
{
    public List<Personaje> ObtenerPersonajes(string path)
    {
        List<Personaje> listaPersonajes = new();
        var personajeJson = new PersonajeJson();
        int cantidadPersonajes = 5;

        if (personajeJson.ExisteArchivo(path))
        {
            listaPersonajes = personajeJson.LeerPersonajes(path);
        }
        else
        {
            var FabricarPersonajes = new FabricaDePersonajes();
            Personaje nuevoPersonaje;
            for (int i = 0; i < cantidadPersonajes; i++)
            {

                do
                {
                    nuevoPersonaje = FabricarPersonajes.crearPersonaje();
                } while (listaPersonajes.Any(p => p.Tipo == nuevoPersonaje.Tipo));

                listaPersonajes.Add(nuevoPersonaje);
            }

            personajeJson.GuardarPersonajes(listaPersonajes, path);
        }

        return listaPersonajes;
    }

    public int RunMenuPricipal(List<Personaje> listaPersonajes)
    {
        string prompt = @"


 █████╗ ███╗   ██╗██╗███╗   ███╗ █████╗ ██╗         ██╗  ██╗ ██████╗ ███╗   ███╗██████╗  █████╗ ████████╗
██╔══██╗████╗  ██║██║████╗ ████║██╔══██╗██║         ██║ ██╔╝██╔═══██╗████╗ ████║██╔══██╗██╔══██╗╚══██╔══╝
███████║██╔██╗ ██║██║██╔████╔██║███████║██║         █████╔╝ ██║   ██║██╔████╔██║██████╔╝███████║   ██║   
██╔══██║██║╚██╗██║██║██║╚██╔╝██║██╔══██║██║         ██╔═██╗ ██║   ██║██║╚██╔╝██║██╔══██╗██╔══██║   ██║   
██║  ██║██║ ╚████║██║██║ ╚═╝ ██║██║  ██║███████╗    ██║  ██╗╚██████╔╝██║ ╚═╝ ██║██████╔╝██║  ██║   ██║   
╚═╝  ╚═╝╚═╝  ╚═══╝╚═╝╚═╝     ╚═╝╚═╝  ╚═╝╚══════╝    ╚═╝  ╚═╝ ╚═════╝ ╚═╝     ╚═╝╚═════╝ ╚═╝  ╚═╝   ╚═╝   
                                                                                                         
  
                                                 
(use las flechas para recorrer las opciones y presione enter para seleccionar)                                                             
 
                                                                                                              
";
        string[] options = { "JUGAR COMBATE", "JUGAR TORNEO", "VER PERSONAJES", "INFO DEL JUEGO", "SALIR" };
        Menu menuPrincipal = new Menu(options, prompt);
        int seleccionMenuPrincipal = menuPrincipal.Run();
        switch (seleccionMenuPrincipal)
        {
            case 0:
                //seleccionar personajes
                Console.Clear();
                return 1;

                break;
            case 1:
                Console.Clear();
                return 2;
                break;
            case 2:
                //mostrarPersonajes
                Console.Clear();
                mostrarPersonajes(listaPersonajes);

                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.WriteLine("Volver");
                Console.ResetColor();
                ConsoleKey keyPressed;
                do
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    keyPressed = keyInfo.Key;

                    if (keyPressed == ConsoleKey.Enter)
                    {
                        RunMenuPricipal(listaPersonajes);

                    }
                } while (keyPressed != ConsoleKey.Enter);
                break;
            case 3:
                Console.Clear();
                Console.WriteLine(@"¡Bienvenido al emocionante mundo de Animal Combat!
En este trepidante juego, te sumergirás en una batalla épica entre animales poderosos y valientes que luchan por la supremacía. 
¿Tienes lo que se necesita para enfrentar a tus oponentes en una intensa lucha de habilidades y estrategia?
  
Elige tu animal favorito y prepárate para desafiar a tus amigos en el emocionante modo 'COMBATE'. Aquí, tendrás la oportunidad de demostrar tu valentía en un único round donde cada movimiento cuenta. ¿Te atreverás a usar tu poder especial, sabiendo que podría jugarte en contra al restar tu salud? La adrenalina se elevará a medida que tomes decisiones tácticas y te enfrentes cara a cara con tus oponentes.

Pero eso no es todo, porque si buscas un desafío aún más grande, el modo 'TORNEO' te espera. Enfréntate a una serie de combates con diferentes animales y demuestra tu destreza para llegar a la cima. ¡No te rindas, sigue luchando y sé el campeón indiscutible del torneo!
En Animal Combat, la emoción nunca se detiene.¡Enfréntate a los desafíos, desata tus habilidades y conquista la gloria en este apasionante juego de luchas entre animales!


¡Que empiece el combate!");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.WriteLine("Volver");
                Console.ResetColor();
                ConsoleKey teclaPres;
                do
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    teclaPres = keyInfo.Key;

                    if (teclaPres == ConsoleKey.Enter)
                    {
                        RunMenuPricipal(listaPersonajes);

                    }
                } while (teclaPres != ConsoleKey.Enter);

                break;
            case 4:
                ExitGame();
                break;


        }
        return 0;
    }
    private void ExitGame()
    {
        Environment.Exit(0);
    }

    public void mostrarPersonajes(List<Personaje> listaPersonajes)
    {
        foreach (var personaje in listaPersonajes)
        {
            Console.WriteLine($"{personaje.Nombre} ({personaje.Tipo})");
            Console.WriteLine($"{personaje.Asci}");
        }
    }

    public void resetearPersonajesSeleccionadosYColores(List<Personaje> listaPersonajes, string path)
    {
        foreach (var personaje in listaPersonajes)
        {
            personaje.Seleccionado = false;
            personaje.Color = "White";
        }
        var personajeJson = new PersonajeJson();
        personajeJson.GuardarPersonajes(listaPersonajes, path);


    }

    public Personaje SeleccionarPersonajeYColor(List<Personaje> listaPersonajes, string path, int numeroJugador)
    {
        Personaje personajeSeleccionado = new Personaje();
        var personajeJson = new PersonajeJson();
        bool seleccionValida = false;
        bool colorValido = false;
        string colorSeleccionado = "";
        string[] opcionesPersonajes = listaPersonajes.Select(p => p.Tipo).ToArray();
        string[] opcionesColor = { "Rojo", "Azul", "Amarillo", "Rosa" };
        Menu menuSeleccionPersonaje = new Menu(opcionesPersonajes, $"SELECCIONE JUGADOR {numeroJugador}:");
        Menu menuSeleccionColor = new Menu(opcionesColor, $"SELECCIONE COLOR JUGADOR {numeroJugador}:");





        do
        {

            int indexPersonajeSeleccionado = menuSeleccionPersonaje.Run();
            personajeSeleccionado = listaPersonajes[indexPersonajeSeleccionado];
            if (!personajeSeleccionado.Seleccionado)
            {
                personajeSeleccionado.Seleccionado = true;
                seleccionValida = true;
            }


            if (!seleccionValida)
            {
                Console.WriteLine("Personaje ya seleccionado. Intente nuevamente.");
                Thread.Sleep(2000);
                desabTeclado(2);
                indexPersonajeSeleccionado = menuSeleccionPersonaje.Run();
                personajeSeleccionado = listaPersonajes[indexPersonajeSeleccionado];
            }
        } while (!seleccionValida);

        do
        {

            colorValido = false;
            int indexColorSeleccionado = menuSeleccionColor.Run();
            switch (indexColorSeleccionado)
            {
                case 0:
                    colorSeleccionado = "Red";
                    break;
                case 1:
                    colorSeleccionado = "Blue";
                    break;
                case 2:
                    colorSeleccionado = "Yellow";
                    break;
                case 3:
                    colorSeleccionado = "Magenta";
                    break;

            }
            foreach (Personaje personaje in listaPersonajes)
            {
                if (personaje.Color == colorSeleccionado) colorValido = true;

            }
            if (!colorValido)
            {
                personajeSeleccionado.Color = colorSeleccionado;
            }
            else
            {
                Console.WriteLine("Color ya seleccionado. Intente nuevamente.");
                Thread.Sleep(2000);
                desabTeclado(2);
                indexColorSeleccionado = menuSeleccionColor.Run();
                colorSeleccionado = opcionesColor[indexColorSeleccionado];
            }

        } while (colorValido);


        personajeJson.GuardarPersonajes(listaPersonajes, path);
        return personajeSeleccionado;
    }
}
public void dibujarEscena(Personaje jugador1, Personaje jugador2)
{

    Console.Clear();
    Console.WriteLine(@"
.-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-.
|                                                                       |
|                    {0}     VS    {1}                                      
|                                                                       |
`-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-----'", jugador1.Nombre, jugador2.Nombre);


    Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), jugador1.Color, true);
    Console.WriteLine(jugador1.Asci);
    dibujarBarraSalud(jugador1.Salud);
    Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), jugador2.Color, true);

    Console.WriteLine(jugador2.Asci);
    dibujarBarraSalud(jugador2.Salud);
    Console.ResetColor();

}
private void dibujarBarraSalud(int saludJugador)
{
    Console.ResetColor();
    Console.Write("[");
    Console.BackgroundColor = ConsoleColor.Green;
    for (int i = 0; i < saludJugador / 2; i++)
    {
        Console.Write(" ");
    }
    Console.BackgroundColor = ConsoleColor.Black;
    for (int i = saludJugador / 2; i < 50; i++)
    {
        Console.Write(" ");
    }
    Console.ResetColor();
    Console.Write(@"] ({0}/100)", saludJugador);



}
}