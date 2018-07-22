# VuelingExam

1. He utilizado Architecture DDD for Vueling Examn.

Las operaciones que nos demanda la empresa son estas:
  - GetById (Buscar un cliente por Id)
  - GetByUserName (Buscar un cliente por UserName)
  - GetLinkUsername (BUscar a policies que estén vinculados con los clientes)

En el proyecto he trabajado con ficheros de recursos y ficheros de configuración (Webconfig).
Está compuesto y construido Siguiendo la arquitectura practicada en clase. 

La solución se ha hecho extrayendo y deserializando mediante Json pero igualmente dejo las tablas de la Base de datos dibujadas previamente. 

![alt text](Image/BBDD_Company.PNG "Base de Datos Web Api")


He eliminado varias clases que hemos definido en clase como Arquitectura básica para poder iniciar nuestra aplicación.

Yakni.- Clases que no me hacía falta utilizar para poder extraer datos de la WebApi.

Log4Net.- Mi aplicación gestiona Logs para informar al usuario en cada momento donde está el fallo. 

![alt text](Image/LogError.PNG "Imágen Log")


Metodos.- 
  - GetAll (Muestra todos los usuarios de la WebApi)
  - GetById (Muestra usuarios filtrados por Id)
  - GetByUserName (Muestra los usuarios por userName).
  
Las clases: 
  - ClientsApiController.- Gestiona la busqueda de Clientes filtrados por los metodos anteriores.
  - PoliciesApiController .- Gestiona la busqueda de Policies filtrados por los metodos anteriores. 
  
Ficheros de Configuración:
  - Ficheros de configuración para ApiController y Excepciones. 
  
DLL Utilizadas:

- Json.
- Linq.


