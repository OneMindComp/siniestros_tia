# Instalación
Los siguientes apartados corresponde a una guía de instalación básica para el despliegue de una aplicación web en un servidor Internet Information Service.
## Requisitos de sistema
- Runtime .Net Core 8.0
## Instalación en IIS
1. Ingresar a servidor de aplicación con sistema operativo Windows Server.
2. En caso de ser una instalación nueva, en Internet Information Service, agregar Application Pool de la aplicación, según el paso siguiente. En caso de ser una actualización, pasar al paso 5.
3. En la ventana de Application Pool, Indicar nombre y los siguientes parámetros:
    ```
    .NET CLR Version: .NET CLR Version v4.0.30319
    Managed pipeline mode: Integrated
    Start application pool inmediately: true
    ```
5. En caso de ser instalación nueva, en Internet Information Service, agregar aplicación bajo el sitio Default o el designado.
6. Navegar al directorio inetpub/wwwroot asociado.
7. En el directorio asignado a la aplicación. Respaldar fuentes existentes en un archivo comprimido. Luego, extraer y reemplazar los archivos fuentes.
8. Verificar los archivos de configuración appsettings.json y archivo web.config.
### Rollback
En caso de tener algún error en la instalación, se deberá realizar los siguientes pasos para dejar la versión anterior o eliminación o eliminación completa del despliegue.
1. Reemplazar los archivos escritos con los respaldados en el paso 7.
# Configuración
## Archivo appsettings.json
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "TiaServicesSettings": {
    "PartyBasePath": "http://130.61.232.125:7311/party/api/",
    "ClaimsBasePath": "http://130.61.232.125:7315/claim/api/",
    "CommonBasePath": "http://tic-sb-711-dev.tia.eu:7314/common/api/",
    "CaseBasePath": "http://130.61.232.125:7312/case/api/"
  },
  "TiaAuthSettings": {
    "Url": "https://tic-sb-711-dev.tia.eu/auth/realms/tia/protocol/openid-connect/token",
    "Id": "rest2-m2m",
    "Secret": "VHNwBxyoQiRiAF7bX12RmIuLdhZnVacm",
    "Audience": "rest2-api",
    "GrantType": "client_credentials",
    "SecondAdjust": 14400
  },
  "Sentry": {
    "Dsn": "https://3f2caf58f5202518aa684846873c53be@o956313.ingest.sentry.io/4506111203934208",
    "Environment": "Development",
    "MaxRequestBodySize": "Always",
    "SendDefaultPii": true,
    "MinimumBreadcrumbLevel": "Debug",
    "MinimumEventLevel": "Warning",
    "AttachStackTrace": true,
    "Debug": true
  },
  "AllowedHosts": "*"
}
```
### Telemetría Sentry
La sección `Sentry` corresponde a la configuración de los parámetros para la telemetría mediante la herramienta Sentry. Los parámetros principales a configurar son los siguientes:
1. `Dsn` es el identificador de la aplicación en el servicio de telemetría.
2. `Environment` refiere a la versión del ambiente en que se encuentra desplegada la aplicación (development, staging, production).
3. `Debug` indicador si la ejecución es para fines de depuración.
Para mayor información, hacer referencia a la [documentación oficial](https://docs.sentry.io/platforms/dotnet/configuration/options).
### Servicios TIA
La sección `TiaServicesSettings` son los valores para la integración con los servicios del sistema CORE TIA.
1. `PartyBasePath` es la ruta donde se encuentran alojados los servicios de party TIA.
2. `ClaimsBasePath` es la ruta donde se encuentran alojados los servicios de claims TIA.
3. `CommonBasePath` es la ruta donde se encuentra alojada los servicios comunes TIA.
4. `CaseBasePath` es la ruta donde se encuentra alojada los servicios case TIA.
### Autenticación TIA
La sección `TiaAuthSettings` corresponde a los parámetros de configuración para la autenticación con el servicio de Sapiens.
1. `Url` es la ruta donde se encuentra alojado el servicio de autenticación de Sapiens.
2. `Id` es el identificador del cliente.
3. `Secret` es el secreto o contraseña del cliente.
4. `Audience` es la audiencia para la cual se generará el token de seguridad.
5. `GrantType` es el tipo de autorización solicitado.
