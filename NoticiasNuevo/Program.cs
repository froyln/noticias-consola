using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Noticias
{
    internal class NoticieroBar
    {
        static int color = 3;
        static int colorSeleccion = 12;
        static int select = 0;
        static string path = Directory.GetCurrentDirectory() + "/Config";
        static string archivo = path + "/Frases.txt";
        static void Main(string[] args) 
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            
            string[] opciones =
            {
                "1. Iniciar programa        ",
                "2. Agregar nuevas frases   ",
                "3. Ver las frases actuales ",
                "4. Salir                   "
            };

            string[] frases = new string[5];
            if (File.Exists(archivo))
            {
                frases = File.ReadAllLines(archivo);
            }

            int posicionX = Console.WindowWidth / 2;
            int posicionY = Console.WindowHeight / 2;

            while (true)
            {
                switch (Menu(opciones, "N O T I C I A S", posicionX, posicionY, "Utiliza las flechas."))
                {
                    case 0:
                        Noticiero(); 
                        break;
                    case 1:
                        frases = AgregarFrases();
                        break;
                    case 2:
                        VerFrases(frases);
                        break;
                    case 3:
                        return;
                }
            }
            
        }
        static int Menu(string[] opciones, string titulo, int posicionX, int posicionY, string subTitulo) {

            select = 0;
            Console.CursorVisible = false;
            ConsoleKeyInfo key = new ConsoleKeyInfo();

            //Hago que la posicion reste los caracteres de las opciones
            //para que se posicione correctamente y no inicie desde el centro
            posicionX = posicionX - opciones[1].Length / 2;
            posicionY = posicionY - opciones.Length / 2;

            //Personalizacion del menu
            MenuBackground(opciones, titulo, posicionX, posicionY, subTitulo);
            while (true)
            {
                if (select >= opciones.Length)
                {
                    select = opciones.Length - 1;
                }
                for (int i = 0; i < opciones.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.SetCursorPosition(posicionX, posicionY + i);
                    if (select == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = (ConsoleColor)colorSeleccion;
                    }
                    Console.Write(opciones[i]);
                    Console.ResetColor();
                }
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Gray;
                key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (select > 0)
                            select--;
                        else
                            select = opciones.Length - 1;
                        break;
                    case ConsoleKey.DownArrow:

                        if (select < opciones.Length - 1)
                            select++;
                        else
                            select = 0;
                        break;

                    case ConsoleKey.D1:
                        select = 0;
                        break;

                    case ConsoleKey.D2:
                        select = 1;
                        break;

                    case ConsoleKey.D3:
                        select = 2;
                        break;

                    case ConsoleKey.D4:
                        select = 3;
                        break;

                    case ConsoleKey.D5:
                        select = 4;
                        break;

                    case ConsoleKey.D6:
                        select = 5;
                        break;

                    case ConsoleKey.D7:
                        select = 6;
                        break;

                    case ConsoleKey.D8:
                        select = 7;
                        break;

                    case ConsoleKey.D9:
                        select = 8;
                        break;

                    case ConsoleKey.Enter:
                        Console.ResetColor();
                        Console.Clear();
                        return select;

                    case ConsoleKey.Escape:
                        Console.ResetColor();
                        Console.Clear();
                        return 32;
                }
            }
        }
        static void MenuBackground(string[] opciones, string titulo, int posicionXOriginal, int posicionYOriginal, string subTitulo) {

            //Fondo 
            Console.BackgroundColor = (ConsoleColor)color;
            Console.Clear();

            //Sombra del fondo del Menu
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Black;
            int posicionX = posicionXOriginal;
            int posicionY = posicionYOriginal - 3;
            int j = 0;
            for (int i = 0; i < opciones.Length + 7; i++)
            {
                while (j < opciones[0].Length + 3)
                {
                    Console.SetCursorPosition(posicionX, posicionY);
                    Console.Write(" ");
                    posicionX++;
                    j++;
                }
                posicionX = posicionXOriginal;
                j = 0;
                posicionY++;
            }

            //Fondo del Menu
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            posicionX = posicionXOriginal - 2;
            posicionY = posicionYOriginal - 4;
            j = 0;
            for (int i = 0; i < opciones.Length + 6; i++)
            {
                while (j < opciones[0].Length + 3)
                {
                    Console.SetCursorPosition(posicionX, posicionY);
                    Console.Write(" ");
                    posicionX++;
                    j++;
                }
                posicionX = posicionXOriginal - 2;
                j = 0;
                posicionY++;
            }

            //Bordes
            posicionX = posicionXOriginal - 2;
            posicionY = posicionYOriginal - 4;
            Console.SetCursorPosition(posicionX, posicionY);
            Console.Write("┌");
            posicionX++;
            for (int i = 0; i < opciones[0].Length / 2 - titulo.Length / 2; i++)
            {
                Console.SetCursorPosition(posicionX, posicionY);
                Console.Write("─");
                posicionX++;
            }
            Console.SetCursorPosition(posicionX, posicionY);
            Console.Write("┤");
            posicionX++;
            Console.SetCursorPosition(posicionX, posicionY);
            Console.Write(titulo);
            posicionX += titulo.Length;
            Console.SetCursorPosition(posicionX, posicionY);
            Console.Write("├");
            posicionX++;
            for (int i = 0; i < opciones[0].Length / 2 - titulo.Length / 2; i++)
            {
                Console.SetCursorPosition(posicionX, posicionY);
                Console.Write("─");
                posicionX++;
            }
            Console.SetCursorPosition(posicionX, posicionY);
            Console.Write("┐");
            posicionY++;
            for (int i = 0; i < opciones.Length + 5; i++)
            {
                Console.SetCursorPosition(posicionX, posicionY);
                Console.Write("│");
                posicionY++;
            }
            Console.SetCursorPosition(posicionX, posicionY);
            Console.Write("┘");
            posicionX--;
            for (int i = 0; i < opciones[0].Length + 2; i++)
            {
                Console.SetCursorPosition(posicionX, posicionY);
                Console.Write("─");
                posicionX--;
            }
            Console.SetCursorPosition(posicionX, posicionY);
            Console.Write("└");
            posicionY--;
            for (int i = 0; i < opciones.Length + 5; i++)
            {
                Console.SetCursorPosition(posicionX, posicionY);
                Console.Write("│");
                posicionY--;
            }

            posicionY += 2;
            posicionX++;
            Console.SetCursorPosition(posicionX, posicionY);
            Console.Write(subTitulo);
        }
        static void MenuNoOpciones(string[] preguntas, string titulo, int posicionX, int posicionY, string subTitulo) {
            Console.CursorVisible = false;

            //Hago que la posicion reste los caracteres de las opciones
            //para que se posicione correctamente y no inicie desde el centro
            posicionX = posicionX - preguntas[0].Length / 2;
            posicionY = posicionY - preguntas.Length / 2;

            //Personalizacion del menu
            MenuBackground(preguntas, titulo, posicionX, posicionY, subTitulo);

            //Muestra las preguntas
            for (int i = 0; i < preguntas.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(posicionX, posicionY + i);
                Console.Write(preguntas[i]);
            }
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ResetColor();
        }
        static string[] AgregarFrases() {
            //Creamos el archivo de texto donde se guardaran las frases (si es que no existe, si existe da igual)
            if (!File.Exists(archivo))
            {
                File.Create(archivo).Close();
            }
            string[] frases = new string[5];
            //Capturar datos del alumno
            string[] preguntas = {
                "Ingresa la Frase 1:                                ",
                "Ingresa la Frase 2:                                ",
                "Ingresa la Frase 3:                                ",
                "Ingresa la Frase 4:                                ",
                "Ingresa la Frase 5:                                "
            };

            //Mostrar preguntas en el menu
            MenuNoOpciones(preguntas, "F R A S E S", Console.WindowWidth / 2, Console.WindowHeight / 2, "Rellene los datos correspondientes.");

            //Guardar los datos en un arreglo
            Console.CursorVisible = true;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2 - 2);
            frases[0] = Console.ReadLine();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2 - 1);
            frases[1] = Console.ReadLine();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2);
            frases[2] = Console.ReadLine();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2 + 1);
            frases[3] = Console.ReadLine();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2 + 2);
            frases[4] = Console.ReadLine();

            //Imprimir las frases en el archivo de texto
            using (StreamWriter sw = new StreamWriter(archivo))
            {
                for (int i = 0; i < frases.Length; i++)
                {
                    sw.WriteLine(frases[i]);
                }
            }
            //Retornar el arreglo
            return frases;
        }
        static void VerFrases(string[] frases) {
            //Verificar si existe el archivo (si no existe, no existen frases)
            //Si no existe, mostrar mensaje de error y regresar al menu
            if (!File.Exists(archivo))
            {
                Console.Clear();
                string[] noExiste = {
                    "No existen frases actuales.                    ",
                    "Necesitan existir frases para poder verlas.    "
                };
                MenuNoOpciones(noExiste, "F R A S E S", Console.WindowWidth / 2, Console.WindowHeight / 2, "Frases actuales:");
                Thread.Sleep(2000);
                return;
            }

            //Capturar datos del alumno
            string[] preguntas = {
                "Las frases actuales son:                         ",
                "1. Frase 1:                                      ",
                "2. Frase 2:                                      ",
                "3. Frase 3:                                      ",
                "4. Frase 4:                                      ",
                "5. Frase 5:                                      "
            };
            //Mostrar preguntas en el menu
            MenuNoOpciones(preguntas, "F R A S E S", Console.WindowWidth / 2, Console.WindowHeight / 2, "Frases actuales:");
            //Guardar los datos en un arreglo
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2 - 2);
            for (int i = 0; i < frases.Length; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 12, Console.WindowHeight / 2 - 2 + i);
                Console.Write(frases[i]);
            }
            Console.ReadKey();
        }
        static void Noticiero() {
            Console.Clear();
            // Verificar si existe el archivo (si no existe, no existen frases)
            // Si no existe, mostrar mensaje de error y regresar al menu
            if (!File.Exists(archivo))
            {
                Console.Clear();
                string[] noExiste = {
                "No existen frases actuales.                    ",
                "Necesitan existir frases para poder verlas.    "
                };
                MenuNoOpciones(noExiste, "F R A S E S", Console.WindowWidth / 2, Console.WindowHeight / 2, "Frases actuales:");
                Thread.Sleep(2000);
                return;
            }

            string[] frases = File.ReadAllLines(archivo);
            string[] frasesNew = new string[5];
            Random random = new Random();
            // Ordenar las frases de manera aleatoria
            int[] OldNum = new int[frases.Length];
            int numRandom = random.Next(0, frases.Length - 1);
            for (int i = 1; i < frases.Length; i++)
            {
                while (numRandom == OldNum[i - 1])
                    numRandom = random.Next(0, frases.Length - 1);
                frasesNew[i] = frases[numRandom];
                OldNum[i] = numRandom;
            }
            // Crear variable para la frase
            string frase = $"{frasesNew[0]} // {frasesNew[1]} // {frasesNew[2]} // {frasesNew[3]} // {frasesNew[4]} // ";

            int anchoConsola = Console.WindowWidth;
            string espacio = "";
            if (frase.Length < anchoConsola)
            {
                espacio = new string(' ', (anchoConsola - frase.Length - 1));
            }
            string textoAnimado = espacio + frase + " ";

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            //Sacar la frase de mayor tamaño
            int mayor = 0;
            for (int i = 0; i < frases.Length; i++)
            {
                if (frases[i].Length > mayor)
                {
                    mayor = frases[i].Length;
                }
            }

            //Crear variable vacia
            string enVivo = frases[random.Next(0, frases.Length - 1)];
            string enVivoVacio = new string(' ', mayor);
            int parpadeos = 3;

            int j = 0, p = 0;
            while (true)
            {
                for (int i = 0; i < textoAnimado.Length; i++)
                {
                    //Sacar enVivo de una frase
                    if (parpadeos == 3)
                    {
                        //Darle valor al enVivo
                        enVivo = frases[random.Next(0, frases.Length - 1)];
                        parpadeos = 0;

                        //Poner un caracter de la frase en una posicion aleatoria de la pantalla
                        char letraRand = enVivo[random.Next(0, enVivo.Length - 1)];
                        int posicionX = random.Next(0, Console.WindowWidth - 1);
                        int posicionY = random.Next(0, Console.WindowHeight - 1);
                        Console.SetCursorPosition(posicionX, posicionY);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = (ConsoleColor)random.Next(1, 15);
                        Console.Write(letraRand);
                    }

                    // Barra de noticias
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(0, Console.WindowHeight - 3);
                    Console.Write(textoAnimado.Substring(i) + textoAnimado.Substring(0, i));

                    // En vivo
                    if (j % 5 == 0 && p == 0 && j != 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(Console.WindowWidth - enVivo.Length - 1, 1);
                        Console.Write(enVivo);
                        p = 1;
                        j = 0;
                    }

                    if (j % 5 == 0 && p == 1 && j != 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(Console.WindowWidth - enVivo.Length - 1, 1);
                        Console.Write(enVivoVacio);
                        p = 0;
                        j = 0;
                        parpadeos++;
                    }

                    // Delay
                    Thread.Sleep(50);
                    j++;
                }
            }
        }

    }
}
