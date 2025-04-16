using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.DataAccessLayer.Concrete;
using Cental.DtoLayer.MessageDtos;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class MessageService(IMessageDal messageDal, IMapper mapper) : IMessageService
    {
        public void TCreate(CreateMessageDto dto)
        {
            var item = mapper.Map<Message>(dto);
            messageDal.Create(item);
        }

        public void TDelete(int id)
        {
            messageDal.Delete(id);
        }

        public List<ResultMessageDto> TGetAll()
        {
            var items = messageDal.GetAll();
            return mapper.Map<List<ResultMessageDto>>(items);
        }

        public ResultMessageDto TGetById(int id)
        {
            var item = messageDal.GetById(id);
            return mapper.Map<ResultMessageDto>(item);
        }
    }
}
