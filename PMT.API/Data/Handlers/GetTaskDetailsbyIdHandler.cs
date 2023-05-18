using MediatR;
using PMT.API.Data.Queries;
using PMT.API.Model;
using PMT.API.Repository;

namespace PMT.API.Data.Handlers
{
    public class GettaskDetailsbyIdHandler : IRequestHandler<GetTaskDetailsbyIdQueries, MemberDetail>
    {
        private readonly IMemberDetailsRepository _memberRepository;

        public GettaskDetailsbyIdHandler(IMemberDetailsRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<MemberDetail> Handle(GetTaskDetailsbyIdQueries query, CancellationToken cancellationToken)
        {
            return await _memberRepository.GetMemberProjectDetails(query.Name, query.Id);
        }
    }
}
