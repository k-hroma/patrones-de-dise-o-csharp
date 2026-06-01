using System;
using System.Collections.Generic;

// ======================================================
// COMPONENT
// ======================================================
// Clase abstracta común para TODOS los elementos del árbol.
//
// Define:
// - La operación principal del negocio.
// - Los métodos para manipular la estructura.
//
// En esta versión "transparente" incluso los Leaf
// deben implementar Add(), Remove() y GetChild().
//
// Esto simplifica el uso desde el cliente, pero hace
// que los Leaf tengan métodos que realmente no necesitan.
// ======================================================

public abstract class Component
{
  protected string nombre;
  protected int tamanio;

  public string Nombre
  {
    get { return nombre; }
    set { nombre = value; }
  }

  public int Tamanio
  {
    get { return tamanio; }
    set { tamanio = value; }
  }

  public Component(string nombre, int tamanio)
  {
    this.nombre = nombre;
    this.tamanio = tamanio;
  }

  // -------------------------
  // Operación de negocio
  // -------------------------
  public abstract int DevolverTamanio();

  public abstract void Mostrar(int nivel);

  // -------------------------
  // Operaciones estructurales
  // -------------------------
  public abstract void Add(Component component);

  public abstract void Remove(Component component);

  public abstract Component GetChild(int index);
}

// ======================================================
// LEAF
// ======================================================
// Representa un nodo final.
//
// Un archivo NO puede contener otros componentes.
//
// Sin embargo, como Component obliga a implementar
// Add(), Remove() y GetChild(), debemos definirlos.
//
// Aquí aparece la crítica al ISP.
// ======================================================

public class Archivo : Component
{
  public Archivo(string nombre, int tamanio)
      : base(nombre, tamanio)
  {
  }

  public override int DevolverTamanio()
  {
    return Tamanio;
  }

  public override void Mostrar(int nivel)
  {
    Console.WriteLine(
        new string('-', nivel) +
        $"{Nombre} ({Tamanio} MB)"
    );
  }

  // ---------------------------------
  // Métodos sin sentido para un Leaf
  // ---------------------------------

  public override void Add(Component component)
  {
    throw new NotSupportedException(
        "Un archivo no puede contener hijos."
    );
  }

  public override void Remove(Component component)
  {
    throw new NotSupportedException(
        "Un archivo no puede contener hijos."
    );
  }

  public override Component GetChild(int index)
  {
    throw new NotSupportedException(
        "Un archivo no tiene hijos."
    );
  }
}

// ======================================================
// COMPOSITE
// ======================================================
// Puede contener otros Component.
//
// Los hijos pueden ser:
// - Archivo (Leaf)
// - Carpeta (Composite)
//
// Aquí sí tienen sentido Add(), Remove()
// y GetChild().
// ======================================================

public class Carpeta : Component
{
  private readonly List<Component> hijos =
      new List<Component>();

  public Carpeta(string nombre, int tamanio)
      : base(nombre, tamanio)
  {
  }

  public override void Add(Component component)
  {
    hijos.Add(component);
  }

  public override void Remove(Component component)
  {
    hijos.Remove(component);
  }

  public override Component GetChild(int index)
  {
    return hijos[index];
  }

  public override int DevolverTamanio()
  {
    int total = Tamanio;

    foreach (Component hijo in hijos)
    {
      total += hijo.DevolverTamanio();
    }

    return total;
  }

  public override void Mostrar(int nivel)
  {
    Console.WriteLine(
        new string('-', nivel) +
        $"{Nombre} ({DevolverTamanio()} MB)"
    );

    foreach (Component hijo in hijos)
    {
      hijo.Mostrar(nivel + 2);
    }
  }
}


// CLIENTE

class Program
{
  static void Main()
  {
    Component disco = new Carpeta("Disco C", 1);

    Component src = new Carpeta("src", 1);

    Component archivo1 =
        new Archivo("Program.cs", 5);

    Component archivo2 =
        new Archivo("Usuario.cs", 9);

    Component archivo3 =
        new Archivo("README.md", 2);

    disco.Add(archivo3);

    src.Add(archivo1);
    src.Add(archivo2);

    disco.Add(src);

    Console.WriteLine(
        $"Tamaño total: {disco.DevolverTamanio()} MB"
    );

    Console.WriteLine();

    disco.Mostrar(1);
  }
}