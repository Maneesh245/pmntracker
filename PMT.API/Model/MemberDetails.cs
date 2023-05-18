using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMT.API.Model
{

    public class MemberDetail
    {

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MemberID { get; set; }
        [Required]
        public string MemberName { get; set; }
        [Required]
        public int YearsOfExperience { get; set; }
        [Required]
        public string SkillSet { get; set; }
        [Required]
        public string AdditionalDescription { get; set; }
        [Required]
        public DateTime ProjectStartDate { get; set; }
        [Required]
        public DateTime ProjectEndDate { get; set; }
        [Required]
        [Range(0, 100)]
        public int AllocationPercentage { get; set; }


    }
}
