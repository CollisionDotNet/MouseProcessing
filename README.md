# MouseProcessing
Web-приложение для сбора информации об изменении положения мыши. Стек: ASP.NET Core Web API, MS SQL Server, Entity Framework, HTML, CSS, JavaScript

## О проекте и развертывании

Приложение состоит из трех частей, каждая из которых обернута в контейнер Docker для удобства развертывания. Запуск осуществляется при помощи [Docker Compose](docker-compose.yml).

### frontend 
Реализован в виде ASP.NET Core приложения с [HTML-страницей](MouseProcessing.Client/wwwroot/index.html) и [привязанным JS-скриптом](MouseProcessing.Client/wwwroot/js/mousetracker.js), отслеживающим перемещение мыши.

Рабочая директория: [/MouseProcessing.Client](MouseProcessing.Client).

Порты контейнера mouseprocessing.client в Docker: 5000:5000.

### backend 
Реализован в виде ASP.NET Core Web API приложения, который принимает собранные данные, сохраняет их в базу и возвращает результат операции. Спроектирован согласно принципам DDD и Clean Architecture. 

Рабочие директории определены на основе деления проекта на слои по Clean Architecture:
[/MouseProcessing.Domain](MouseProcessing.Domain)
[/MouseProcessing.Application](MouseProcessing.Application)
[/MouseProcessing.Infrastructure](MouseProcessing.Infrastructure)
[/MouseProcessing.API](MouseProcessing.API)

С методами-действиями контроллера по работе с REST API запросами можно ознакомиться в Swagger.

Порты контейнера mouseprocessing.api в Docker: 8080:8080.

### База данных 
БД cursordb развернута на MS SQL Server 2022, образ mcr.microsoft.com/mssql/server:2022-latest. Имеет единственную таблицу CursorInfos со схемой (uniqueidentifier Id, int X, int Y, datetime2(7)).

Порты контейнера mouseprocessing.database в Docker: 1433:1433.

## О ТЗ
В ТЗ была описана необходимость сбора информации о движении мыши через JS скрипт в ASP.NET Core приложении, однако далее было указано, что при нажатии на кнопку данные должны "отправляться на бекенд". По этой причине я разделил приложение на фронт (ASP.NET Core + HTML, CSS, JS) и бек с обработкой переданных данных (ASP.NET Core Web API). 

Также отмечу, что если трактовать условие "массив ... должен сохраняться через Entity в таблицу произвольной базы данных в формате json" прямо, то данные будут храниться в реляционной БД в виде JSON, что крайне неоптимально. JSON должен в первую очередь применяться для передачи данных между фронтом и беком. В БД данные хранятся в формате Guid (Id замера), int (X), int (Y), DateTime (дата и время замера). 
