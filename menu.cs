using System;
using static System.Console;


namespace EspacioMenu
{
    internal class Menu
    {
        private int indexSeleccionado;
        private string[] Options;
        private string Prompt;

        public Menu(string[] options, string prompt)
        {
            Prompt = prompt;
            Options = options;
            indexSeleccionado = 0;
        }

        private void mostrarOpciones(string color)
        {
            Console.WriteLine(Prompt);
            for (int i = 0; i < Options.Length; i++)
            {
                string opcionActual = Options[i];
                string prefix = "";

                if (i == indexSeleccionado)
                {
                    prefix = "->";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color, true);

                }
                else
                {
                    prefix = " ";
                    Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color, true);
                    Console.BackgroundColor = ConsoleColor.Black;

                }
                Console.WriteLine($"{prefix} {opcionActual}");
            }
            ResetColor();
        }

        public int Run()
        {
            ConsoleKey teclaPresionada;
            do
            {
                Clear();
                mostrarOpciones("White");

                ConsoleKeyInfo keyInfo = ReadKey(true);
                teclaPresionada = keyInfo.Key;
                if (teclaPresionada == ConsoleKey.UpArrow)
                {
                    indexSeleccionado--;
                    if (indexSeleccionado == -1) indexSeleccionado = Options.Length - 1;
                }
                else if (teclaPresionada == ConsoleKey.DownArrow)
                {
                    indexSeleccionado++;
                    if (indexSeleccionado == Options.Length) indexSeleccionado = 0;
                }

            } while (teclaPresionada != ConsoleKey.Enter);

            return indexSeleccionado;
        }


        public int RunSinClear(string? color)
        {
            ConsoleKey teclaPresionada;
            int left = 3;
            int top = 19;
            int width = 0;
            int height = 6;
            do
            {

                Console.SetCursorPosition(left, top);

                for (int i = 0; i < height; i++)
                {
                    Console.SetCursorPosition(left, top + i);
                    Console.Write(new string(' ', width));
                }

                mostrarOpciones(color);

                ConsoleKeyInfo keyInfo = ReadKey(true);
                teclaPresionada = keyInfo.Key;
                if (teclaPresionada == ConsoleKey.UpArrow)
                {
                    indexSeleccionado--;
                    if (indexSeleccionado == -1) indexSeleccionado = Options.Length - 1;
                }
                else if (teclaPresionada == ConsoleKey.DownArrow)
                {
                    indexSeleccionado++;
                    if (indexSeleccionado == Options.Length) indexSeleccionado = 0;
                }

            } while (teclaPresionada != ConsoleKey.Enter);

            return indexSeleccionado;
        }
    }

}
