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

        }

        public static bool CheckPosition(int row, int col)
        {
            /* Implementació 2
             * comprovem si una posició del tauler és aceptable
             */
            return false;
        }
    }
}
