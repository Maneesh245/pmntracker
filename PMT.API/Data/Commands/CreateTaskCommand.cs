using MediatR;
using PMT.API.Model;
using System.ComponentModel.DataAnnotations;

namespace PMT.API.Data.Commands
{
    public class CreateTaskCommand : IRequest<MemberTaskDetail>
    {
        public MemberTaskDetail ObjMemberTaskDetail { get; set; }
        public CreateTaskCommand(MemberTaskDetail membertaskdetails)
        {
            ObjMemberTaskDetail = membertaskdetails;
        }
    }

}