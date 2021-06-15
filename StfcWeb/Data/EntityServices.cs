using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StfcWeb.Data
{
    public class EntityServices
    {
        public Task<List<Entities.News>> GetFrontPageNewsAsync()
        {
            using (var dbContext = new ApplicationDbContext())
            {
                var newsItems = from x in dbContext.News orderby x.CreatedOn descending select x;
                
                return Task.FromResult(newsItems.Take(5).ToList());
            }
        }
    }
}
