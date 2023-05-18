using MediatR;
using PMT.API.Model;
using System.ComponentModel.DataAnnotations;

namespace PMT.API.Data.Commands
{
    public class CreateMemberCommand : IRequest<MemberDetail>
    {
        public int AllocationPercentage { get; set; }

        public MemberDetail ObjMemberDetail { get; set; }
        public CreateMemberCommand(MemberDetail memberdetails)
        {
            ObjMemberDetail = memberdetails;
        }
    }

}