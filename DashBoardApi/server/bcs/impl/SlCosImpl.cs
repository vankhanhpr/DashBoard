using ClassModel.connnection.reponsitory.impl;
using ClassModel.connnection.sql;
using ClassModel.model.realIncrease;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashBoardApi.server.bcs.impl
{
    public class SlCosImpl : Reponsitory<DataReal>, ISlCos
    {
        public SlCosImpl(DataContext context) : base(context)
        {
        }
    }
}
