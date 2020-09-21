using ClassModel.connnection.reponsitory.impl;
using ClassModel.connnection.sql;
using ClassModel.model.bsc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashBoardApi.server.bcs.impl
{
    public class Detail_Fiber_MyTVImpl : Reponsitory<DetailFiberMyTV>, IDetail_Fiber_MyTV
    {
        public Detail_Fiber_MyTVImpl(DataContext context) : base(context)
        {
        }
    }
}
