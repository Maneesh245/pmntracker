using System.ComponentModel.DataAnnotations;

namespace PMT.API.Model.ViewModel
{
    public class MemberTaskDetailViewModel
    {
    
        public int TaskID { get; set; }
        
        public int MemberID { get; set; }
        
        public string MemberName { get; set; }
        
        public string TaskName { get; set; }
        
        public string Deliverables { get; set; }
        
        public DateTime TaskStartDate { get; set; }
        
        public DateTime TaskEndDate { get; set; }
        public DateTime ProjectStartDate { get; set; }
     
        public DateTime ProjectEndDate { get; set; }
        
        public int AllocationPercentage { get; set; }
    }
}
