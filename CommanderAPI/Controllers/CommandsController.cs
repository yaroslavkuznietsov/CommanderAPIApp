using AutoMapper;
using CommanderAPI.Data;
using CommanderAPI.Dtos;
using CommanderAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommanderAPI.Controllers
{
    // api/commands
    // [Route("api/[controller]")]
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repo;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        //private readonly MockCommanderRepo _repo = new MockCommanderRepo();

        // GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repo.GetAppCommands();

            IEnumerable<CommandReadDto> commandReadDtos = _mapper.Map<List<CommandReadDto>>(commandItems);

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        // GET api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _repo.GetCommandById(id);

            if (commandItem != null)
            {
                CommandReadDto commandReadDto = _mapper.Map<CommandReadDto>(commandItem);
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            }
            return NotFound();
        }

       // POST api/commands
       [HttpPost]
       public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _repo.CreateCommand(commandModel);
            _repo.SaveChanges();

            return Ok(_mapper.Map<CommandReadDto>(commandModel));
        }
    }
}
