using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace STFCLibrary.Sqlite.Entities;

public class Trait : BaseTable<Trait>, IEntityTypeConfiguration<Trait>
{
    /// <summary>
    /// Formal description, in game, of the officer.
    /// This should never be empty. If this is empty the JSON reading was incomplete.
    /// </summary>
    
    public int OfficerId { get; set; }
    public int Tier { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
    public int TraitXp { get; set; }

    public override void Configure(EntityTypeBuilder<Trait> modelBuilder)
    {
        modelBuilder.HasIndex(k => k.Name).IsUnique(true);
    }
}