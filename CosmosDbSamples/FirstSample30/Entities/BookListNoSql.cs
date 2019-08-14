using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstSample30.Entities
{

    public class BookListNoSql
    {
        [Key]
        public Guid BookId { get; set; }

        public string Title { get; set; }
        public DateTime PublishedOn { get; set; }
        public decimal OrgPrice { get; set; }
        public decimal ActualPrice { get; set; }
        public string PromotionalText { get; set; }
        public string AuthorsOrdered { get; set; }
        public int ReviewsCount { get; set; }
        public double? ReviewsAverageVotes { get; set; }
    }

}
