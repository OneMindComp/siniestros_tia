## API Integracion Core Siniestros
Cambios realizados en la definición de la API de Integracion Core Siniestros.

### /v1/perform-transaction
---
#### Ruta de la Propiedad:

`paths>/v1/perform-transaction>post>responses>200>headers>Location`

#### Cambios

| Propiedad | Descripción                | Versión |
| --------- | -------------------------- | :-----: |
| Location  | Se agrega propiedad schema |    1    |


#### Código ejemplo
Nota: Se puede copiar y reemplazar por completa la propiedad `Location` por la del ejemplo.

```json
"Location": {
    "description": "Link to created resource",
    "style": "simple",
    "schema": {
        "type": "string"
    }
}
```

### claim-cases/\{claimCaseNo\}/close
---
#### Ruta de la Propiedad:

`paths>/v1/claim-cases/{claimCaseNo}/close>post>responses>200>headers>ETag`

#### Cambios

| Propiedad | Descripción                | Versión |
| --------- | -------------------------- | :-----: |
| ETag      | Se agrega propiedad schema |    1    |


#### Código ejemplo
Nota: Se puede copiar y reemplazar por completa la propiedad `ETag`.

```json
"ETag": {
    "description": "Version tag",
    "style": "simple",
    "schema": {
        "type": "string"
    }
}
```

### Cambios generales
---
1. Buscar y eliminar todas las propiedades `example` que tengan un valor que termine con `+27`.
```json
//Ejemplo
"hoursSpendOnClaimCaseHandling": {
    "type": "number",
    "description": " ... ",
    "example": 7.128423423023237e+27 <--Eliminar
},
```