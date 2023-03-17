using PlatformService.Model;
using System.Collections.Generic;
namespace PlatformService.Data
{
    public interface IPlatformReop
    {
        bool SaveChanges();
        IEnumerable<Platform>GetAllPlatforms() ;
        Platform GetPlatFormsById(int id);
        void CreatePlatForms(Platform plat);

    }
}