using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicBilling.API.Models
{
    public class Bill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BillId { get; set; }
        [MaxLength(25, ErrorMessage = "Cannot exceed 25 characteres")]
        public int Period { get; set; }
        public int Category_Id { get; set; }
        public int BillStatus_Id { get; set; }
        public int Client_Id { get; set; }
        public double Amount { get; set; }
    }
}
