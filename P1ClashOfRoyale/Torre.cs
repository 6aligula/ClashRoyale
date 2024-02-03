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
            return false;
        }

        public bool IsAlive()
        {
            /* Implementació 4
             * aquest mètode comprova si la torre s'ha enfonsat 
             */
            return true;
        }
    }
}
