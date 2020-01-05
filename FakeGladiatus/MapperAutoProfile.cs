using AutoMapper;
using FakeGladiatus.Application.Entities;
using FakeGladiatus.Shared.Models.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeGladiatus
{
    public class MapperAutoProfile : Profile
    {
        public MapperAutoProfile()
        {
            CreateMap<Character, CharacterReadModel>();
            CreateMap<CharacterGenerateModel, Character>().ForMember(x => x.Agility, y => y.MapFrom(z => Convert.ToInt32(z.Agility)))
            .ForMember(x => x.Defense, y => y.MapFrom(z => Convert.ToInt32(z.Defence)))
            .ForMember(x => x.Hp, y => y.MapFrom(z => Convert.ToInt32(z.Hp)))
            .ForMember(x => x.Intelligence, y => y.MapFrom(z => Convert.ToInt32(z.Intelligence)))
            .ForMember(x => x.Power, y => y.MapFrom(z => Convert.ToInt32(z.Power)));

        }
    }
}
