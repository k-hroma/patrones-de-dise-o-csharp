# Patrones de Diseño — Guía Completa y Pedagógica

# Índice

1. [Introducción a los Patrones de Diseño](#1-introducción-a-los-patrones-de-diseño)
2. [¿Qué es un patrón?](#2-qué-es-un-patrón)
3. [¿Qué es un patrón de diseño?](#3-qué-es-un-patrón-de-diseño)
4. [Historia y Gang of Four (GoF)](#4-historia-y-gang-of-four-gof)
5. [Elementos de un patrón de diseño](#5-elementos-de-un-patrón-de-diseño)
6. [Beneficios de utilizar patrones](#6-beneficios-de-utilizar-patrones)
7. [Cómo y cuándo aplicar patrones](#7-cómo-y-cuándo-aplicar-patrones)
8. [Conceptos fundamentales de POO necesarios](#8-conceptos-fundamentales-de-poo-necesarios)
9. [Clasificación de patrones](#9-clasificación-de-patrones)
10. [Patrones Creacionales](#10-patrones-creacionales)
    - Singleton
    - Factory Method
    - Abstract Factory
    - Builder
11. [Patrones Estructurales](#11-patrones-estructurales)
    - Adapter
    - Composite
    - Decorator
    - Facade
12. [Patrones de Comportamiento](#12-patrones-de-comportamiento)
    - Strategy
    - Observer
    - Chain of Responsibility
    - Template Method
13. [Comparaciones importantes entre patrones](#13-comparaciones-importantes-entre-patrones)
14. [Buenas prácticas y errores comunes](#14-buenas-prácticas-y-errores-comunes)
15. [Conclusión](#15-conclusión)

---

# 1. Introducción a los Patrones de Diseño

A lo largo de la historia del desarrollo de software, ciertos problemas comenzaron a repetirse constantemente.  
Los programadores descubrieron que algunas soluciones eran más efectivas, mantenibles y reutilizables que otras.

Los patrones de diseño nacen justamente como una formalización de esas soluciones exitosas.

No son código listo para copiar y pegar.  
Son modelos conceptuales que describen:

- un problema recurrente,
- el contexto donde aparece,
- y una solución general reutilizable.

Los patrones ayudan a:

- escribir código más flexible,
- reducir acoplamiento,
- mejorar mantenimiento,
- facilitar escalabilidad,
- mejorar la comunicación entre desarrolladores.

---

# 2. ¿Qué es un patrón?

Christopher Alexander, arquitecto y urbanista, definía un patrón como:

> “Cada patrón describe un problema que ocurre una y otra vez en nuestro entorno y describe también el núcleo de la solución al problema.”

La idea principal es:

- los problemas se repiten,
- por lo tanto las soluciones también pueden reutilizarse.

---

# 3. ¿Qué es un patrón de diseño?

Un patrón de diseño es:

> “Una descripción de clases y objetos comunicándose entre sí adaptada para resolver un problema de diseño general en un contexto particular.”

## Idea clave

Un patrón:

- NO es una implementación concreta,
- NO es una librería,
- NO es una función mágica.

Es una guía estructural.

---

# 4. Historia y Gang of Four (GoF)

En 1994, Erich Gamma, Richard Helm, Ralph Johnson y John Vlissides publicaron:

> Design Patterns: Elements of Reusable Object-Oriented Software

Son conocidos como:

# Gang of Four (GoF)

Este libro formalizó 23 patrones fundamentales.

Aunque hoy existen muchos más, estos 23 siguen siendo la base del aprendizaje.

---

# 5. Elementos de un patrón de diseño

Todo patrón posee cuatro elementos principales.

## 5.1 Nombre

Permite generar vocabulario común.

Ejemplo:

En vez de explicar durante 20 minutos una estructura de algoritmos intercambiables, se dice:

> “Usamos Strategy”

Y todos entienden la idea.

---

## 5.2 Problema

Describe:

- cuándo usar el patrón,
- qué problema resuelve,
- qué contexto debe existir.

---

## 5.3 Solución

Describe:

- clases involucradas,
- relaciones,
- responsabilidades,
- colaboración entre objetos.

Importante:

La solución es abstracta y debe adaptarse al dominio.

---

## 5.4 Consecuencias

Todo patrón tiene ventajas y costos.

Las consecuencias incluyen:

- flexibilidad,
- complejidad,
- rendimiento,
- extensibilidad,
- mantenibilidad.

---

# 6. Beneficios de utilizar patrones

## Reutilización de soluciones

Evita reinventar la rueda.

---

## Comunicación más rápida

Decir:

- Singleton,
- Strategy,
- Observer,

ya transmite muchísima información técnica.

---

## Diseños más flexibles

Los patrones ayudan a:

- desacoplar componentes,
- encapsular cambios,
- facilitar extensiones futuras.

---

## Mejor mantenimiento

El código queda:

- más organizado,
- más predecible,
- más modular.

---

## Punto importante

Los patrones NO deben usarse por moda.

Usar patrones innecesarios puede:

- sobrecomplicar el sistema,
- aumentar cantidad de clases,
- volver el código difícil de entender.

---

# 7. Cómo y cuándo aplicar patrones

## En análisis

Generalmente todavía no se usan porque aún se está entendiendo el dominio.

---

## En diseño

Es la etapa ideal.

Acá se detecta:

- qué puede variar,
- qué puede cambiar,
- qué debe permanecer estable.

---

## En desarrollo

Puede descubrirse la necesidad de introducir un patrón no previsto.

---

# 8. Conceptos fundamentales de POO necesarios

# Clase abstracta

No puede instanciarse directamente.

Sirve como base común.

```csharp
abstract class Animal
{
    public abstract void Hablar();
}
```

---

# Herencia

Permite extender funcionalidades.

```csharp
class Perro : Animal
{
    public override void Hablar()
    {
        Console.WriteLine("Guau");
    }
}
```

---

# Interfaz

Define contratos.

```csharp
interface INotificacion
{
    void Enviar();
}
```

---

# Polimorfismo

Permite tratar objetos distintos de manera uniforme.

```csharp
Animal a = new Perro();
a.Hablar();
```

---

# Sobrecarga

Mismo nombre, distinta firma.

```csharp
void Mostrar(int x)
void Mostrar(string texto)
```

---

# 9. Clasificación de patrones

# 9.1 Creacionales

Resuelven problemas de creación de objetos.

Ejemplo:

- Singleton
- Factory
- Builder

---

# 9.2 Estructurales

Organizan relaciones entre clases y objetos.

Ejemplo:

- Composite
- Decorator
- Facade
- Adapter

---

# 9.3 De comportamiento

Manejan comunicación y responsabilidades.

Ejemplo:

- Strategy
- Observer
- Template Method

---

# 10. Patrones Creacionales

# 10.1 Singleton

## Intención

Garantizar que exista una única instancia de una clase -> y ofrece acceso global a esa instancia.

---

## Problema que resuelve

Cuando múltiples instancias serían incorrectas.

Ejemplo:

- configuración del sistema,
- logger,
- conexión compartida,
- balanceador.

---

## Implementación básica

```csharp
public class Configuracion
{
    // referencia a la única instancia que existirá de la clase
    // al ser static pertenece a las clase y no a los objetos
    private static Configuracion instancia;

    // Propiedades de configuración global.
    public string NombreAplicacion { get; set; }
    public int MaximoUsuarios { get; set; }
    public bool ModoDebug { get; set; }


    // constructor privado
    private Configuracion() {
        // inicializar propiedades de configuración
    }

    // método para obtener instancia
    public static Configuracion ObtenerInstancia()
    {
        if(instancia == null)
        {
            instancia = new Configuracion();
        }

        return instancia;
    }
}
```

## Implementación real

```csharp
public class Configuracion
{
    // Referencia a la única instancia que existirá de la clase.
    // Al ser static pertenece a la clase y no a los objetos.
    // Una única referencia estática (instancia) → hay un único lugar donde se guarda la instancia.
    // Si no fuera static: cada objeto Configuracion tendría su propia variable instancia
    private static Configuracion instancia;

    // Constructor privado -> solo puede ser invocado desde dentro de la propia clase
    // Impide que alguien haga:
    // Configuracion config = new Configuracion();
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
    // La lógica del método → sólo crea el objeto cuando instancia es null.
    // es static para que pueda llamarse así: Configuracion.ObtenerInstancia()---> sin necesidad de crear previamente un objeto, algo fundamental porque el constructor es privado.
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

// ambas llamadas consultan la misma variable estática instancia.
Configuracion config1 = Configuracion.ObtenerInstancia();
Configuracion config2 = Configuracion.ObtenerInstancia();
```

---

## Características importantes

- Constructor privado.
- Instancia estática.
- Método global de acceso.

---

## Ventajas

- Una sola instancia.
- Control centralizado.
- Evita variables globales dispersas.

---

## Desventajas

- Puede ocultar mal diseño.
- Rompe responsabilidad única.
- Puede dificultar testing.
- Problemas en multithreading si no se protege correctamente.

---

## Cuándo usarlo

Cuando realmente tenga sentido que exista una sola instancia.

NO debe usarse como reemplazo universal de variables globales.

---

# 10.2 Factory Method

## Idea principal

Delegar creación de objetos a subclases.

---

## Problema

El código no debería depender directamente de clases concretas.

---

## Estructura

- Product
- ConcreteProduct
- Creator
- ConcreteCreator

---

## Ejemplo conceptual

```csharp
interface IVehiculo
{
    void Conducir();
}

class Auto : IVehiculo
{
    public void Conducir()
    {
        Console.WriteLine("Conduciendo auto");
    }
}

abstract class Fabrica
{
    public abstract IVehiculo CrearVehiculo();
}

class FabricaAuto : Fabrica
{
    public override IVehiculo CrearVehiculo()
    {
        return new Auto();
    }
}
```

---

## Ventajas

- Reduce acoplamiento.
- Facilita extensión.
- Cumple Open/Closed.

---

## Desventajas

- Muchas clases.
- Más complejidad estructural.

---

# 10.3 Abstract Factory

## Índice

- [Intención](#intención)
- [Problema que resuelve](#problema-que-resuelve)
- [Idea principal](#idea-principal)
- [Estructura del patrón](#estructura-del-patrón)
- [Ejemplo cotidiano](#ejemplo-cotidiano)
- [Implementación paso a paso](#implementación-paso-a-paso)
  - [Productos abstractos](#1-productos-abstractos)
  - [Productos concretos](#2-productos-concretos)
  - [Fábrica abstracta](#3-fábrica-abstracta)
  - [Fábricas concretas](#4-fábricas-concretas)
  - [Cliente](#5-cliente)
- [Implementación completa](#implementación-completa)
- [Explicación detallada del flujo](#explicación-detallada-del-flujo)
- [Características importantes](#características-importantes)
- [Ventajas](#ventajas)
- [Desventajas](#desventajas)
- [Diferencia con Factory Method](#diferencia-con-factory-method)
- [Cuándo usarlo](#cuándo-usarlo)
- [Cuándo NO usarlo](#cuándo-no-usarlo)
- [Resumen conceptual](#resumen-conceptual)

---

# Intención

Garantizar la creación de **familias de objetos relacionados** sin que el cliente conozca las clases concretas que se están utilizando.

En lugar de crear objetos con `new`, el cliente delega la creación a una fábrica.

---

# Problema que resuelve

Supongamos una aplicación con distintos temas visuales:

- Tema Claro
- Tema Oscuro

Cada tema necesita:

- Botón
- Ventana
- Menú

No queremos mezclar componentes:

❌ Botón Oscuro + Ventana Clara

Necesitamos una forma de garantizar que todos los objetos creados pertenezcan a la misma familia.

---

# Idea principal

En lugar de hacer:

```csharp
Boton boton = new BotonOscuro();
Ventana ventana = new VentanaOscura();
```

hacemos:

```csharp
IFabricaGUI fabrica = new FabricaOscura();

IBoton boton = fabrica.CrearBoton();
IVentana ventana = fabrica.CrearVentana();
```

La aplicación no sabe qué clases concretas está utilizando.

Trabaja únicamente con interfaces.

---

# Estructura del patrón

## Productos Abstractos

Definen las operaciones disponibles.

```csharp
IBoton
IVentana
```

## Productos Concretos

Implementaciones reales.

```csharp
BotonClaro
BotonOscuro

VentanaClara
VentanaOscura
```

## Fábrica Abstracta

Declara qué productos puede crear.

```csharp
IFabricaGUI
```

## Fábricas Concretas

Implementan la creación de una familia específica.

```csharp
FabricaClara
FabricaOscura
```

## Cliente

Utiliza únicamente interfaces.

---

# Ejemplo cotidiano

Imaginemos una fábrica de muebles.

Familia Moderna:

- Silla Moderna
- Mesa Moderna

Familia Clásica:

- Silla Clásica
- Mesa Clásica

La fábrica moderna siempre crea muebles modernos.

La fábrica clásica siempre crea muebles clásicos.

Nunca se mezclan estilos.

## Estructura del Patrón

```csharp
using System;

#region Productos Abstractos

public interface IProductA
{
    string OperacionA();
}

public interface IProductB
{
    string OperacionB();
}

#endregion

#region Productos Concretos Familia 1

public class ConcreteProductA1 : IProductA
{
    public string OperacionA()
    {
        return "Producto A1";
    }
}

public class ConcreteProductB1 : IProductB
{
    public string OperacionB()
    {
        return "Producto B1";
    }
}

#endregion

#region Productos Concretos Familia 2

public class ConcreteProductA2 : IProductA
{
    public string OperacionA()
    {
        return "Producto A2";
    }
}

public class ConcreteProductB2 : IProductB
{
    public string OperacionB()
    {
        return "Producto B2";
    }
}

#endregion

#region Abstract Factory

public interface IAbstractFactory
{
    IProductA CreateProductA();
    IProductB CreateProductB();
}

#endregion

#region Concrete Factory 1

public class ConcreteFactory1 : IAbstractFactory
{
    public IProductA CreateProductA()
    {
        return new ConcreteProductA1();
    }

    public IProductB CreateProductB()
    {
        return new ConcreteProductB1();
    }
}

#endregion

#region Concrete Factory 2

public class ConcreteFactory2 : IAbstractFactory
{
    public IProductA CreateProductA()
    {
        return new ConcreteProductA2();
    }

    public IProductB CreateProductB()
    {
        return new ConcreteProductB2();
    }
}

#endregion

#region Client

public class Client
{
    private readonly IProductA productA;
    private readonly IProductB productB;

    public Client(IAbstractFactory factory)
    {
        productA = factory.CreateProductA();
        productB = factory.CreateProductB();
    }

    public void SomeOperation()
    {
        Console.WriteLine(productA.OperacionA());
        Console.WriteLine(productB.OperacionB());
    }
}

#endregion

class Program
{
    static void Main()
    {
        Console.WriteLine("Familia 1");

        IAbstractFactory factory1 = new ConcreteFactory1();
        Client client1 = new Client(factory1);

        client1.SomeOperation();

        Console.WriteLine();

        Console.WriteLine("Familia 2");

        IAbstractFactory factory2 = new ConcreteFactory2();
        Client client2 = new Client(factory2);

        client2.SomeOperation();
    }
}
```

---

# Implementación paso a paso

## 1. Productos abstractos

### Botón

```csharp
public interface IBoton
{
    void Dibujar();
}
```

### Ventana

```csharp
public interface IVentana
{
    void Mostrar();
}
```

---

## 2. Productos concretos

### Tema Claro

```csharp
public class BotonClaro : IBoton
{
    public void Dibujar()
    {
        Console.WriteLine("Botón Claro");
    }
}
```

```csharp
public class VentanaClara : IVentana
{
    public void Mostrar()
    {
        Console.WriteLine("Ventana Clara");
    }
}
```

### Tema Oscuro

```csharp
public class BotonOscuro : IBoton
{
    public void Dibujar()
    {
        Console.WriteLine("Botón Oscuro");
    }
}
```

```csharp
public class VentanaOscura : IVentana
{
    public void Mostrar()
    {
        Console.WriteLine("Ventana Oscura");
    }
}
```

---

## 3. Fábrica abstracta

```csharp
public interface IFabricaGUI
{
    IBoton CrearBoton();
    IVentana CrearVentana();
}
```

La interfaz obliga a todas las fábricas concretas a producir la misma familia de productos.

---

## 4. Fábricas concretas

### Fábrica Clara

```csharp
public class FabricaClara : IFabricaGUI
{
    public IBoton CrearBoton()
    {
        return new BotonClaro();
    }

    public IVentana CrearVentana()
    {
        return new VentanaClara();
    }
}
```

### Fábrica Oscura

```csharp
public class FabricaOscura : IFabricaGUI
{
    public IBoton CrearBoton()
    {
        return new BotonOscuro();
    }

    public IVentana CrearVentana()
    {
        return new VentanaOscura();
    }
}
```

---

## 5. Cliente

```csharp
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
```

La aplicación nunca utiliza:

```csharp
new BotonClaro();
new BotonOscuro();
new VentanaClara();
new VentanaOscura();
```

Solo conoce:

```csharp
IBoton
IVentana
IFabricaGUI
```

---

# Implementación completa

```csharp
using System;

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
        IFabricaGUI fabrica = new FabricaOscura();

        Aplicacion app = new Aplicacion(fabrica);

        app.Ejecutar();
    }
}
```

---

# Explicación detallada del flujo

### Paso 1

Elegimos una fábrica.

```csharp
IFabricaGUI fabrica = new FabricaOscura();
```

### Paso 2

La aplicación recibe la fábrica.

```csharp
Aplicacion app = new Aplicacion(fabrica);
```

### Paso 3

La aplicación solicita productos.

```csharp
fabrica.CrearBoton();
fabrica.CrearVentana();
```

### Paso 4

La fábrica decide qué objetos crear.

```text
BotonOscuro
VentanaOscura
```

### Paso 5

La aplicación utiliza los objetos sin conocer sus clases concretas.

```csharp
boton.Dibujar();
ventana.Mostrar();
```

---

# Características importantes

## Familias de objetos

Crea grupos completos de objetos relacionados.

## Bajo acoplamiento

El cliente depende de interfaces.

## Consistencia

Evita combinar objetos incompatibles.

## Fácil intercambio

Permite cambiar familias completas reemplazando una única fábrica.

---

# Ventajas

- Reduce el acoplamiento.
- Garantiza compatibilidad entre productos.
- Principio de responsabilidad única: el código de creación de un producto puede moverse a un lugar del programa. codigo más fácil de mantener.
- Encapsula la creación de objetos.
- Facilita el mantenimiento.
- Principio Open/Close: se pueden incorporar nuevos tipos de productos en el programa sin descomponer el código.
- Permite intercambiar familias completas fácilmente.

---

# Desventajas

- Incrementa la cantidad de clases.
- Agrega complejidad.
- Agregar nuevos productos requiere modificar todas las fábricas.

Ejemplo:

Si agregamos:

```csharp
ICheckbox
```

debemos modificar:

```csharp
IFabricaGUI
FabricaClara
FabricaOscura
```

y todas las fábricas existentes.

---

# Diferencia con Factory Method

## Factory Method

Crea un único tipo de producto.

```csharp
Vehiculo CrearVehiculo();
```

## Abstract Factory

Crea familias completas de productos relacionados.

```csharp
CrearBoton();
CrearVentana();
CrearMenu();
CrearCheckbox();
```

### Resumen

Factory Method:

```text
1 fábrica
1 producto
```

Abstract Factory:

```text
1 fábrica
muchos productos relacionados
```

---

# Cuándo usarlo

Usalo cuando:

- Existan familias de objetos relacionadas.
- Quieras garantizar compatibilidad.
- Necesites intercambiar implementaciones fácilmente.
- Quieras desacoplar la creación de objetos.

Ejemplos:

- Temas visuales.
- Motores de bases de datos.
- Sistemas operativos.
- Frameworks gráficos.
- Aplicaciones multiplataforma.

---

# Cuándo NO usarlo

No lo uses cuando:

- Solo exista un tipo de producto.
- No haya familias relacionadas.
- La complejidad adicional no aporte beneficios.
- Un Factory Method sea suficiente.

---

# Resumen conceptual

Abstract Factory es un patrón creacional que permite crear familias completas de objetos relacionados sin que el cliente conozca las clases concretas utilizadas.

La aplicación trabaja contra interfaces:

```csharp
IBoton
IVentana
IFabricaGUI
```

y delega la construcción de objetos a fábricas concretas:

```csharp
FabricaClara
FabricaOscura
```

Esto proporciona:

- Bajo acoplamiento.
- Mayor mantenibilidad.
- Consistencia entre productos.
- Facilidad para intercambiar implementaciones.

# 10.4 Builder

## Problema

Constructores gigantes con muchos parámetros.

---

## Idea

Construir objetos paso a paso.

---

## Ejemplo

```csharp
var computadora = new ComputadoraBuilder()
    .AgregarRAM(16)
    .AgregarSSD(512)
    .AgregarGPU("RTX")
    .Build();
```

---

## Ventajas

- Construcción flexible.
- Código más legible.
- Distintas configuraciones.

---

## Desventajas

- Más clases.
- Mayor complejidad general.

---

# 11. Patrones Estructurales

# 11.1 Adapter

## Intención

Permitir que clases incompatibles trabajen juntas.

---

## Analogía

Adaptador de enchufe.

---

## Ejemplo conceptual

Una impresora vieja:

```csharp
void ImprimirViejo()
```

pero el sistema moderno espera:

```csharp
void Imprimir()
```

Adapter traduce llamadas.

---

## Cuándo usarlo

- bibliotecas externas,
- sistemas legacy,
- APIs incompatibles.

---

# 11.2 Composite

## Intención

Representar estructuras árbol parte-todo.

---

## Idea clave

Tratar:

- objetos simples,
- objetos compuestos,

de manera uniforme.

---

## Ejemplo típico

Menús.

Un menú puede contener:

- opciones,
- submenús.

---

## Estructura

- Component
- Leaf
- Composite

---

## Ejemplo simplificado

```csharp
interface IMenu
{
    void Mostrar();
}
```

Las hojas:

```csharp
class Opcion : IMenu
```

Los compuestos:

```csharp
class Submenu : IMenu
```

---

## Ventajas

- Simplifica cliente.
- Facilita estructuras jerárquicas.
- Uniformidad.

---

## Desventajas

- Puede volver el diseño demasiado general.
- Algunas hojas implementan métodos inútiles.

---

## Concepto importante

Composite usa composición recursiva.

Un Composite contiene Components,
que pueden ser:

- Leaf,
- Composite.

---

# 11.3 Decorator

## Intención

Agregar responsabilidades dinámicamente.

---

## Problema

Extender comportamiento sin modificar clases existentes.

---

## Analogía

Un café:

- café base,
- agregar crema,
- agregar azúcar,
- agregar leche.

Cada agregado “decora” al anterior.

---

## Ejemplo conceptual

```csharp
interface IBebida
{
    double Costo();
}
```

---

## Decorador

```csharp
class Azucar : IBebida
{
    private IBebida bebida;

    public Azucar(IBebida bebida)
    {
        this.bebida = bebida;
    }

    public double Costo()
    {
        return bebida.Costo() + 1;
    }
}
```

---

## Ventajas

- Más flexible que herencia.
- Responsabilidades dinámicas.
- Evita clases monstruosas.

---

## Desventajas

- Muchos objetos pequeños.
- Más difícil de seguir mentalmente.

---

## Diferencia con Composite

Decorator:

- agrega comportamiento.

Composite:

- organiza jerarquías.

---

# 11.4 Facade

## Intención

Ocultar complejidad detrás de una interfaz simple.

---

## Ejemplo

Encender cine en casa:

Sin Facade:

- prender TV,
- prender parlantes,
- configurar HDMI,
- iniciar reproductor.

Con Facade:

```csharp
cine.VerPelicula();
```

---

## Ventajas

- Simplifica uso.
- Reduce acoplamiento.
- Oculta complejidad.

---

## Desventajas

- Puede convertirse en “objeto dios”.

---

# 12. Patrones de Comportamiento

# 12.1 Strategy

## Intención

Permitir intercambiar algoritmos dinámicamente.

---

## Problema

Muchos comportamientos similares.

---

## Ejemplo

Distintos algoritmos de ordenamiento:

- QuickSort
- BubbleSort
- MergeSort

---

## Estructura

- Strategy
- ConcreteStrategy
- Context

---

## Ejemplo

```csharp
interface IDescuento
{
    double Aplicar(double total);
}
```

---

## Estrategias

```csharp
class DescuentoNavidad : IDescuento
```

```csharp
class DescuentoBlackFriday : IDescuento
```

---

## Context

```csharp
class Carrito
{
    private IDescuento descuento;
}
```

---

## Ventajas

- Evita if/switch gigantes.
- Algoritmos intercambiables.
- Polimorfismo limpio.

---

## Desventajas

- Más objetos.
- Cliente debe conocer estrategias.

---

## Diferencia importante

Strategy usa:

# composición sobre herencia

---

# 12.2 Observer

## Intención

Dependencia uno-a-muchos.

Cuando un objeto cambia,
notifica a los demás.

---

## Ejemplo típico

Sistema de notificaciones.

---

## Estructura

- Subject
- Observer
- ConcreteSubject
- ConcreteObserver

---

## Flujo

1. Observadores se suscriben.
2. Subject cambia estado.
3. Subject notifica.
4. Observadores reaccionan.

---

## Ejemplo conceptual

```csharp
interface IObserver
{
    void Actualizar();
}
```

---

## Subject

```csharp
class CanalYoutube
{
    private List<IObserver> suscriptores;
}
```

---

## Ventajas

- Bajo acoplamiento.
- Comunicación automática.
- Muy extensible.

---

## Desventajas

- Difícil rastrear notificaciones.
- Riesgo de cascadas complejas.

---

## Uso moderno

Muy utilizado en:

- eventos,
- interfaces gráficas,
- Reactividad,
- arquitecturas pub/sub.

---

# 12.3 Chain of Responsibility

## Intención

Pasar solicitudes por una cadena de objetos.

Cada objeto decide:

- manejarla,
- o pasarla al siguiente.

---

## Ejemplo

Soporte técnico:

- nivel 1,
- nivel 2,
- supervisor.

---

## Ventajas

- Desacopla emisor y receptor.
- Flexible.
- Fácil agregar nuevos handlers.

---

## Desventajas

- Difícil depuración.
- Solicitud puede no ser manejada.

---

# 12.4 Template Method

## Intención

Definir estructura fija de algoritmo,
permitiendo redefinir ciertos pasos.

---

## Idea principal

La estructura general NO cambia.

Algunos pasos sí.

---

## Ejemplo

Proceso de exportación:

1. abrir archivo,
2. procesar datos,
3. escribir resultado,
4. cerrar archivo.

Cada formato redefine:

- cómo escribir.

---

## Estructura

- AbstractClass
- ConcreteClass

---

## Ejemplo conceptual

```csharp
abstract class Exportador
{
    public void Exportar()
    {
        Abrir();
        Procesar();
        Guardar();
    }

    protected abstract void Procesar();
}
```

---

## Hook Methods

Métodos opcionales redefinibles.

Pueden no hacer nada por defecto.

---

## Ventajas

- Reutilización.
- Evita duplicación.
- Controla estructura.

---

## Desventajas

- Dependencia fuerte por herencia.
- Puede rigidizar diseño.

---

# 13. Comparaciones importantes entre patrones

# Strategy vs Template Method

## Strategy

- composición,
- comportamiento intercambiable en runtime.

## Template Method

- herencia,
- estructura fija.

---

# Composite vs Decorator

## Composite

Organiza árboles jerárquicos.

## Decorator

Agrega funcionalidades dinámicas.

---

# Factory Method vs Abstract Factory

## Factory Method

Crea un producto.

## Abstract Factory

Crea familias completas.

---

# 14. Buenas prácticas y errores comunes

# Buenas prácticas

## Pensar en interfaces

Programar contra abstracciones.

---

## Usar composición sobre herencia

La composición suele ser más flexible.

---

## Encapsular cambios

Gamma recomienda encapsular lo variable.

---

# Errores comunes

## Usar patrones innecesariamente

No todo necesita un patrón.

---

## Sobreingeniería

Demasiadas capas pueden empeorar el diseño.

---

## Copiar sin entender

El patrón debe resolver un problema real.

---

# 15. Conclusión

Los patrones de diseño representan experiencia acumulada de décadas de desarrollo.

No son recetas mágicas,
pero sí herramientas extremadamente poderosas.

Entenderlos permite:

- escribir mejor software,
- razonar arquitecturas,
- comunicar ideas,
- diseñar sistemas escalables.

La clave no es memorizar diagramas.

La clave es:

# comprender qué problema resuelve cada patrón

# y cuándo realmente conviene usarlo.
