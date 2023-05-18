using MediatR;
using PMT.API.Data.Queries;
using PMT.API.Model;
using PMT.API.Repository;

namespace PMT.API.Data.Handlers
{
    public class GetMemberDetailsbyIdHandler : IRequestHandler<GetMemberDetailsbyIdQueries, MemberDetail>
    {
        private readonly IMemberDetailsRepository _memberRepository;

        public GetMemberDetailsbyIdHandler(IMemberDetailsRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<MemberDetail> Handle(GetMemberDetailsbyIdQueries query, CancellationToken cancellationToken)
        {
            return await _memberRepository.GetMemberDetailsByID(query.Id);
        }
    }
}
