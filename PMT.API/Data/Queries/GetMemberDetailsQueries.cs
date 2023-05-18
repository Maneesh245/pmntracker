using MediatR;
using PMT.API.Model;

namespace PMT.API.Data.Queries
{
    public class GetMemberDetailsQueries  : IRequest<IEnumerable<MemberDetail>>
    {
    }
   
}
