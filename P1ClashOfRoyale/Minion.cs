using System;
using System.Collections.Generic;
using System.Text;

namespace P1ClashOfRoyale
{
    class Minion
    {
        // dos atributs que determinen la posició del minion
        private int row; // fila
        private int col; // columna

        public Minion(int row, int col)
        {
            // definim la seva posició al crear un minion
            this.row = row;
            this.col = col;
        }
        public int GetRow() { return row; }
        public int GetCol() { return col; }

        public void Print()
        {
            /* Implementació 7
             * imprimeix per pantalla una m a la posició col,row
             */
            Console.SetCursorPosition(col, row);
            Console.ForegroundColor = ConsoleColor.Yellow; // Escollim un color per la lletra
            Console.Write("m");
            Console.ResetColor(); // Restablim el color predeterminat
        }

        public void Move()
        {
            /* Implementació 8
             * mou el miniom cap amunt, 
             * o en direcció a un pont, 
             * o en direcció a la torre del mig
             */
            // Comprovem si la posició de dalt està lliure
            if (Arena.CheckPosition(row - 1, col))
            {
                row--; // Movem el minion cap amunt
            }
            else
            {
                // Si està a la part inferior, busca un pont
                if (row >= Arena.nRow - 2)
                {
                    // Movem el minion cap al pont més proper
                    if (Arena.CheckPosition(row, col - 1)) col--;
                    else if (Arena.CheckPosition(row, col + 1)) col++;
                }
                // Si està a la primera fila, anem cap a la torre del mig
                else if (row == 0)
                {
                    if (col < Arena.nCol / 2 && Arena.CheckPosition(row, col + 1)) col++;
                    else if (col > Arena.nCol / 2 && Arena.CheckPosition(row, col - 1)) col--;
                }
            }

        }

    }
}
