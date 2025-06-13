//// File: DAL/ApplicationDbContext.cs

//using Microsoft.EntityFrameworkCore;
//using DAL.Models;

//namespace DAL
//{
//    public class ApplicationDbContext : DbContext
//    {
//        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
//        {
//        }

//        public DbSet<Prompt> Prompts { get; set; } = null!;
//        public DbSet<Category> Categories { get; set; } = null!;
//        public DbSet<SubCategory> SubCategories { get; set; } = null!;
//        public DbSet<User> Users { get; set; } = null!;

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            base.OnModelCreating(modelBuilder);

//            modelBuilder.Entity<Prompt>().ToTable("Prompts");
//            modelBuilder.Entity<Category>().ToTable("Categories");
//            modelBuilder.Entity<SubCategory>().ToTable("SubCategories");
//            modelBuilder.Entity<User>().ToTable("Users");

//            modelBuilder.Entity<Prompt>()
//                .Property(p => p.Prompt1)
//                .HasColumnName("Prompt");

//            // Define relationships if not handled by convention
//            // modelBuilder.Entity<Prompt>()
//            //     .HasOne(p => p.Category)
//            //     .WithMany() // Or WithMany(c => c.Prompts) if you have a collection in Category
//            //     .HasForeignKey(p => p.CategoryId);

//            // modelBuilder.Entity<Prompt>()
//            //     .HasOne(p => p.SubCategory)
//            //     .WithMany()
//            //     .HasForeignKey(p => p.SubCategoryId);

//            // modelBuilder.Entity<Prompt>()
//            //     .HasOne(p => p.User)
//            //     .WithMany()
//            //     .HasForeignKey(p => p.UserId);
//        }
//    }
//}
