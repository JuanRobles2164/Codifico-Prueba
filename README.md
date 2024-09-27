# Codifico-Prueba
 Prueba para desarrollador

## Requisitos previos
### Herramientas necesarias
1. Node.js (versión 16 o superior) para ejecutar la aplicación Angular.
   * Descargar desde Node.js.
2. .NET SDK (versión 6.0 o superior) para ejecutar la API.
   * Descargar desde Microsoft .NET SDK.
3. Angular CLI para desarrollar y servir la aplicación Angular.
   * Instalar con `npm install -g @angular/cli`.

## Configuración de los proyectos

### 1. Configuración de la API(.NET)
#### a) Configuración inicial
Primero, id a la carpeta raíz donde se encuentra la API
```bash
cd /api
```
#### b) Restaurar dependencias

```bash
dotnet restore
```

#### c) Configurar las conexiones (opcional)
Ajusta el archivo de configuración (appsettings.json) en la carpetas `/SalesDatePrediction` para configurar la base de datos u otros servicios.

#### d) Ejecutar la API
Ejecuta el siguiente comando para correr la API:

```bash
dotnet run --project SalesDatePrediction
```
Esto iniciará la API en el puerto por defecto

#### e) API Tests
Para ejecutar los Tests, navega al proyecto `Tests` y ejecuta los siguientes comandos:

```bash
dotnet test
```

### 2. Configuración del Frontend (Angular 17)
#### a) Instalar dependencias
Navega a la carpeta del frontend y ejecuta el siguiente comando para instalar las dependencias de Node.js y Angular:

```bash
cd /front-end
npm install
```

#### b) Configuración del entorno (opcional)
Ajusta el archivo de configuración `environment.ts` en la carpeta `src/environments` para cambiar la URL de la API o las configuraciones de entorno. (A veces el puerto del API cambia)

#### c) Ejecutar la aplicación Angular
Para ejecutar el frontend, ejecutar el siguiente comando:

```bash
ng serve
```

## ¿Cómo se ejecutó la prueba?

### Para el Back-end
- Primero, es necesario leer los diagramas y la arquitectura necesitada para ambas aplicaciones solicitada en los requerimientos
- Se creó una aplicación .NET Web Api, se configuró la conexión a la base de datos. Se realizaron unas cuantas consultas luego de migrada la base de datos con su script para asegurarnos de que esté ejecutandose sin problemas
- Se crearon carpetas y se distribuyó el código aplicando patrones de diseño, inyección de dependencias y buenas prácticas (**SOLID principles**)
- Se creó un proyecto de pruebas por separado para testear todos los repositorios y los resultados esperados
- Se agregó un gitignore a la raíz del proyecto para que no suba archivos temporales, binarios ni librerías de nuget, pues esto agrega peso innecesario al repositorio.
- DISCLAIMER: Los archivos con credenciales o de acceso global para el proyecto (appsettings.json, por ejemplo) se subieron con las credenciales para ejecutar localmente, sin embargo es importante recordar que al repositorio nunca se suben estos archivos

### Para el Front-End
- Se créo un nuevo proyecto de Angular 17
- Se determinó que el diseño que más fidelizaba por el propuesto en la prueba era el de Material Design, así que se procedió con la instalación de esta librería
- Se usó una distribución de carpetas personalizada y no la que está por defecto que habilita Angular
- Se distribuyeron las vistas acorde a la arquitectura planteada en el diagrama del inicio

### Para D3
- Se usó un CDN para usar la librería sin instalaciones ni descargas adicionales