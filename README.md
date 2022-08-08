# Grupo 16
Este es el repositorio del *Grupo 16*, cuyos integrantes son:

* Diego Saa 
* Amanda Salinas 
* Matias Vargas 
* **Tutor**: Ibet Lara

## Wiki

Puede acceder a la Wiki mediante el siguiente [enlace](https://gitlab.labcomp.cl/wladimir.ormazabal.ex/pruebas-asignatura/-/wikis/inicio)

## Videos

* [Video presentación final](https://drive.google.com/file/d/1X4Phn2VVGvDbDZ2l15d36Sjd5EwXb-5s/view)

## Aspectos técnicos relevantes

*Por ejemplo, como poder levantar el proyecto, etc...*

El proyecto de ejemplo se baso en la documentación disponible en:

* [MVC Core](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-5.0&tabs=visual-studio-code)
* [.Net Core + Docker](https://code.visualstudio.com/docs/containers/quickstart-aspnet-core)

Desarrollado con [Docker](https://www.docker.com/) y complementos de [Visual Studio Code](https://code.visualstudio.com/)

**Importante:** Requiere tener [Docker](https://www.docker.com/) instalado. Para levantar el proyecto ejecutar los siguientes pasos:
1. ```docker-compose -f docker-compose.yml build --no-cache```
2. ```docker-compose -f docker-compose.yml up -d```
3. Acceder a http://localhost:5000/

Puede validar la creación de la imagen y contenedor:

1. ```docker images```
2. ```docker ps -a```
