using System;
using System.Collections.Generic;
using System.Text;

namespace P1ClashOfRoyale
{
    class Enemic
    {
        // dos atributs que determinen la posició del minion
        private int row; // fila
        private int col; // columna

        public Enemic(int row, int col)
        {
            // definim la seva posició al crear un minion
            this.row = row;
            this.col = col;
        }
        public int GetRow() { return row; }
        public int GetCol() { return col; }

        public void Print()
        {
            /* Implementació 11
             * imprimeix per pantalla una e a la posició col,row
             */
            Console.SetCursorPosition(col, row);
            Console.ForegroundColor = ConsoleColor.Red; // Seleccionem un color diferent per l'enemic
            Console.Write("e");
            Console.ResetColor(); // Tornem al color per defecte
        }

        public void Move()
        {
            /* Implementació 12
             * mou el miniom cap avall, 
             * o en direcció a un pont, 
             * o en direcció a la torre del mig
             */
            // Comprovem si la posició de sota està lliure
            if (Arena.CheckPosition(row + 1, col))
            {
                row++; // Movem l'enemic cap avall
            }
            else
            {
                // Si està a la part superior, busca un pont
                if (row <= 1)
                {
                    // Movem l'enemic cap al pont més proper
                    if (Arena.CheckPosition(row, col - 1)) col--;
                    else if (Arena.CheckPosition(row, col + 1)) col++;
                }
                // Si està a l'última fila, anem cap a la torre del mig
                else if (row == Arena.nRow - 1)
                {
                    if (col < Arena.nCol / 2 && Arena.CheckPosition(row, col + 1)) col++;
                    else if (col > Arena.nCol / 2 && Arena.CheckPosition(row, col - 1)) col--;
                }
            }

        }

    }
}
