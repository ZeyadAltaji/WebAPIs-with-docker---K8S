using System.Collections.Generic;
using PlatformService.Model;
using System.Linq;
using System;

namespace PlatformService.Data
{
    public class PlatformReop : IPlatformReop
    {
        private readonly AppDBContext Dc;
        public PlatformReop(AppDBContext dc)
        {
            Dc =dc;
        }
        public void CreatePlatForms(Platform plat)
        {
            if(plat ==null)
            {
                throw new ArgumentNullException(nameof(plat));
            }
            Dc.Platforms.Add(plat);
        }

        public void DeletePlatForm(int id)
        {
           var platformDelete = Dc.Platforms.Find(id);
           Dc.Platforms.Remove(platformDelete);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return Dc.Platforms.ToList();
        }

        public Platform GetPlatFormsById(int id)
        {
            return Dc.Platforms.FirstOrDefault(p => p.Id==id);
        }

        public bool SaveChanges()
        {
            return (Dc.SaveChanges()>=0);
        }
    }
}