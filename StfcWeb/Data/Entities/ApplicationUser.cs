using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace StfcWeb.Data.Entities
{
    public class ApplicationUser : IdentityUser, IEntityTypeConfiguration<ApplicationUser>
    {
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public string DisplayName { get; set; }

        /// <summary>
        /// Users are NEVER deleted because they can reference data and deleting them would orphan that data.
        /// </summary>
        public bool IsDeleted { get; set; } = false;

        public bool IsDisabled { get; set; } = false;

        //=================
        // CreatedBy
        //=================
        public ICollection<News> NewsCreatedBy { get; set; }

        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasMany(x => x.NewsCreatedBy).WithOne(x => x.CreatedBy).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
