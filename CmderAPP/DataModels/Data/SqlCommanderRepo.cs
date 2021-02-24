using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataModels.Data
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private readonly CommanderDBContext _context;

        public SqlCommanderRepo(CommanderDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public void CreateCommand(Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            _context.Commands.Add(command);
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.SingleOrDefault(x => x.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCommand(Command command)
        {
            if (command == null)
            {
                throw new NotImplementedException(nameof(command));
            }

            _context.Commands.Update(command);
        }

        public void DeleteCommand(Command command)
        {
            if (command == null)
            {
                throw new NotImplementedException(nameof(command));
            }

            _context.Commands.Remove(command);
        }
    }
}
