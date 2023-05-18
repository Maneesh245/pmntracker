using Microsoft.EntityFrameworkCore;
using PMT.API.Data;
using PMT.API.Model;
using PMT.API.Model.ViewModel;
using System;
using System.Runtime.CompilerServices;

namespace PMT.API.Repository
{
    public class MemberDetailsRepository : IMemberDetailsRepository
    {
        private readonly PMTrackerContext _dbContext;

        public MemberDetailsRepository()
        {
            PMTrackerContext dbContext = new PMTrackerContext();
            _dbContext = dbContext;
        }
        public async Task<MemberDetail?> GetMemberProjectDetails(string memberName, int memberDetailsId)
        {
            return await _dbContext.MemberDetails.Where(m => m.MemberName == memberName || m.MemberID == memberDetailsId).FirstOrDefaultAsync();

        }

        public async  Task<IEnumerable<MemberDetail ?>> GetMemberDetails()
        {
            return await _dbContext.MemberDetails.OrderByDescending(ex => ex.YearsOfExperience).ToListAsync();
        }
        public async Task<MemberDetail?> GetMemberDetailsByID(int memberid)
        {
            return await _dbContext.MemberDetails.Where(md=> md.MemberID==memberid).FirstOrDefaultAsync();
        }
        public async Task<MemberDetail> InsertMemberDetails(MemberDetail memberDetail)
        {
            var result = await _dbContext.MemberDetails.AddAsync(memberDetail);
            Save();
            return result.Entity;
        }

        public void Save()
        {
          _dbContext.SaveChangesAsync();
        }

        public async Task<MemberDetail> UpdateMemberDetails(MemberDetail MemberDetails)
        {
            var result = await _dbContext.MemberDetails
               .FirstOrDefaultAsync(e => e.MemberID == MemberDetails.MemberID);

            if (result != null)
            {
                _dbContext.Entry(MemberDetails).State = EntityState.Modified;
                Save();
                return MemberDetails;
            }
            return null;
        }
        public async Task<MemberTaskDetail> AssignMemberTaskDetails(MemberTaskDetail memberTaskDetail)
        {
            var result = await _dbContext.MemberTaskDetails.AddAsync(memberTaskDetail);
            Save();
            return result.Entity;
        }
        public async Task<IEnumerable<MemberTaskDetailViewModel>> GetAssignedTask(int memberid)
        {
            var query = from md in _dbContext.MemberDetails
                        join td in _dbContext.MemberTaskDetails on md.MemberID equals td.MemberID
                        where md.MemberID == memberid
                        select new MemberTaskDetailViewModel()
                        {
                            ProjectStartDate = md.ProjectStartDate,
                            ProjectEndDate = md.ProjectEndDate,
                            AllocationPercentage = md.AllocationPercentage
                              ,
                            TaskID = td.TaskID,
                            TaskName = td.TaskName,
                            MemberID = td.MemberID,
                            MemberName = td.MemberName,
                            TaskStartDate = td.TaskStartDate,
                            TaskEndDate = td.TaskEndDate,
                            Deliverables = td.Deliverables
                        };
            return await query.ToListAsync();


        }
    }
}
