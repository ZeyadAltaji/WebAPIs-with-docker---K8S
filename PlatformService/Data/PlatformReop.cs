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
        public void CreatePlatForms(platform plat)
        {
            if(plat ==null)
            {
                throw new ArgumentNullException(nameof(plat));
            }
            Dc.Platforms.Add(plat);
        }

        public IEnumerable<platform> GetAllPlatforms()
        {
            return Dc.Platforms.ToList();
        }

        public platform GetPlatFormsById(int id)
        {
            return Dc.Platforms.FirstOrDefault(p => p.Id==id);
        }

        public bool SaveChanges()
        {
            return (Dc.SaveChanges()>=0);
        }
    }
}