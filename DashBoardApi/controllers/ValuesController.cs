using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassModel.model.bsc;
using ClassModel.respond;
using DashBoardApi.schedule;
using DashBoardApi.server.bcs;
using Microsoft.AspNetCore.Mvc;

namespace DashBoardApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IBsc m_bsc;
        public ValuesController(IBsc _bsc)
        {
            m_bsc = _bsc;
        }
        [HttpGet("test")]
        public dynamic get()
        {
            return "success";
        }

        [HttpPost("execureI8MobileApp")]
        public dynamic execureI8MobileApp([FromBody] BscRequest data)
        {
            return m_bsc.execureI8MobileApp(data);
        }
        [HttpPost("execureI8NghiemThu")]
        public dynamic execureI8NghiemThu([FromBody] BscRequest data)
        {
            return m_bsc.execureI8NghiemThu(data);
        }

        [HttpPost("execureDetailFiberMyTV")]
        public dynamic execureDetailFiberMyTV([FromBody] BscRequest data)
        {
            return m_bsc.execureDetailFiberMyTV(data);
        }

        [HttpPost("execureDataIncrese")]
        public DataRespond execureDataIncrese([FromBody] BscRequest data)
        {
            DataRespond datarp = new DataRespond();
            // return "202003".Substring(0, 4);
            try
            {
                datarp.data = m_bsc.execureDataIncrese(data);
            }
            catch (Exception e)
            {
                datarp.error = e;
            }
            return datarp;
        }

        [HttpGet("execureDataIncreseTest")]
        public dynamic execureDataIncreseTest()
        {
            DataRespond datarp = new DataRespond();
            BscRequest data = new BscRequest();
            data.i_Thang = "202007";
            //Object[] temp = new Object[] {
            //             new { target = "upper_50", refId = "A", type = "timeserie" },
            //             new { target = "upper_75", refId = "B", type = "timeserie" }
            //};
            //Object[] temp2 = new Object[]
            //{
            //    new {
            //            key = "City",
            //            operator1 = "=",
            //            value = "Berlin"
            //        }
            //};
            // return "202003".Substring(0, 4);
            try
            {
                //var x = new
                //{
                //    panelId = 1,
                //    range = new {
                //        from = "2016-10-31T06:33:44.866Z",
                //        to = "2016-10-31T12:33:44.866Z",
                //        raw = new {
                //            from = "now-6h",
                //            to = "now"
                //        }
                //    },
                //    rangeRaw = new {
                //        from = "now-6h",
                //        to = "now"
                //    },
                //    interval = "30s",
                //    intervalMs = 30000,
                //    targets = temp,
                //    adhocFilters = temp2,
                //    format = "json",
                //    maxDataPoints = 550
                //};
                Object[] temp = new Object[] {
                                         new { text = "Time", type = "time"},
                                         new { text = "Country",type = "string"},
                                         new { text = "Number",type = "number"}
                };
                Object[] temp2 = new Object[] {
                };
                Object[] x = new Object[] {
                      new {
                          columns =temp,
                        rows = temp2,
                        type = "tab"
                      }
                    };
                return x;
                  
             }
            catch (Exception e)
            {
                datarp.error = e;
            }
            return datarp;
        }


        [HttpGet("query")]
        public dynamic query()
        {
            DataRespond datarp = new DataRespond();
            BscRequest data = new BscRequest();
            data.i_Thang = "202007";
            try { 
                Object[] temp = new Object[] {
                                         new { text = "Time", type = "time"},
                                         new { text = "Country",type = "string"},
                                         new { text = "Number",type = "number"}
                };
                Object[] temp2 = new Object[] {
                };
                Object[] x = new Object[] {
                      new {
                          columns =temp,
                        rows = temp2,
                        type = "tab"
                      }
                    };
                return x;

            }
            catch (Exception e)
            {
                datarp.error = e;
            }
            return datarp;
        }




        [HttpGet("getDetailDataReal")]
        public dynamic getDetailDataReal()
        {
            BscRequest x = new BscRequest();
            return m_bsc.execureDetailDataReal(x);
        }

    }
}
