using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace STFC_Web.Data.Entities
{
    public class Group : BasicTable<Group>, IEntityTypeConfiguration<Group>
    {
        public override void Configure(EntityTypeBuilder<Group> modelBuilder)
        {
            modelBuilder.HasIndex(k => k.Name).IsUnique(true);
        }
    }
}
