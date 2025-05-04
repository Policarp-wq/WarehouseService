# WarehouseService
## Сервис для склада.
Предоставляет базовый функционал для осуществелния управления складами и предметами между ними.
**Пагинация внутри системы отстуствует! Поэтому при большом объёме данных будут просадки**
## Архитектура

- **Чистая архитектура ** с разделением на:
  - `Application` — интерфейсы, DTO, бизнес-логика
  - `Domain` — сущности
  - `Infrastructure` — реализация репозиториев, доступ к БД
  - `Web` (или `API`) — minimal api
 
## Используется
- **PostgreSQL** — основная база данных.
- **Redis** — кеширование вместимости складов.
- **EF Core** — ORM для работы с данными.

Также реализован [глобальный обработчик ошибок](https://github.com/Policarp-wq/WarehouseService/blob/master/WarehouseService.AppHost/Middleware/GlobalExceptionHandler.cs)

## [Сущности](https://github.com/Policarp-wq/WarehouseService/tree/master/WarehouseSevice.Domain/Entities)
- Warehouse
Содержит информацию об адресе и владельце склада.
- Item
Содержит инфомрацию о наименовании предмета, размерах, на каком складе в текущий момент находится (при этом если предмет перемещается, то значение может отсутствовать). Также содержит статус и категорию.
- Employee
Хранит имя и фамилию, склад, к которому прикреплён, а также позицию. Позиция нужна для идентификации и предоставления доступа к функционалу
Полное представление указано на диаграмме
![Diagram 1](https://github.com/user-attachments/assets/f49706ec-47e9-440a-8d6f-7156f406cb9a)
## Сервисы
### WarehouseService
Управление складами и логикой перемещения товаров:

- `CreateWarehouse(WarehouseInfo info)`  
  Создание нового склада.

- `DeleteWarehouse(int warehouseId)`  
  Удаление склада по ID.

- `CreateItem(ItemCreateInfo info)`  
  Создание нового товара и размещение на складе (с проверкой вместимости).

- `AcceptItem(AcceptShipment shipment)`  
  Приёмка существующего товара на склад.

- `ReleaseItem(ReleaseShipment shipment)`  
  Перемещение товара на другой склад (с проверкой вместимости).

- `AllocateItem(int itemId, string sector)`  
  Назначение сектора хранения для товара.

- `GetOwner(int warehouseId)`  
  Получение сотрудника-владельца склада (если есть).

- `GetFullness(int warehouseId)`  
  Получение текущей загруженности склада 

---

### EmployeeService
Создание и управление работниками:

- `CreateEmployee(EmployeeInfo info)`  
  Создание сотрудника. Проверка: на складе может быть только один владелец.

- `UpdatePosition(PositionUpdateInfo info)`  
  Обновление должности сотрудника (с проверкой владельца).

- `UpdateWarehouseWork(WarehouseWorkUpdateInfo info)`  
  Перевод сотрудника на другой склад (если это не нарушает правило об одном владельце).

---

### ItemService
Фильтрация и управление товарами:

- `GetItemFullInfo(int itemId)`  
  Получение полной информации о товаре.

- `GetItemsByCategory(ItemCategory category)`  
  Получение товаров по категории.

- `GetItemsByCategoryFromWarehouse(ItemCategory category, int warehouseId)`  
  Получение товаров по категории и складу.

- `GetItemsFromWarehouse(int warehouseId)`  
  Список ID всех товаров на складе.

- `UpdateStatus(int itemId, ItemStatus status)`  
  Обновление статуса товара.

## Планы на реализацию
- Авторизация и аутентификация полльзователей через JWT
- Оптимизация запросов и пагинация
- Кеширование часто используемых данных
- Минимизация хардокиднга (перенос строк подключения в опции и глобальные переменные)
- Добавление проверок здоровья для БД и Redis

## Эндпоинты
![image](https://github.com/user-attachments/assets/cbf475a9-fec0-43a3-afe9-3ace4f6e7575)

