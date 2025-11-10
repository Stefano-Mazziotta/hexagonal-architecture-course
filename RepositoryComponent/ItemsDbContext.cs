using Microsoft.EntityFrameworkCore;
using RepositoryComponent.Models;

namespace RepositoryComponent
{
    public class ItemsDbContext : DbContext
    {
        public DbSet<ItemModel> ItemsModel { get; set; }
        public DbSet<NoteModel> NotesModel { get; set; }

        public ItemsDbContext(DbContextOptions<ItemsDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemModel>().ToTable("Items");
            modelBuilder.Entity<NoteModel>().ToTable("Notes")
                .HasOne(n => n.Item)
                .WithMany(i => i.Notes)
                .HasForeignKey(n => n.ItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
