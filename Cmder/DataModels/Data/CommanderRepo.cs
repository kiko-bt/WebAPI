using Models.Models;
using System.Collections.Generic;

namespace DataModels.Data
{
    public class CommanderRepo : ICommanderRepo
    {
        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>()
            {
                new Command { Id = 0, Building = "Project from scratch", RestAPI = "Web application programming interface", Project = "CRUD Commands" },
                new Command { Id = 1, Building = "Core Project", RestAPI = "With Repository Pattern", Project = "And dependency injection" },
                new Command { Id = 2, Building = "Building my experience", RestAPI = "With Database Context", Project = "Called CommanderAPI" },
                new Command { Id = 3, Building = "Application returns data type", RestAPI = "No UI Content", Project = "My Project" },
            };

            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command { Id = 0, Building = "Project from scratch", RestAPI = "Web application programming interface", Project = "CRUD Commands" };
        }

        public void CreateCommand(Command command)
        {
            throw new System.NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(Command command)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(Command command)
        {
            throw new System.NotImplementedException();
        }
    }
}
