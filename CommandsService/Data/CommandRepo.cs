using System;
using System.Collections.Generic;
using System.Linq;
using CommandsService.Models;

namespace CommandsService.Data
{
    public class CommandRepo : ICommandRepo
    {
        private readonly AppDbContext _dc;

        public CommandRepo(AppDbContext dc)
        {
            _dc=dc;
            
        }
        public void CreateNewCommand(int platfromsId, Command command)
        {
             if(command==null)
             {
                throw new ArgumentNullException(nameof(command));
             }
             command.PlatFromsId = platfromsId;
             _dc.commands.Add(command);
        }

        public void CreateNewPlatFroms(PlatFroms plat)
        {
           if(plat==null)
           {
                throw new ArgumentNullException(nameof(plat));
           }
           _dc.platfroms.Add(plat);
        }

        public IEnumerable<PlatFroms> GetAllPlatFroms()
        {
          return _dc.platfroms.ToList();
        }

        public Command GetCommand(int platfromsId, int CommandId)
        {
            return _dc.commands.Where(
            c=>c.PlatFromsId==platfromsId && c.Id==CommandId).FirstOrDefault();
        }

        public IEnumerable<Command> GetCommandForPlatFroms(int platfromsId)
        {
            return _dc.commands.Where(
                c=>c.PlatFromsId==platfromsId)
                .OrderBy(c=>c.platFroms.Name);
         
        }

        public bool platfromsExitAlready(int platfromsId)
        {
            return _dc.platfroms.Any(p=>p.Id==platfromsId);
        }

        public bool SaveChanges()
        {
            return (_dc.SaveChanges()>=0);
        }
    }
}