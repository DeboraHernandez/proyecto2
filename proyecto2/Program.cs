// See https://aka.ms/new-console-template for more information

using proyecto2;
using System.Reflection;
string cont;
int turno1 = 0;
int turno2 = 0;
juego juego = new juego();
bool victoria = false;
string ganador = null;
List<string> registroGanadores = new List<string>();
do
{
    Console.Clear();
    Console.WriteLine("MENU");
    Console.WriteLine("1. Jugar");
    Console.WriteLine("2. Tabla de ganadores");
    Console.WriteLine("3. Cerrar programa");
    int op = Convert.ToInt32(Console.ReadLine());
    
    while (op > 3 || op < 0)
    {
        Console.WriteLine("La opcion ingresada no es valida, intentelo de nuevo");
        op = Convert.ToInt32(Console.ReadLine());
    }
    Console.Clear();
    switch (op)
    {
        case 1:

            string nombre;
            string nombre2;

            Console.WriteLine("BIENVENIDO");
            Console.WriteLine("Cuantas personas jugaran?");
            int per = Convert.ToInt32(Console.ReadLine());

            while (per != 1 && per != 2)
            {
                Console.WriteLine("ERROR: jugara 1 o 2 personas?");
                per = Convert.ToInt32(Console.ReadLine());
            }

            switch (per)
            {
                case 1:

                    Console.WriteLine("Ingrese su nombre");
                    nombre = Console.ReadLine();

                    juego.GraficarTablero();
                    while (victoria == false)
                    {
                        Console.WriteLine("Es el turno de " + nombre);
                        turno1++;
                        juego.jugador1();
                        victoria = juego.Victoria1();
                        Console.Clear();
                        juego.GraficarTablero();
                        if (victoria == true)
                        {
                            Console.WriteLine("GANÓ " + nombre);
                            Console.WriteLine("Has ganado en " + turno1 + " turnos");
                            ganador = nombre;
                            break;
                        }
                        Console.WriteLine("Es el turno de computadora");
                        juego.computadora();
                        victoria = juego.Victoria2();
                        juego.GraficarTablero();
                        if (victoria == true)
                        {
                            Console.WriteLine("GANÓ COMPUTADORA");
                            break;
                        }
                    }
                    if (ganador != null)
                    {
                        registroGanadores.Add(ganador);
                    }
                    break;

                case 2:

                    Console.WriteLine("Ingrese el nombre del jugador 1");
                    nombre = Console.ReadLine();
                    Console.WriteLine("Ingrese el nombre del jugador 2");
                    nombre2 = Console.ReadLine();

                    while (nombre == "computadora" && nombre2 == "computadora")
                    {
                        Console.WriteLine("ERROR: ningun jugador puede llamarse: Computadora");
                        nombre = Console.ReadLine();
                    }
                    
                    juego.GraficarTablero();
                    while (victoria == false)
                    {
                        Console.WriteLine("Es el turno de " + nombre);
                        turno1++;
                        juego.jugador1();
                        victoria = juego.Victoria1();
                        Console.Clear();
                        juego.GraficarTablero();
                        if (victoria == true)
                        {
                            Console.WriteLine("FELICIDADES" + nombre + "!");
                            Console.WriteLine("Has ganado en "+turno1+" turnos");
                            ganador = nombre;
                            break;
                        }
                        Console.WriteLine("Es el turno de " + nombre2);
                        turno2++;
                        juego.jugador2();
                        victoria = juego.Victoria2();
                        Console.Clear();
                        juego.GraficarTablero();
                        if (victoria == true)
                        {
                            Console.WriteLine("FELICIDADES" + nombre2+"!");
                            Console.WriteLine("Has ganado en " + turno2 + " turnos");
                            ganador = nombre2;
                            break;
                        }
                    }
                    if (ganador != null)
                    {
                        registroGanadores.Add(ganador);
                    }
                    break;
            }
            break;

        case 2:
            MostrarRegistroGanadores(registroGanadores);
            break;

        case 3:
            Console.WriteLine("Gracias por jugar");
            break;
    }

    Console.WriteLine("Desea volver al menu principal?");
    cont = Console.ReadLine();

} while (cont == "si");

static void MostrarRegistroGanadores(List<string> registroGanadores)
{
    Console.Clear();
    Console.WriteLine("GANADORES:");
    if (registroGanadores.Count == 0)
    {
        Console.WriteLine("No hay ganadores registrados.");
    }
    else
    {
        foreach (string ganador in registroGanadores)
        {
            Console.WriteLine(ganador);
        }
    }

}

