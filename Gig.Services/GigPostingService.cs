using Gig.Data;
using Gig.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gig.Services
{
    public class GigPostingService
    {
        private readonly Guid _userId;

        public GigPostingService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateGigPosting(GigPostingCreate model)
        {
            var entity =
                new GigPosting()
                {
                    OwnerId = _userId,
                    JobTitle = model.JobTitle,
                    DescriptionOfJob = model.DescriptionOfJob,
                    Location = model.Location,
                    PayPerHour = model.PayPerHour
                }; ;
            using (var ctx = new ApplicationDbContext())
            {
                ctx.GigPostings.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GigPostingListItem> GetGigPosting()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .GigPostings
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new GigPostingListItem
                        {
                            GigPostId = e.GigPostId,
                            JobTitle = e.JobTitle,
                            DescriptionOfJob = e.DescriptionOfJob,
                            Location = e.Location,
                            PayPerHour = e.PayPerHour
                        }
                        );

                return query.ToArray();
            }
        }

        public IEnumerable<GigPostingListItem> GetAllGigPosting()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .GigPostings
                    //.Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new GigPostingListItem
                        {
                            GigPostId = e.GigPostId,
                            JobTitle = e.JobTitle,
                            DescriptionOfJob = e.DescriptionOfJob,
                            Location = e.Location,
                            PayPerHour = e.PayPerHour
                        }
                        );

                return query.ToArray();
            }
        }

        public GigPostingDetail GetGigPostingById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .GigPostings
                    .Single(e => e.GigPostId == id && e.OwnerId == _userId);
                return
                    new GigPostingDetail
                    {
                        GigPostId = entity.GigPostId,
                        JobTitle = entity.JobTitle,
                        DescriptionOfJob = entity.DescriptionOfJob,
                        Location = entity.Location,
                        PayPerHour = entity.PayPerHour
                    };
            }
        }

        public bool UpdateGigposting(GigPostingEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.GigPostings
                    .Single(e => e.GigPostId == model.GigPostId && e.OwnerId == _userId);

                entity.PayPerHour = model.PayPerHour;
                entity.GigPostId = model.GigPostId;
                entity.Location = model.Location;
                entity.DescriptionOfJob = model.DescriptionOfJob;
                entity.JobTitle = model.JobTitle;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteGigPosting(int gigPostId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.GigPostings
                    .Single(e => e.GigPostId == gigPostId && e.OwnerId == _userId);

                ctx.GigPostings.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
