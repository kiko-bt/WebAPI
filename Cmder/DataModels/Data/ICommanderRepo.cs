using Models.Models;
using System.Collections.Generic;

namespace DataModels.Data
{
    public interface ICommanderRepo
    {
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
        void CreateCommand(Command command);
        void UpdateCommand(Command command);
        void DeleteCommand(Command command);
        bool SaveChanges();
    }
}
