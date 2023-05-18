using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PMT.API.Model;

namespace PMT.API.Data
{
    public class PMTrackerContext :DbContext
    {
        protected readonly IConfiguration Configuration;
        public PMTrackerContext()
        {
            
        }
        public PMTrackerContext(DbContextOptions<PMTrackerContext>  dbContextOptions): base(dbContextOptions)
        {
            
        }

        public PMTrackerContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //  optionsBuilder.UseSqlServer("Server=CTSDOTNET973; Database=ProjectManagement; User ID=sa; Password=pass@word1;Trusted_Connection=true;TrustServerCertificate=True");
            IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
            var connectionString = configuration.GetConnectionString("ProductDB");
            optionsBuilder.UseSqlServer(connectionString);

        }
        public DbSet<MemberDetail> MemberDetails { get; set; }
        public DbSet<MemberTaskDetail> MemberTaskDetails { get; set; }
    }
}
