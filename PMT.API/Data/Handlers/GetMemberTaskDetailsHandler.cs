using MediatR;
using PMT.API.Data.Queries;
using PMT.API.Model;
using PMT.API.Model.ViewModel;
using PMT.API.Repository;

namespace PMT.API.Data.Handlers
{
    public class GetMemberTaskDetailsHandler : IRequestHandler<GetMemberTaskDetailsQueries, IEnumerable<MemberTaskDetailViewModel>>
    {
        private readonly IMemberDetailsRepository _memberRepository;

        public GetMemberTaskDetailsHandler(IMemberDetailsRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<IEnumerable<MemberTaskDetailViewModel>> Handle(GetMemberTaskDetailsQueries query, CancellationToken cancellationToken)
        {
            return await _memberRepository.GetAssignedTask(query.MemberId);
        }
    }
}
