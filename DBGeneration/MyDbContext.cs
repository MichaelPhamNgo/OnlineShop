using DBGeneration.Entities;
using MySql.Data.Entity;
using System.Data.Entity;

namespace DBGeneration
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("name=OSConnectionString")
        {
            
        }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<SystemConfig> SystemConfigs { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<MenuType> MenuTypes { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<ContentTag> ContentTags { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Action> Actions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AboutConfigurations());
            modelBuilder.Configurations.Add(new ActionConfigurations());
            modelBuilder.Configurations.Add(new CategoryConfigurations());
            modelBuilder.Configurations.Add(new ContactConfigurations());
            modelBuilder.Configurations.Add(new ContentConfigurations());
            modelBuilder.Configurations.Add(new FeedbackConfigurations());
            modelBuilder.Configurations.Add(new FooterConfigurations());
            modelBuilder.Configurations.Add(new FunctionConfigurations());
            modelBuilder.Configurations.Add(new MenuConfigurations());
            modelBuilder.Configurations.Add(new ProductConfigurations());
            modelBuilder.Configurations.Add(new ProductCategoryConfigurations());
            modelBuilder.Configurations.Add(new SlideConfigurations());
            modelBuilder.Configurations.Add(new StateConfigurations());
            modelBuilder.Configurations.Add(new SystemConfigConfigurations());
            modelBuilder.Configurations.Add(new TagConfigurations());
            modelBuilder.Configurations.Add(new UserConfigurations());
            modelBuilder.Configurations.Add(new UserGroupConfigurations());
            modelBuilder.Configurations.Add(new RoleConfigurations());
            modelBuilder.Configurations.Add(new CredentialConfigurations());
        }
    }
}
