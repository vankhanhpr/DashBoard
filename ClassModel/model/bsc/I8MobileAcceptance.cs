using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClassModel.model.bsc
{
    public class I8MobileAcceptance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int i8mbacceptid { get; set; }
        public int donvi_id { get; set; }
        public int donvi_cha_id { get; set; }
        public string doi_vt { get; set; }
        public string trungtam { get; set; }
        public DateTime ngay_ht { get; set; }
        public int PCT_CCDV_VA_SCDV_HOAN_TAT { get; set; }
        public int PCT_HOAN_TAT_QUA_MOBILE_APP { get; set; }
        public double ty_le { get; set; }
    }
}
