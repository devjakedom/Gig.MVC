using Gig.Data;
using Gig.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gig.Services
{
    public class ProfileService
    {
        private readonly Guid _userId;

        public ProfileService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateProfile(CreateProfile model)
        {
            var entity =
                new Profile()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    Address = model.Address,
                    City = model.City,
                    State = model.State
                }; ;
            using (var ctx = new ApplicationDbContext())
            {
                ctx.profiles.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        

        public IEnumerable<ProfileListItem> GetProfiles()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .profiles
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new ProfileListItem
                        {
                            OwnerId = _userId,
                            ProfileId = e.ProfileId,
                            Name = e.Name,
                            Address = e.Address,
                            City = e.City,
                            State = e.State
                        }
                        );

                return query.ToArray();
            }
        }

        public ProfileDetail GetProfileById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .profiles
                    .Single(e => e.ProfileId == id && e.OwnerId == _userId);
                return
                    new ProfileDetail
                    {
                        ProfileId = entity.ProfileId,
                        Name = entity.Name,
                        Address = entity.Address,
                        City = entity.City,
                        State = entity.State
                    };
            }
        }

        public bool UpdateProfile(ProfileEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.profiles
                    .Single(e => e.ProfileId == model.ProfileId && e.OwnerId == _userId);

                entity.ProfileId = model.ProfileId;
                entity.Name = model.Name;
                entity.Address = model.Address;
                entity.City = model.City;
                entity.State = model.State;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteProfile(int profileId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.profiles
                    .Single(e => e.ProfileId == profileId && e.OwnerId == _userId);

                ctx.profiles.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
