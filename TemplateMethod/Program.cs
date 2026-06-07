
// ======================================================
// TEMPLATE METHOD
// ======================================================
// Patrón de comportamiento.
//
// Define el esqueleto de un algoritmo dentro de una
// clase base, permitiendo que las subclases redefinan
// ciertos pasos sin modificar la estructura general.
//
// ======================================================

public abstract class Juego
{
  protected int numeroJugadores;

  // ==================================================
  // TEMPLATE METHOD
  // ==================================================
  // Define el algoritmo completo.
  //
  // Las clases hijas NO pueden modificar el orden.
  //
  // Flujo:
  //
  // 1. MostrarBienvenida()
  // 2. Iniciar()
  // 3. HookAntesDeJugar()
  // 4. HacerJugada()
  // 5. HookDespuesDeJugar()
  // 6. FinJuego()
  // 7. PublicarGanador()
  //
  // ==================================================

  public void Jugar()
  {
    MostrarBienvenida();

    Iniciar();

    HookAntesDeJugar();

    HacerJugada();

    HookDespuesDeJugar();

    FinJuego();

    PublicarGanador();
  }

  // ==================================================
  // OPERACIÓN CONCRETA COMÚN A TODAS LAS SUBLCASES
  // ==================================================
  // Implementación común para todos los juegos.
  // Las subclases la heredan automáticamente.
  // ==================================================

  protected void MostrarBienvenida()
  {
    Console.WriteLine("================================");
    Console.WriteLine("Comienza una nueva partida");
    Console.WriteLine("================================");
  }

  // ==================================================
  // PRIMITIVE OPERATIONS (Declara operaciones primitivas abstractas que deberán implementar las subclases.)
  // ==================================================
  // Pasos obligatorios.
  //
  // Las clases hijas DEBEN implementarlos.
  // ==================================================

  protected abstract void Iniciar();

  protected abstract void HacerJugada();

  protected abstract void FinJuego();

  protected abstract void PublicarGanador();

  // ==================================================
  // HOOKS (Puede definir operaciones Hook opcionales para que las subclases las sobrescriban si lo necesitan.)
  // ==================================================
  // Puntos de extensión opcionales.
  //
  // Las clases hijas pueden sobrescribirlos
  // o ignorarlos.
  //
  // Tienen implementación por defecto.
  // ==================================================

  protected virtual void HookAntesDeJugar()
  {
    // Vacío por defecto
  }

  protected virtual void HookDespuesDeJugar()
  {
    // Vacío por defecto
  }
}

// ======================================================
// AJEDREZ: CLASE CONCRETA
// ======================================================
// Utiliza únicamente las operaciones obligatorias.
// Proporciona el comportamiento específico de los pasos variables del algoritmo.
// No necesita Hooks. (Puede sobrescribir operaciones Hook para personalizar determinados puntos de extensión.)
// ======================================================

public class Ajedrez : Juego
{
  public Ajedrez()
  {
    numeroJugadores = 2;
  }

  protected override void Iniciar()
  {
    Console.WriteLine("Preparando tablero de ajedrez...");
  }

  protected override void HacerJugada()
  {
    Console.WriteLine("Los jugadores realizan movimientos.");
  }

  protected override void FinJuego()
  {
    Console.WriteLine("Se produce un jaque mate.");
  }

  protected override void PublicarGanador()
  {
    Console.WriteLine("Se publica el ganador del ajedrez.");
  }
}

// ======================================================
// PARCHIS
// ======================================================
// Además de las operaciones obligatorias,
// utiliza los Hooks para personalizar el algoritmo.
//
// Observá que NO cambia el orden del algoritmo.
// Sólo agrega comportamiento adicional.
// ======================================================

public class Parchis : Juego
{
  public Parchis()
  {
    numeroJugadores = 4;
  }

  protected override void Iniciar()
  {
    Console.WriteLine("Se reparten las fichas.");
  }

  protected override void HacerJugada()
  {
    Console.WriteLine("Los jugadores lanzan los dados.");
  }

  protected override void FinJuego()
  {
    Console.WriteLine("Un jugador llega a la meta.");
  }

  protected override void PublicarGanador()
  {
    Console.WriteLine("Se publica el ganador del parchís.");
  }

  // ==================================================
  // HOOK
  // ==================================================
  // Se ejecuta antes de comenzar las jugadas.
  // ==================================================

  protected override void HookAntesDeJugar()
  {
    Console.WriteLine("Verificando que todos los jugadores estén listos...");
  }

  // ==================================================
  // HOOK
  // ==================================================
  // Se ejecuta después de las jugadas.
  // ==================================================

  protected override void HookDespuesDeJugar()
  {
    Console.WriteLine("Actualizando ranking de jugadores...");
  }
}

/**
**Client(Cliente) **:
   - Trabaja con la abstracción.
   - Invoca el Template Method.
   - No necesita conocer los detalles de implementación de cada paso del algoritmo.

*/
class Program
{
  static void Main()
  {
    Juego juego1 = new Ajedrez();

    Console.WriteLine("=== AJEDREZ ===");

    juego1.Jugar();

    Console.WriteLine();

    Juego juego2 = new Parchis();

    Console.WriteLine("=== PARCHIS ===");

    juego2.Jugar();
  }
}

/**
=== AJEDREZ ===

================================
Comienza una nueva partida
================================
Preparando tablero de ajedrez...
Los jugadores realizan movimientos.
Se produce un jaque mate.
Se publica el ganador del ajedrez.

=== PARCHIS ===

================================
Comienza una nueva partida
================================
Se reparten las fichas.
Verificando que todos los jugadores estén listos...
Los jugadores lanzan los dados.
Actualizando ranking de jugadores...
Un jugador llega a la meta.
Se publica el ganador del parchís.


| Elemento             | En el ejemplo                                                   |
| -------------------- | --------------------------------------------------------------- |
| AbstractClass        | `Juego`                                                         |
| Template Method      | `Jugar()`                                                       |
| Primitive Operations | `Iniciar()`, `HacerJugada()`, `FinJuego()`, `PublicarGanador()` |
| Concrete Operation   | `MostrarBienvenida()`                                           |
| Hooks                | `HookAntesDeJugar()`, `HookDespuesDeJugar()`                    |
| ConcreteClass        | `Ajedrez`, `Parchis`                                            |

*/