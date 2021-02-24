using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoteApp.Models;
using NoteApp.Services;
using NoteApp.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace NoteApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        public readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }



        [HttpGet]
        public ActionResult<IEnumerable<NoteModel>> Get()
        {
            try
            {
                int userId = GetAuthorizedUserId();
                return Ok(_noteService.GetUserNotes(userId));
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong. Please contact support! Message: {ex.Message}");
            }
        } 


        [HttpGet("{id}")]
        public ActionResult<NoteModel> Get(int id)
        {
            try
            {
                int userId = GetAuthorizedUserId();
                return Ok(_noteService.GetNote(id, userId));
            }
            catch (UserException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong. Please contact support! Message: {ex.Message}");
            }
        } 


        [HttpPost]
        public IActionResult Post([FromBody] NoteModel model)
        {
            try
            {
                _noteService.AddNote(model);
                return Ok("Successfuly added note!");
            }
            catch (UserException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong. Please contact support! Message: {ex.Message}");
            }

        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                //int userId = 1;
                int userId = GetAuthorizedUserId();
                _noteService.DeleteNote(id, userId);
                return Ok("Note deleted successfuly");
            }
            catch (UserException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NoteException ex)
            {
                return BadRequest(ex.Message);
            }      
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong. Please contact support! Message: {ex.Message}");
            }
        }


        private int GetAuthorizedUserId()
        {
           if(!int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var userId))
            {
                string name = User.FindFirst(ClaimTypes.Name)?.Value;
                //throw new Exception("Name identifier claim does not exist!");
                throw new UserException(userId, name, "Name identifier claim does not exists");
            }

            return userId;
        }


    }
}
