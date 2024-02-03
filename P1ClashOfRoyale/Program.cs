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
                Thread.Sleep(700);//miliseconds
                if (Console.KeyAvailable)
                    UserInput();
            }
        }

        private static void Init()
        {
            torresEnemigues = new List<Torre>() { };
            myTowers = new List<Torre>() {};
            enemics = new List<Enemic>() {};
            myMinions = new List<Minion>() { };

        /* Implementació 5  - Passos 1-6
         * Crea les 6 torres dins dels corresponents llistats
         */

        /* Implementació 9 - Pas 1
         * Instancia la llista buida myMinions
         */


        /* Implementació 13 - Pas 1
         * Instancia la llista buida enemics
         */

    }

    private static bool Finish()
        {
            /*
             * implementació 6
             * Si una de les dues llistes de torres és buida, 
             * s'acaba el joc.
             */
            return false;
        }

        private static void Print()
        {
            Arena.Print();

            /* Implementació 5 - Passos 7-8
             * mostra les torres, necessitaràs un bucle per cada llista
             */

            /* Implementació 9 - Pas 2
             * mostra els minions, fes un bucle que cridi el mètode print de cada objecte.
             */

            /* Implementació 13 - Pas 2
             * mostra els enemics, fes un bucle que cridi el mètode print de cada objecte.
             */


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
