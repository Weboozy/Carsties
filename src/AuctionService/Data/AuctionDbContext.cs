﻿using AuctionService.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Data.Migrations;

public class AuctionDbContext : DbContext
{
  public AuctionDbContext(DbContextOptions options) : base(options)
  {
    
  }
  public DbSet<Auction> Auctions {get;set;}
}
