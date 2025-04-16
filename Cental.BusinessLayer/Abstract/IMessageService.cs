using Cental.DtoLayer.FeatureDtos;
using Cental.DtoLayer.MessageDtos;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<ResultMessageDto> TGetAll();
        ResultMessageDto TGetById(int id);
        void TDelete(int id);
        void TCreate(CreateMessageDto dto);
    }
}
