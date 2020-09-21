using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClassModel.model.realIncrease
{
    public class DetailDataReal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int THUEBAO_ID { get; set; }
        public int HDKH_ID { get;set;}
        public string MA_GD {get;set;}
        public int HDTB_ID { get;set;}
        public int CTV_ID { get;set;}
        public string MA_TB { get;set;}
        public string TEN_TB { get;set;}
        public string DIACHI_LD { get;set;}
        public string NGAYCN_BBBG { get;set;}
        public string NGAY_BBBG { get;set;}
        public int DICHVUVT_ID { get;set;}
        public int DONVI_ID { get;set;}
        public int LAPMOI { get;set;}
        public int DONVI_TT { get;set;}
        public int FIBER { get; set; }
        public int MYTV { get; set; }
    }
}
