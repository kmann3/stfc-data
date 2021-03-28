using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace STFC_Web.Data.Entities
{
    public class Tags : BasicTable<Tags>, IEntityTypeConfiguration<Tags>
    {
        public ICollection<Officer> Officers { get; set; }

        public override void Configure(EntityTypeBuilder<Tags> modelBuilder)
        {
            modelBuilder.HasIndex(k => k.Name).IsUnique(true);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
