# Учёт книг в библиотеке
Десктопное приложение на WPF для отслеживания выдачи книг в библиотеке. Реализует операции CRUD, поиск, фильтрацию и сортировку данных в базе SQL Server с использованием Entity Framework.

## Возможности
- Выдача книги читателю
- Редактирование и удаление записей
- Отметка возврата книги (автоматически освобождает книгу для повторной выдачи)
- Поиск по имени читателя
- Фильтр должников (книги, не возвращённые на текущий момент)
- Сортировка по дате выдачи

## Стек технологий
- WPF (.NET Framework 4.7.2)
- Entity Framework 5
- SQL Server

## Структура проекта
```text
├── DatabaseScripts/           	# SQL-скрипты для базы данных
│   ├── script.sql              # Скрипт создания таблиц БД
│   └── seed.sql                # Скрипт заполнения базы тестовыми данными
├── LibraryManager/
│   ├── ADO/                  	# Слой работы с базой данных (Entity Framework)
│   │   ├── Model1.edmx
│   │   ├── AppData.cs        	# Класс для централизованного доступа к контексту БД
│   │   ├── Book.cs           	# Модель книги
│   │   └── IssuedBook.cs      	# Модель выданной книги
│   ├── Views/
│   │   ├── DataPage.xaml
│   │   ├── IssueBookPage.xaml
│   │   └── EditIssuedBookPage.xaml
│   ├── App.config
│   ├── App.xaml
│   └── MainWindow.xaml
├── LibraryManager.slnx
└── README.md
```

## Запуск
1. Клонировать репозиторий
2. Открыть `LibraryManager.slnx`
3. Восстановить пакеты NuGet (`Restore NuGet Packages`).
4. В SQL Server создать базу данных `LibraryDB` и выполнить скрипт из папки [`DatabaseScripts/script.sql`](DatabaseScripts/script.sql).
5. Для быстрой проверки поиска и фильтров выполните скрипт с тестовыми данными [`DatabaseScripts/seed.sql`](DatabaseScripts/seed.sql).
6. В файле LibraryManager/App.config при необходимости обновить имя сервера в строке подключения (data source)
