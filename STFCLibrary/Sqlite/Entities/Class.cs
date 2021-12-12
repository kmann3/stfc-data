using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace STFCLibrary.Sqlite.Entities
{
    internal class Class : BaseTable<Class>, IEntityTypeConfiguration<Class>
    {
        /// <summary>
        /// Formal description, in game, of the officer.
        /// This should never be empty. If this is empty the JSON reading was incomplete.
        /// </summary>

        public override void Configure(EntityTypeBuilder<Class> modelBuilder)
        {
            modelBuilder.HasIndex(k => k.Name).IsUnique(true);
        }
    }
}
