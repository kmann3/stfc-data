using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace STFCLibrary.Sqlite.Entities;

public class Group : BaseTable<Group>, IEntityTypeConfiguration<Group>
{
    /// <summary>
    /// Formal description, in game, of the officer.
    /// This should never be empty. If this is empty the JSON reading was incomplete.
    /// </summary>

    public override void Configure(EntityTypeBuilder<Group> modelBuilder)
    {
        modelBuilder.HasIndex(k => k.Name).IsUnique(true);
    }
}
