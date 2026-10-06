using Globomantics.Domain.Models;
using Globomantics.Infrastructure.Data;
using Globomatics.Infrastructure.Interfaces.Repositories;
using Globomatics.Infrastructure.Repositories;
using Globomatics.Web.Constraints;
using Globomatics.Web.Transformers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(options =>
{
    options.ConstraintMap["validateSlug"] = typeof(SlugConstraint);
    options.ConstraintMap["validateTransform"] = typeof(SlugParameterTransformer);
});

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<GlobomanticsContext>(ServiceLifetime.Scoped);
builder.Services.AddTransient<IRepository<Cart>, CartRepository>();
builder.Services.AddTransient<ICartRepository, CartRepository>();
builder.Services.AddTransient<IRepository<Customer>, CustomerRepository>();
builder.Services.AddTransient<IRepository<Order>, OrderRepository>();
builder.Services.AddTransient<IRepository<Product>, ProductRepository>();

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Initialize database, creating the necessary migrations.
// To be able to resolve a service first create a scope.
// Resolve the dbContext, which is a scoped type.
// `Using` to dispose of scope. ServiceProvider is our collection of services.
// Previously registered: GetRequiredService().
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<GlobomanticsContext>();
    GlobomanticsContext.CreateInitialDatabase(context);
}
app.Run();