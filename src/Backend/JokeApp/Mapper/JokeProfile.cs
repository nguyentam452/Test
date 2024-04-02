using AutoMapper;
using JokeApp.Dtos;
using JokeApp.Models;

namespace JokeApp.Mapper
{
    public class JokeProfile: Profile
    {
        public JokeProfile()
        {
            CreateMap<Joke, JokeDto>().ReverseMap();
        }
    }
}
