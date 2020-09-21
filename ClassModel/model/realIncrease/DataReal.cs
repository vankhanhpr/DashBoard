using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClassModel.model.realIncrease
{
    public class DataReal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string donvi { get; set; }
        public int ptm_fiber_ttkd { get; set; }
        public int ptm_fiber_ttvt { get; set; }
        public int ptm_mytv_ttkd { get; set; }
        public int ptm_mytv_ttvt { get; set; }
        public int huy_fiber { get; set; }
        public int huy_mytv { get; set; }
        public int ctld_mytv { get; set; }
        public int ctld_fiber { get; set; }
        public DateTime ngay { get; set; }
        public DateTime ngaytao { get; set; }
        public int thang { get; set; }
        public int nam { get; set; }

    }
}
