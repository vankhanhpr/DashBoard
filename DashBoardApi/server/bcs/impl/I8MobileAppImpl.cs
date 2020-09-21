using ClassModel.connnection.reponsitory.impl;
using ClassModel.connnection.sql;
using ClassModel.model.bsc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashBoardApi.server.bcs.impl
{
    public class I8MobileAppImpl : Reponsitory<I8MobileApp>, II8MobileApp
    {
        public I8MobileAppImpl(DataContext context) : base(context)
        {
        }
    }
}
