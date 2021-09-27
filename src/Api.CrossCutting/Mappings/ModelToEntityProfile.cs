using Api.Domain.Entities;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            //Corrweção após implementar testes unitários
            //CreateMap<UserEntity, UserModel>().ReverseMap();
            CreateMap<UserModel, UserEntity>().ReverseMap();
        }

    }
}