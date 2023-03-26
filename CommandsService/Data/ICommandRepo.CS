using System.Collections.Generic;
using CommandsService.Models;

namespace CommandsService.Data
{
    public interface ICommandRepo
    {
        bool SaveChanges();
        // platFroms
        IEnumerable<PlatFroms>GetAllPlatFroms();
        void CreateNewPlatFroms(PlatFroms plat);
        bool platfromsExitAlready(int platfromsId);
        // Command
        IEnumerable<Command>GetCommandForPlatFroms(int platfromsId);
        Command GetCommand(int platfromsId,int CommandId);
        void CreateNewCommand(int platfromsId,Command command);
    }
}