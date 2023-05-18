using MediatR;
using PMT.API.Data.Commands;
using PMT.API.Data.Queries;
using PMT.API.Model;
using PMT.API.Repository;

namespace PMT.API.Data.Handlers
{
    public class CreateTaskHandler : IRequestHandler<CreateTaskCommand, MemberTaskDetail>
    {
        private readonly IMemberDetailsRepository _memberDetailsRepository;

    public CreateTaskHandler(IMemberDetailsRepository memberDetailsRepository)
    {
            _memberDetailsRepository = memberDetailsRepository;
    }
    public async Task<MemberTaskDetail> Handle(CreateTaskCommand command, CancellationToken cancellationToken)
    {
            var membertaskDetail = new MemberTaskDetail();
            membertaskDetail = command.ObjMemberTaskDetail;

        return await _memberDetailsRepository.AssignMemberTaskDetails(membertaskDetail);
    }
}
}