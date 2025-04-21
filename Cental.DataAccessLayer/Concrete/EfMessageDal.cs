using Cental.DataAccessLayer.Abstract;
using Cental.DataAccessLayer.Context;
using Cental.DataAccessLayer.Repositories;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DataAccessLayer.Concrete
{
    public class EfMessageDal : GenericRepository<Message>, IMessageDal
    {
        public EfMessageDal(CentalContext context) : base(context)
        {
        }

        public void MarkAsRead(int id)
        {
            var message = _context.Messages.Find(id);
            if (message != null)
            {
                message.IsRead = true;
                _context.SaveChanges();
            }
        }
    }
}
