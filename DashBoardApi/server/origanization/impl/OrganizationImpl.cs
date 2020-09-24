using ClassModel.connnection.oracle;
using ClassModel.connnection.reponsitory.impl;
using ClassModel.connnection.sql;
using ClassModel.model.bsc;
using ClassModel.model.organization;
using Dapper;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DashBoardApi.server.origanization.impl
{
    public class OrganizationImpl : Reponsitory<Organization>, IOrganization
    {
        private IConfiguration m_configuration;
        public OrganizationImpl(DataContext context, IConfiguration configuration) : base(context)
        {
            m_configuration = configuration;
        }

        public dynamic execureOrganization()
        {
            List<Organization> result = new List<Organization>();
            var dyParam = new OracleDynamicParameters();
            //dyParam.Add("vtungay", OracleDbType.Varchar2, ParameterDirection.Input, bscRequest.vtungay);
            //dyParam.Add("vdenngay", OracleDbType.Varchar2, ParameterDirection.Input, bscRequest.vdenngay);

            //dyParam.Add("returnds", OracleDbType.RefCursor, ParameterDirection.Output);
            var conn = GetConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            if (conn.State == ConnectionState.Open)
            {
                var query = "select dv.* from ADMIN_HCM.donvi dv where dv.donvi_id is not null and dv.donvi_id in(select donvi_id from  ADMIN_HCM.nhanvien_dv nvdv)";
                result = SqlMapper.Query<Organization>(conn, query, param: dyParam, commandType: CommandType.Text).AsList<Organization>();
                insertOrganization(result);
            }
            return result;
        }
        private void insertOrganization(List<Organization> listData)
        {
            foreach (var i in listData)
            {
                insert(i);
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
