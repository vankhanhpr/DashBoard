using ClassModel.model.bsc;
using DashBoardApi.server.bcs;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashBoardApi.schedule
{
    public class QueryData : IJob
    {
        private IBsc m_bsc;
        public QueryData(IBsc bsc)
        {
            m_bsc = bsc;
        }

        public Task Execute(IJobExecutionContext context)
        {
            BscRequest bscRequest = new BscRequest();
            bscRequest.vtungay = DateTime.Now.AddDays(-2).Day +"/"+ DateTime.Now.AddDays(-2).Month+"/"+ DateTime.Now.AddDays(-2).Year;
            bscRequest.vtungay = DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year;
            return m_bsc.execureI8NghiemThu(bscRequest);
        }
    }
}
