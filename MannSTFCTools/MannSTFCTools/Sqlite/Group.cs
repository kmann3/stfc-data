﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MannSTFCTools.Sqlite
{
    public class Group : BasicTable<Group>, IEntityTypeConfiguration<Group>
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
}
