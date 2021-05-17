namespace diary
{
    using diary.Models.Configurations;
    using diary.Models.Domains;
    using diary.Properties;
    using System.Data.Entity;
    
   
    public class ApplicationDbContext : DbContext
    {

        
        private static string _connectionString = $@"
            Server={Settings.Default.ServerAdress}\{Settings.Default.ServerName};
             Database={Settings.Default.DataBaseName};
             User Id={Settings.Default.UserName};
              Password={Settings.Default.UserPassword};";

        
       

        public ApplicationDbContext() : base(_connectionString)
        { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Rating> Ratings { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StudentConfigurations());
            modelBuilder.Configurations.Add(new GroupConfigurations());
            modelBuilder.Configurations.Add(new RatingConfigurations());
           
        }
        
    }

    
}