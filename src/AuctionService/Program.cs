using AuctionService.Data;
using AuctionService.Data.Migrations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<AuctionDbContext>(opt=>{
  opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});



var app = builder.Build();


app.UseAuthorization();

app.MapControllers();

try{
  DbInitializer.InitDb(app);
}
catch(Exception e){
  Console.WriteLine(e);
}
app.Run();
