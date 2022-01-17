# schedule
# Agenda de Turnos 📖

## Objetivos 📋

Desarrollar un sistema, que permita la administración general de un consultorio.\
Los administradores gestionarán: Prestaciones, Profesionales, Pacientes, etc.\
Permitir a los pacientes realizar reservas sobre turnos ofrecidos.\
Utilizar Visual Studio 2019 y crear una aplicación utilizando `ASP.NET MVC Core versión 3.1`.

---------------------------------------

## Enunciado 📢

La idea principal de este trabajo práctico, es que ustedes se comporten como un equipo de desarrollo. Este documento, les acerca un equivalente al resultado de una primera entrevista entre el cliente y alguien del equipo que relevó e identificó la información aquí contenida. A partir de este momento, deberán comprender lo que se está requiriendo y construir dicha aplicación.\
Deben recopilar todas las dudas que tengan y evacuarlas con su nexo (el docente) de cara al cliente. De esta manera, él nos ayudará a conseguir la información ya un poco más procesada. Es importante destacar que este proceso no debe esperar a ser en clase, sino que debe darse a medida que vayan trabajando en el proyecto. Por otro lado es importante que agrupen sus consultas ya sea por criterios funcionales o técnicos y envíen correos con las consultas agrupadas en lugar de enviar cada consulta de forma independiente.

**Subject:**


**Body:**

---------------------------------------

## Proceso de ejecución en alto nivel ☑️

- Crear un proyecto utilizando [visual studio].
- Adicionar todos los modelos dentro de la carpeta Models cada uno en un archivo separado.
- Especificar todas las restricciones y validaciones solicitadas a cada una de las entidades. [DataAnnotations].
- Crear las relaciones entre las entidades.
- Crear una carpeta Data que dentro tendrá al menos la clase que representará el contexto de la base de datos DbContext.
- Crear el DbContext utilizando base de datos sqlite. [DbContext], [Database Sqlite], [Db browser sqlite].
- Agregar los DbSet para cada una de las entidades en el DbContext.
- Crear el Scaffolding para permitir los CRUD de las entidades.
- Aplicar las adecuaciones y validaciones necesarias en los controladores.
- Realizar un sistema de login para los roles identificados en el sistema y un administrador.
- Un administrador podrá realizar todas tareas que impliquen interacción del lado del negocio (ABM "Alta-Baja-Modificación" de las entidades del sistema y configuraciones en caso de ser necesarias).
- Cada usuario sólo podrá tomar acción en el sistema en base al rol que tiene.
- Realizar todos los ajustes necesarios en los modelos y/o funcionalidades.
- Realizar los ajustes requeridos del lado de los permisos.
- Todo lo referido a la presentación de la aplicaión (cuestiones visuales).
- Para la visualización se recomienda utilizar [Bootstrap], pero se puede utilizar cualquier herramienta que el grupo considere.

---------------------------------------

## Entidades básicas 📄

- Usuario
- Paciente
- Profesional
- Turno
- Prestación
- Formulario

`Importante: Todas las entidades deben tener su identificador único Id de tipo Guid.`

`Las propiedades descriptas a continuación, son las mínimas que deben tener las entidades, dejando explícito que ustedes pueden agregar las que consideren necesarias.  
De la misma manera deben definir los tipos de datos asociados a cada una de ellas, como así también las restricciones que apliquen.`

| Entidad | Propiedades |
| ----- | ----- |
| Usuario | Nombre, Email, FechaAlta, Password |
| Paciente | Nombre, Apellido, DNI, Telefono, Direccion, FechaAlta, Email, ObraSocial, Turnos |
| Profesional | Nombre, Apellido, Telefono, Direccion, FechaAlta, Email, Matricula, Prestacion, HoraInicio, HoraFin, Turnos |
| Turno | Fecha, Confirmado, Activo, FechaAlta, Paciente, Profesional, DescripcionCancelacion |
| Prestacion | Nombre, Descripcion, Duracion, Precio, Profesionales |
| Formulario | Fecha, Email, Nombre, Apellido, Leido, Titulo, Mensaje, Usuario |

**NOTA:** aquí un link para refrescar el uso de los [Data annotations].

---------------------------------------

## Características y Funcionalidades ⌨️

`Todas las entidades deben tener implementado su correspondiente ABM, a menos que sea implícito el no tener que soportar alguna de estas acciones.`

### Paciente

- Los pacientes pueden auto registrarse.
  - La autoregistración desde el sitio, es exclusiva para los pacientes, por lo cual, se le asignará automáticamente dicho rol.
- Gestión de sus turnos
  - Un paciente puede sacar un turno Online. El proceso será en modo Wizard (o sea paso a paso).
    - Selecciona la prestación.
    - Selecciona un profesional que ofrezca dicha prestación.
    - Seleccionará un turno disponible dentro de la oferta.
      - La oferta estará restringida desde el momento de la consulta hasta 7 días posteriores.
      - No debe incluir, desde luego, turnos tomados.
      - Debe ser en base a la oferta del profesional seleccionado, o sea, turnos no tomados y dentro del horario de trabajo del profesional.
  - El paciente, solo puede tener un turno activo.
  - El paciente podrá, en todo momento, ver si tiene o no un turno solicitado.
    - Verá el estado, o sea, si está o no confirmado
    - Podrá cancelarlo sólo si es hasta 24 horas antes.
- El paciente puede llenar un formulario de contacto para enviar una consulta.
  - El formulario puede ser enviado de forma anónima (el usuario no se encuentra logueado en el sitio), pero si el paciente está logueado, cargará automaticamente los datos de éste, sino éstos deben ser ingresados al momento de enviar el formulario.
- Puede actualizar datos de contacto, como el teléfono, dirección, etc. pero no puede modificar su DNI, Nombre, Apellido, etc.

### Profesional

- Los profesionales deben ser agregados exclusivamente por un Administrador.
  - Al momento del alta del profesional, se le definirá un username y password.
  - También se le asignará a estas cuentas el rol de Profesional automáticamente.
- El profesional puede listar los turnos que tiene asignado en el futuro para atender.
- El profesional puede confirmar sus turnos.
- También puede ver un balance de los turnos que ya realizó en el mes calendario.
  - Visualizará en éste el valor que deberá percibir a fin de mes x valor hora.

### Administrador

- Un Administrador puede confirmar los turnos de cualquier profesional.
- Un Administrador puede cancelar un turno en cualquier momento, agregando una descripción del motivo.
- Un Administrador puede cargar las prestaciones que brinda el centro.
- Un Administrador puede dar de alta a profesionales con su horario de atención y todos los datos requeridos.

### Turno

- Al crearse un turno debe estar en estado "sin confirmar" y algún administrador o el profesional a quien corresponde dicho turno lo debe confirmar.
- No se pueden superponer dos turnos del mismo profesional.

### Aplicación General

- Información institucional.
- Se deben mostrar las Prestaciones ofrecidas, con una descripción de las mismas, costos, duración típica de la prestación, etc.
- Se deben listar los profesionales que brindan atención.
- Nadie puede eliminar los pacientes del sistema. Esto debe estar restringido.
- Los accesos a las funcionalidades y/o capacidades debe estar basada en los roles que tenga cada usuario que acceda.

**Nota:** `El centro tiene consultorios ilimitados y cada consultorio está preparado para soportar cualquier prestación, por lo cual esto no implica restricciones.`

[//]: # (referencias externas)
   [visual studio]: <https://visualstudio.microsoft.com/en/vs/>
   [Data annotations]: <https://www.c-sharpcorner.com/UploadFile/af66b7/data-annotations-for-mvc/>
   [Bootstrap]: <https://getbootstrap.com/>
   [DbContext]: <https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontext?view=efcore-3.1>
   [Database Sqlite]: <https://docs.microsoft.com/en-us/ef/core/providers/sqlite/?tabs=dotnet-core-cli>
   [Db browser sqlite]: <https://sqlitebrowser.org/>
   [DataAnnotations]: <https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=netcore-3.1>
