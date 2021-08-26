using AutoMapper;
using CommanderAPI.Dtos;
using CommanderAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommanderAPI.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            // Source -> Target
            CreateMap<Command, CommandReadDto>();
            // Target -> Source
            CreateMap<CommandCreateDto, Command>();
            // Target -> Source
            CreateMap<CommandUpdateDto, Command>();
        }
    }
}
