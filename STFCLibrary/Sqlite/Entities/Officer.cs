using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace STFCLibrary.Sqlite.Entities;

internal class Officer : BaseTable<Officer>, IEntityTypeConfiguration<Officer>
{
    /// <summary>
    /// Formal description, in game, of the officer.
    /// This should never be empty. If this is empty the JSON reading was incomplete.
    /// </summary>

    public override void Configure(EntityTypeBuilder<Officer> modelBuilder)
    {
        modelBuilder.HasIndex(k => k.Name).IsUnique(true);
    }
}
