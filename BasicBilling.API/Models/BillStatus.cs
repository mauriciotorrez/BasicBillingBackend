using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicBilling.API.Models
{
    public class BillStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BillStatusId { get; set; }
        [MaxLength(25, ErrorMessage = "Cannot exceed 25 characteres")]
        public string Status { get; set; }
    }
}
