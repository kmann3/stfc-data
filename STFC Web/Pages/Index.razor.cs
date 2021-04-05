using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using STFC_Web.Data;
using STFC_Web.Data.Entities;

namespace STFC_Web.Pages
{
    public partial class Index
    {
        Data.ApplicationDbContext _context;
        void OnButtonClicked()
        {
            _context = new();
            var off = (from o in _context.Officers select o).FirstOrDefault();
            if(off == null)
            {
                _context.Classes.AddRange(Seeds.Class_Command, Seeds.Class_Engineering, Seeds.Class_Science);
                _context.Tags.AddRange(Seeds.Tag_Mining, Seeds.Tag_Neutral, Seeds.Tag_ProtectedCargo, Seeds.Tag_ShieldMitigation, Seeds.Tag_Shields);
                _context.Factions.AddRange(Seeds.Faction_Federation, Seeds.Faction_Neutral);
                _context.Rarities.Add(Seeds.Rarity_Rare);
                _context.RankResourceCosts.AddRange(Seeds.RRC_6_10, Seeds.RRC_11_15, Seeds.RRC_16_20, Seeds.RRC_22_30);
                _context.SaveChanges();
                _context.Officers.Add(Data.Seeds.Officer_OneOfTen);
                _context.SaveChanges();

            } else
            {

            }
            string x = Data.Seeds.Officer_OneOfTen.ToJSON;
            Console.WriteLine(x);
        }
    }
}
