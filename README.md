# Prueba de conocimiento en .NET

## Introducción

> Es importante para nosotros demostrar el conocimiento aprendido en las plataformas de .NET.
Nuestra empresa ha trabajado durante años sobre esta plataforma y consideramos importantes los conocimientos basicos para poder iniciar de manera proactiva las labores en nuestra representada.

## Ejercicio

• Crear un proyecto web MVC en NET 5.

• Consumir el servicio descrito en #Servicios a consumir utilizando la libreria RestSharp. Parsear la respuesta usando Newtonsoft Json.NET.

• Crear un segundo proyecto para guardar la logica de negocio y agregar la referencia al proyecto web.
En este proyecto debe estar el consumo al servicio, 
las clases de los objetos para la serialización de los datos que vienen en el servicio y que el metodo retorne toda la data.

• En la interfaz, agregar un boton que obtenga la información del servicio y lo muestre en el HTML.

• Usar LINQ (Lambda) en caso de ser necesario ejemplo: var _Results = _List.Where(x => x.Value == 1);

---------------------------------------------
Opcional:
Crear un segundo proyecto que haga exactamente lo mismo pero que sea Blazor Server y que consuma la libreria.
Se puede agregar en el mismo solution.

## Servicios a consumir

• Posts: https://jsonplaceholder.typicode.com/posts

• Comentarios: https://jsonplaceholder.typicode.com/comments

• Users: https://jsonplaceholder.typicode.com/users

## Bonus

• Para el endpoint de los comentarios, el campo *body* mostrarlo en el sitio con la letra mayuscula en cada palabra.


