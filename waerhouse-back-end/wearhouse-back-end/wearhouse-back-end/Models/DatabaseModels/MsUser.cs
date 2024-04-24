using System.ComponentModel.DataAnnotations;

namespace wearhouse_back_end.Models.DatabaseModels
{
    public class MsUser
    {
        [Key]
        public string UserID { get; set; }
        public string userName { get; set; }
        public string userEmail { get; set; }
        public string userPassword { get; set; }
    }
}
