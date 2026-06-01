public class Configuracion
{
  private static Configuracion instancia;
  private Configuracion()
  {
    NombreAplicacion = "Mi Sistema";
    MaximoUsuarios = 100;
    ModoDebug = false;
  }

  // Propiedades de configuración global.
  public string NombreAplicacion { get; set; }
  public int MaximoUsuarios { get; set; }
  public bool ModoDebug { get; set; }

  // Método estático para obtener la instancia única.
  public static Configuracion ObtenerInstancia()
  {
    // Si todavía no existe una instancia...
    if (instancia == null)
    {
      // ...la creamos.
      instancia = new Configuracion();
    }

    // Si ya existía, simplemente devolvemos la misma.
    return instancia;
  }

  // Método de ejemplo para mostrar los valores actuales.
  public void MostrarConfiguracion()
  {
    Console.WriteLine($"Aplicación: {NombreAplicacion}");
    Console.WriteLine($"Máximo usuarios: {MaximoUsuarios}");
    Console.WriteLine($"Modo Debug: {ModoDebug}");
  }
}

class Program
{
  static void Main()
  {
    // Obtiene la instancia única.
    Configuracion config1 = Configuracion.ObtenerInstancia();
    config1.MostrarConfiguracion();

    // Modifica algunos valores.
    config1.ModoDebug = true;
    config1.MaximoUsuarios = 500;

    // Vuelve a pedir la instancia.
    Configuracion config2 = Configuracion.ObtenerInstancia();

    // Ambos objetos apuntan a la misma instancia.
    Console.WriteLine(config1 == config2); // True

    // Los cambios realizados desde config1
    // son visibles desde config2.
    Console.WriteLine(config2.ModoDebug);      // True
    Console.WriteLine(config2.MaximoUsuarios); // 500

    config1.MostrarConfiguracion();
    config2.MostrarConfiguracion();
  }
}
