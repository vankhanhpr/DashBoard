using Dapper;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ClassModel.connnection.oracle
{
    public interface IOracleDyamicParameters
    {
        void Add(string name, OracleDbType oracleDbType, ParameterDirection direction, object value = null, int? size = null);
        void Add(string name, OracleDbType oracleDbType, ParameterDirection direction);
        void AddParameters(IDbCommand command, SqlMapper.Identity identity);
        IDbConnection GetConnection();
    }
}
