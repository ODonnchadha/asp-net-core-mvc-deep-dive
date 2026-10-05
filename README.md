## ASP.NET Core MVC Deep Dive by Philip Ekberg.

- OVERVIEW:
    - Dependency injection, logging and get an in-depth understanding of routing. Model binding, input sanitation, razor, as well as all about working with data and the views. Manage state, work with filters and understand middleware. Prerequisites: C#.

- GETTING STARTED:
    - Version Check: C# 12. .NET 8. Visual Studio 2022.
    - MVC Pattern.
        - View: UI representation. Intereacts with the controller.
        - Controller: Methods.
        - Model:
    - HTTP is a stateless protocol.
        - Sessions:
        - Cookies:
    - Globomantics.Domain: Data representation. E-commerce.
    - NOTE: SQLite does not support DateTimeOffset. Ensure DateTime is stored in UTC.
    - Globomantics.Infrastructure:
        - Context. EF Core. DBSet.
        - Repositories: GenericRepository<T>
    - Globomantics.Web: Areas. Attributes. View components.

- ROUTING:

- WORKING WITH VIEWS:

- WORKING WITH MODELS AND DATA:

- WORKING WITH STATE:

- FILTERS AND MIDDLEWARE:

- FINISHING UP: