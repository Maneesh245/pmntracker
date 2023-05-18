using PMT.API.Model;
using PMT.API.Model.ViewModel;

namespace PMT.API.Repository
{
    public interface IMemberDetailsRepository
    {
        //Task DeleteMember(int memberId);
        Task<MemberDetail?> GetMemberDetailsByID(int MemberDetailsId);
        Task<MemberDetail?> GetMemberProjectDetails(string memberName, int memberDetailsId);
        Task<IEnumerable<MemberDetail?>> GetMemberDetails();
        Task<MemberDetail> InsertMemberDetails(MemberDetail MemberDetails);
        Task<MemberDetail> UpdateMemberDetails(MemberDetail MemberDetails);
        Task <MemberTaskDetail> AssignMemberTaskDetails(MemberTaskDetail memberTaskDetail);
        Task<IEnumerable<MemberTaskDetailViewModel>> GetAssignedTask(int memberid);

    }
}
