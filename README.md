## ASP.NET Core MVC Deep Dive by Philip Ekberg

- OVERVIEW:
    - Dependency injection, logging and get an in-depth understanding of routing. Model binding, input sanitation, razor, as well as all about working with data and the views. Manage state, work with filters and understand middleware. Prerequisites: C#.

- GETTING STARTED:
    - Version Check: C# 12. .NET 8. Visual Studio 2022.
    - MVC Pattern.
        - View: UI representation. Intereacts with the controller.
        - Controller: Methods.
        - Model:
            - Could be identical to a domain model, contain a subset, or be an aggregation.
            - Should only expose data used by a view.
            - Limit what data is allowed to be passed in by an HTTP request.
    - HTTP is a stateless protocol.
        - Sessions:
        - Cookies:
    - Globomantics.Domain: Data representation. E-commerce.
    - NOTE: SQLite does not support DateTimeOffset. Ensure DateTime is stored in UTC.
    - Globomantics.Infrastructure:
        - Context. EF Core. DBSet.
        - Repositories: GenericRepository<T>
    - Globomantics.Web: Areas. Attributes. View components.
        - Scaffolding is the process of generating code.
        - The IActionResult return type is appropriate when multiple ActionResult return types are possible in an action.
        - The ActionResult types represent vasious HTTP status codes.
        - Calling View() produces a ViewResult with HTML and a 200 OK response code.
        - View Discovery:
            - Views/{controller}/{ViewName}.cshtml
                - CustomerController.Create() => Views/Customers/Create.cshtml
            - Views/Shared/{viewName}.cshtml
                - CustomerController.Create() => Views/Shared/Create.cshtml
            - Custom locations supported through IViewLocationExpander.
        - ASP.NET Core will match as incoming HTTP request to a specific endpoint (Controller + Action) using a URL matching (Routing.)
        - Asynchronous programming in ASP.NET Core can greatly help with scalability if used correctly.
    - Logging:
        - ILogger<T>. Generic parameter defines the category, providing further information to the logged data.
        - Log providers: Console or debug. EventSource or Windows EventLog. Azure App Service.
            - Third-party providers: Serilog. Sentry. NLog. Log4Net.
            - Built-in by default.
    - Index. Default on a Web server.

- ROUTING:
    1. HTTP Request
    2. URL Match to Route
    3. Map data from the request (URI segments, query parameters, headers, etc.)
    4. Invoke Endpoint (Action on the controller.)
    ```csharp
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
    ```
    - Allow any controller name and its actions to be invoked with an optional id.
    - Default controller is Home unless specified.
    - Allow any controller and its actions to be executed with a `/v2` path in the beginning.
    - [Route] attribute. Tag helpers use route details to perform a URL generation.
    - Optional parameters in routes. Nullable types.
        - Any controller and any action on that controller may have an optional id parameter specified in the URI.
        ```csharp
            app.MapControllerRoute(
                name: "ticketDetailsRoute",
                defaults: new { action = "TicketDetails", controller = "Home" }
                pattern: "/details/{productId}/{slug?}");
        ```
        - Map URI parameter productId and optionally slug into matching parameters on the action method.
        ```csharp
            [Route("/details/{productId}/{slug}")]
            public IActionResult TicketDetails(Guid productId, string slug)
        ```
    - Route constraint.
        ```csharp
            [Route("/details/{productId:guid}/{slug}")]
        ```
        - Examples: Integer. Valid DateTime. Character length. Integer range. Alaphabetical characters.
    - Custom constraints with `IRouterConstraint.` Validation. Pattern. Alpha-numeric.
        ```csharp
            builder.Services.AddRouting(options =>
            {
                options.ConstraintMap["validateSlug"] = typeof(SlugConstraint);
            });
        ```
        ```csharp
            [Route("/details/{productId:guid}/{slug:validateSlug}")]
        ```
    - NOTE: The route constraint is *also* onvoked when generating the URL.
        - e.g.: Within anchor tag helpers.
        - If not a match, tag helper will not generate *that* URL.
    - Transformer.

- WORKING WITH VIEWS:

- WORKING WITH MODELS AND DATA:

- WORKING WITH STATE:

- FILTERS AND MIDDLEWARE:

- FINISHING UP: