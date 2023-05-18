using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

namespace PMT.API.Model
{
    public class MemberTaskDetail
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TaskID { get; set; }
      
        public int MemberID { get; set; }
     
        public string MemberName { get; set; }
        [Required]
        public string TaskName { get; set; }
        [Required]
        public string Deliverables { get; set; }
        [Required]
        public DateTime TaskStartDate { get; set; }
        [Required]
        public DateTime TaskEndDate { get; set; }

    }
}
