using System;

// ======================================================
// COMPONENT
// ======================================================
// Define la interfaz común para todos los objetos que pueden ser decorados.
//
// ======================================================

public interface IBebida
{
  string Descripcion();
  decimal Costo();
}

// ======================================================
// CONCRETE COMPONENT
// ======================================================
// Objeto base.
//
// Es el objeto real al que luego iremos agregando funcionalidades.
//
// ======================================================

public class Cafe : IBebida
{
  public string Descripcion()
  {
    return "Café";
  }

  public decimal Costo()
  {
    return 1000;
  }
}

// ======================================================
// DECORATOR
// ======================================================
// Implementa la misma interfaz que el Component.
//
// Además TIENE una referencia a otro Component. (composición)
//
// Esto permite envolver objetos.
//
// ======================================================

public abstract class DecoradorBebida : IBebida
{
  protected IBebida bebida;

  public DecoradorBebida(IBebida bebida)
  {
    this.bebida = bebida;
  }

  public virtual string Descripcion()
  {
    return bebida.Descripcion();
  }

  public virtual decimal Costo()
  {
    return bebida.Costo();
  }
}

// ======================================================
// CONCRETE DECORATOR
// ======================================================
// Agrega funcionalidad al objeto decorado.
//
// ======================================================

public class Leche : DecoradorBebida
{
  public Leche(IBebida bebida) : base(bebida)
  {
  }

  public override string Descripcion()
  {
    return bebida.Descripcion() + " + Leche";
  }

  public override decimal Costo()
  {
    return bebida.Costo() + 200;
  }
}

// ======================================================
// CONCRETE DECORATOR
// ======================================================

public class Azucar : DecoradorBebida
{
  public Azucar(IBebida bebida) : base(bebida)
  {
  }

  public override string Descripcion()
  {
    return bebida.Descripcion() + " + Azúcar";
  }

  public override decimal Costo()
  {
    return bebida.Costo() + 50;
  }
}

// ======================================================
// CONCRETE DECORATOR
// ======================================================

public class Chocolate : DecoradorBebida
{
  public Chocolate(IBebida bebida) : base(bebida)
  {
  }

  public override string Descripcion()
  {
    return bebida.Descripcion() + " + Chocolate";
  }

  public override decimal Costo()
  {
    return bebida.Costo() + 300;
  }
}

class Program
{
  static void Main()
  {
    // =====================================
    // Café simple
    // =====================================

    IBebida cafe = new Cafe();
    //variable = cafe
    //Tipo declarado = IBebida
    //Objeto Real = Cafe

    Console.WriteLine($"{cafe.Descripcion()} - ${cafe.Costo()}");
    // salida : Café - $1000
    Console.WriteLine();

    // =====================================
    // Café + Leche
    // =====================================

    cafe = new Leche(cafe);
    // variable = cafe
    // new Leche(referencia_al_Cafe)
    // IBebida bebida > recibe la referencia al objeto Cafe

    Console.WriteLine($"{cafe.Descripcion()} - ${cafe.Costo()}");
    // salida: Café + Leche - $1200
    Console.WriteLine();

    // =====================================
    // Café + Leche + Azúcar
    // =====================================

    cafe = new Azucar(cafe);

    Console.WriteLine($"{cafe.Descripcion()} - ${cafe.Costo()}");

    Console.WriteLine();

    // =====================================
    // Café + Leche + Azúcar + Chocolate
    // =====================================

    cafe = new Chocolate(cafe);

    Console.WriteLine($"{cafe.Descripcion()} - ${cafe.Costo()}");
  }
}

/**
Resumen conceptual

Decorator permite agregar responsabilidades a un objeto dinámicamente sin modificar su clase original.

La clave del patrón es:

Un Decorator implementa la misma interfaz
que el objeto que decora
y además contiene una referencia a él.

Por eso puede actuar como un "envoltorio" (wrapper) agregando comportamiento antes, después o alrededor de la operación original.
*/