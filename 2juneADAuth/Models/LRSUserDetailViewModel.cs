using System.ComponentModel.DataAnnotations;
namespace _2juneADAuth.Models
{
    public class LRSUserDetailViewModel
    {
        [Key]
        public int LRSUserDataId { get; set; }
        public string LRSUserDataName { get; set; }
        public string State { get; set; }
        public int StateID { get; set; }
        public string Country { get; set; }
        public int CountryID { get; set; }
        public string District { get; set; }
        public int DistrictID { get; set; }
        public DateTime SubmitteDate { get; set; }
        public decimal Budget { get; set; }
    }
}
