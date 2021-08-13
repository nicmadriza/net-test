# Prueba de conocimiento en .NET

## Introducción

> Es importante para nosotros demostrar el conocimiento aprendido en las plataformas de .NET.
Nuestra empresa ha trabajado durante años sobre esta plataforma y consideramos importantes los conocimientos básicos para poder iniciar de manera proactiva las labores en nuestra representada.

## Ejercicio

• Crear un proyecto web MVC en NET 5.

• Consumir el servicio descrito en #Servicios a consumir utilizando la librería RestSharp. Parsear la respuesta usando Newtonsoft Json.NET.

• Crear un segundo proyecto para guardar la lógica de negocio y agregar la referencia al proyecto web.
En este proyecto debe estar el consumo al servicio, 
las clases de los objetos para la serialización de los datos que vienen en el servicio y que el método retorne toda la data.

• En la interfaz, agregar un botón que obtenga la información del servicio y lo muestre en el HTML.

• Usar LINQ (Lambda) para poder filtrar en los casos que sean necesarios: var _Results = _List.Where(x => x.Value == 1);

---------------------------------------------
Opcional:
Crear un segundo proyecto que haga exactamente lo mismo pero que sea Blazor Server y que consuma la librería que consume los datos del servicio.
Se puede agregar en el mismo solution.

## Servicios a consumir

• Posts: https://jsonplaceholder.typicode.com/posts

• Comentarios: https://jsonplaceholder.typicode.com/comments

• Users: https://jsonplaceholder.typicode.com/users

## Bonus

• Para el endpoint de los comentarios, el campo *body* mostrarlo en el html con la letra mayúscula en cada palabra. Ejemplo: hola mundo -> Hola Mundo

• Implementar un filtro básico en el proyecto web para realizar una búsqueda por texto sobre la data de *title* y *body* de cada post y que muestre los resultados filtrados.
Ya sea mediante un post normal o un post mediante un llamado ajax utilizando jQuery.

## Bonus avanzado

• Usar dependency injection en el proyecto web para instanciar de manera automática la clase de la librería que consume el servicio en el constructor del controlador del proyecto web. (Esta característica es nueva en Net Core y Net 5)
Debe utilizar uno de los tres metodos disponibles para inyectar que son: AddTransient, AddScope o AddSingleton.

• Mostrar el UserAgent y la IP actual del navegador en la página web.
