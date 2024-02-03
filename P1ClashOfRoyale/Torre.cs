using System;
using System.Collections.Generic;
using System.Text;

namespace P1ClashOfRoyale
{
    class Torre
    {
        // dos atributs que determinen la posició de la torre
        // readonly = només li podem donar valor a l'inici, no es podrà canviar
        private readonly int row; // fila
        private readonly int col; // columna
        // un atribut que determina la vida de la torre
        private int life;

        public Torre(int row, int col)
        {
            // definim la seva posició al crear una torre
            this.row = row;
            this.col = col;
            // la vida inicial és 2
            life = 2;
        }

        public void Print()
        {
            /* mètode de la classe Console
             * public static void SetCursorPosition(int left, int top);
             * left = columna
             * top = fila
             */
            Console.SetCursorPosition(col, row); 
            Console.Write("T");
        }

        public bool Atac(int row, int col)
        {
            /* Implementació 3
             * aquest mètode comprova si la torre és atacada
             * i disminueix la seva vida.
             */
            // Utilitzem 'this' per referir-nos als atributs de l'instància actual
            if (this.row == row && this.col == col)
            {
                this.life--; // Disminuir la vida en 1
                return true; // Retornar true per indicar que la torre ha estat atacada
            }
            return false; // Retornar false si no hi ha coincidència de posició
        }

        public bool IsAlive()
        {
            /* Implementació 4
             * aquest mètode comprova si la torre s'ha enfonsat 
             */
            return this.life > 0; // Retornar true si la vida és més gran que 0
        }
    }
}
