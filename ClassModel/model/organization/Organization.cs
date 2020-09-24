using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClassModel.model.organization
{
    public class Organization
    {
        [Key]
        public int donvi_id { get; set; }
        public string ten_dv { get; set; }
        public string ma_dv { get; set; }
        public string diachi_dv { get; set; }
        public string so_dt { get; set; }
        public string so_fax { get; set; }
        public string mst { get; set; }
        public string stk { get; set; }
        public string nguoi_dd { get; set; }
        public string chucdanh { get; set; }
        public int nganhang_id { get; set; }
        public string ten_dvql { get; set; }
        public int donvi_ql { get; set; }
        public int muc_id { get; set; }
        public int donvi_cha_id { get; set; }
        public int donvi_id_neo { get; set; }
        public string ghichu { get; set; }
        public string email { get; set; }
        public string website { get; set; }
        public int tinh_id { get; set; }
        public string tiento { get; set; }
        public int kinhdo { get; set; }
        public int vido { get; set; }
        public string mota { get; set; }
        public int hthd_id { get; set; }
        public int mabc_id_neo { get; set; }
        public string icon { get; set; }
        public string giay_uq { get; set; }
        public string giayphep_kd { get; set; }
        public string ngaycap { get; set; }
        public string noicap { get; set; }
    }
}
