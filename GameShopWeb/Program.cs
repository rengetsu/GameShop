/*
 *  File responsible for running the application.
 *  Initializes a new instance of the WebApplicationBuilder
 *  class with preconfigured defaults.
 *  Here we can pass custom arguments if we need
 */
var builder = WebApplication.CreateBuilder(args);

/*
 *  Here we add services to the container.
 *  We are addings services to the container because we are using MVC application.
 *  If we will using RazorPages, than the services will be different.
 */
builder.Services.AddControllersWithViews();

/*
 * Add razor pages with  runtime compilation from nuget package
 */
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

/*
 *  Before builder.Build() we can register anything that have dependency injection container.
 *  So if we want to register as example our database,email or anything else,
 *  we will do it between creating builder and builder.Build.
 */
var app = builder.Build();

/*
 * Everything from here before .NET 6 was a configure method.
 */

/*
 * Configure the HTTP request pipeline.
 * First we checking if it currently in development or not. If it is we adding UseExceptionHandlers.
 * It will show you user-friendly exceptions, so that we can debug and solve them.
 */
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

/*
 * Next we adding different layers (middlewares) to our pipilene.
 * Pipeline will be in what order we added these layers (middlewares).
 */
app.UseHttpsRedirection();  //  Pipeline middleware for redirecting HTTP requests to HTTPS
app.UseStaticFiles();       //  Pipiline middleware to use our static files in wwwroot folder

app.UseRouting();

/*
 * Authentication and authorization.
 * Authentication always must come before authorization, because you can authorizate only authenticated users.
 */
app.UseAuthentication();
app.UseAuthorization();


//  Redirect our request to corresponding controller.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
