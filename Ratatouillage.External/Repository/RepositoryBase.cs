using Ratatouillage.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratatouillage.External.Repository
{
    public abstract class RepositoryBase<TKey, TEntity>
    {
        protected readonly IDbConnection _Connection;

        public RepositoryBase(IDbConnection connection)
        {
            _Connection = connection;
        }

        protected virtual void AddParameter(IDbCommand cmd, string key, object? value)
        {
            IDataParameter parameter = cmd.CreateParameter();
            parameter.ParameterName = key;
            parameter.Value = value ?? DBNull.Value;
            cmd.Parameters.Add(parameter);
        }

        protected abstract TEntity Convert(IDataRecord record);
    }
}
