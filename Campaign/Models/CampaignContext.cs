using Microsoft.EntityFrameworkCore;

namespace Campaign.Models
{
  public class CampaignContext : DbContext
  {
    public DbSet<Operation> Operations { get; set; }
    public DbSet<Mission> Missions { get; set; }

    public CampaignContext(DbContextOptions options) : base(options) { }
  }
}
