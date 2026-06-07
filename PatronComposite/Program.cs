using System;
using System.Collections.Generic;

// ======================================================
// COMPONENT
// ======================================================
//
// Abstracción común para TODOS los elementos del árbol.
//
// Gracias a esta clase, el cliente puede trabajar de
// forma uniforme tanto con hojas (Archivo) como con
// compuestos (Carpeta).
//
// En esta implementación se utiliza la variante
// "Composite Transparente":
//
// - Component declara las operaciones de negocio.
// - Component también declara las operaciones para
//   manipular la estructura (Add, Remove, GetChild).
//
// Esto simplifica el código cliente porque todos los
// objetos exponen la misma interfaz.
//
// Como contrapartida, las hojas deben implementar
// métodos que no tienen sentido para ellas,
// lo que suele considerarse una violación del
// Interface Segregation Principle (ISP).
//
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

  protected Component(string nombre, int tamanio)
  {
    this.nombre = nombre;
    this.tamanio = tamanio;
  }

  // ==================================================
  // OPERACIONES DE NEGOCIO
  // ==================================================

  // Devuelve el tamaño total del componente.
  //
  // - En un Leaf será su propio tamaño.
  // - En un Composite será la suma de su tamaño
  //   más el tamaño de todos sus hijos.
  public abstract int DevolverTamanio();

  // Muestra el componente dentro de la estructura.
  //
  // El parámetro nivel se utiliza únicamente para
  // representar visualmente la profundidad dentro
  // del árbol.
  public abstract void Mostrar(int nivel = 0);

  // ==================================================
  // OPERACIONES ESTRUCTURALES
  // ==================================================

  // Agrega un hijo al componente.
  public abstract void Add(Component component);

  // Elimina un hijo del componente.
  public abstract void Remove(Component component);

  // Devuelve un hijo por posición.
  public abstract Component GetChild(int index);
}

// ======================================================
// LEAF
// ======================================================
//
// Representa un nodo terminal del árbol.
//
// Un Archivo no puede contener otros Component.
//
// Sin embargo, debido a la interfaz común definida
// por Component, debe implementar Add(), Remove()
// y GetChild(), aunque dichas operaciones no tengan
// sentido para una hoja.
//
// Este es uno de los puntos más criticados del patrón
// Composite en su versión transparente.
//
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

  public override void Mostrar(int nivel = 0)
  {
    string indentacion = new string(' ', nivel * 2);
    Console.WriteLine($"{indentacion}📄 {Nombre} ({Tamanio} MB)");
  }

  // ==================================================
  // OPERACIONES NO VÁLIDAS PARA UNA HOJA
  // ==================================================

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
//
// Representa un nodo compuesto.
//
// Puede contener otros objetos Component.
//
// LA CLAVE DEL PATRON COMPOSITE
//
// Un Composite almacena referencias a Component,
// por lo que puede contener indistintamente:
//
// - Leaf (Archivo)
// - Composite (Carpeta)
//
// Esto permite construir estructuras jerárquicas
// recursivas de profundidad arbitraria.
//
// Gracias al polimorfismo, Composite no necesita
// conocer el tipo concreto de los objetos que contiene.
//
// ======================================================

public class Carpeta : Component
{
  // Colección que almacena los hijos.
  //
  // Observá que la colección almacena Component,
  // no Archivo ni Carpeta.
  //
  // Gracias a esto podemos almacenar cualquier
  // objeto de la jerarquía.
  private readonly List<Component> hijos = new List<Component>();

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
    // Comenzamos con el tamaño propio
    // de la carpeta.
    int total = Tamanio;

    // Delegamos el cálculo a cada hijo.
    //
    // No importa si el hijo es una hoja
    // o un compuesto.
    foreach (Component hijo in hijos)
    {
      total += hijo.DevolverTamanio();
    }

    return total;
  }

  public override void Mostrar(int nivel = 0)
  {
    string indentacion = new string(' ', nivel * 2);

    Console.WriteLine(
        $"{indentacion}📁 {Nombre} ({Tamanio} MB)"
    );

    // Delegamos la visualización
    // a cada uno de los hijos.
    //
    // Nuevamente, no importa si son
    // hojas o compuestos.
    foreach (Component hijo in hijos)
    {
      hijo.Mostrar(nivel + 1);
    }
  }
}

// ======================================================
// CLIENTE
// ======================================================
//
// El cliente trabaja únicamente con Component.
//
// No necesita distinguir entre:
//
// - Archivo (Leaf)
// - Carpeta (Composite)
//
// Gracias al polimorfismo ambos pueden tratarse
// de manera uniforme.
//
// Esta transparencia para el cliente es uno de los
// principales objetivos del patrón Composite.
//
// ======================================================

class Program
{
  static void Main()
  {
    // ==========================================
    // El cliente declara variables del tipo
    // Component.
    //
    // No depende de clases concretas.
    // ==========================================

    Component disco = new Carpeta("Disco C", 1);

    Component src = new Carpeta("Src", 1);

    Component models = new Carpeta("Models", 1);

    Component archivo1 =
        new Archivo("Program.cs", 5);

    Component archivo2 =
        new Archivo("Usuario.cs", 9);

    Component archivo3 =
        new Archivo("README.md", 2);

    Component archivo4 =
        new Archivo("Producto.cs", 4);

    // ==========================================
    // Construcción de la estructura jerárquica.
    //
    // Como todos implementan Component,
    // una carpeta puede contener tanto
    // archivos como otras carpetas.
    // ==========================================

    models.Add(archivo4);

    src.Add(archivo1);
    src.Add(archivo2);

    // Una carpeta contiene otra carpeta.
    src.Add(models);

    disco.Add(archivo3);

    // Una carpeta contiene otra carpeta.
    disco.Add(src);

    // ==========================================
    // Uso uniforme de la estructura.
    //
    // El cliente no necesita saber si está
    // trabajando con hojas o compuestos.
    // ==========================================

    Console.WriteLine(
        $"Tamaño total: {disco.DevolverTamanio()} MB"
    );

    Console.WriteLine();

    disco.Mostrar();
  }
}

/*
SALIDA

Tamaño total: 23 MB

📁 Disco C (1 MB)
  📄 README.md (2 MB)
  📁 Src (1 MB)
    📄 Program.cs (5 MB)
    📄 Usuario.cs (9 MB)
    📁 Models (1 MB)
      📄 Producto.cs (4 MB)

*/