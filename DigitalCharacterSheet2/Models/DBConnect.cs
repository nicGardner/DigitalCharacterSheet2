namespace DigitalCharacterSheet2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBConnect : DbContext
    {
        public DBConnect()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<attribute> attributes { get; set; }
        public virtual DbSet<character> characters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<attribute>()
                .Property(e => e.characterName)
                .IsUnicode(false);

            modelBuilder.Entity<attribute>()
                .Property(e => e.attributeName)
                .IsUnicode(false);

            modelBuilder.Entity<character>()
                .Property(e => e.character_name)
                .IsUnicode(false);

            modelBuilder.Entity<character>()
                .Property(e => e.campaign)
                .IsUnicode(false);

            modelBuilder.Entity<character>()
                .HasMany(e => e.attributes)
                .WithRequired(e => e.character)
                .HasForeignKey(e => e.characterName)
                .WillCascadeOnDelete(false);
        }
    }
}
