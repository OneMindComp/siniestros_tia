# integracion-core-siniestros-api
API encargada de orquestar, con el nuevo CORE, la creación y obtención de siniestros.
```mermaid
---
title: Diagrama de componentes de integración 
---
flowchart LR
  subgraph Sapiens
    direction LR    
    subgraph TIA
        direction LR
        API_Common
        API_Custom
    end
  end
  subgraph Sbins
    direction LR
    subgraph Integracion Core
        direction LR
        API_ICore_Siniestro:::someclass --> API_Common
        API_ICore_Siniestro --> API_Custom
    end
    
    classDef someclass fill:#f96
  end
```
## Documentación
- [Definición de API (Swagger)](http://192.168.10.14/API_IntegracionCoreSiniestros/api-doc/index.html)
- [Instalación y configuración](docs/instalacion.md) 
