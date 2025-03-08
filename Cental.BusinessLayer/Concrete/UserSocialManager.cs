using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.DtoLayer.UserSocialDtos;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class UserSocialManager(IUserSocialDal _userSocialDal) : IUserSocialService
    {
        public void TCreate(UserSocial entity)
        {
            _userSocialDal.Create(entity);
        }

        public void TDelete(int id)
        {
           _userSocialDal.Delete(id);
        }

        public List<UserSocial> TGetAll()
        {
           return _userSocialDal.GetAll();
        }

        public UserSocial TGetById(int id)
        {
           return _userSocialDal.GetById(id);
        }

        public List<UserSocial> TGetSocialsByUserId(int userId)
        {
            return _userSocialDal.GetSocialsByUserId(userId);
        }

        public void TUpdate(UserSocial entity)
        {
           _userSocialDal.Update(entity);
        }
    }
}
