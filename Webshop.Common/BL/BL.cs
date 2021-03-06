﻿using System;
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
        private readonly IBLBestellung _blBestellung;
        private readonly IBLUser _blUser;
        private readonly IBLAuthentication _blAuthentication;

        public BL(IDAL dal, IBLProdukt blProdukt, IBLBestellung blBestellung, IBLUser blUser, IBLAuthentication blAuthentication)
        {
            _dal = dal;
            _blProdukt = blProdukt;
            _blBestellung = blBestellung;
            _blUser = blUser;
            _blAuthentication = blAuthentication;
        }

        public IBLProdukt Produkt { get { return _blProdukt; } }
        public IBLBestellung Bestellung { get { return _blBestellung; } }
        public IBLUser User { get { return _blUser; } }
        public IBLAuthentication Authentication { get { return _blAuthentication; } }

        public void SaveChanges()
        {
            _dal.SaveChanges();
        }

    }
}
