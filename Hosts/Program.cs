using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Simple.Loan.App.DataStores;
using Simple.Loan.App.DataStores.DbContexts;
using Simple.Loan.App.Providers.Customer;
using Simple.Loan.App.Providers.FileStore;
using Simple.Loan.App.Providers.Option;
using Simple.Loan.App.ServiceLogics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDataStores(builder.Configuration);
builder.Services.AddServiceLogics();
builder.Services.AddControllers();
builder.Services.AddCustomerEFCoreProvider(builder.Configuration);
builder.Services.AddFileStoreEFCoreProvider(builder.Configuration);
builder.Services.AddOptionEFCoreProvider(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// In production, the React files will be served from this directory
builder.Services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/build"; });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseSpaStaticFiles();
app.UseHttpsRedirection();

app.MapControllers();

app.UseSpa(spa =>
{
    spa.Options.SourcePath = "ClientApp";

    if (builder.Configuration["Environment"] == "Local") spa.UseReactDevelopmentServer("start");
});


#if DEBUG
using (var scope = app.Services.CreateScope())
{
    new List<DbContext>
    {
        scope.ServiceProvider.GetRequiredService<LoanApplicationDbContext>(),
        scope.ServiceProvider.GetRequiredService<CustomerDbContext>(),
        scope.ServiceProvider.GetRequiredService<FileDbContext>(),
        scope.ServiceProvider.GetRequiredService<OptionDbContext>()
    }.ForEach(ctx => ctx.Database.Migrate());
}
#endif

app.Run();
