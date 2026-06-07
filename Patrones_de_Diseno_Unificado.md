# Patrones de Diseño

## Índice

- [Introducción](#introducción)
- [Elementos más relevantes](#elementos-más-relevantes)
  - [Nombre](#nombre)
  - [Problema](#problema)
  - [Solución](#solución)
  - [Consecuencias](#consecuencias)
- [Beneficios de utilizar patrones de diseño](#beneficios-de-utilizar-patrones-de-diseño-y-por-qué-utilizarlos)
- [En qué etapas aplicarlos](#en-qué-etapas-aplicarlos)
- [Tipos](#tipos)
- [Patrones Creacionales](#patrones-creacionales)
  - [Singleton](#singleton)
  - [Factory Method](#factory-method)
  - [Abstract Factory](#abstract-factory)
- [Patrones de Comportamiento](#patrones-de-comportamiento)
  - [Strategy](#strategy)
  - [Template Method](#template-method)
- [Patrones Estructurales](#patrones-estructurales)
  - [Composite](#composite)
  - [Decorator](#decorator)

---

## Introducción

> "Es una regla que expresa la relación entre un contexto, un problema y una solución."

> "Es una descripción de clases y objetos comunicándose entre sí adaptada para resolver un problema de diseño general en un contexto particular."

> Para evitar que los profesionales implementen estrategias que quizá no sean las mejores en términos de mantenibilidad, lectura y escalabilidad, el conocido grupo "Gang of Four" ha estado estudiando los problemas con mayor recurrencia y el modo en el que los desarrolladores supieron abordarlos, identificando los patrones de arquitectura que ofrecen mejores beneficios en relación con su implementación.

> Surgen como las propuestas más naturales para enfrentar un desafío, siempre y cuando el arquitecto se ciña a las buenas prácticas de la programación orientada a objetos.

---

## Elementos más relevantes

### Nombre

> Nos permite tener un vocabulario en común con otros. Simplifica la comunicación.

> Permite tener un nivel de abstracción más amplio. Con sólo un nombre podemos asociar un problema, solución y consecuencias.

> Resumiendo: Con sólo mencionar el nombre de un patrón podremos transmitir un cuerpo de conocimiento amplio y abstracto qué llevaría mucho más tiempo de explicar en detalle cada vez que se lo necesita.

### Problema

> Nos indicará cuándo utilizar un patrón.

> Nos brinda el contexto del problema a solucionar.

> Puede incluir precondiciones, estructuras, algoritmos, etc. que son comunes en el problema a resolver.

### Solución

> Describe los elementos que utiliza el diseño, sus relaciones, responsabilidades y colaboraciones.

> No es una implementación en particular, sino un template genérico.

> La abstracción representada debe adaptarse a nuestro dominio.

### Consecuencias

> Describe los resultados de aplicar un patrón de diseño.

> Como todo lo que hacemos en el diseño el impacto estará en la flexibilidad, extensibilidad y portabilidad.

---

## Beneficios de utilizar patrones de diseño y por qué utilizarlos

> Son una buena formalización de diseños probados y útiles en infinidad de ocasiones.

> Porque abre la mente, nos da la capacidad de explorar mejoras a nivel de diseño.

> Porque al adaptarnos al vocabulario de la comunidad ganamos tiempo.

> Nos obliga a ir adelante y atrás en el diseño y no pensar exclusivamente en una solución de compromiso para hoy.

> Esto no sólo produce diseños más elegantes, sino que así también aprendo a equilibrar hasta cuándo dejo la puerta abierta para cambios y hasta cuándo cierro una solución para poder implementarla.

> Es una forma de documentación que fomenta la reutilización de nuestros diseños y nos permite compartirlos de forma mas sencilla y formal.

---

## En qué etapas aplicarlos

> **Análisis:** NO. En esta etapa se estudia el dominio.

> **Diseño:** No tenemos conocimiento completo pero se puede identificar qué es lo que puede cambiar en el sistema.

> **Desarrollo:** Si al desarrollar detectamos algún patrón no diseñado, entonces debemos actualizar el diseño.

---

## Tipos

### Creacionales: estrategias para la creación de objetos.

> Estos patrones son herramientas que facilitan la creación de las entidades, encapsulando el proceso de construcción; de este modo, si se necesitara cambiar la estructura de un objeto, sus requerimientos o la manera en que estos se componen, las modificaciones se verían muy acotadas.

> Abstraen el proceso de instanciación.

### Comportamiento: focaliza sobre la comunicación entre objetos.

> Se ocupan de la asignación de responsabilidades entre objetos y como se comunican entre sí.

> Se centran en la resolución de problemas relacionados con el comportamiento de una aplicación en tiempo de ejecución.

### Estructurales: aborda la relación entre los objetos.

> Define estructuras de clases y objetos.

---

## Patrones Creacionales

---

## Singleton

### Intención

> Singleton es un patrón de diseño creacional que garantiza que una clase tenga una única instancia y proporciona un punto global de acceso a ella.
>
> Su objetivo principal es controlar la creación de un recurso compartido dentro de la aplicación.

### Aplicabilidad

Utilizar Singleton cuando:

- Debe existir una única instancia de una clase durante toda la ejecución de la aplicación.
- Varias partes del sistema necesitan acceder al mismo recurso compartido.
- Se requiere centralizar la administración de un recurso o servicio global.
- Es necesario controlar estrictamente la creación de instancias de una clase.

Ejemplo de uso:
- Configuración global de una aplicación.
- Sistema de logging.
- Caché compartida.
- Administrador de conexiones.
- Acceso controlado a recursos compartidos.

### Estructura

1. **Singleton**:
   - Declara un campo estático que almacena la única instancia.
   - Declara un constructor privado para impedir la creación de objetos desde el exterior.
   - Expone un método o propiedad estática para obtener la instancia.

2. **Cliente**:
   - Obtiene la instancia a través del punto de acceso proporcionado por el Singleton.
   - Nunca crea objetos mediante el operador `new`.

### La clave del Singleton es la COMBINACIÓN de:

- Un campo estático que almacena la única instancia compartida por toda la aplicación.
- Un constructor privado que impide crear instancias desde el exterior.
- Un método o propiedad estática que constituye el único punto autorizado para obtener la instancia.

### Ventajas

1. Garantiza que exista una única instancia de la clase.
2. Proporciona un punto de acceso global a dicha instancia.
3. Permite la inicialización diferida (*lazy initialization*), creando la instancia solo cuando es necesaria.
4. Facilita la coordinación y administración de recursos compartidos.
5. Puede evitar la creación innecesaria de objetos costosos.

### Desventajas

1. Puede violar el Principio de Responsabilidad Única (SRP) al encargarse tanto de la lógica de negocio como del control de instancias.
2. Introduce dependencias globales ocultas, dificultando las pruebas unitarias y el mantenimiento.
3. Puede dificultar la aplicación del Principio de Inversión de Dependencias (DIP) cuando las clases acceden directamente al Singleton en lugar de recibir sus dependencias mediante inyección.
4. En aplicaciones multihilo requiere mecanismos de sincronización para evitar la creación de múltiples instancias.
5. Introduce estado global compartido, aumentando el acoplamiento entre componentes.

### Idea principal

> Singleton controla la creación de objetos para garantizar que exista una única instancia accesible desde cualquier parte de la aplicación.
>
> Su principal ventaja es la gestión centralizada de recursos compartidos; su principal desventaja es la introducción de estado global y acoplamiento entre componentes.

### Ejemplo en C#

```csharp
public class Configuracion
{
  // Propiedades de configuración global.
  public string NombreAplicacion { get; set; }
  public int MaximoUsuarios { get; set; }
  public bool ModoDebug { get; set; }

  // Atributo estático que almacena la única instancia de la clase.
  // Referencia a la única instancia del Singleton.
  private static Configuracion instancia;

  // Constructor privado: garantiza que la instancia solo pueda ser creada por la propia clase.
  private Configuracion()
  {
    NombreAplicacion = "Mi Sistema";
    MaximoUsuarios = 100;
    ModoDebug = false;
  }

  // Método estático que devuelve la única instancia de la clase.
  // Si aún no existe, la crea.
  public static Configuracion ObtenerInstancia()
  {
    // Si todavía no existe una instancia...
    if (instancia == null)
    {
      // ...la creamos.
      instancia = new Configuracion();
    }

    // Devolvemos la instancia única.
    return instancia;
  }

  // Métodos de negocio de la clase.
  // Método de ejemplo para utilizar la configuración.
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
```

---

## Factory Method

### Intención

> Factory Method es un patrón de diseño creacional que define una interfaz para crear objetos, permitiendo que las subclases decidan qué clase concreta instanciar.
>
> Su objetivo principal es desacoplar el código cliente de las clases concretas que necesita utilizar.

### Aplicabilidad

Utilizar Factory Method cuando:

- Una clase no puede anticipar qué tipos concretos de objetos deberá crear.
- Se desea desacoplar la lógica de creación de objetos de la lógica de negocio.
- Se quiere permitir que las subclases determinen qué productos concretos crear.
- Se busca extender el sistema con nuevos productos sin modificar el código existente.

### Estructura

1. **Product (Producto)**: declara la interfaz o abstracción común que deben implementar todos los productos concretos.

2. **Concrete Product (Producto Concreto)**: implementa la interfaz del producto.

3. **Creator (Creador)**:
   - Declara el **Factory Method**.
   - El tipo de retorno del Factory Method debe ser la abstracción del producto.
   - Puede contener lógica de negocio que utilice los productos creados.

4. **Concrete Creator (Creador Concreto)**:
   - Sobrescribe el Factory Method.
   - Decide qué producto concreto instanciar y devolver.

5. **Client (Cliente)**:
   - Trabaja con las abstracciones (`Creator` y `Product`).
   - Solicita la creación de productos a través del Factory Method.
   - No necesita conocer las clases concretas de los productos que utiliza.

### Funcionamiento

La clase creadora trabaja únicamente con la abstracción del producto y delega la creación de los objetos concretos a sus subclases.

De esta manera:

- El creador no depende de clases concretas.
- La creación de objetos queda encapsulada.
- Nuevos productos pueden incorporarse mediante nuevas fábricas concretas.

### Ventajas

1. Reduce el acoplamiento entre el creador y los productos concretos.
2. Centraliza y encapsula la lógica de creación de objetos.
3. Favorece el cumplimiento del Principio de Responsabilidad Única (SRP).
4. Favorece el cumplimiento del Principio Abierto/Cerrado (OCP), permitiendo agregar nuevos productos sin modificar código existente.
5. Favorece el cumplimiento del Principio Dependency Inversion Principle (DIP) ya que la clase creadora depende de una abstracción del producto y no de implementaciones concretas.
6. Permite trabajar mediante abstracciones y aprovechar el polimorfismo.

### Desventajas

1. Puede aumentar la complejidad del diseño al introducir nuevas clases y jerarquías.
2. Para agregar un nuevo producto suele ser necesario crear una nueva clase creadora concreta.
3. En aplicaciones pequeñas puede resultar una solución excesiva para problemas simples.

### Idea principal

> La clase creadora conoce únicamente la abstracción del producto.
>
> Las subclases de la creadora son las responsables de decidir qué producto concreto instanciar mediante la implementación del Factory Method.

### Ejemplo en C#

```csharp
#region PRODUCTOS

// ==========================================================
// PRODUCT (Producto)
// ==========================================================
// Define el contrato común que deben cumplir todos los
// objetos que podrán ser creados por las fábricas.
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

    // Camion.Entregar o Barco.Entregar
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
```

---

## Abstract Factory

### Intención

> Abstract Factory es un patrón de diseño creacional que nos permite producir familias de objetos relacionados sin especificar sus clases concretas.

### Aplicabilidad

Utilizar Abstract Factory cuando:

- El sistema debe trabajar con familias de objetos relacionados o dependientes entre sí.
- Se desea garantizar que los productos utilizados sean compatibles entre sí.
- Se quiere desacoplar el código cliente de las clases concretas que utiliza.
- Se necesita intercambiar familias completas de productos sin modificar el código cliente.
- Se busca centralizar la creación de objetos relacionados en un único punto.
- El sistema debe ser fácilmente extensible para incorporar nuevas familias de productos.

### Estructura

1. **Abstract Product (Producto Abstracto)**:
   - Declara la interfaz o abstracción común para CADA tipo de producto de la familia de productos. Ej: sillón, mesa, sofá, etc.

2. **Abstract Factory (Fábrica Abstracta)**:
   - Declara los métodos para crear cada tipo de producto de una familia.
   - Sus métodos devuelven abstracciones de productos, no implementaciones concretas.

3. **Concrete Factory (Fábrica Concreta)**:
   - Implementa los métodos definidos por la fábrica abstracta.
   - Es responsable de crear una familia específica de productos relacionados y compatibles entre sí.

4. **Concrete Product (Producto Concreto)**:
   - Implementa la interfaz del producto abstracto.
   - Pertenece a una familia específica de productos.

5. **Client (Cliente)**:
   - Trabaja únicamente con las abstracciones de las fábricas y los productos.
   - Utiliza la fábrica para obtener los productos que necesita.
   - No conoce ni depende de las clases concretas de los productos.

### Ventajas

1. Garantiza la compatibilidad entre los productos pertenecientes a una misma familia.
2. Reduce el acoplamiento entre el código cliente y las clases concretas de los productos.
3. Centraliza y encapsula la creación de familias de objetos relacionados.
4. Favorece el cumplimiento del Principio de Responsabilidad Única (SRP), separando la lógica de creación de objetos de la lógica de negocio.
5. Favorece el cumplimiento del Principio Abierto/Cerrado (OCP), permitiendo incorporar nuevas familias de productos sin modificar el código cliente.
6. Favorece el cumplimiento del Principio de Inversión de Dependencias (DIP), ya que el cliente depende de abstracciones y no de implementaciones concretas.
7. Permite intercambiar familias completas de productos de manera transparente para el cliente.

### Desventajas

1. Puede aumentar considerablemente la complejidad del diseño al introducir múltiples interfaces y clases concretas.
2. La incorporación de un nuevo tipo de producto suele requerir modificar la interfaz de la fábrica abstracta y todas sus implementaciones concretas.
3. Puede generar una gran cantidad de clases cuando existen muchas familias y muchos productos.
4. En aplicaciones pequeñas puede resultar una solución excesiva para problemas simples.
5. Si se agregan frecuentemente nuevos tipos de productos, puede verse afectado el Principio Abierto/Cerrado (OCP), ya que será necesario modificar las fábricas existentes.

### Idea principal

> Abstract Factory encapsula la creación de una familia completa de productos relacionados.
> Proporciona una interfaz para crear familias de objetos relacionados o dependientes entre sí sin especificar sus clases concretas.

> El cliente conoce únicamente las abstracciones de la fábrica y de los productos, mientras que las fábricas concretas deciden qué implementaciones específicas crear.
> El cliente trabaja únicamente con abstracciones y puede intercambiar familias completas de productos sin modificar su código.

### Ejemplo en C#

```csharp
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
   - Es responsable de crear una familia específica de productos relacionados y compatibles entre sí. Para cada variante de una familia de productos, creamos una clase de fábrica independiente basada en la interfaz Fábrica Abstracta.
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
```

---

## Patrones de Comportamiento

---

## Strategy

### Intención

> Strategy es un patrón de diseño comportamental que define una familia de algoritmos, encapsula cada uno de ellos y los hace intercambiables.

> Permite modificar el comportamiento de un objeto dinámicamente mediante la sustitución de la estrategia utilizada, sin alterar el código del contexto.

### Aplicabilidad

Utilizar Strategy cuando:

- Muchas clases relacionadas difieren únicamente en su comportamiento.
- Existen múltiples variantes de un mismo algoritmo.
- Se desea seleccionar algoritmos dinámicamente durante la ejecución.
- Una clase contiene múltiples sentencias condicionales (`if`, `switch`, etc.) para elegir distintos comportamientos.
- Se busca desacoplar la lógica de negocio de los algoritmos que utiliza.
- No se desea exponer estructuras de datos complejas o específicas de un algoritmo al cliente.

### Estructura

1. **Strategy (Estrategia)**:
   - Declara una interfaz común para todos los algoritmos soportados.
   - El contexto utiliza esta interfaz para ejecutar el algoritmo seleccionado.

2. **Concrete Strategy (Estrategia Concreta)**:
   - Implementa un algoritmo específico utilizando la interfaz Strategy.
   - Cada estrategia concreta representa una variante distinta del comportamiento.

3. **Context (Contexto)**:
   - Mantiene una referencia a un objeto Strategy.
   - Se configura con una estrategia concreta.
   - Delega la ejecución del algoritmo a la estrategia almacenada.
   - Puede exponer información necesaria para que la estrategia realice su trabajo.

4. **Client (Cliente)**:
   - Selecciona la estrategia adecuada.
   - Configura el contexto con la estrategia elegida.
   - Interactúa únicamente con el contexto.

### Funcionamiento

El contexto no implementa directamente el algoritmo que necesita ejecutar.

En su lugar:

- Mantiene una referencia a una estrategia.
- Delega la ejecución del comportamiento en dicha estrategia.
- Puede cambiar de estrategia durante la ejecución.

De esta manera:

- El algoritmo puede variar independientemente del contexto.
- Se eliminan grandes estructuras condicionales.
- El comportamiento puede modificarse dinámicamente.

### Colaboración entre Context y Strategy

- El contexto delega la ejecución del algoritmo a la estrategia.
- El contexto puede pasar a la estrategia únicamente los datos necesarios para ejecutar el algoritmo.
- Alternativamente, puede pasarse a sí mismo como parámetro para que la estrategia obtenga la información que necesite.
- Los clientes suelen configurar una estrategia al crear el contexto y posteriormente interactúan únicamente con el contexto.

### Ventajas

1. Permite intercambiar algoritmos dinámicamente durante la ejecución.
2. Reduce el acoplamiento entre el contexto y los algoritmos concretos.
3. Elimina grandes estructuras condicionales (`if`, `switch`, etc.) utilizadas para seleccionar comportamientos.
4. Facilita la incorporación de nuevos algoritmos sin modificar el contexto.
5. Favorece el cumplimiento del Principio Abierto/Cerrado (OCP), permitiendo agregar nuevas estrategias sin modificar código existente.
6. Favorece el cumplimiento del Principio de Responsabilidad Única (SRP), separando la lógica de negocio de la implementación de los algoritmos.
7. Favorece el cumplimiento del Principio de Inversión de Dependencias (DIP), ya que el contexto depende de una abstracción (`Strategy`) y no de implementaciones concretas.
8. Permite reutilizar algoritmos en distintos contextos.
9. Facilita las pruebas unitarias al poder sustituir estrategias fácilmente.

### Desventajas

1. Aumenta la cantidad de clases y objetos del sistema.
2. El cliente debe conocer las distintas estrategias disponibles para poder seleccionar una adecuada.
3. Puede resultar excesivo para algoritmos simples o que rara vez cambian.
4. Existe una sobrecarga adicional en la comunicación entre el contexto y las estrategias.
5. Algunas estrategias pueden recibir más información de la necesaria debido a la interfaz común compartida.
6. Una mala definición de la interfaz Strategy puede dificultar la incorporación de nuevas estrategias.
7. Si el cliente debe conocer demasiados detalles de las estrategias disponibles, puede aumentar el acoplamiento entre cliente y estrategias concretas.

### Relación con SOLID

#### Single Responsibility Principle (SRP)

Cada estrategia encapsula un único algoritmo o comportamiento específico, separándolo de la lógica del contexto.

#### Open/Closed Principle (OCP)

Es uno de los patrones que mejor ejemplifica este principio, ya que permite agregar nuevas estrategias sin modificar el contexto existente.

#### Dependency Inversion Principle (DIP)

El contexto depende de la abstracción `Strategy` y no de implementaciones concretas.

#### Liskov Substitution Principle (LSP)

Cualquier estrategia concreta debe poder sustituir a otra estrategia sin alterar el comportamiento esperado del contexto.

#### Interface Segregation Principle (ISP)

Conviene que la interfaz `Strategy` contenga únicamente las operaciones necesarias para todos los algoritmos; interfaces demasiado grandes pueden obligar a algunas estrategias a implementar métodos que no necesitan.

### Idea principal

> El contexto delega un comportamiento variable a un objeto Strategy.

> Distintas estrategias implementan distintas variantes del algoritmo y pueden intercambiarse dinámicamente sin modificar el contexto.

> En lugar de heredar para cambiar comportamientos, Strategy favorece la composición y el polimorfismo.

### Ejemplo en C#

```csharp
using System;

// ======================================================
// STRATEGY
// ======================================================
// Define el contrato que deben cumplir todos los
// algoritmos (de pago en este ejemplo)
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
// Implementa un algoritmo específico utilizando la interfaz Strategy.
// Cada estrategia concreta (de pago en este ejemplo) representa una variante del comportamiento.
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
// NO sabe cómo se realiza el pago. No conoce detalles de implementación.
// Sólo sabe que existe una estrategia capaz de ejecutar:
//  Pagar(monto)
// Gracias a esto puede trabajar con cualquier implementación y cambiar de estrategia en tiempo de ejecución.
//
// ======================================================

public class CarritoCompras
{
  // Mantiene una referencia a un objeto Strategy.
  private IEstrategiaPago estrategiaPago;

  // Se configura con una estrategia concreta -> la selecciona el cliente.
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

  // Delega la ejecución del algoritmo a la estrategia almacenada.
  public void FinalizarCompra(decimal monto)
  {
    Console.WriteLine("Procesando compra...");

    estrategiaPago.Pagar(monto);
  }
}

/**
 Client (Cliente):
   - Selecciona la estrategia adecuada.
   - Configura el contexto con la estrategia elegida.
   - Interactúa únicamente con el contexto.
*/
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
IMPORTANTE
Lo importante del patrón no es que exista una única interfaz llamada Strategy, sino que:

1. Existe un comportamiento variable.
2. Ese comportamiento se encapsula detrás de una abstracción.
3. El contexto delega la ejecución a esa abstracción.
4. Las implementaciones pueden intercambiarse.
*/
```

---

## Template Method

### Intención

> Template Method es un patrón de diseño comportamental que define el esqueleto de un algoritmo en una operación, permitiendo que las subclases redefinan ciertos pasos sin modificar la estructura general del algoritmo.

> Su objetivo principal es reutilizar la parte común de un algoritmo y delegar en las subclases únicamente aquellos pasos que pueden variar.

### Aplicabilidad

Utilizar Template Method cuando:

- Varias clases comparten la misma estructura general de un algoritmo, pero difieren en algunos pasos específicos.
- Se desea evitar la duplicación de código entre clases relacionadas.
- Existen pasos invariantes que deben ejecutarse siempre en el mismo orden.
- Se busca controlar los puntos de extensión permitiendo que las subclases personalicen únicamente determinadas partes del algoritmo.
- Se desea centralizar el comportamiento común en una clase base.

### Estructura

1. **Abstract Class (Clase Abstracta)**:
   - Define el **Template Method**.
   - Implementa el esqueleto general del algoritmo.
   - Define operaciones concretas comunes a todas las subclases.
   - Declara operaciones primitivas abstractas que deberán implementar las subclases.
   - Puede definir operaciones Hook opcionales para que las subclases las sobrescriban si lo necesitan.

2. **Concrete Class (Clase Concreta)**:
   - Implementa las operaciones primitivas abstractas.
   - Proporciona el comportamiento específico de los pasos variables del algoritmo.
   - Puede sobrescribir operaciones Hook para personalizar determinados puntos de extensión.

3. **Client (Cliente)**:
   - Trabaja con la abstracción.
   - Invoca el Template Method.
   - No necesita conocer los detalles de implementación de cada paso del algoritmo.

### Funcionamiento

La clase abstracta define el flujo completo del algoritmo mediante un Template Method.

Durante la ejecución:

- Los pasos comunes son ejecutados por la clase base.
- Los pasos variables son delegados a las subclases.
- La estructura general del algoritmo permanece inalterable.

De esta manera:

- Se reutiliza código común.
- Se evita la duplicación de lógica.
- Se controla exactamente qué partes pueden modificarse.

### Colaboración entre Abstract Class y Concrete Class

- La clase abstracta controla la secuencia de ejecución del algoritmo.
- Las subclases implementan únicamente los pasos variables.
- El Template Method invoca operaciones concretas, operaciones abstractas y operaciones Hook.
- Las subclases no modifican la estructura del algoritmo, únicamente ciertos pasos específicos.

### Tipos de operaciones utilizadas por el Template Method

1. **Operaciones concretas**:
   - Ya están implementadas en la clase base.
   - Son reutilizadas por todas las subclases.

2. **Operaciones primitivas (abstractas)**:
   - Deben ser implementadas obligatoriamente por las subclases.
   - Representan los pasos variables del algoritmo.

3. **Hook Operations (Hooks)**:
   - Son métodos opcionales.
   - Poseen una implementación por defecto (frecuentemente vacía).
   - Las subclases pueden sobrescribirlos si desean modificar el comportamiento.

4. **Factory Methods (opcionalmente)**:
   - Un Template Method puede utilizar Factory Methods para crear objetos durante la ejecución del algoritmo.

### Ventajas

1. Favorece la reutilización de código al centralizar la lógica común en una clase base.
2. Evita la duplicación de algoritmos similares.
3. Permite variar partes específicas del algoritmo sin modificar su estructura general.
4. Favorece el cumplimiento del Principio de Responsabilidad Única (SRP), separando la estructura general del algoritmo de los detalles de implementación.
5. Favorece el cumplimiento del Principio Abierto/Cerrado (OCP), permitiendo incorporar nuevas variantes mediante herencia sin modificar la clase base.
6. Facilita el mantenimiento al concentrar el comportamiento común en un único lugar.
7. Permite controlar estrictamente el flujo de ejecución de un algoritmo.

### Desventajas

1. Introduce dependencia mediante herencia, aumentando el acoplamiento entre la clase base y las subclases.
2. Puede dificultar la comprensión del flujo cuando existen muchas operaciones primitivas y hooks.
3. Las subclases están limitadas por la estructura definida en el Template Method.
4. Puede violar el Principio de Sustitución de Liskov (LSP) si una subclase modifica el comportamiento esperado del algoritmo.
5. Un diseño incorrecto puede generar jerarquías de herencia complejas y difíciles de mantener.
6. En algunos casos Strategy puede ofrecer una solución más flexible al utilizar composición en lugar de herencia.

### Relación con SOLID

#### Single Responsibility Principle (SRP)

La clase base concentra la lógica común del algoritmo, mientras que las subclases implementan únicamente los pasos variables.

#### Open/Closed Principle (OCP)

Es uno de los principios más favorecidos por este patrón, ya que permite agregar nuevas variantes del algoritmo creando nuevas subclases sin modificar la clase base.

#### Liskov Substitution Principle (LSP)

Las subclases deben respetar el comportamiento esperado del Template Method para poder sustituir correctamente a la clase base.

#### Dependency Inversion Principle (DIP)

No es un patrón especialmente orientado a DIP, ya que se basa principalmente en herencia y no en abstracciones inyectadas mediante composición.

### Idea principal

> Template Method define la estructura general de un algoritmo en una clase base y delega en las subclases únicamente los pasos que pueden variar.

> La secuencia de ejecución permanece fija, mientras que ciertos pasos pueden personalizarse mediante herencia.

> En lugar de permitir que cada subclase implemente el algoritmo completo, la clase base controla el flujo y las subclases completan los detalles específicos.

### Ejemplo en C#

```csharp
// ======================================================
// TEMPLATE METHOD
// ======================================================
// Patrón de comportamiento.
//
// Define el esqueleto de un algoritmo dentro de una
// clase base, permitiendo que las subclases redefinan
// ciertos pasos sin modificar la estructura general.
//
// ======================================================

public abstract class Juego
{
  protected int numeroJugadores;

  // ==================================================
  // TEMPLATE METHOD
  // ==================================================
  // Define el algoritmo completo.
  //
  // Las clases hijas NO pueden modificar el orden.
  //
  // Flujo:
  //
  // 1. MostrarBienvenida()
  // 2. Iniciar()
  // 3. HookAntesDeJugar()
  // 4. HacerJugada()
  // 5. HookDespuesDeJugar()
  // 6. FinJuego()
  // 7. PublicarGanador()
  //
  // ==================================================

  public void Jugar()
  {
    MostrarBienvenida();

    Iniciar();

    HookAntesDeJugar();

    HacerJugada();

    HookDespuesDeJugar();

    FinJuego();

    PublicarGanador();
  }

  // ==================================================
  // OPERACIÓN CONCRETA COMÚN A TODAS LAS SUBCLASES
  // ==================================================
  // Implementación común para todos los juegos.
  // Las subclases la heredan automáticamente.
  // ==================================================

  protected void MostrarBienvenida()
  {
    Console.WriteLine("================================");
    Console.WriteLine("Comienza una nueva partida");
    Console.WriteLine("================================");
  }

  // ==================================================
  // PRIMITIVE OPERATIONS
  // ==================================================
  // Pasos obligatorios.
  //
  // Las clases hijas DEBEN implementarlos.
  // ==================================================

  protected abstract void Iniciar();

  protected abstract void HacerJugada();

  protected abstract void FinJuego();

  protected abstract void PublicarGanador();

  // ==================================================
  // HOOKS
  // ==================================================
  // Puntos de extensión opcionales.
  //
  // Las clases hijas pueden sobrescribirlos
  // o ignorarlos.
  //
  // Tienen implementación por defecto.
  // ==================================================

  protected virtual void HookAntesDeJugar()
  {
    // Vacío por defecto
  }

  protected virtual void HookDespuesDeJugar()
  {
    // Vacío por defecto
  }
}

// ======================================================
// AJEDREZ: CLASE CONCRETA
// ======================================================
// Utiliza únicamente las operaciones obligatorias.
// Proporciona el comportamiento específico de los pasos variables del algoritmo.
// No necesita Hooks.
// ======================================================

public class Ajedrez : Juego
{
  public Ajedrez()
  {
    numeroJugadores = 2;
  }

  protected override void Iniciar()
  {
    Console.WriteLine("Preparando tablero de ajedrez...");
  }

  protected override void HacerJugada()
  {
    Console.WriteLine("Los jugadores realizan movimientos.");
  }

  protected override void FinJuego()
  {
    Console.WriteLine("Se produce un jaque mate.");
  }

  protected override void PublicarGanador()
  {
    Console.WriteLine("Se publica el ganador del ajedrez.");
  }
}

// ======================================================
// PARCHIS
// ======================================================
// Además de las operaciones obligatorias,
// utiliza los Hooks para personalizar el algoritmo.
//
// Observá que NO cambia el orden del algoritmo.
// Sólo agrega comportamiento adicional.
// ======================================================

public class Parchis : Juego
{
  public Parchis()
  {
    numeroJugadores = 4;
  }

  protected override void Iniciar()
  {
    Console.WriteLine("Se reparten las fichas.");
  }

  protected override void HacerJugada()
  {
    Console.WriteLine("Los jugadores lanzan los dados.");
  }

  protected override void FinJuego()
  {
    Console.WriteLine("Un jugador llega a la meta.");
  }

  protected override void PublicarGanador()
  {
    Console.WriteLine("Se publica el ganador del parchís.");
  }

  // ==================================================
  // HOOK
  // ==================================================
  // Se ejecuta antes de comenzar las jugadas.
  // ==================================================

  protected override void HookAntesDeJugar()
  {
    Console.WriteLine("Verificando que todos los jugadores estén listos...");
  }

  // ==================================================
  // HOOK
  // ==================================================
  // Se ejecuta después de las jugadas.
  // ==================================================

  protected override void HookDespuesDeJugar()
  {
    Console.WriteLine("Actualizando ranking de jugadores...");
  }
}

/**
**Client (Cliente)**:
   - Trabaja con la abstracción.
   - Invoca el Template Method.
   - No necesita conocer los detalles de implementación de cada paso del algoritmo.
*/
class Program
{
  static void Main()
  {
    Juego juego1 = new Ajedrez();

    Console.WriteLine("=== AJEDREZ ===");

    juego1.Jugar();

    Console.WriteLine();

    Juego juego2 = new Parchis();

    Console.WriteLine("=== PARCHIS ===");

    juego2.Jugar();
  }
}
```

**Salida esperada:**

```
=== AJEDREZ ===

================================
Comienza una nueva partida
================================
Preparando tablero de ajedrez...
Los jugadores realizan movimientos.
Se produce un jaque mate.
Se publica el ganador del ajedrez.

=== PARCHIS ===

================================
Comienza una nueva partida
================================
Se reparten las fichas.
Verificando que todos los jugadores estén listos...
Los jugadores lanzan los dados.
Actualizando ranking de jugadores...
Un jugador llega a la meta.
Se publica el ganador del parchís.
```

| Elemento             | En el ejemplo                                                   |
| -------------------- | --------------------------------------------------------------- |
| AbstractClass        | `Juego`                                                         |
| Template Method      | `Jugar()`                                                       |
| Primitive Operations | `Iniciar()`, `HacerJugada()`, `FinJuego()`, `PublicarGanador()` |
| Concrete Operation   | `MostrarBienvenida()`                                           |
| Hooks                | `HookAntesDeJugar()`, `HookDespuesDeJugar()`                    |
| ConcreteClass        | `Ajedrez`, `Parchis`                                            |

---

## Patrones Estructurales

---

## Composite

### Intención

> Composite es un patrón de diseño estructural que compone objetos en estructuras de árbol para representar jerarquías parte-todo.

> Permite tratar de manera uniforme tanto a los objetos individuales como a los grupos de objetos.

### Aplicabilidad

Utilizar Composite cuando:

- Se necesita representar estructuras jerárquicas parte-todo.
- Existen objetos contenedores que pueden contener otros objetos del mismo tipo.
- Se desea que clientes trabajen de forma uniforme con objetos simples y compuestos.
- Se requiere recorrer estructuras arborescentes sin distinguir constantemente entre hojas y ramas.
- La estructura puede crecer dinámicamente agregando nuevos niveles de composición.

### Estructura

1. **Component (Componente)**:
   - Declara la interfaz común para hojas y compuestos.
   - Define las operaciones que todos los elementos de la estructura deben soportar.
   - Opcionalmente puede declarar operaciones para administrar hijos (`Add`, `Remove`, `GetChild`).

2. **Leaf (Hoja)**:
   - Representa los objetos terminales de la estructura.
   - No posee hijos.
   - Implementa el comportamiento definido por Component.

3. **Composite (Compuesto)**:
   - Representa objetos que pueden contener otros componentes.
   - Mantiene una colección de objetos Component.
   - Implementa las operaciones de administración de hijos.
   - Delega trabajo a sus componentes hijos.

4. **Client (Cliente)**:
   - Trabaja únicamente con la abstracción Component.
   - No necesita distinguir entre hojas y compuestos.

### Funcionamiento

El patrón construye una estructura recursiva donde cada elemento implementa la misma interfaz.

De esta manera:

- Una hoja representa un objeto individual.
- Un compuesto representa un conjunto de objetos.
- Tanto hojas como compuestos pueden ser tratados de forma uniforme.

La clave del patrón es que un Composite puede contener objetos Leaf y otros Composite simultáneamente.

### Colaboración entre Composite y Component

- El cliente interactúa únicamente con Component.
- Composite almacena referencias a Component.
- Composite delega operaciones a sus hijos utilizando polimorfismo.
- Los hijos pueden ser tanto hojas como otros compuestos.

### Ventajas

1. Permite representar jerarquías complejas de manera natural.
2. Simplifica el código cliente al tratar uniformemente objetos simples y compuestos.
3. Facilita la construcción de estructuras recursivas.
4. Favorece el cumplimiento del Principio Abierto/Cerrado (OCP), permitiendo agregar nuevos tipos de componentes sin modificar código existente.
5. Reduce la necesidad de realizar comprobaciones de tipo (`if`, `switch`, `instanceof`, etc.).
6. Facilita la reutilización de componentes dentro de diferentes estructuras.
7. Permite construir árboles de profundidad arbitraria.

### Desventajas

1. Puede dificultar la restricción de ciertos tipos de componentes dentro de la estructura.
2. Puede generar diseños excesivamente generales.
3. En algunas implementaciones las hojas terminan implementando operaciones que no tienen sentido para ellas.
4. Puede aumentar la complejidad al depurar estructuras muy profundas.
5. Puede entrar en conflicto con el Principio de Segregación de Interfaces (ISP) cuando las hojas se ven obligadas a implementar métodos como `Add()` o `Remove()` que nunca utilizarán.

### Relación con SOLID

#### Single Responsibility Principle (SRP)

Cada componente mantiene únicamente la lógica correspondiente a su función dentro de la estructura.

#### Open/Closed Principle (OCP)

Nuevos tipos de hojas o compuestos pueden incorporarse sin modificar el código cliente.

#### Liskov Substitution Principle (LSP)

Las hojas y compuestos deben poder utilizarse indistintamente mediante la interfaz Component.

#### Interface Segregation Principle (ISP)

Es el principio más discutido en Composite. Cuando Component define métodos para manipular hijos, las hojas se ven obligadas a implementar operaciones que no necesitan.

#### Dependency Inversion Principle (DIP)

El cliente depende de la abstracción Component y no de implementaciones concretas.

### Idea principal

> Composite permite representar estructuras jerárquicas parte-todo mediante una composición recursiva de objetos.

> Gracias a una interfaz común, clientes pueden tratar de forma uniforme tanto a objetos individuales como a grupos de objetos.

> Un Composite contiene Components; esos Components pueden ser hojas o nuevos Composite.

### Ejemplo en C#

```csharp
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
// LA CLAVE DEL PATRÓN COMPOSITE
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
```

**Salida esperada:**

```
Tamaño total: 23 MB

📁 Disco C (1 MB)
  📄 README.md (2 MB)
  📁 Src (1 MB)
    📄 Program.cs (5 MB)
    📄 Usuario.cs (9 MB)
    📁 Models (1 MB)
      📄 Producto.cs (4 MB)
```

---

## Decorator

### Intención

> Decorator es un patrón de diseño estructural que permite agregar responsabilidades o funcionalidades adicionales a un objeto de forma dinámica.

> Proporciona una alternativa flexible a la herencia para extender comportamientos.

### También conocido como

> Wrapper (Envoltorio)

### Aplicabilidad

Utilizar Decorator cuando:

- Se desea agregar funcionalidades a objetos sin modificar su código.
- La herencia produciría una explosión de clases para representar todas las combinaciones posibles.
- Se necesita agregar o quitar responsabilidades dinámicamente durante la ejecución.
- No es posible modificar las clases originales.
- Se busca extender el comportamiento de objetos individuales sin afectar a otros objetos de la misma clase.

### Estructura

1. **Component (Componente)**:
   - Declara la interfaz común para los objetos concretos y decoradores.
   - Define las operaciones que pueden ser decoradas.

2. **Concrete Component (Componente Concreto)**:
   - Implementa el comportamiento base.
   - Es el objeto al que se le agregarán nuevas responsabilidades.

3. **Decorator (Decorador Abstracto)**:
   - Implementa la misma interfaz que Component.
   - Mantiene una referencia a un objeto Component.
   - Delega las operaciones al componente encapsulado.

4. **Concrete Decorator (Decorador Concreto)**:
   - Extiende Decorator.
   - Agrega nuevas responsabilidades antes o después de delegar la operación al componente encapsulado.

5. **Client (Cliente)**:
   - Trabaja únicamente con la abstracción Component.
   - Puede envolver componentes con uno o varios decoradores.

### Funcionamiento

El patrón utiliza composición para extender comportamientos.

De esta manera:

- El decorador envuelve un componente.
- Implementa la misma interfaz que el componente.
- Puede agregar comportamiento antes o después de delegar la llamada.
- Múltiples decoradores pueden encadenarse.

### Colaboración entre Decorator y Component

- Decorator implementa la misma interfaz que Component.
- Decorator mantiene una referencia a Component.
- Las llamadas son delegadas al componente encapsulado.
- Los decoradores agregan funcionalidad adicional durante la cadena de llamadas.

### Ventajas

1. Permite agregar funcionalidades dinámicamente.
2. Evita crear grandes jerarquías de herencia.
3. Favorece la reutilización de comportamientos.
4. Permite combinar funcionalidades de manera flexible.
5. Favorece el cumplimiento del Principio Abierto/Cerrado (OCP), permitiendo extender comportamientos sin modificar clases existentes.
6. Favorece el cumplimiento del Principio de Responsabilidad Única (SRP), encapsulando cada responsabilidad adicional en un decorador independiente.
7. Favorece el cumplimiento del Principio de Inversión de Dependencias (DIP), ya que trabaja sobre la abstracción Component.
8. Permite agregar o remover funcionalidades sin afectar otras instancias.

### Desventajas

1. Incrementa la cantidad de objetos en el sistema.
2. Puede dificultar el seguimiento del flujo de ejecución cuando existen muchos decoradores encadenados.
3. El comportamiento final surge de múltiples objetos colaborando, lo que puede dificultar la depuración.
4. Un componente decorado no es estrictamente idéntico al componente original desde el punto de vista de identidad del objeto.
5. Puede resultar excesivo para funcionalidades simples.

### Relación con SOLID

#### Single Responsibility Principle (SRP)

Cada decorador encapsula una única responsabilidad adicional.

#### Open/Closed Principle (OCP)

Es uno de los patrones que mejor ejemplifica este principio, ya que permite extender funcionalidades sin modificar código existente.

#### Liskov Substitution Principle (LSP)

Los decoradores deben poder sustituir al componente original sin alterar el comportamiento esperado por el cliente.

#### Interface Segregation Principle (ISP)

Las interfaces pequeñas y específicas facilitan la creación de decoradores reutilizables.

#### Dependency Inversion Principle (DIP)

El cliente y los decoradores dependen de la abstracción Component y no de implementaciones concretas.

### Idea principal

> Decorator agrega funcionalidades a un objeto mediante composición en lugar de herencia.

> Un decorador envuelve un componente, implementa la misma interfaz y añade comportamiento antes o después de delegar la operación.

> Múltiples decoradores pueden encadenarse para construir funcionalidades complejas de manera flexible.

### Ejemplo en C#

```csharp
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
    // variable = cafe
    // Tipo declarado = IBebida
    // Objeto Real = Cafe

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
```

**Resumen conceptual:**

> Decorator permite agregar responsabilidades a un objeto dinámicamente sin modificar su clase original.

> La clave del patrón es: un Decorator implementa la misma interfaz que el objeto que decora y además contiene una referencia a él.

> Por eso puede actuar como un "envoltorio" (wrapper) agregando comportamiento antes, después o alrededor de la operación original.
