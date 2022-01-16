using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace STFCLibrary.Sqlite.Entities;

public class Rank : BaseTable<Rank>, IEntityTypeConfiguration<Rank>
{
    /// <summary>
    /// Formal description, in game, of the officer.
    /// This should never be empty. If this is empty the JSON reading was incomplete.
    /// </summary>

    public double AbilityValue { get; set; }
    public int Badges { get; set; }
    public int Credits { get; set; }
    public int Shards { get; set; }
    public int Xp { get; set; }

    public int ActiveNanoprobe { get; set; } = 0;

    public override void Configure(EntityTypeBuilder<Rank> modelBuilder)
    {
        modelBuilder.HasIndex(k => k.Name).IsUnique(true);
    }
}