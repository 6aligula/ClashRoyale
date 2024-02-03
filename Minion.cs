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
                // Si el minion está en la fila justo antes de los puentes (fila 7 si los puentes están en la 6)
                if (row == Arena.nRow - 6)
                {
                    // Determina si debe moverse hacia el puente más cercano
                    // Mueve el minion hacia la derecha si está a la izquierda del puente de la columna 2
                    // y puede moverse hacia la derecha
                    if (col < 2 && Arena.CheckPosition(row, col + 1))
                    {
                        col++; // Mueve a la derecha hacia el puente
                    }
                    // De lo contrario, si está a la derecha del puente de la columna 6
                    // y puede moverse hacia la izquierda
                    else if (col > 6 && Arena.CheckPosition(row, col - 1))
                    {
                        col--; // Mueve a la izquierda hacia el puente
                    }
                    // Si está entre los dos puentes, elige el puente de la columna 2 si está más cerca o está en la misma columna
                    else if (col >= 2 && col <= 6)
                    {
                        if (col - 2 <= 6 - col && Arena.CheckPosition(row, col - 1)) col--; // Puente columna 2 está más cerca o igual distancia
                        else if (col - 2 > 6 - col && Arena.CheckPosition(row, col + 1)) col++; // Puente columna 6 está más cerca
                    }
                }
                // Si està a la primera fila, anem cap a la torre del mig
                else if (row == 1)
                {
                    if (col < (Arena.nCol-1) / 2 && Arena.CheckPosition(row, col + 1)) col++;
                    else if (col > (Arena.nCol - 1) / 2 && Arena.CheckPosition(row, col - 1)) col--;
                }
            }

        }

    }
}
