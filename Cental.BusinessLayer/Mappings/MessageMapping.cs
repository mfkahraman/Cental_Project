using AutoMapper;
using Cental.DtoLayer.MessageDtos;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Mappings
{
    public class MessageMapping : Profile
    {
        public MessageMapping()
        {
            CreateMap<Message, ResultMessageDto>();
            CreateMap<Message, CreateMessageDto>().ReverseMap();
        }
    }
}
