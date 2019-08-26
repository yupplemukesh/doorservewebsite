using Doorserve.Core.Dtos;
using DoorServe;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Doorserve.Core
{
    public static class Helper
     {

        public async static Task<List<T>> RawSqlQuery<T>(string query, List<SqlParameter> parms,   Func<DbDataReader, T> map, GlobalProperties db, string type)
        {
            using (db =new GlobalProperties())
            {
                using (var command = db.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = query;
                    if (type == "Query")
                        command.CommandType = CommandType.Text;
                    else
                        command.CommandType = CommandType.StoredProcedure;
                    if (parms.Count > 0)
                        command.Parameters.AddRange(parms.ToArray());
                    db.Database.OpenConnection();
                    using (var result = await command.ExecuteReaderAsync())
                    {
                        var entities = new List<T>();
                        if (result.HasRows)
                        {
                            while (result.Read())
                            {
                                entities.Add(map(result));
                            }
                        }
                        return entities;
                    }
                }
            }
        }

        public async static Task<bool> AddOrEdit(  string query, List<SqlParameter> parms, GlobalProperties db, string type )
        {
            using (db =new GlobalProperties())
            {
                using (var command = db.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = query;
                    if (type == "Query")
                        command.CommandType = CommandType.Text;
                    else
                        command.CommandType = CommandType.StoredProcedure;
                    if (parms.Count > 0)
                        command.Parameters.AddRange(parms.ToArray());
                    db.Database.OpenConnection();
                  int value=  await command.ExecuteNonQueryAsync();
                    if (value > 0)
                        return true;
                    else
                        return false;
                }
            }


        }
    }
}
