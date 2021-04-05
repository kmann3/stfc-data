using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace STFC_Web.Data.Entities
{
    public class Class : BasicTable<Class>, IEntityTypeConfiguration<Class>
    {
        public ICollection<Officer> Officers { get; set; }

        public override void Configure(EntityTypeBuilder<Class> modelBuilder)
        {
            modelBuilder.HasIndex(k => k.Id).IsUnique(true);
        }
    }
}
