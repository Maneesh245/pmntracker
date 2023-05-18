using MediatR;
using PMT.API.Data.Queries;
using PMT.API.Model;
using PMT.API.Repository;

namespace PMT.API.Data.Handlers
{
    public class GetMemberDetailsHandler : IRequestHandler<GetMemberDetailsQueries, IEnumerable<MemberDetail>>
    {
        private readonly IMemberDetailsRepository _memberRepository;

        public GetMemberDetailsHandler(IMemberDetailsRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<IEnumerable<MemberDetail>> Handle(GetMemberDetailsQueries query, CancellationToken cancellationToken)
        {
            return await _memberRepository.GetMemberDetails();
        }
    }
}
