using MediatR;
using PMT.API.Model;
using System.ComponentModel.DataAnnotations;

namespace PMT.API.Data.Commands
{
    public class UpdateMemberCommand : IRequest<MemberDetail>
    {
        public int AllocationPercentage { get; set; }

        public MemberDetail ObjMemberDetail { get; set; }
        public UpdateMemberCommand(MemberDetail memberdetails)
        {
            ObjMemberDetail = memberdetails;
        }
    }

}