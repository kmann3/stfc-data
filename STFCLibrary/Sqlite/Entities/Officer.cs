using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace STFCLibrary.Sqlite.Entities;

public class Officer : BaseTable<Officer>, IEntityTypeConfiguration<Officer>
{
    public string Description { get; set; }

    public string CaptainManeuver_Name { get; set; }
    public string CaptainManeuver_Buff_Name { get; set; }
    public string CaptainManeuver_Buff_Type { get; set; }
    public string CaptainManeuver_Bonus { get; set; }
    public bool CaptainManeuver_Percentage { get; set; }
    public double CaptainManeuver_Value { get; set; }

    public string OfficerAbility_Name { get; set; }
    public string OfficerAbility_Buff_Name { get; set; }
    public string OfficerAbility_Buff_Type { get; set; }
    public bool OfficerAbility_Bonus { get; set; }
    public double OfficerAbility_Percentage { get; set; }

    public Class Class { get; set; }
    public Faction Faction { get; set; }
    public Group Group { get; set; }
    
    public byte[] ImageData { get; set; }

    public Rank Rank_I { get; set; }



    /// <summary>
    /// Formal description, in game, of the officer.
    /// This should never be empty. If this is empty the JSON reading was incomplete.
    /// </summary>

    public override void Configure(EntityTypeBuilder<Officer> modelBuilder)
    {
        modelBuilder.HasIndex(k => k.Name).IsUnique(true);
    }
}
