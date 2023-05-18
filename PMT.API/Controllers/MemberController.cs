using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PMT.API.Data.Commands;
using PMT.API.Data.Queries;
using PMT.API.Model;
using PMT.API.Model.ViewModel;
using PMT.API.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PMT.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MemberController : ControllerBase
    {
        private readonly IMediator mediator;
        public MemberController(IMemberDetailsRepository memberRepository, IMediator mediator)
        {
            this.mediator = mediator;
        }

        
        [HttpGet("/api/v1/manager/list")]
        public async Task<ActionResult> Get()
        {
            try
            {
                var memberdetails = await mediator.Send(new GetMemberDetailsQueries());
                if (memberdetails.Count() > 0)
                {
                    return Ok(memberdetails);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound,
                    "Data not exist");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error while inserting data in database");
            }
        }
        
        [HttpPost("/api/v1/manager/add-member")]
        public async Task<ActionResult> Addmember([FromBody] MemberDetail member)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (member != null)
                {
                    // Add custom model validation error
                    if (member.SkillSet.Split(',').Length < 3)
                        ModelState.AddModelError("Skill", " minium 3 Skillsets  required");
                    if (member.ProjectStartDate > member.ProjectEndDate)
                        ModelState.AddModelError("ProjectStartDate", "Project end date should be greater than project start date");
                    if (member.YearsOfExperience < 4)
                        ModelState.AddModelError("YearsOfExperience", "experiences must be greater greater than 4");
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }
                }


                var emp = await mediator.Send(new GetTaskDetailsbyIdQueries() { Id = member.MemberID });

                if (emp != null)
                {
                    ModelState.AddModelError("MemberID", "Member details already exists");
                    return BadRequest(ModelState);
                }
                var createdMember = await mediator.Send(new CreateMemberCommand(member));
                return StatusCode(StatusCodes.Status201Created, "Member Added");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error while inserting data in database");
            }

        }

        [HttpPost("/api/v1/manager/update")]
        public async Task<ActionResult> updateAllocation([FromBody] int  memberid)
        {
            try
            {
                MemberDetail member = new MemberDetail();
                member.MemberID = memberid;
                MemberDetail member_detailUpdate = await mediator.Send(new GetMemberDetailsbyIdQueries() { Id = member.MemberID });

                if (member_detailUpdate != null)
                {
                    if (member_detailUpdate.ProjectStartDate < DateTime.Now)
                    {
                        member_detailUpdate.AllocationPercentage = 0;
                    }
                    else
                    {
                        member_detailUpdate.AllocationPercentage = 100;
                    }

                    var memberdetails = await mediator.Send(new UpdateMemberCommand(member_detailUpdate));
                    return Ok(new { status = "Ok", message = "Project allocation percentage updated sucessfully" });
                    //return Ok("Project allocation percentage updated sucessfully");
                }
                else
                {
                    return Ok(new { status = "Ok", message = "please provice valid member id" });
                    //return Ok("please provice valid member id");

                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error while inserting data in database");
            }

        }
        
        [HttpPost("/api/v1/manager/assign-task")]
        public async Task<ActionResult> AssignTask([FromBody] MemberTaskDetail TaskDetails)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (TaskDetails != null )
                {
                    MemberDetail memberDetail = await mediator.Send(new GetTaskDetailsbyIdQueries() { Name = TaskDetails.MemberName, Id = TaskDetails.MemberID });

                    if (memberDetail == null)
                        ModelState.AddModelError("Member", "Member not exist with relevant details");
                    else
                    {
                        TaskDetails.MemberID = memberDetail.MemberID;
                        TaskDetails.MemberName = memberDetail.MemberName;
                    }
                    if (TaskDetails.TaskEndDate < TaskDetails.TaskStartDate)
                        ModelState.AddModelError("Task End date", " Task End date should be greater than task start date");
                    if (memberDetail != null && TaskDetails.TaskEndDate > memberDetail.ProjectEndDate)
                        ModelState.AddModelError("TaskEndDate", "Task End date should be less than project end date");
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }
                }
                var result = await mediator.Send(new CreateTaskCommand(TaskDetails));
                return Ok(new { status = "Ok", message = "Task Assigned" });

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error while inserting data in database");
            }

        }
        
        [HttpGet("/api/v1/member/list/{memberId}")]
        public async Task<ActionResult> GetAssignedTask(int memberId)
        {
            try
            {
                var taskdetails = await mediator.Send(new GetMemberTaskDetailsQueries() { MemberId = memberId });
                    return Ok(taskdetails);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error while fetching data from database");
            }
        }
    }
}
