using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto2
{
    internal class juego
    {
        
        int[,] tablero = new int[6,7];
       
            public void GraficarTablero()
        {
            Console.WriteLine(" 1  2  3  4  5  6  7");
            for (int f = 0; f < 6; f++)
            {
                for (int c = 0; c < 7; c++)
                {
                    Console.Write("|");
                    Console.Write(tablero[f,c]);
                    Console.Write("|");
                }
                Console.WriteLine(" ");
            }
        }
        //asignar valor a la ficha
        public void IgualarTablero()
        {
            for (int f = 0; f < 6; f++)
            {
                for (int c = 0; c < 7; c++)
                {
                    tablero[f, c] = 0;
                }
                Console.WriteLine(" ");
            }
        }
      
        public void computadora()
        {
            
            int numColumna = 0;
            Random random = new Random();
            numColumna = random.Next(1, 7);
            int numFila = 0;

            for (int i = 0; i < 6; i++)
            {
                if (tablero[i, numColumna - 1] != 0)
                {
                    numFila = i - 1;
                    break;
                }
                else if (i == 5)
                {
                    numFila = 5;
                }
            }
            tablero[numFila, numColumna - 1] = 2;
        }
        public void jugador1()
        {
           
            int numColumna = 0;
            Console.WriteLine("Ingrese el numero de columna");
            numColumna = Convert.ToInt32(Console.ReadLine());

            while (numColumna > 7 && numColumna < 0) 
            {
                Console.WriteLine("ERROR: el numero de columna debe estar entre 1 y 7, ingreselo nuevamente");
                numColumna = Convert.ToInt32(Console.ReadLine());
            }
            int numFila = 0;

            for (int i = 0; i < 6; i++)
            {
                if (tablero[i, numColumna - 1] != 0)
                {
                    numFila = i - 1;
                    break;
                }
                else if (i == 5)
                {
                    numFila = 5;
                }
            }
            tablero[numFila, numColumna - 1] = 1;
        }
        public void jugador2()
        {
           
            int numColumna = 0;
            Console.WriteLine("Ingrese el numero de columna");
            numColumna = Convert.ToInt32(Console.ReadLine());

            while (numColumna > 7 && numColumna < 0)
            {
                Console.WriteLine("ERROR: el numero de columna debe estar entre 1 y 7, ingreselo nuevamente");
                numColumna = Convert.ToInt32(Console.ReadLine());
            }

            int numFila = 0;

            for (int i = 0; i < 6; i++)
            {
                if (tablero[i, numColumna - 1] != 0)
                {
                    numFila = i - 1;
                    break;
                }
                else if (i == 5)
                {
                    numFila = 5;
                }
            }
            tablero[numFila, numColumna - 1] = 2;
        }

        public bool Victoria1()
        //victoria jugador 1
        {
            bool victoria = false;
            //fichas = fichas seguidas
            int fichas = 0; 

            //validar victoria de forma horizontal 
            for (int f = 0; f < 6; f++)
            {
                for (int c = 0; c < 7; c++)   //revisa la matriz
                {
                    try
                    {
                        if (tablero[f, c] == 1) //para encontrar una ficha
                        {
                            fichas = 1;
                            for (int i = 1; i < 4; i++) //revisa las posiciones siguientes
                            {
                                if (tablero[f, c + i] == 1)
                                {
                                    fichas++;
                                }
                                else if (tablero[f, c + i] != 1)
                                {
                                    victoria = false;
                                    break;
                                }
                            }
                            if (fichas == 4)
                            {
                                victoria = true;
                                return victoria; 
                            }
                            break;
                        }
                    }
                    catch
                    {
                        victoria = false;
                        break;
                    }

                }
            }

            fichas = 0; 
            //validar victoria de forma horizontal
            for (int c = 0; c < 6; c++) //columna
            {
                for (int f = 0; f < 7; f++) //fila
                {
                    //EXAMINA TODA LA MATRIZ
                    try
                    {
                        if (tablero[f, c] == 1)
                        {
                            fichas = 1;

                            for (int i = 1; i < 4; ++i) //revisa las posiciones siguientes
                            {
                                if (tablero[f + i, c] == 1)
                                {
                                    fichas++;
                                }
                                else if (tablero[f + i, c] != 1)
                                {
                                    victoria = false;
                                    break;
                                }
                            }
                            if (fichas == 4)
                            {
                                victoria = true;

                                return victoria;  //vict
                            }
                            break;
                        }
                    }
                    catch
                    {
                        victoria = false;
                        break;
                    }
                }
            }

            //diagonal izquierda a derecha

            for (int f = 0; f < 6; f++) //columna
            {
                for (int c = 0; c < 7; c++) //fila
                {
                    try
                    {
                        if (tablero[f, c] == 1)
                        {
                            fichas = 1;

                            for (int i = 1; i < 4; ++i) //revisa las posiciones siguientes
                            {
                                {
                                    if (tablero[f + i, c + i] == 1)
                                    {
                                        fichas++;
                                    }
                                    else if (tablero[f + i, c + i] != 1)
                                    {
                                        victoria = false;
                                        break;
                                    }
                                }
                                if (fichas == 4)
                                {
                                    victoria = true;
                                    return victoria;  //victoria
                                }
                                break;
                            }

                        }
                    }
                    catch
                    {
                        victoria = false;
                        break;
                    }
                }
            }
            ///diagonal izquierda a derecha

            for (int f = 0; f < 6; f++) //columna
            {
                for (int c = 0; c < 7; c++) //fila
                {
                    try
                    {
                        if (tablero[f, c] == 1)
                        {
                            fichas = 1;

                            for (int i = 1; i < 4; ++i) //revisa las posiciones siguientes 
                            {
                                if (tablero[f + i, c - i] == 1)
                                {
                                    fichas++;
                                }
                                else if (tablero[f + i, c - i] != 1)
                                {
                                    victoria = false;
                                    break;
                                }
                            }
                            if (fichas == 4)
                            {
                                victoria = true;
                                return victoria;  //victoria
                            }
                            break;
                        }
                    }
                    catch
                    {
                        victoria = false;
                        break;
                    }
                }
            }
            return victoria;
        }
        public bool Victoria2()
        //victoria jugador 1
        {
            bool victoria = false;
            //fichas = fichas seguidas
            int fichas = 0;

            //validar victoria de forma horizontal 
            for (int f = 0; f < 6; f++)
            {
                for (int c = 0; c < 7; c++)   //revisa la matriz
                {
                    try
                    {
                        if (tablero[f, c] == 2) //para encontrar una ficha
                        {
                            fichas = 1;
                            for (int i = 1; i < 4; i++) //revisa las posiciones siguientes
                            {
                                if (tablero[f, c + i] == 2)
                                {
                                    fichas++;
                                }
                                else if (tablero[f, c + i] != 2)
                                {
                                    victoria = false;
                                    break;
                                }
                            }
                            if (fichas == 4)
                            {
                                victoria = true;
                                return victoria;
                            }
                            break;
                        }
                    }
                    catch
                    {
                        victoria = false;
                        break;
                    }

                }
            }

            fichas = 0;
            //validar victoria de forma horizontal
            for (int c = 0; c < 6; c++) //columna
            {
                for (int f = 0; f < 7; f++) //fila
                {
                    //EXAMINA TODA LA MATRIZ
                    try
                    {
                        if (tablero[f, c] == 2)
                        {
                            fichas = 1;

                            for (int i = 1; i < 4; ++i) //revisa las posiciones siguientes
                            {
                                if (tablero[f + i, c] == 2)
                                {
                                    fichas++;
                                }
                                else if (tablero[f + i, c] != 2)
                                {
                                    victoria = false;
                                    break;
                                }
                            }
                            if (fichas == 4)
                            {
                                victoria = true;
                                return victoria;  //vict
                            }
                            break;
                        }
                    }
                    catch
                    {
                        victoria = false;
                        break;
                    }
                }
            }

            //diagonal izquierda a derecha

            for (int f = 0; f < 6; f++) //columna
            {
                for (int c = 0; c < 7; c++) //fila
                {
                    try
                    {
                        if (tablero[f, c] == 2)
                        {
                            fichas = 1;

                            for (int i = 1; i < 4; ++i) //revisa las posiciones siguientes
                            {
                                {
                                    if (tablero[f + i, c + i] == 2)
                                    {
                                        fichas++;
                                    }
                                    else if (tablero[f + i, c + i] != 2)
                                    {
                                        victoria = false;
                                        break;
                                    }
                                }
                                if (fichas == 4)
                                {
                                    victoria = true;
                                    return victoria;  //victoria
                                }
                                break;
                            }

                        }
                    }
                    catch
                    {
                        victoria = false;
                        break;
                    }
                }
            }
            ///diagonal izquierda a derecha

            for (int f = 0; f < 6; f++) //columna
            {
                for (int c = 0; c < 7; c++) //fila
                {
                    try
                    {
                        if (tablero[f, c] == 2)
                        {
                            fichas = 1;

                            for (int i = 1; i < 4; ++i) //revisa las posiciones siguientes 
                            {
                                if (tablero[f + i, c - i] == 2)
                                {
                                    fichas++;
                                }
                                else if (tablero[f + i, c - i] != 2)
                                {
                                    victoria = false;
                                    break;
                                }
                            }
                            if (fichas == 4)
                            {
                                victoria = true;
                                return victoria;  //victoria
                            }
                            break;
                        }
                    }
                    catch
                    {
                        victoria = false;
                        break;
                    }
                }
            }
            return victoria;
        }
    }
    
}

