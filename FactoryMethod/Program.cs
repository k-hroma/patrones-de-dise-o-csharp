#region PRODUCTOS

// ==========================================================
// PRODUCT (Producto)
// ==========================================================
// Define el contrato común que deben cumplir todos los
// los objetos que podrán ser creados por las fábricas.
//
// El cliente trabajará contra esta interfaz y no contra
// clases concretas como Camion o Barco.
//
public interface ITransporte
{
  void Entregar();
}

// ==========================================================
// CONCRETE PRODUCT
// ==========================================================
// Implementación concreta del producto.
//
public class Camion : ITransporte
{
  public void Entregar()
  {
    Console.WriteLine("Entrega realizada por camión.");
  }
}

// ==========================================================
// CONCRETE PRODUCT
// ==========================================================
// Otra implementación concreta del producto.
//
public class Barco : ITransporte
{
  public void Entregar()
  {
    Console.WriteLine("Entrega realizada por barco.");
  }
}

#endregion

#region CREADORES

// ==========================================================
// CREATOR (Creador)
// ==========================================================
//
// Esta es la pieza central del patrón.
//
// Declara el Factory Method:
//
//      CrearTransporte()
//
// pero NO decide qué objeto concreto crear.
//
// Esa responsabilidad se delega a las clases hijas.
//
public abstract class EmpresaLogistica
{
  // ======================================================
  // FACTORY METHOD
  // ======================================================
  //
  // Las clases derivadas decidirán qué implementación
  // concreta devolver.
  //
  public abstract ITransporte CrearTransporte();

  // ======================================================
  // MÉTODO DE NEGOCIO
  // ======================================================
  //
  // Este método utiliza el producto creado por el
  // Factory Method.
  //
  // Observá que NO hace:
  //
  //      new Camion()
  //      new Barco()
  //
  // Trabaja únicamente contra la abstracción
  // ITransporte.
  //
  public void PlanificarEntrega()
  {
    Console.WriteLine("Planificando entrega...");
    // new Camion o new Barco
    ITransporte transporte = CrearTransporte();

    // Camion.Entregar 0 Barco.Entregar
    transporte.Entregar();
  }
}

// ==========================================================
// CONCRETE CREATOR
// ==========================================================
//
// Decide que el producto a crear será un Camion.
//
public class LogisticaTerrestre : EmpresaLogistica
{
  public override ITransporte CrearTransporte()
  {
    return new Camion();
  }
}

// ==========================================================
// CONCRETE CREATOR
// ==========================================================
//
// Decide que el producto a crear será un Barco.
//
public class LogisticaMaritima : EmpresaLogistica
{
  public override ITransporte CrearTransporte()
  {
    return new Barco();
  }
}

#endregion

class Program
{
  static void Main()
  {
    // ==============================================
    // El cliente decide qué fábrica utilizar.
    // ==============================================

    EmpresaLogistica logistica;

    logistica = new LogisticaTerrestre();
    logistica.PlanificarEntrega();

    Console.WriteLine();

    logistica = new LogisticaMaritima();
    logistica.PlanificarEntrega();
  }
}