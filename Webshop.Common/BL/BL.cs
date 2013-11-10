using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.Common.DAL;

namespace Webshop.Common.BL
{
    public class BL: Webshop.Common.BL.IBL
    {
        private readonly IDAL _dal;
        private readonly IBLProdukt _blProdukt;
        //private readonly IBLUser _blUser;
        //private readonly IBLAuthentication _blAuth;

        public BL(IDAL dal, IBLProdukt blProdukt/*, IBLUser blUser, IBLAutentication blAuth*/)
        {
            _dal = dal;
            _blProdukt = blProdukt;
            //_blUser = blUser;
            //_blAuth = blAuth;
        }

        public IBLProdukt Produkt { get { return _blProdukt; } }
        //public IBLUser User { get { return _blUser; } }
        //public IBLAuthentication Auth { get { return _blAuth; } }

        public void SaveChanges()
        {
            _dal.SaveChanges();
        }

    }
}
