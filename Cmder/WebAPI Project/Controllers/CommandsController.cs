using AutoMapper;
using DataModels.Data;
using DataModels.DTO_s;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using System;
using System.Collections.Generic;

namespace WebAPI_Project
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private IMapper _mapper;

        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<CommandDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandDto>>(commandItems));
        }


        [HttpGet("{id}", Name="GetCommandById")]
        public ActionResult<CommandDto> GetCommandById(int id)
        {
            try
            {
                var commandItem = _repository.GetCommandById(id);

                if (commandItem != null)
                {
                    return Ok(_mapper.Map<CommandDto>(commandItem));
                }

                return NotFound();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public ActionResult<CommandDto> CreateCommand(CommandDto commandDto)
        {
            var commandModel = _mapper.Map<Command>(commandDto);

            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            return CreatedAtRoute(nameof(GetCommandById), new { commandDto.Id }, commandDto);
        }


        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandDto command)
        {
            try
            {
                var model = _repository.GetCommandById(id);

                if (model == null)
                {
                    return NotFound();
                }

                _mapper.Map(command, model);
                _repository.UpdateCommand(model);
                _repository.SaveChanges();


                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPatch("{id:int}")]
        public IActionResult PartialCommandUpdate(int id, [FromBody] JsonPatchDocument<CommandDto> patchEntity)
        {
            try
            {
                var model = _repository.GetCommandById(id);

                if (model == null)
                {
                    return NotFound();
                }

                var commandToPatch = _mapper.Map<CommandDto>(model);

                patchEntity.ApplyTo(commandToPatch, ModelState);


                _mapper.Map(commandToPatch, model);
                _repository.UpdateCommand(model);
                _repository.SaveChanges();

                return Ok(commandToPatch);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            try
            {
                var model = _repository.GetCommandById(id);

                if (model == null)
                {
                    return NotFound();
                }

                _repository.DeleteCommand(model);
                _repository.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
