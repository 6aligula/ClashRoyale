using System;
using System.Collections.Generic;
using System.Text;

namespace P1ClashOfRoyale
{
    static class Arena
    {
        // definim una atributs constant amb la mida del tauler
        public const int nRow = 13;
        public const int nCol = 9;
        // definim el tauler com una matriu de caràcters
        private static char[,] tauler = new char[nRow, nCol] {
            { '#', '#', '#', '#', '#', '#', '#', '#', '#' },
            {'#',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ','#'},
            { '#','*',' ','*','*','*',' ','*','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ','#'},
            { '#','#','#','#','#','#','#','#','#'}
        };


        public static void Print()
        {
            /* Implementació 1
             * aquesta classe imprimeix el tauler a la consola
             */
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int row = 0; row < nRow; row++)
            {
                for (int col = 0; col < nCol; col++)
                {
                    char c = tauler[row, col];
                    if (c != ' ')
                    {
                        Console.SetCursorPosition(col, row);
                        Console.Write(c);
                    }
                }
            }
            Console.ResetColor();

        }

        public static bool CheckPosition(int row, int col)
        {
            /* Implementació 2
             * comprovem si una posició del tauler és aceptable
             */
             // Primer comprovem que la posició estigui dins dels límits del tauler
            if (row >= 0 && row < nRow && col >= 0 && col < nCol)
            {
                // Si la posició és dins dels límits, comprovem si el caràcter és un espai
                return tauler[row, col] == ' ';
            }
            // Si la posició no és dins dels límits, retornem false
            return false;
        }
    }
}
