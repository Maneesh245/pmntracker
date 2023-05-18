using MediatR;
using PMT.API.Data.Commands;
using PMT.API.Data.Queries;
using PMT.API.Model;
using PMT.API.Repository;

namespace PMT.API.Data.Handlers
{
    public class CreateMemberHandler : IRequestHandler<CreateMemberCommand, MemberDetail>
    {
        private readonly IMemberDetailsRepository _memberDetailsRepository;

    public CreateMemberHandler(IMemberDetailsRepository memberDetailsRepository)
    {
            _memberDetailsRepository = memberDetailsRepository;
    }
    public async Task<MemberDetail> Handle(CreateMemberCommand command, CancellationToken cancellationToken)
    {
            var memberDetail = new MemberDetail();
        memberDetail = command.ObjMemberDetail;

        return await _memberDetailsRepository.InsertMemberDetails(memberDetail);
    }
}
}