using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MannSTFCTools.Sqlite
{
    public class Officer : BasicTable<Officer>, IEntityTypeConfiguration<Officer>
    {
        /// <summary>
        /// Formal description, in game, of the officer.
        /// This should never be empty. If this is empty the JSON reading was incomplete.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        public override void Configure(EntityTypeBuilder<Officer> modelBuilder)
        {
            modelBuilder.HasIndex(k => k.Name).IsUnique(true);
        }
    }
}
