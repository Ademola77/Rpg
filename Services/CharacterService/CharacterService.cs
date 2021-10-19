using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using rpg.Dtos.Character;
using rpg.Models;
using rpg.Utilities;

namespace rpg.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly List<Character> characters= new List<Character>
        {
            new Character(),
            new Character{Name = "Samx",Id=1}
        };
        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
       {
            _mapper = mapper;
        }
                
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharcter)
        {
           characters.Add(_mapper.Map<Character>(newCharcter));
           //var x =new ServiceResponse<List<GetCharacterDto>>{Data=_mapper.Map<List<GetCharacterDto>>(characters)};
     var x =new ServiceResponse<List<GetCharacterDto>>{Data=characters.Select(c=>_mapper.Map<GetCharacterDto>(c)).ToList()};


           return x;
        }

        public async  Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
          return new ServiceResponse<List<GetCharacterDto>> { Data= characters.Select(c=>_mapper.Map<GetCharacterDto>(c)).ToList()};
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int Id)
        {
            var character = characters.Find(x=>x.Id ==Id);
            return new ServiceResponse<GetCharacterDto>{ Data =_mapper.Map<GetCharacterDto>(character) };
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter)
        {  
            var sResponse =new ServiceResponse<GetCharacterDto>();
            
            try
            {
           
            var x = characters.Find(c=>c.Id ==updateCharacter.Id);
     
      x.Name=updateCharacter.Name;
      x.HitPoints=updateCharacter.HitPoints;
       x.Strength=updateCharacter.Strength;
        x.Defense=updateCharacter.Defense;
      x.Intelligence=updateCharacter.Intelligence;
      x.Class=updateCharacter.Class;
           
      sResponse.Data =_mapper.Map<GetCharacterDto>(x) ;
      
            }
            catch (System.Exception ex)
            {
                
                sResponse.IsSuccessful=false;
                sResponse.Message=ex.Message;
            }


      return sResponse;
        }
    }
}