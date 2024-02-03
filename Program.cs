using P1ClashOfRoyale;
using System;
using System.Collections.Generic;
using System.Threading;

namespace P1ClashOfRoyale
{
    class Program
    {
        private static List<Torre> torresEnemigues;
        private static List<Torre> myTowers;
        private static List<Enemic> enemics;
        private static List<Minion> myMinions;
        private static Random random = new Random();

        static void Main()
        {
            Console.WriteLine("Hello World!");
            Init();
            Print();
            while (!Finish())
            {
                CreateEnemic();
                Update();
                Print();
                Thread.Sleep(300);//miliseconds
                if (Console.KeyAvailable)
                    UserInput();
            }
        }

        private static void Init()
        {
            torresEnemigues = new List<Torre>();
            myTowers = new List<Torre>();

            /* Implementació 5  - Passos 1-6
             * Crea les 6 torres dins dels corresponents llistats
             */
            // Creem i afegim les torres aliades
            myTowers.Add(new Torre(10, 2));
            myTowers.Add(new Torre(11, 4));
            myTowers.Add(new Torre(10, 6));

            // Creem i afegim les torres enemigues
            torresEnemigues.Add(new Torre(2, 2));
            torresEnemigues.Add(new Torre(1, 4));
            torresEnemigues.Add(new Torre(2, 6));

            /* Implementació 9 - Pas 1
             * Instancia la llista buida myMinions
             */
            myMinions = new List<Minion>();

            /* Implementació 13 - Pas 1
             * Instancia la llista buida enemics
             */
            enemics = new List<Enemic>();

        }

        private static bool Finish()
        {
            /*
             * implementació 6
             * Si una de les dues llistes de torres és buida, 
             * s'acaba el joc.
             */
            if (torresEnemigues.Count == 0)
            {
                Console.WriteLine("Has guanyat la partida!");
                return true;
            }
            else if (myTowers.Count == 0)
            {
                Console.WriteLine("Has perdut la partida.");
                return true;
            }
            return false;
        }

        private static void Print()
        {
           
            Arena.Print();
            
            /* Implementació 5 - Passos 7-8
             * mostra les torres, necessitaràs un bucle per cada llista
             */
            // Mostrem les torres aliades
            foreach (Torre t in myTowers)
            {
                t.Print();
            }

            // Mostrem les torres enemigues
            foreach (Torre t in torresEnemigues)
            {
                t.Print();
            }

            /* Implementació 9 - Pas 2
             * mostra els minions, fes un bucle que cridi el mètode print de cada objecte.
             */
            foreach (Minion minion in myMinions)
            {
                minion.Print();
            }

            /* Implementació 13 - Pas 2
             * mostra els enemics, fes un bucle que cridi el mètode print de cada objecte.
             */
            foreach (Enemic enemic in enemics)
            {
                enemic.Print();
            }

            //Console.SetCursorPosition(Arena.nCol + 1, Arena.nRow);
            Console.SetCursorPosition(Arena.nCol, Arena.nRow);
            Console.WriteLine("Tria una posició per inserir un nou minion, per exemple 9,2");
        }
        private static void UserInput()
        {
            /* Implementació 10
             * Llegir l'entrada de la consola,
             * comprovem que sigui correcte
             * creem un minion i el inserim al llistat
             */
            string input = Console.ReadLine();
            //Console.WriteLine("Input: " + input);
            string[] parts = input.Split(',');
            
            //Console.WriteLine("parte1 " + parts[0] + "parte2 " + parts[1]);
            if (parts.Length == 2 && int.TryParse(parts[0], out int row) && int.TryParse(parts[1], out int col) && Arena.CheckPosition(row, col))
            {
                // Comprovar si la posició donada és correcte dins del nostre tauler
                if (Arena.CheckPosition(row, col))
                {
                    // Si és correcte, crea un minion a la posició donada i afegeix al llistat myMinions
                    myMinions.Add(new Minion(row, col));
                    //Console.WriteLine("Minion añadido en posición: " + row + "," + col); // Confirma que se añadió

                }
                else
                {
                    // Si no és correcte, mostrar un missatge d'error
                    Console.WriteLine("Posició no vàlida, intenta-ho de nou.");
                    //Console.ReadKey(true);
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida. Formato correcto: fila,columna"); // Indica problema con el formato de entrada
            }
        }

        private static void CreateEnemic()
        {
            /* Implementació 14
             * Simulem que llancem un dau de 6 cares utilitzant el mètode Next:
             * public virtual int Next (int minValue, int maxValue);
             * minValue està inclòs
             * maxValue està exclòs
             * 
             * Si surt 1, crearem un enemic a una posició a l'atzar
             * assignem una posició de la part superior del tauler
             */
            if (random.Next(1, 7) == 1) // Hay una probabilidad de 1 en 6 de crear un enemigo
            {
                int row = 1; // Enemigos aparecen en la primera fila
                int col = random.Next(1, Arena.nCol - 1); // Posición aleatoria en la columna
                if (Arena.CheckPosition(row, col))
                {
                    enemics.Add(new Enemic(row, col));
                }
            }

        }

        private static void Update()
        {
            Console.WriteLine(enemics.Count);
            // primer actualitzem els enemics
            for (int n = 0; n < enemics.Count; n++)
            {
                bool remove = false;
                // movem els enemics
                Enemic e = enemics[n];
                e.Move();
                // comprovem si la seva posició coincideix amb una torre
                int row = e.GetRow();
                int col = e.GetCol();
                for (int m = 0; m < myTowers.Count && remove == false; m++)
                {
                    Torre t = myTowers[m];
                    if (t.Atac(row, col))
                    {
                        // eliminar enemic
                        remove = true;
                        // comprovar si eliminem torre
                        if (!t.IsAlive())
                        {
                            myTowers.RemoveAt(m);
                            m--;
                        }
                    }
                }
                // comprovem si la seva posició coincideix amb un minion
                for (int m = 0; m < myMinions.Count && remove == false; m++)
                {
                    Minion unMinion = myMinions[m];
                    if (row == unMinion.GetRow() && col == unMinion.GetCol())
                    {
                        remove = true;
                        myMinions.RemoveAt(m);
                        m--;
                    }
                }
                if (remove)
                {
                    enemics.RemoveAt(n);
                    n--;
                }
            }
            // ara actualitzem els minions
            for (int m = 0; m < myMinions.Count; m++)
            {
                bool remove = false;
                Minion unMinion = myMinions[m];
                unMinion.Move();

                // comprovem si la seva posició coincideix amb una torre
                int row = unMinion.GetRow();
                int col = unMinion.GetCol();
                for (int n = 0; n < torresEnemigues.Count && remove == false; n++)
                {
                    Torre t = torresEnemigues[n];
                    if (t.Atac(row, col))
                    {
                        // eliminar minion
                        remove = true;
                        // comprovar si eliminem torre
                        if (!t.IsAlive())
                        {
                            torresEnemigues.RemoveAt(n);
                            n--;
                        }
                    }
                }

                // comprovem si la seva posició coincideix amb un enemic
                for (int n = 0; n < enemics.Count && remove == false; n++)
                {
                    Enemic e = enemics[n];
                    if (row == e.GetRow() && col == e.GetCol())
                    {
                        remove = true;
                        enemics.RemoveAt(n);
                        n--;
                    }
                }
                if (remove)
                {
                    myMinions.RemoveAt(m);
                    m--;
                }
            }

        }


    }
}
