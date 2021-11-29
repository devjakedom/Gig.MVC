using Gig.Data;
using Gig.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gig.Services
{
    public class GigApplyService
    {
        private readonly Guid _userId;

        public GigApplyService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateGigApply(GigApplyCreate model)
        {
            var entity =
                new GigApply()
                {
                    OwnerId = _userId,
                    GigPostId = model.GigPostId,
                    ProfileId = model.ProfileId,
                    //OwnerId = model._userId

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.gigApplies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GigApplyListItem> GetGigApply()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                   .gigApplies
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new GigApplyListItem
                        {
                            GigApplyId = e.GigApplyId,
                            GigPostId = e.GigPostId,
                            ProfileId = e.ProfileId,
                        }
                        );

                return query.ToArray();
            }
        }

        public GigApplyDetail GetGigApplyById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .gigApplies
                    .Single(e => e.GigApplyId == id && e.OwnerId == _userId);
                return
                    new GigApplyDetail
                    {
                        GigApplyId = entity.GigApplyId,
                        GigPostId = entity.GigPostId,
                        ProfileId = entity.ProfileId,
                    };
            }
        }

        public bool UpdateGigApply(GigApplyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.gigApplies
                    .Single(e => e.GigApplyId == model.GigApplyId && e.OwnerId == _userId);

                entity.GigApplyId = model.GigApplyId;
                    entity.GigPostId = model.GigPostId;
                entity.ProfileId = model.ProfileId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteGigApply(int gigApplyId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.gigApplies
                    .Single(e => e.GigApplyId == gigApplyId && e.OwnerId == _userId);

                ctx.gigApplies.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
