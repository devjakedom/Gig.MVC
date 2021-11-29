using Gig.Data;
using Gig.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gig.Services
{
    public class WorkHistoryService
    {
        private readonly Guid _userId;

        public WorkHistoryService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateWorkHistory(WorkHistoryCreate model)
        {
            var entity =
                new WorkHistory()
                {
                    OwnerId = _userId,
                   ProfileId = model.ProfileId,
                    Company = model.Company,
                    TimeWorked = model.TimeWorked,
                    JobTitle = model.JobTitle,
                    JobDescription = model.JobDescription,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.WorkHistories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<WorkHistoryListItem> GetWorkHistory()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .WorkHistories
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new WorkHistoryListItem
                        {
                            //OwnerId = _userId,
                            WorkHistoryId = e.WorkHistoryId,
                            Company = e.Company,
                            TimeWorked = e.TimeWorked,
                            JobTitle = e.JobTitle,
                            JobDescription = e.JobDescription,
                        }
                        );

                return query.ToArray();
            }
        }

        public WorkHistoryDetail GetWorkHistoryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .WorkHistories
                    .Single(e => e.WorkHistoryId == id && e.OwnerId == _userId);
                return
                    new WorkHistoryDetail
                    {
                        WorkHistoryId = entity.WorkHistoryId,
                        Company = entity.Company,
                        TimeWorked = entity.TimeWorked,
                        JobTitle = entity.JobTitle,
                        JobDescription = entity.JobDescription,
                        ProfileId = entity.ProfileId,
            };
            }
        }

        public bool UpdateWorkHistory(WorkHistoryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.WorkHistories
                    .Single(e => e.WorkHistoryId == model.WorkHistoryId && e.OwnerId == _userId);

                entity.ProfileId = model.ProfileId;
                entity.Company = model.Company;
                entity.TimeWorked = model.TimeWorked;
                entity.JobDescription = model.JobDescription;
                entity.JobTitle = model.JobTitle;
                entity.WorkHistoryId = model.WorkHistoryId;

                return ctx.SaveChanges() == 1;
            }
        }


        public bool DeleteWorkHistory(int workHistoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.WorkHistories
                    .Single(e => e.WorkHistoryId == workHistoryId && e.OwnerId == _userId);

                ctx.WorkHistories.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
