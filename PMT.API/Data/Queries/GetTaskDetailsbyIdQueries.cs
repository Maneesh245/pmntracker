using MediatR;
using PMT.API.Model;

namespace PMT.API.Data.Queries
{
    public class GetTaskDetailsbyIdQueries : IRequest<MemberDetail>
    {
        public string Name { get; set; }
        public int Id { get; set; }
        

    }
   
}
