# Seminario .NET - Sistema de Gestión del Centro Deportivo Universitario (Proyecto Final)

## Integrantes
* Bie, Leandro
* Castañeda, Isabella
* Dobal, Federico
* Villca, Facundo

## Descripción General
Este proyecto es la versión final del **Sistema de Gestión del Centro Deportivo Universitario**. Partiendo de una base con gestión de eventos, personas y reservas, esta versión expande la funcionalidad incorporando una completa gestión de usuarios, una nueva interfaz web y persistencia de datos a través de una base de datos.

## Características Principales
* **Gestión de Usuarios**: Funcionalidad completa para la gestión de usuarios del sistema, incluyendo nombre, apellido, correo y contraseña. El primer usuario registrado asume el rol de Administrador con todos los permisos. El Administrador puede delegar permisos de gestión de usuarios a otras cuentas. Los nuevos usuarios comienzan con permisos de solo lectura.
* **Interfaz Web con Blazor**: Se desarrolló una nueva interfaz de usuario utilizando Blazor en un proyecto llamado `CentroEventos.UI`, descartando la aplicación de consola anterior.
* **Persistencia con Entity Framework Core**: Se utiliza Entity Framework Core con una base de datos SQLite para persistir toda la información, aplicando una metodología "code first".
* **Seguridad de Contraseñas**: Las contraseñas no se guardan en texto plano; en su lugar, se almacena un hash (utilizando SHA-256) para garantizar la seguridad.
* **Autenticación y Sesión**: Flujo de inicio de sesión y registro de usuarios. La sesión del usuario se gestiona a través de un servicio con alcance *Scoped* en Blazor.

## Arquitectura del Sistema
El proyecto mantiene una Arquitectura Limpia para asegurar un bajo acoplamiento y alta cohesión entre sus componentes.

* **CentroEventos.Aplicacion**: El núcleo del sistema, contiene la lógica de negocio, entidades, casos de uso e interfaces.
* **CentroEventos.Repositorios**: Capa de acceso a datos que implementa las interfaces de la aplicación utilizando Entity Framework Core y SQLite.
* **CentroEventos.UI**: La capa de presentación, desarrollada con Blazor. Es el punto de entrada para el usuario final.

## Instrucciones para Correr el Programa

### Prerrequisitos
* Tener instalado el **SDK de .NET 8.0** - [Descarga](https://dotnet.microsoft.com/es-es/download/dotnet/8.0).
* Tener instalado el gestor de bases de datos **SQLite** - [Descarga](https://sqlite.org/download.html).

### Pasos para Ejecutar
1.  **Clonar el repositorio**:
    ```bash
    git clone https://github.com/fededobal/CentroEventos-FINAL-.NET.git
    ```
2.  **Navegar al directorio de la solución**:
    ```bash
    cd CentroEventos-TP1-.NET/CentroEventos
    ```
3.  **Navegar al proyecto de UI**:
    ```bash
    cd CentroEventos.UI
    ```
4.  **Ejecutar la aplicación**:
    ```bash
    dotnet run
    ```
5.  **Abrir en el navegador**: Una vez que la aplicación esté corriendo, abre tu navegador web y ve a la dirección que se indica en la consola (generalmente `https://localhost:xxxx` o `http://localhost:xxxx`). La primera vez que se ejecute, Entity Framework creará la base de datos SQLite automáticamente gracias al code first.
