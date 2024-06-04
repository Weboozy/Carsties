using AuctionService.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Data.Migrations;

public class DbInitializer
{

  public static void InitDb(WebApplication app){
    using (var scope = app.Services.CreateScope()){
      SeedData(scope.ServiceProvider.GetService<AuctionDbContext>());
    }
  }
  private static void SeedData(AuctionDbContext context){
    context.Database.Migrate();
    if(context.Auctions.Any()){
      Console.WriteLine("Already have data - no need to seed");
      return;
    }
    var auction  = new List<Auction>(){
      new Auction(){
        Id = Guid.NewGuid(),
        Status = Status.Live,
        ReservePrice = 20000,
        Seller = "Bob",
        AuctionEnd = DateTime.UtcNow.AddDays(10),
        Item = new Item(){
          Make = "Ford",
          Model = "GT",
          Color = "White",
          Mileage = 40032,
          Year = 2020,
          ImageUrl = "no have url"
        }
      },
      new Auction(){
        Id = Guid.NewGuid(),
        Status = Status.Finished,
        ReservePrice = 15000,
        Seller = "Tomas",
        AuctionEnd = DateTime.UtcNow.AddDays(-10),
        Item = new Item(){
          Make = "Doddge",
          Model = "AB",
          Color = "Black",
          Mileage = 2032,
          Year = 2022,
          ImageUrl = "no have url"
        }
      }
    };
    context.Auctions.AddRange(auction);
    context.SaveChanges();

  }
}
