using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicBilling.API.Models
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PayId { get; set; }
        [MaxLength(25, ErrorMessage = "Cannot exceed 25 characteres")]
        public int Period { get; set; }
        public int Category_Id { get; set; }
        public int Client_Id { get; set; }
    }
}
