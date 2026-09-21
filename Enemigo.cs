using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego_de_Rol
{
    internal class Enemigo
    {
        int vida;
        int daño;

        public Enemigo(int vida, int daño)
        {
            this.vida = vida;
            this.daño = daño;
        }

        public void RecibirDaño(int daño)
        {
            vida -= daño;

            if (vida < 0)
            {
                vida = 0;
            }
        }

        public int CausarDaño()
        {
            return daño;
        }

        public bool EstaVivo()
        {
            return vida > 0;
        }

        public int ObtenerVida()
        {
            return vida;
        }
    }
}
