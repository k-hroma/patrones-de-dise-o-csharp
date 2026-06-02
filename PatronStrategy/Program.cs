using System;

// ======================================================
// STRATEGY
// ======================================================
// Define el contrato que deben cumplir todos los
// algoritmos de pago.
//
// Todas las estrategias saben procesar un pago,
// aunque cada una lo haga de forma diferente.
//
// ======================================================

public interface IEstrategiaPago
{
  void Pagar(decimal monto);
}

// ======================================================
// CONCRETE STRATEGY
// ======================================================
// Implementa el algoritmo de pago con tarjeta.
//
// ======================================================

public class PagoTarjeta : IEstrategiaPago
{
  public void Pagar(decimal monto)
  {
    Console.WriteLine($"Pagando ${monto} con Tarjeta de Crédito.");

    Console.WriteLine("Autorizando operación con el banco...");
  }
}

// ======================================================
// CONCRETE STRATEGY
// ======================================================
// Implementa el algoritmo de MercadoPago.
//
// ======================================================

public class PagoMercadoPago : IEstrategiaPago
{
  public void Pagar(decimal monto)
  {
    Console.WriteLine($"Pagando ${monto} con MercadoPago.");

    Console.WriteLine("Generando solicitud a MercadoPago...");
  }
}

// ======================================================
// CONCRETE STRATEGY
// ======================================================
// Implementa el algoritmo de transferencia.
//
// ======================================================

public class PagoTransferencia : IEstrategiaPago
{
  public void Pagar(decimal monto)
  {
    Console.WriteLine($"Pagando ${monto} mediante transferencia.");

    Console.WriteLine("Verificando cuenta bancaria...");
  }
}

// ======================================================
// CONTEXT
// ======================================================
//
// Es la clase que utiliza la estrategia.
//
// NO sabe cómo se realiza el pago. No conoce detalles de implementación
//
// Sólo sabe que existe una estrategia capaz de ejecutar:
//
//  Pagar(monto)
//
// Gracias a esto puede trabajar con cualquier implementación y cambiar de estrategia en tiempo de ejecución.
//
// ======================================================

public class CarritoCompras
{
  private IEstrategiaPago estrategiaPago;

  // Inyección por constructor.
  public CarritoCompras(IEstrategiaPago estrategiaPago)
  {
    this.estrategiaPago = estrategiaPago;
  }

  // Permite cambiar la estrategia durante la ejecución.
  public void CambiarMetodoPago(IEstrategiaPago nuevaEstrategia)
  {
    estrategiaPago = nuevaEstrategia;
  }

  public void FinalizarCompra(decimal monto)
  {
    Console.WriteLine("Procesando compra...");

    estrategiaPago.Pagar(monto);
  }
}

class Program
{
  static void Main()
  {
    // =====================================
    // El cliente elige Tarjeta
    // =====================================

    CarritoCompras carrito = new CarritoCompras(new PagoTarjeta());

    carrito.FinalizarCompra(10000);

    Console.WriteLine();

    // =====================================
    // Cambiamos la estrategia
    // durante la ejecución
    // =====================================

    carrito.CambiarMetodoPago(new PagoMercadoPago());

    carrito.FinalizarCompra(5000);

    Console.WriteLine();

    // =====================================
    // Volvemos a cambiar
    // =====================================

    carrito.CambiarMetodoPago(new PagoTransferencia());

    carrito.FinalizarCompra(3000);
  }
}

/**
Procesando compra...

Pagando $10000 con Tarjeta de Crédito.
Autorizando operación con el banco...

Procesando compra...

Pagando $5000 con MercadoPago.
Generando solicitud a MercadoPago...

Procesando compra...

Pagando $3000 mediante transferencia.
Verificando cuenta bancaria...
*/
