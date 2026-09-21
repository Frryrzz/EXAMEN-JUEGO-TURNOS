using System;
using System.Collections.Generic;

namespace Juego_de_Rol
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("===== ¡Bienvenido al juego! =====");
                Console.WriteLine("1. Crear personaje");
                Console.WriteLine("2. Salir");
                Console.Write("Ingrese una opción: ");

                string opcion = Console.ReadLine();

                if (opcion == "1")
                {
                    Console.WriteLine("Ingrese la vida de su personaje (máximo 100): ");
                    int vidaJugador = Convert.ToInt32(Console.ReadLine());
                    if (vidaJugador > 100) vidaJugador = 100;

                    Console.WriteLine("Ingrese el daño de su personaje (máximo 100): ");
                    int dañoJugador = Convert.ToInt32(Console.ReadLine());
                    if (dañoJugador > 100) dañoJugador = 100;

                    Jugador jugador = new Jugador(vidaJugador, dañoJugador);

                    Console.WriteLine("Ingrese la cantidad de enemigos: ");
                    int cantidadEnemigos = Convert.ToInt32(Console.ReadLine());
                    List<Enemigo> enemigos = new List<Enemigo>();

                    for (int i = 0; i < cantidadEnemigos; i++)
                    {
                        Console.WriteLine($"Ingrese la vida del enemigo {i + 1} (máximo 100): ");
                        int vidaEnemigo = Convert.ToInt32(Console.ReadLine());
                        if (vidaEnemigo > 100) vidaEnemigo = 100;

                        Console.WriteLine($"Ingrese el daño del enemigo {i + 1} (máximo 100): ");
                        int dañoEnemigo = Convert.ToInt32(Console.ReadLine());
                        if (dañoEnemigo > 100) dañoEnemigo = 100;

                        Enemigo enemigo = new Enemigo(vidaEnemigo, dañoEnemigo);
                        enemigos.Add(enemigo);
                    }

                    // BUCLE DE COMBATE 
                    while (jugador.ObtenerVida() > 0 && enemigos.Count > 0)
                    {
                        // 1. TURNO DEL JUGADOR
                        Console.WriteLine("\n--- Turno del jugador ---");
                        Console.WriteLine("Elija un enemigo para atacar:");
                        for (int i = 0; i < enemigos.Count; i++)
                        {
                            // Muestra la vida restante accediendo a la propiedad Vida del enemigo
                            Console.WriteLine($"{i + 1}. Enemigo {i + 1} - Vida restante: {enemigos[i].ObtenerVida()}");
                        }

                        int opcionAtaque = Convert.ToInt32(Console.ReadLine()) - 1;
                        if (opcionAtaque >= 0 && opcionAtaque < enemigos.Count)
                        {
                            Enemigo enemigoSeleccionado = enemigos[opcionAtaque];
                            enemigoSeleccionado.RecibirDaño(jugador.CausarDaño());
                            Console.WriteLine($"Atacaste al Enemigo {opcionAtaque + 1} e infligiste {jugador.CausarDaño()} de daño.");

                            // Si el enemigo fue derrotado, se remueve de la lista
                            if (!enemigoSeleccionado.EstaVivo())
                            {
                                Console.WriteLine($"¡El Enemigo {opcionAtaque + 1} ha sido derrotado!");
                                enemigos.RemoveAt(opcionAtaque);
                            }
                        }

                        // Verificar si ya no quedan enemigos antes del turno enemigo
                        if (enemigos.Count == 0) break;

                        // 2. TURNO DE LOS ENEMIGOS
                        Console.WriteLine("--- Turno de los enemigos ---");
                        foreach (var enemigo in enemigos)
                        {
                            jugador.RecibirDaño(enemigo.CausarDaño());
                            Console.WriteLine($"Un enemigo te ataca e inflige {enemigo.CausarDaño()} de daño.");
                        }
                    }

                    // RESULTADO DE LA BATALLA
                    if (jugador.ObtenerVida() > 0)
                    {
                        Console.WriteLine("¡Has ganado la batalla!");
                    }
                    else
                    {
                        Console.WriteLine("¡Has sido derrotado por los enemigos!");
                    }
                }
                else if (opcion == "2")
                {
                    Console.WriteLine("¡Gracias por jugar!");
                    return;
                }
                else
                {
                    Console.WriteLine("Opción inválida. Intente nuevamente.");
                }
            }
        }
    }
}