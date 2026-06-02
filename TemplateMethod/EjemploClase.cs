using System;

// ======================================================
// TEMPLATE METHOD
// ======================================================
// Patrón de comportamiento.
//
// Intención:
// Definir el esqueleto de un algoritmo en una clase base
// permitiendo que las subclases redefinan algunos pasos
// sin alterar la estructura general del algoritmo.
//
// En este ejemplo:
//
// Clase Abstracta  -> ProcesadorPago
// Template Method  -> ProcesarPago()
// Primitive Ops    -> ValidarMonto()
//                     Aplicar()
//                     NotificarUsuario()
// Concrete Method  -> LogPago()
//
// ======================================================

public abstract class ProcesadorPago
{
  // ==================================================
  // TEMPLATE METHOD
  // ==================================================
  // Define el flujo completo del procesamiento.
  //
  // Las clases hijas NO pueden modificar el orden
  // de los pasos.
  //
  // Flujo:
  //
  // 1. Validar monto
  // 2. Aplicar pago
  // 3. Registrar operación
  // 4. Notificar usuario
  //
  // ==================================================

  public decimal ProcesarPago(decimal monto)
  {
    if (ValidarMonto(monto))
    {
      Aplicar(monto);

      LogPago(monto);

      NotificarUsuario();
    }

    return monto;
  }

  // ==================================================
  // PRIMITIVE OPERATIONS
  // ==================================================
  // Son pasos obligatorios del algoritmo.
  //
  // La clase abstracta define QUE deben existir.
  // Las clases concretas definen COMO se realizan.
  //
  // ==================================================

  protected abstract bool ValidarMonto(decimal monto);

  protected abstract void Aplicar(decimal monto);

  protected abstract bool NotificarUsuario();

  // ==================================================
  // CONCRETE OPERATION
  // ==================================================
  // Método completamente implementado en la clase base.
  //
  // Todas las subclases reutilizan exactamente esta
  // implementación.
  //
  // ==================================================

  protected void LogPago(decimal monto)
  {
    Console.WriteLine($"Se registró el pago por ${monto}");
  }
}

// ======================================================
// CONCRETE CLASS
// ======================================================
// Implementa los pasos específicos para pagos
// realizados mediante Banco.
//
// ======================================================

public class ProcesadorPagoBanco : ProcesadorPago
{
  protected override bool ValidarMonto(decimal monto)
  {
    Console.WriteLine(
        "Validando monto con Banco..."
    );

    return monto > 0;
  }

  protected override void Aplicar(decimal monto)
  {
    Console.WriteLine(
        $"Procesando pago bancario por ${monto}"
    );
  }

  protected override bool NotificarUsuario()
  {
    Console.WriteLine(
        "Se notificó al usuario por email."
    );

    return true;
  }
}

// ======================================================
// CONCRETE CLASS
// ======================================================
// Implementa los pasos específicos para pagos
// realizados mediante MercadoPago.
//
// Observá que el algoritmo sigue siendo exactamente
// el mismo definido por ProcesarPago().
//
// Sólo cambia la implementación de los pasos.
//
// ======================================================

public class ProcesadorPagoMercadoPago : ProcesadorPago
{
  protected override bool ValidarMonto(decimal monto)
  {
    Console.WriteLine(
        "Validando monto con MercadoPago..."
    );

    return monto > 0;
  }

  protected override void Aplicar(decimal monto)
  {
    Console.WriteLine(
        $"Procesando pago por MercadoPago de ${monto}"
    );
  }

  protected override bool NotificarUsuario()
  {
    Console.WriteLine(
        "Se notificó al usuario mediante la aplicación."
    );

    return true;
  }
}

// ======================================================
// CLIENTE
// ======================================================
// Utiliza la abstracción ProcesadorPago.
//
// No necesita conocer los detalles de cada forma
// de pago.
//
// Trabaja contra la clase abstracta.
//
// ======================================================

public class BilleteraVirtual
{
  private readonly ProcesadorPago procesador;

  public BilleteraVirtual(ProcesadorPago procesador)
  {
    this.procesador = procesador;
  }

  public void Pagar(decimal monto)
  {
    procesador.ProcesarPago(monto);
  }
}

// ======================================================
// DEMOSTRACIÓN
// ======================================================
//
// Mismo algoritmo.
// Distintas implementaciones.
//
// Gracias al polimorfismo:
//
// ProcesadorPago procesador;
//
// puede apuntar a:
//
// - ProcesadorPagoBanco
// - ProcesadorPagoMercadoPago
//
// ======================================================

class EjemploClase
{
  static void Main()
  {
    Console.WriteLine("===== PAGO CON BANCO =====");

    BilleteraVirtual billeteraBanco = new BilleteraVirtual(new ProcesadorPagoBanco());

    billeteraBanco.Pagar(1000);

    Console.WriteLine(); Console.WriteLine("===== PAGO CON MERCADOPAGO =====");

    BilleteraVirtual billeteraMP = new BilleteraVirtual(new ProcesadorPagoMercadoPago());

    billeteraMP.Pagar(500);
  }
}

/*

SALIDA

===== PAGO CON BANCO =====

Validando monto con Banco...
Procesando pago bancario por $1000
Se registró el pago por $1000
Se notificó al usuario por email.

===== PAGO CON MERCADOPAGO =====

Validando monto con MercadoPago...
Procesando pago por MercadoPago de $500
Se registró el pago por $500
Se notificó al usuario mediante la aplicación.

--------------------------------------------------------

ANÁLISIS DEL PATRÓN

Template Method:
    ProcesarPago()

Primitive Operations:
    ValidarMonto()
    Aplicar()
    NotificarUsuario()

Concrete Operation:
    LogPago()

Abstract Class:
    ProcesadorPago

Concrete Classes:
    ProcesadorPagoBanco
    ProcesadorPagoMercadoPago

Cliente:
    BilleteraVirtual

--------------------------------------------------------

IDEA CENTRAL

La clase base controla el algoritmo.

Las clases hijas solamente personalizan
algunos pasos.

NO pueden alterar la secuencia:

1. Validar
2. Aplicar
3. Registrar
4. Notificar

Esto es exactamente lo que busca resolver
el patrón Template Method.

*/