using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rpg.Dtos.Character;
using rpg.Services.CharacterService;
using rpg.Utilities;

namespace rpg.Models
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CharacterController:ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }


        [HttpGet("GetAllCharacters")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> GetAllCharacters()
        {
            
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("GetACharacter/{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetCharacterById(int id)
        {
          
            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpPost("AddNewCharcter")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> AddCharacter ([FromBody] AddCharacterDto newcharcter)
        {
          
           return Ok(await _characterService.AddCharacter(newcharcter));
        }

[HttpPut("UpdateCharacter")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> UpdateCharacter(UpdateCharacterDto updateCharacter)
        {

var o =await _characterService.UpdateCharacter(updateCharacter);
if (o.Data is null)
{
    return NotFound(o);
}

           return Ok( await _characterService.UpdateCharacter(updateCharacter));
        }


    }
}