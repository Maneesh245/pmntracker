using MediatR;
using PMT.API.Model;
using PMT.API.Model.ViewModel;

namespace PMT.API.Data.Queries
{
    public class GetMemberDetailsbyIdQueries : IRequest<MemberDetail>
    {
        public int Id { get; set; }
    }
   
}
