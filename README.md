# SiaesAPISolution

## Descripción General

`SiaesAPISolution` es una solución completa para el "Registro de Actividades Diarias" diseñada para mejorar la eficiencia y organización de las tareas cotidianas. Esta solución está compuesta por tres proyectos principales: `SiaesCliente`, `SiaesLibraryShared` y `SiaesServer`, cada uno enfocado en diferentes aspectos de la aplicación, desde la interfaz de usuario hasta la lógica de negocio y el almacenamiento de datos.

## Tecnologías y Frameworks

- **Frontend**: Blazor WebAssembly
- **Backend**: ASP.NET Core 5.0/6.0
- **Shared Library**: .NET Standard 2.1
- **Base de Datos**: SQL Server/Entity Framework Core
- **Autenticación**: JWT Bearer Token Authentication
- **Estilos/UI**: Bootstrap, Radzen Blazor Components

## Componentes Principales

- **Radzen Blazor Components**: Utilizados para construir una interfaz de usuario rica y dinámica con menos código y tiempo.
- **Entity Framework Core**: ORM de .NET utilizado para interactuar con la base de datos de manera eficiente, aprovechando LINQ para consultas y operaciones de datos.
- **JWT Authentication**: Sistema de autenticación basado en tokens para asegurar la API y gestionar el acceso de usuarios.

  ## Proyectos

### SiaesCliente

Interfaz de usuario desarrollada con [Blazor WebAssembly](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor). Permite a los usuarios interactuar con el sistema de registro de manera intuitiva, facilitando la creación, visualización y gestión de actividades diarias.
SiaesCliente es una aplicación web creada con Blazor WebAssembly. Proporciona la interfaz de usuario para el registro y gestión de actividades diarias. La aplicación se comunica con SiaesServer a través de llamadas API para realizar operaciones CRUD (Crear, Leer, Actualizar y Eliminar) en la base de datos

### SiaesLibraryShared

Librería de clases compartidas que contiene la lógica de negocio y los modelos de datos utilizados por ambos, el cliente y el servidor. Facilita la reutilización de código y mantiene la cohesión en toda la solución.
SiaesLibraryShared es una biblioteca de clases compartida entre SiaesCliente y SiaesServer. Contiene las clases de modelos, contratos y otros elementos comunes utilizados por ambos proyectos.

### SiaesServer

API REST construida con [ASP.NET Core](https://dotnet.microsoft.com/apps/aspnet/apis) que actúa como el servidor backend, gestionando las solicitudes HTTP, el acceso a bases de datos y la ejecución de la lógica de negocio.
SiaesServer es una API web creada con ASP.NET Core. Proporciona los servicios web necesarios para que SiaesCliente realice operaciones CRUD en la base de datos. La API utiliza Entity Framework Core para el acceso a datos y JWT para la autenticación y autorización de usuarios.

### Base de datos
La solución utiliza SQL Server como sistema de gestión de bases de datos. La base de datos contiene las tablas necesarias para almacenar la información de las actividades diarias, los usuarios y otros datos relevantes para la aplicación.

### Despliegue
La solución puede desplegarse en Azure utilizando los siguientes servicios:

Azure App Service: Servicio de hosting web para SiaesCliente y SiaesServer.
Azure SQL Database: Base de datos SQL Server como servicio para almacenar los datos de la aplicación.


## Contribuciones

¡Las contribuciones a este proyecto son bienvenidas! Si estás interesado en mejorar `SiaesAPISolution`, sigue estos pasos para contribuir:

1. **Fork** el repositorio en tu cuenta de GitHub.
2. **Clona** el repositorio forkeado a tu máquina local.
3. **Crea** una nueva rama para tus cambios: `git checkout -b mi-nueva-caracteristica`.
4. **Realiza** tus cambios y **haz commit** a ellos: `git commit -am 'Añadir alguna característica'`.
5. **Empuja** la rama a tu fork: `git push origin mi-nueva-caracteristica`.
6. **Crea** una nueva Pull Request desde tu fork en GitHub.

Antes de enviar una Pull Request, por favor asegúrate de que tu código sigue las directrices de estilo del proyecto y pasa todas las pruebas.

¡Agradecemos tu tiempo y esfuerzo para mejorar este proyecto!

## Licencia

Este proyecto se distribuye bajo la Licencia MIT. Esto significa que puedes usar, copiar, modificar, fusionar, publicar, distribuir, sublicenciar y/o vender copias del software, bajo los términos de la licencia, sin restricción alguna, siempre que se proporcione el aviso de derechos de autor adecuado y este aviso de permiso en todas las copias o partes sustanciales del software.

