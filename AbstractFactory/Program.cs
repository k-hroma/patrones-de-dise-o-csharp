
public interface IBoton
{
  void Dibujar();
}

public interface IVentana
{
  void Mostrar();
}

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

public interface IFabricaGUI
{
  IBoton CrearBoton();
  IVentana CrearVentana();
}

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