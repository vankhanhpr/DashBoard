using ClassModel.connnection.oracle;
using ClassModel.model.bsc;
using ClassModel.model.realIncrease;
using Dapper;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace DashBoardApi.server.bcs.impl
{
    public class BscImpl : IBsc
    {
        private IConfiguration m_configuration;
        private II8MobileApp m_i8MobileApp;
        private II8MobileAcceptance m_i8MobileAcceptance;
        private IDirectory m_directory;
        private ISlCos m_slCos;
        private IDetail_Fiber_MyTV m_detail_Fiber_MyTV;
        private IDetailDataReal m_detailDataReal;
        public BscImpl(IConfiguration configuration, II8MobileApp i8MobileApp, II8MobileAcceptance i8MobileAcceptance, IDirectory directory, ISlCos slCos, IDetail_Fiber_MyTV detail_Fiber_MyTV, IDetailDataReal detailDataReal)
        {
            m_configuration = configuration;
            m_i8MobileApp = i8MobileApp;
            m_i8MobileAcceptance = i8MobileAcceptance;
            m_directory = directory;
            m_slCos = slCos;
            m_detail_Fiber_MyTV = detail_Fiber_MyTV;
            m_detailDataReal = detailDataReal;
        }
        /*
          call stores  with the parameter
          the first
        */
        public dynamic execureI8MobileApp(BscRequest bscRequest)
        {
            List<BscRespond> result = new List<BscRespond>();
            var dyParam = new OracleDynamicParameters();
            dyParam.Add("vtungay", OracleDbType.Varchar2, ParameterDirection.Input, bscRequest.vtungay);
            dyParam.Add("vdenngay", OracleDbType.Varchar2, ParameterDirection.Input, bscRequest.vdenngay);

            dyParam.Add("returnds", OracleDbType.RefCursor, ParameterDirection.Output);
            var conn = GetConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            if (conn.State == ConnectionState.Open)
            {
                var query = "kiemsoat.bc_dashboard.i8_sudung_mobile_app_by_khanh";
                result = SqlMapper.Query<BscRespond>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure).AsList<BscRespond>();
                insertToI8MobileApp(result);
            }
            return result;
        }

        /*
         * select the second i8
         */
        public dynamic execureI8NghiemThu(BscRequest bscRequest)
        {
            List<I8AcceptanceRespond> result = new List<I8AcceptanceRespond>();
            var dyParam = new OracleDynamicParameters();
            dyParam.Add("vtungay", OracleDbType.Varchar2, ParameterDirection.Input, bscRequest.vtungay);
            dyParam.Add("vdenngay", OracleDbType.Varchar2, ParameterDirection.Input, bscRequest.vdenngay);
            dyParam.Add("vtrangthai", OracleDbType.Varchar2, ParameterDirection.Input, bscRequest.vtrangthai);

            dyParam.Add("returnds", OracleDbType.RefCursor, ParameterDirection.Output);
            var conn = GetConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            if (conn.State == ConnectionState.Open)
            {
                // var query = "select * from ppm_tuyetnt.I8NGHIEMTHU_KHANH";
                var query = "kiemsoat.bc_dashboard.i8_tk_tyle_ccdv_va_scdv_nghiem_thu_mobile_app";
                result = SqlMapper.Query<I8AcceptanceRespond>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure).AsList<I8AcceptanceRespond>();
                //result = SqlMapper.Query<I8AcceptanceRespond>(conn, query, param: dyParam, commandType: CommandType.Text).AsList<I8AcceptanceRespond>(); ;
                insertToI8MobileAcceptance(result);
            }
            return result;
        }

        /*
        * select danh ba thue bao
        */
        public dynamic execureDbThueBao(BscRequest bscRequest)
        {
            List<ListDirectoryRespond> result = new List<ListDirectoryRespond>();
            var dyParam = new OracleDynamicParameters();
            dyParam.Add("i_Thang", OracleDbType.Varchar2, ParameterDirection.Input, bscRequest.i_Thang);
            dyParam.Add("i_TTVT", OracleDbType.Varchar2, ParameterDirection.Input, bscRequest.i_TTVT);
            dyParam.Add("o_data", OracleDbType.RefCursor, ParameterDirection.Output);
            var conn = GetConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            if (conn.State == ConnectionState.Open)
            {
                var query = "kiemsoat.bc_dashboard.tke_lm_go_theo_dvtb";
                result = SqlMapper.Query<ListDirectoryRespond>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure).AsList<ListDirectoryRespond>();
               // insertToDirectory(result);
            }
            return result;
        }
        /*
         * get so luong thuc tan
         */
        public dynamic execureDataIncrese(BscRequest bscRequest)
        {
            List<DataReal> result = new List<DataReal>();
            var dyParam = new OracleDynamicParameters();
            dyParam.Add("i_thang", OracleDbType.Varchar2, ParameterDirection.Input, bscRequest.i_Thang);
            dyParam.Add("o_data", OracleDbType.RefCursor, ParameterDirection.Output);
            var conn = GetConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            if (conn.State == ConnectionState.Open)
            {
                var query = "mivtt.SL_COS.TK_TT_FIBER_MYTV";
                result = SqlMapper.Query<DataReal>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure).AsList<DataReal>();
                insertToCos(result, bscRequest);
            }
            return result;
        }
        /*
        * get chi tiet so luong thuc tan
        */
        public dynamic execureDetailFiberMyTV(BscRequest bscRequest)
        {
            List<DetailFiberMyTV> result = new List<DetailFiberMyTV>();
            var dyParam = new OracleDynamicParameters();
            dyParam.Add("i_tungay", OracleDbType.Varchar2, ParameterDirection.Input, bscRequest.i_tungay);
            dyParam.Add("i_denngay", OracleDbType.Varchar2, ParameterDirection.Input, bscRequest.i_denngay);
            dyParam.Add("o_data", OracleDbType.RefCursor, ParameterDirection.Output);
            var conn = GetConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            if (conn.State == ConnectionState.Open)
            {
                var query = "kiemsoat.bc_dashboard.detail_fiber_mytv";
                result = SqlMapper.Query<DetailFiberMyTV>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure).AsList<DetailFiberMyTV>();
                //insertDetailFiberMyTV(result);
            }
            return result;
        }
        /*
        * insert detail myvt fiber to database
        */
        public void insertDetailFiberMyTV(List<DetailFiberMyTV> listCos)
        {
            foreach (var cos in listCos)
            {
                DetailFiberMyTV data = new DetailFiberMyTV();
                data.id = cos.id;
                data.thuebao_id = cos.thuebao_id;
                data.ma_gd = cos.ma_gd;
                data.hdkh_id = cos.hdkh_id;
                data.ctv_id = cos.ctv_id;
                data.ma_gd = cos.ma_gd;
                data.ten_tb = cos.ten_tb;
                data.diachi_ld = cos.diachi_ld;
                data.ngaycn_bbbg = cos.ngaycn_bbbg;
                data.ngay_bbbg = cos.ngaycn_bbbg;
                data.dichvuvt_id = cos.dichvuvt_id;
                data.donvi_id = cos.donvi_id;
                data.fibervnn = cos.fibervnn;
                data.my_tv = cos.my_tv;
                data.donvi_tt = cos.donvi_tt;
                data.ma_tb = cos.ma_tb;
                m_detail_Fiber_MyTV.insert(data);
            }
        }
        /*
         * insert to SL_COS
         */
        public void insertToCos(List<DataReal> listCos, BscRequest bscRequest)
        {
            foreach (var cos in listCos)
            {
                DataReal data = new DataReal();
                data.id = cos.id;
                data.donvi = cos.donvi;
                data.ptm_fiber_ttkd = cos.ptm_fiber_ttkd;
                data.ptm_fiber_ttvt = cos.ptm_fiber_ttvt;
                data.ptm_mytv_ttkd = cos.ptm_mytv_ttkd;
                data.ptm_mytv_ttvt = cos.ptm_mytv_ttvt;
                data.huy_fiber = cos.huy_fiber;
                data.huy_mytv = cos.huy_mytv;
                data.ctld_mytv = cos.ctld_mytv;
                data.ctld_fiber = cos.ctld_fiber;
                data.ngaytao = DateTime.Now;
                var day = "01/" + bscRequest.i_Thang.ToString().Substring(4, 2) + "/" + bscRequest.i_Thang.ToString().Substring(0, 4);
                data.ngay = DateTime.ParseExact(day, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                data.thang = Int32.Parse(bscRequest.i_Thang.ToString().Substring(4,2));
                data.nam = Int32.Parse(bscRequest.i_Thang.ToString().Substring(0, 4));
                m_slCos.insert(data);
            }
        }

        /*
         * insert to II8Mobile
         */
        public void insertToI8MobileApp(List<BscRespond> bscResponds)
        {
            foreach (var bsc in bscResponds)
            {
                I8MobileApp i8MobileApp = new I8MobileApp();
                i8MobileApp.sl_login = bsc.sl_login;
                i8MobileApp.ten_tt = bsc.ten_tt;
                i8MobileApp.donvicha_id = bsc.donvicha_id;
                i8MobileApp.ten_dv = bsc.ten_dv;
                i8MobileApp.dv_id = bsc.dv_id;
                i8MobileApp.tong_nv = bsc.tong_nv;
                i8MobileApp.ty_le = bsc.ty_le;
                i8MobileApp.ngay = DateTime.ParseExact(bsc.ngay, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                m_i8MobileApp.insert(i8MobileApp);
            }
        }
        /*
         * insert to II8Mobile instance
         */
        public void insertToI8MobileAcceptance(List<I8AcceptanceRespond> bscResponds)
        {
            foreach (var bsc in bscResponds)
            {
                I8MobileAcceptance i8MobileAcceptance = new I8MobileAcceptance();
                i8MobileAcceptance.donvi_id = bsc.donvi_id;
                i8MobileAcceptance.PCT_CCDV_VA_SCDV_HOAN_TAT = bsc.PCT_CCDV_VA_SCDV_HOAN_TAT;
                i8MobileAcceptance.PCT_HOAN_TAT_QUA_MOBILE_APP = bsc.PCT_HOAN_TAT_QUA_MOBILE_APP;
                i8MobileAcceptance.donvi_cha_id = bsc.donvi_cha_id;
                i8MobileAcceptance.doi_vt = bsc.doi_vt;
                i8MobileAcceptance.trungtam = bsc.TTVT;
                i8MobileAcceptance.ngay_ht = DateTime.ParseExact(bsc.ngay_ht, "dd/MM/yyyy", CultureInfo.InvariantCulture); ;
                i8MobileAcceptance.ty_le = bsc.ty_le;

                m_i8MobileAcceptance.insert(i8MobileAcceptance);
            }
        }

        /*
        * insert to thong ke danh ba thue bao
        */
        public void insertToDirectory(List<ListDirectoryRespond> bscResponds)
        {
            foreach (var bsc in bscResponds)
            {
                ListDirectory directory = new ListDirectory();
                directory.TTVT = bsc.TTVT;
                directory.NAM = bsc.NAM;
                directory.THANG = bsc.THANG;
                directory.TOVT = bsc.TOVT;
                directory.DICHVU = bsc.DICHVU;
                directory.SANLUONG_GO = bsc.SOLUONG_GO;
                directory.SANLUONG_LM = bsc.SOLUONG_LM;
                m_directory.insert(directory);
            }
        }



        /*
       * get chi tiet so luong thuc tan
       */
        public dynamic execureDetailDataReal(BscRequest bscRequest)
        {
            List<DetailDataReal> result = new List<DetailDataReal>();
            var dyParam = new OracleDynamicParameters();
            dyParam.Add("o_data", OracleDbType.RefCursor, ParameterDirection.Output);
            var conn = GetConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            if (conn.State == ConnectionState.Open)
            {
                var query = "kiemsoat.bc_dashboard.detail_sl_thuctang";
                result = SqlMapper.Query<DetailDataReal>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure).AsList<DetailDataReal>();
                insertDetailDataReal(result);
            }
            return result;
        }
        /*
       * insert detail
       */
        public void insertDetailDataReal(List<DetailDataReal> bscResponds)
        {
            foreach (var bsc in bscResponds)
            {
                DetailDataReal data = new DetailDataReal();
                data.THUEBAO_ID = bsc.THUEBAO_ID;
                data.HDKH_ID = bsc.HDKH_ID;
                data.MA_GD = bsc.MA_GD;
                data.HDTB_ID = bsc.HDTB_ID;
                data.CTV_ID = bsc.CTV_ID;
                data.MA_TB = bsc.MA_TB;
                data.TEN_TB = bsc.TEN_TB;
                data.DIACHI_LD = bsc.DIACHI_LD;
                data.NGAYCN_BBBG = bsc.NGAYCN_BBBG;
                data.NGAY_BBBG = bsc.NGAY_BBBG;
                data.DICHVUVT_ID = bsc.DICHVUVT_ID;
                data.DONVI_ID = bsc.DONVI_ID;
                data.LAPMOI = bsc.LAPMOI;
                data.DONVI_TT = bsc.DONVI_TT;
                data.FIBER = bsc.FIBER;
                data.MYTV = bsc.MYTV;
                m_detailDataReal.insert(data);
            }
        }



        public IDbConnection GetConnection()
        {
            var connectionString = m_configuration.GetSection("connectionstrings").GetSection("defaultconnection2").Value;
            var conn = new OracleConnection(connectionString);
            return conn;
        }
    }
}
