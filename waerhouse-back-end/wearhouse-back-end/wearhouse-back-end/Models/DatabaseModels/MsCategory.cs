using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wearhouse_back_end.Models.DatabaseModels
{
    public class MsCategory
    {
        [Key]
        public string CategoryID { get; set; }
        [ForeignKey("MsUser")]
        public string UserID { get; set; }
        public string Category { get; set; }
        public DateTime categorydate { get; set; }
    }
}
