
/**
1. **Abstract Product (Producto Abstracto)**:
   - Declara la interfaz o abstracción común para CADA tipo de producto de la familia de productos. Ej: sillón, mesa, sofá, etc
*/
public interface IBoton
{
  void Dibujar();
}

public interface IVentana
{
  void Mostrar();
}

/**
2. **Abstract Factory (Fábrica Abstracta)**:
   - Declara los métodos para crear cada tipo de producto de una familia.
   - Sus métodos devuelven abstracciones de productos, no implementaciones concretas. Son las interfaces creadas anteriormente.
*/
public interface IFabricaGUI
{
  IBoton CrearBoton();
  IVentana CrearVentana();
}

/**
3. **Concrete Factory (Fábrica Concreta)**:
   - Implementa los métodos definidos por la fábrica abstracta.
   - Es responsable de crear una familia específica de productos relacionados y compatibles entre sí. Para cada variante de una familia de productos, creamos una clase de fábrica independiente basada en la interfaz FábricaAbstracta. 
   - Una fábrica es una clase que devuelve productos de un tipo particular. 
*/
public class FabricaClara : IFabricaGUI
{
  public IBoton CrearBoton() => new BotonClaro();

  public IVentana CrearVentana() => new VentanaClara();
}

public class FabricaOscura : IFabricaGUI
{
  public IBoton CrearBoton() => new BotonOscuro();

  public IVentana CrearVentana() => new VentanaOscura();
}

/**
4. **Concrete Product (Producto Concreto)**:
   - Implementa la interfaz del producto abstracto.
   - Pertenece a una familia específica de productos.
*/
public class BotonClaro : IBoton
{
  public void Dibujar()
  {
    Console.WriteLine("Botón Claro");
  }
}

public class BotonOscuro : IBoton
{
  public void Dibujar()
  {
    Console.WriteLine("Botón Oscuro");
  }
}

public class VentanaClara : IVentana
{
  public void Mostrar()
  {
    Console.WriteLine("Ventana Clara");
  }
}

public class VentanaOscura : IVentana
{
  public void Mostrar()
  {
    Console.WriteLine("Ventana Oscura");
  }
}

/**
**Client (Cliente)**:
   - Trabaja únicamente con las abstracciones de las fábricas y los productos.
   - Utiliza la fábrica para obtener los productos que necesita.
   - No conoce ni depende de las clases concretas de los productos.
*/
public class Aplicacion
{
  private readonly IBoton boton;
  private readonly IVentana ventana;

  public Aplicacion(IFabricaGUI fabrica)
  {
    boton = fabrica.CrearBoton();
    ventana = fabrica.CrearVentana();
  }

  public void Ejecutar()
  {
    boton.Dibujar();
    ventana.Mostrar();
  }
}

class Program
{
  static void Main()
  {
    Console.WriteLine("Seleccione un tema:");
    Console.WriteLine("1 - Claro");
    Console.WriteLine("2 - Oscuro");

    string opcion = Console.ReadLine()!;

    IFabricaGUI fabrica;

    if (opcion == "1")
    {
      fabrica = new FabricaClara();
    }
    else
    {
      fabrica = new FabricaOscura();
    }

    Aplicacion app = new Aplicacion(fabrica);

    app.Ejecutar();
  }
}