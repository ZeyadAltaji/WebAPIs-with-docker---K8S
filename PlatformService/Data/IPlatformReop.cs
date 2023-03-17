using PlatformService.Model;
using System.Collections.Generic;
namespace PlatformService.Data
{
    public interface IPlatformReop
    {
        bool SaveChanges();
        IEnumerable<platform>GetAllPlatforms() ;
        platform GetPlatFormsById(int id);
        void CreatePlatForms(platform plat);

    }
}