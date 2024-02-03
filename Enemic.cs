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
                if (row == Arena.nRow - 8)
                {
                    // Mueve el enemigo hacia el puente más cercano
                    if (col < 2 && Arena.CheckPosition(row, col + 1)) col++; // Hacia el puente de la derecha
                    else if (col > 6 && Arena.CheckPosition(row, col - 1)) col--; // Hacia el puente de la izquierda
                    else if (col >= 2 && col <= 6)
                    {
                        if (col - 2 <= 6 - col && Arena.CheckPosition(row, col - 1)) col--; // Puente columna 2 está más cerca o igual distancia
                        else if (col - 2 > 6 - col && Arena.CheckPosition(row, col + 1)) col++; // Puente columna 6 está más cerca
                    }
                }
                // Si el enemigo está en la última fila antes de las torres, se dirige hacia la torre del medio
                else if (row == Arena.nRow - 2)
                {
                    if (col < (Arena.nCol - 1) / 2 && Arena.CheckPosition(row, col + 1)) col++; // Hacia la derecha
                    else if (col > (Arena.nCol - 1) / 2 && Arena.CheckPosition(row, col - 1)) col--; // Hacia la izquierda
                }
            }

        }

    }
}
