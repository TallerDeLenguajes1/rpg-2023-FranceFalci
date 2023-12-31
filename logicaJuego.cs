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

    public Personaje combate(Personaje jugador1, Personaje jugador2)
    {

        bool jugadorAbandono = false;
        while (jugador1.Salud > 0 && jugador2.Salud > 0)
        {

            if (jugador2.Salud > 0)
            {
                jugadorAbandono = pelea(jugador1, jugador2);
                dibujarEscena(jugador1, jugador2);
                if (jugadorAbandono) return jugador2;

            }

            if (jugador2.Salud > 0)
            {
                jugadorAbandono = pelea(jugador2, jugador1);
                dibujarEscena(jugador1, jugador2);
                if (jugadorAbandono) return jugador1;

            }
        }
        if (jugador1.Salud > 0) return jugador1;
        return jugador2;



    }



    public bool pelea(Personaje atacante, Personaje defensor)
    {

        if (atacante != null)
        {

            string prompt = (atacante.Nombre).ToUpper() + " (" + atacante.Tipo + ")  ELIJA SU PROXIMO MOVIMIENTO";
            string[] options = { "ATACAR", "USAR PODER", "ABANDONAR" };
            Menu opcionesPelea = new Menu(options, prompt);
            int seleccionPelea = opcionesPelea.RunSinClear(atacante.Color);
            switch (seleccionPelea)
            {
                case 0:
                    atacar(atacante, defensor);
                    break;
                case 1:
                    usarPoder(atacante, defensor);
                    break;
                case 2:
                    return true;


            };

        }
        return false;


    }

    public void atacar(Personaje atacante, Personaje defensor)
    {
        Random random = new Random();
        int ataque = atacante.Fuerza * atacante.Destreza * atacante.Nivel;
        int efectividad = random.Next(1, 101);
        int defensa = defensor.Armadura * defensor.Velocidad;
        int ajuste = 500;
        int danio = ((ataque * efectividad) - defensa) / ajuste;
        defensor.Salud -= danio;


    }
    public void usarPoder(Personaje atacante, Personaje defensor)
    {
        Random random = new Random();
        int fuerza = atacante.Fuerza + 5;
        int ataque = fuerza * atacante.Destreza * atacante.Nivel;
        int efectividad = random.Next(1, 101);
        int defensa = defensor.Armadura * defensor.Velocidad;
        int ajuste = 500;
        int danio = ((ataque * efectividad) - defensa) / ajuste;
        defensor.Salud -= danio;
        atacante.Salud = atacante.Salud - 5;


    }
    public (bool jugadorGano, bool jugadorAbandono) combateTorneo(Personaje jugador1, Personaje jugador2)
    {
        bool jugadorAbandono = false;
        while (jugador1.Salud > 0 && jugador2.Salud > 0)
        {
            if (jugador2.Salud > 0)
            {
                jugadorAbandono = pelea(jugador1, jugador2);
                dibujarEscena(jugador1, jugador2);
                if (jugadorAbandono) return (false, true);


            }

            if (jugador2.Salud > 0)
            {
                atacar(jugador2, jugador1);
                dibujarEscena(jugador1, jugador2);
            }
        }
        if (jugador1.Salud > 0) return (true, false);

        return (false, false);



    }
    public bool torneo(List<Personaje> listaPersonajes, string path, Personaje jugador)
    {
        int contadorRound = 1;
        bool jugadorGanoTorneo = false;
        string[] numeroRounds = {
    @"",

    @"
                                            ██╗
                                           ███║
                                           ╚██║
                                            ██║
                                            ██║
                                            ╚═╝
    
",
    @"

                                           ██████╗ 
                                           ╚════██╗
                                           █████╔╝
                                           ██╔═══╝ 
                                           ███████╗
                                           ╚══════╝
        
",
    @"

                                            ██████╗ 
                                            ╚════██╗
                                            █████╔╝
                                            ╚═══██╗
                                            ██████╔╝
                                            ╚═════╝ 
        
",
    @"
                              ███████╗██╗███╗   ██╗ █████╗ ██╗     
                              ██╔════╝██║████╗  ██║██╔══██╗██║     
                              █████╗  ██║██╔██╗ ██║███████║██║     
                              ██╔══╝  ██║██║╚██╗██║██╔══██║██║     
                              ██║     ██║██║ ╚████║██║  ██║███████╗
                              ╚═╝     ╚═╝╚═╝  ╚═══╝╚═╝  ╚═╝╚══════╝
                                     

        
"
};
        foreach (var personaje in listaPersonajes)
        {
            Console.Clear();
            Console.WriteLine(@"
                        ██████╗  ██████╗ ██╗   ██╗███╗   ██╗██████╗ 
                        ██╔══██╗██╔═══██╗██║   ██║████╗  ██║██╔══██╗
                        ██████╔╝██║   ██║██║   ██║██╔██╗ ██║██║  ██║
                        ██╔══██╗██║   ██║██║   ██║██║╚██╗██║██║  ██║
                        ██║  ██║╚██████╔╝╚██████╔╝██║ ╚████║██████╔╝
                        ╚═╝  ╚═╝ ╚═════╝  ╚═════╝ ╚═╝  ╚═══╝╚═════╝ 
                                            
{0}", numeroRounds[contadorRound]);
            Thread.Sleep(2000);
            desabTeclado(2);

            if (personaje != jugador)
            {
                contadorRound++;
                bool jugadorGanoCombate = false;
                do
                {
                    dibujarEscena(jugador, personaje);
                    (bool jugadorGanoCombate, bool jugadorAbandono) resultadoCombate = combateTorneo(jugador, personaje);
                    if (resultadoCombate.jugadorAbandono) return false;
                    if (!resultadoCombate.jugadorGanoCombate)
                    {
                        Console.Clear();
                        Console.WriteLine(@"    
                                  ¡PERDISTE EL COMBATE! Inténtalo nuevamente.");
                        Console.WriteLine(@"       
                                                    (()__(()
                                                    /       \
                                                   ( /    \  \
                                                    \ o o    /
                                                    (_()_)__/ \
                                                   / _,==.____ \
                                                  (   |--|      )
                                                  /\_.|__|'-.__/\_
                                                 / (        /     \
                                                 \  \      (      /
                                                  )  '._____)    /
                                               (((____.--(((____/



");
                        Thread.Sleep(4000);
                        desabTeclado(4);
                        desabTeclado(4);
                        desabTeclado(4);

                    }
                    else
                    {
                        jugadorGanoCombate = true;
                    }
                    jugador.Salud = 100;
                    personaje.Salud = 100;
                } while (!jugadorGanoCombate);

                if (jugador.Salud <= 0)
                {
                    jugadorGanoTorneo = false;
                    break;
                }
            }
        }


        Console.Clear();
        Console.WriteLine("                               FELICIDADES! HAS GANADO EL TORNEO");
        Console.WriteLine(@"
                                                      _,-'^\
                                                  _,-'   ,\ )
                                              ,,-'     ,'  d'
                               ,,,           J_ \    ,'
                              `\ /     __ ,-'  \ \ ,'
                              / /  _,-'  '      \ \
                             / |,-'             /  }
                            (                 ,'  /
                             '-,________         /
                                        \       /
                                         |      |
                                        /       |
                                       /        |
                                      /  /~\   (\/)
                                     {  /   \     }
                                     | |     |   =|
                                     / |      ~\  |
                                     J \,       (_o
                                      '""
");
        string[] options = { "VOLVER AL MENU", "SALIR" };

        Menu menuSalida = new Menu(options, " ");
        int seleccion = menuSalida.RunSinClear("White");
        switch (seleccion)
        {

            case 1:
                Environment.Exit(0);
                break;
            default:
                break;
        };
        return true;
    }


    public void mostrarGanador(Personaje ganador)
    {
        if (ganador.Nombre != null)
        {

            Thread.Sleep(1000);
            desabTeclado(1);
            Console.Clear();
            Console.WriteLine(@"
                     ,---.           ,---.
                    / /""`.\.--""""""--./,'""\ \
                    \ \    _       _    / /
                     `./  / __   __ \  \,'
                      /    /_O)_(_O\    \
                      |  .-'  ___  `-.  |
                   .--|       \_/       |--.
                 ,'    \   \   |   /   /    `.
                /       `.  `--^--'  ,'       \
             .-""""""""""-.    `--.___.--'     .-""""""""""-.
.-----------/         \------------------/         \--------------.
| .---------\         /----------------- \         /------------. |
| |          `-`--`--'                    `--'--'-'             | |
| |                                                             | |  
| |                GANADOR : {0} {1}                                
| |                                                             | |
| |_____________________________________________________________| |
|_________________________________________________________________|
                   )__________|__|__________(
                  |            ||            |
                  |____________||____________|
                    ),-----.(      ),-----.(
                  ,'   ==.   \    /  .==    `.
                 /            )  (            \
                 `==========='    `==========='  ", ganador.Nombre, ganador.Tipo);
            string[] options = { "VOLVER AL MENU", "SALIR" };

            Menu menuSalida = new Menu(options, " ");
            int seleccion = menuSalida.RunSinClear(ganador.Color);
            switch (seleccion)
            {

                case 1:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            };
        }



    }

    public void desabTeclado(int seconds)
    {
        DateTime end = DateTime.Now.AddSeconds(seconds);
        while (DateTime.Now < end)
        {
            // Leer y descartar cualquier entrada del teclado
            while (Console.KeyAvailable)
            {
                Console.ReadKey(intercept: true);
            }
        }
    }

}

