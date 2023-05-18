using MediatR;
using PMT.API.Model;
using PMT.API.Model.ViewModel;

namespace PMT.API.Data.Queries
{
    public class GetMemberTaskDetailsQueries  : IRequest<IEnumerable<MemberTaskDetailViewModel>>
    {
        public int MemberId { get; set; }
    }
   
}
