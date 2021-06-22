using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StfcWeb.Data.Entities
{
    public class Class : BasicTable<Class>, IEntityTypeConfiguration<Class>
    {
        public override void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.HasIndex(k => k.Name).IsUnique(true);
        }
    }
}
