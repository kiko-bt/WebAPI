using AutoMapper;
using Models.Models;

namespace DataModels.DTO_s.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            CreateMap<Command, CommandDto>();
            CreateMap<CommandDto, Command>();
        }
    }
}
