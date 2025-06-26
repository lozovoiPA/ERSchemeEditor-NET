using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using static System.Windows.Forms.AxHost;

namespace ErEditorProject
{
    public class ErSchemaDbContext : DbContext
    {
        public DbSet<DbEntitySet> entitySets { get; set; }
        public DbSet<DbRelationshipSet> relationshipSets { get; set; }
        public DbSet<DbValueSet> valueSets { get; set; }
        public DbSet<DbAttribute> attributes { get; set; }
        public DbSet<DbRole> roles { get; set; }

        private readonly string dbFullPath = "";

        private List<DbElement> inMemory;
        private Dictionary<int, ErElement> inMemoryIdMap;

        public ErSchemaDbContext(string _dbFullPath)
        {
            dbFullPath = _dbFullPath;
            inMemory = new List<DbElement>();
            inMemoryIdMap = new Dictionary<int, ErElement>();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=" + dbFullPath);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbElement>().UseTptMappingStrategy();
            modelBuilder.Entity<DbElement>()
                .Property(el => el.name)
                .HasDefaultValue(String.Empty);
            modelBuilder.Entity<DbAttribute>()
                .Property(el => el.isKey)
                .HasDefaultValue(false);
            modelBuilder.Entity<DbRole>()
                .Property(el => el.IdDependency)
                .HasDefaultValue(false);
            modelBuilder.Entity<DbRole>()
                .Property(el => el.isKey)
                .HasDefaultValue(false);
        }
    }

    public abstract class DbElement
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; } = null!;
    }

    public abstract class DbAttributeAllowingElement : DbElement
    {
        public virtual ObservableCollectionListSource<DbAttribute> attributes { get; set; } = new();
    }

    [Table("Entity Sets")]
    public class DbEntitySet : DbAttributeAllowingElement
    {
        public virtual ObservableCollectionListSource<DbRole> roles { get; } = new();
    }

    [Table("Relationship Sets")]
    public class DbRelationshipSet : DbAttributeAllowingElement
    {
        public virtual ObservableCollectionListSource<DbRole> roles { get; set; } = new();
    }

    [Table("Value Sets")]
    public class DbValueSet : DbElement
    {
        public virtual ObservableCollectionListSource<DbAttribute> attributes { get; } = new();
    }

    [Table("Attributes")]
    public class DbAttribute : DbElement
    {
        public int parentId { get; set; }
        public virtual DbAttributeAllowingElement parent { get; set; } = null!;

        // Не нотация Чена :V
        public double? minValue { get; set; }
        public double? maxValue { get; set; }
        public string? allowedValues { get; set; }
        public bool isKey { get; set; }

        public virtual ObservableCollectionListSource<DbValueSet> valueSets { get; set; } = new();
    }
    
    //[PrimaryKey(nameof(entitySetId), nameof(relationshipSetId))]
    [Table("DbEntitySetDbRelationshipSet")]
    public class DbRole : DbElement
    {
        public int entitySetId { get; set; }
        public virtual DbEntitySet entitySet { get; set; } = null!;
        public int relationshipSetId { get; set; }
        public virtual DbRelationshipSet relationshipSet { get; set; } = null!;

        public int? minCardinalityOfImage { get; set; }
        public int? maxCardinalityOfImage { get; set; }
        public int? minCardinalityOfPreimage { get; set; }
        public int? maxCardinalityOfPreimage { get; set; }
        public bool IdDependency { get; set; }
        public bool isKey { get; set; }
    }
}
