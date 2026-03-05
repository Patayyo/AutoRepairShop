AutoRepairShop API

REST API для учета обслуживания автомобилей в автосервисе.



Возможности:

* управлять автомобилями
* управлять типами работ
* вести историю обслуживания автомобилей



Слои:

* Domain - сущности и бизнес-модели
* Application - сервисы и бизнес-логика
* Infrastructure - работа с БД
* Web - Web API



Запуск проекта



1. Клонировать репозиторий



git clone https://github.com/Patayyo/AutoRepairShop.git



2\. Применить миграции

dotnet ef database update

или

dotnet ef database update --project "AutoRepairShop.Infrastructure\\AutoRepairShop.Infrastructure.csproj" --startup-project "AutoRepairShop\\AutoRepairShop.Web.csproj"


3\. Запустить приложение
dotnet run --project AutoRepairShop\\AutoRepairShop.Web.csproj 



Swagger



Доступен по адресу:

http://localhost:5259/swagger 

