using Repaso_2.Contracts.ClassMapper;
using Repaso_2.Contracts.Repositories;
using Repaso_2.MPP;
using Repaso_2.Utilities.Connections;
using Repaso_2.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso_2.DAL
{
    public class Repository<T> : IRepository<T>
    {
        public List<T> GetAll()
        {
            string query = CreateSelectQuery();
            return ExecuteSelectStatement(query);
        }


        protected virtual string CreateSelectQuery()
        {
            return $"SELECT {typeof(T).GetColumnValues()} FROM {typeof(T).Name}";
        }

        protected virtual List<T> ExecuteSelectStatement(string query, IDictionary<string,object> parameters = null)
        {
            return ExecuteSelectStatement<T>(query);
        }

        protected virtual List<Q> ExecuteSelectStatement<Q>(string query, IDictionary<string,object> parameters = null)
        {
            using (IDbConnection conn = DbConnection())
            {
                conn.Open();
                IDbCommand command = DbCommand(query,conn);

                if (parameters != null)
                {
                    foreach (var it in parameters)
                    {
                        IDbDataParameter dataParameter = command.CreateParameter();
                        dataParameter.ParameterName = it.Key;
                        dataParameter.Value = it.Value;
                        command.Parameters.Add(dataParameter);
                    }
                }

                IDbDataAdapter dataAdapter = DbDataAdapter(command);
                return FetchData<Q>(dataAdapter);

            }
        }

        protected virtual void ExecuteNonQueryStatement(string query, IDictionary<string,object> parameters = null)
        {
            using (IDbConnection conn = DbConnection())
            {
                conn.Open();
                IDbCommand dbCommand = DbCommand(query, conn);

                if (parameters != null)
                {
                    foreach (var it in parameters)
                    {
                        IDbDataParameter dataParameter = dbCommand.CreateParameter();
                        dataParameter.ParameterName = it.Key;
                        dataParameter.Value = it.Value;
                        dbCommand.Parameters.Add(dataParameter);
                    }
                }
                dbCommand.ExecuteNonQuery();
            }
        }

        protected virtual IDbDataAdapter DbDataAdapter(IDbCommand command)
        {
            return new SqlDataAdapter((SqlCommand)command);
        }

        protected virtual List<Q> FetchData<Q>(IDbDataAdapter dataAdapter)
        {
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            IClassMapper<Q> classMapper = new ClassMapper<Q>();
            return classMapper.Map(dataSet);
        } 

        protected virtual IDbCommand DbCommand(string query, IDbConnection conn)
        {
            return new SqlCommand(query, (SqlConnection)conn);
        }

        protected virtual IDbConnection DbConnection()
        {
            return PringlesMainConnection.GetDbConnection();
        }

        public void Save(T entity)
        {
            string query = CreateQueryInsert(entity);
            ExecuteNonQueryStatement(query);
        }

        protected virtual string CreateQueryInsert(T entity)
        {
            return CreateQueryInsert<T>(entity);
        }

        protected virtual string CreateQueryInsert<Q>(Q entity)
        {
            return $"INSERT INTO {typeof(Q).Name} ({typeof(Q).GetInsertColumn()}) VALUES ({entity.GetInsertColumnValue()})";
        }

        public void Delete(T entity)
        {
            string query = CreateQueryDelete(entity);
            ExecuteNonQueryStatement(query);
        }

        protected virtual string CreateQueryDelete(T entity)
        {
            return CreateQueryDelete<T>(entity);
        }

        protected virtual string CreateQueryDelete<Q>(Q entity)
        {
            return $"DELETE FROM {typeof(Q).Name} WHERE 1 = 1 AND {entity.GetPrimaryKeyComparation()}";
        }

        protected virtual string CreateQueryUpdate<Q>(Q entity)
        {
            return $"UPDATE {typeof(Q).Name} SET {entity.GetUpdateColumnValues()} WHERE 1 = 1 AND {entity.GetPrimaryKeyComparation()}";
        }

        protected virtual string CreateQueryUpdate(T entity)
        {
            return CreateQueryUpdate<T>(entity);
        }

        public void Update(T entity)
        {
            string query = CreateQueryUpdate(entity);
            ExecuteNonQueryStatement(query);
        }
    }
}
