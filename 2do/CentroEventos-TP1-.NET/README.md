# Seminario .NET - Proyecto Centro de Eventos Deportivos (Primera Entrega)

## Integrantes
* Bie, Leandro
* Castañeda, Isabella
* Dobal, Federico
* Villca, Facundo

## Descripción General del Proyecto
Este proyecto representa un sistema para un Centro de Eventos Deportivos. Su funcionalidad principal es administrar eventos deportivos y relacionarlos con personas y reservas, utilizando casos de uso habituales. Toda la información generada se persiste en repositorios de archivos de texto.

## Objetivos Principales
1.  Proveer un sistema básico para la administración de eventos deportivos, personas y reservas.
2.  Implementar funcionalidades CRUD (Crear, Leer, Actualizar, Borrar) en los casos de uso del sistema.
3.  Incorporar validaciones predefinidas al ejecutar los casos de uso.
4.  Expresar la falla de las validaciones mediante excepciones personalizadas.
5.  Respetar la inyección de dependencias por constructor.
6.  Persistir toda la información del CRUD en archivos de texto.

## Arquitectura del Sistema
El sistema está organizado siguiendo los principios de la Arquitectura Limpia, separando los elementos en "capas" para asegurar que las dependencias fluyan hacia el núcleo del sistema. Esto permite que el sistema sea sostenible a largo plazo y facilita futuras modificaciones sin necesidad de una reconstrucción completa.

La estructura se compone de:
* **CentroEventos.Aplicacion**: Es el núcleo de la solución y maneja la lógica del sistema. No posee referencias a otros módulos.
* **CentroEventos.Consola**: Es la interfaz de usuario de la solución. Conoce las referencias de Repositorios y Aplicación.
* **CentroEventos.Repositorios**: Implementa los métodos para el acceso a datos y controla los archivos de texto. Conoce las referencias de Aplicación.

### Componentes de `CentroEventos.Aplicacion`
* **Entities**: `EventoDeportivo`, `Persona`, `Reserva`.
* **Enums**: `Asistencia` (Pendiente, Presente, Ausente) y `Permiso` (para operaciones de Evento, Reserva y Usuario).
* **Exceptions**: Excepciones personalizadas como `CupoExcedidoException`, `DuplicadoException`, `EntidadNotFoundException` (lanzada en repositorios), `FalloAutorizacionException`, `OperacionInvalidaException`, y `ValidacionException`.
* **Interfaces**: `IRepositorioEventoDeportivo`, `IRepositorioPersona`, `IRepositorioReserva`, `IServicioAutorizacion`.
* **Services**: Implementación de `IServicioAutorizacion`. En esta entrega, un usuario tiene permiso si su ID es 1.
* **UseCases**: Implementación de los casos de uso (Alta, Baja, Modificación) con validaciones previas.
* **Validators**: Clases para asegurar que se cumplen las restricciones necesarias para cada caso de uso, lanzando excepciones si no se cumplen.

### Componentes de `CentroEventos.Consola`
* **Programa principal**: Crea instancias e inyecta dependencias. Utiliza un `Selector` para que el usuario controle el flujo del programa.
* **Selector**: Clase para abstraer la selección en consola, mejorando la legibilidad y seguridad al manejar IDs internamente. Permite al usuario seleccionar entidades (Personas, Eventos Deportivos, Reservas) de una lista numerada.

### Componentes de `CentroEventos.Repositorios`
* Implementan las interfaces de repositorio y gestionan los archivos de texto para las entidades.
* Se encargan de asignar y auto-incrementar los IDs de las entidades, almacenándolos en un archivo de texto separado y gestionándolos internamente.

## Proceso de Trabajo
El desarrollo fue realizado en equipo. Inicialmente se intentó usar Live Server para trabajo simultáneo, pero se optó por dividir responsabilidades por entidades y gestionar el proyecto con GitHub, lo cual resultó más efectivo. Esta división optimizó el ritmo de trabajo, manteniendo una comprensión general del código y facilitando la integración.

## Conclusión
Esta primera entrega fue una experiencia enriquecedora en el desarrollo de software con .NET y C#. Se afrontaron desafíos colaborativamente, tanto en dinámicas grupales como en aspectos técnicos (gestión de IDs, arquitectura limpia). El proyecto respeta el principio de inversión de dependencia y el concepto de arquitectura cebolla.

## Instrucciones para Correr el Programa

### Prerrequisitos
* Tener instalado el SDK de .NET 8.0.

### Pasos para Ejecutar
1.  **Clonar el repositorio**:
    ```bash
    git clone https://github.com/fdDbl/CentroEventos-TP1-.NET.git
    ```
2.  **Navegar al directorio del proyecto**:
    ```bash
    cd CentroEventos-TP1-.NET\CentroEventos
    ```
3.  **Navegar al proyecto de Consola**:
    ```bash
    cd CentroEventos.Consola
    ```
4.  **Ejecutar la aplicación**:
    ```bash
    dotnet run
    ```
