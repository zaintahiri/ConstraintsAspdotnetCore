var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints => {
    // here you are applying int constraint on id parameter
    endpoints.MapGet("/Products/{id:int}", async (context) =>
    {
        // we will use RoutValues, not Query.
        var id=context.Request.RouteValues["id"];
        await context.Response.WriteAsync($"Contraint is applied on ID {id}");
    });

    // here you are applying alpha constraint on productname parameter
    // it will not accept any letter other than alpha
    endpoints.MapGet("/Products/{productname:alpha}", async (context) =>
    {
        // we will use RoutValues, not Query.
        var productname = context.Request.RouteValues["productname"];
        await context.Response.WriteAsync($"Your selected Product is: {productname}");
    });

    // you can add more constraints if you want to add, bool, double, decimal etc

    // alpha, minlength, and maxlength
    endpoints.MapGet("/Authors/{authorname:alpha:minlength(3):maxlength(12)}", async (context) =>
    {
        // we will use RoutValues, not Query.
        var authorname = context.Request.RouteValues["authorname"];
        await context.Response.WriteAsync($"Your selected authorname is: {authorname}");
    });

    // you can use following pattern instead of using minlength and maxlength
    endpoints.MapGet("/Books/{bookname:alpha:length(4,12)}", async (context) =>
    {
        // we will use RoutValues, not Query.
        var bookname = context.Request.RouteValues["bookname"];
        await context.Response.WriteAsync($"Your selected bookname is: {bookname}");
    });

    // if you want to match exact length you can use length(13)
    endpoints.MapGet("/Users/{cnic:decimal:length(13)}", async (context) =>
    {
        // we will use RoutValues, not Query.
        var cnic = context.Request.RouteValues["cnic"];
        await context.Response.WriteAsync($"SELECTED CNIC OF USER IS : {cnic}");
    });

    endpoints.MapGet("/Employees/{salary:int:min(10000):max(30000)}", async (context) =>
    {
        // we will use RoutValues, not Query.
        var salary = context.Request.RouteValues["salary"];
        await context.Response.WriteAsync($"Employees salary is : {salary}");
    });

    // you can replace above with following code using range(10000,30000)
    endpoints.MapGet("/Arrears/{arear:int:range(10000,30000)}", async (context) =>
    {
        // we will use RoutValues, not Query.
        var arear = context.Request.RouteValues["arear"];
        await context.Response.WriteAsync($"Employees arears are : {arear}");
    });

    endpoints.MapGet("/quarterly-reports/{year:int:min(1999)}/{month:regex(^jun|sep|dec|$)}", async (context) =>
    {
        // we will use RoutValues, not Query.
        var year = context.Request.RouteValues["year"];
        string? month= Convert.ToString(context.Request.RouteValues["month"]);
        await context.Response.WriteAsync($"Report is {year}-{month}");
    });

    endpoints.MapGet("/monthly-reports/{month:regex(^([0-9]|1[012])$)}", async (context) =>
    {
        // we will use RoutValues, not Query.
        string? month = Convert.ToString(context.Request.RouteValues["month"]);
        await context.Response.WriteAsync($"Monthly report is {month}");
    });

});

app.Run(async(HttpContext context) => {
    await context.Response.WriteAsync("HI, welcome to ASP.NET PAGE");
});
app.Run();
