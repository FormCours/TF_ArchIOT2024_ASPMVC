using Ratatouillage.Core.Interfaces.Repository;
using Ratatouillage.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratatouillage.Data.Repository
{
    public class IngredientRepository : RepositoryBase<int, Ingredient>, IIngredientRepository
    {
        public IngredientRepository(IDbConnection connection) : base(connection) { }

        protected override Ingredient Convert(IDataRecord record)
        {
            return new Ingredient
            {
                Id = (int)record["Id"],
                Name = (string)record["Name"]
            };
        }

        public IEnumerable<Ingredient> GetAll()
        {
            using(IDbCommand cmd =  _Connection.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Ingredient";

                _Connection.Open();
                using (IDataReader  reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return Convert(reader);
                    }
                }
                _Connection.Close();
            }
        }

        public Ingredient? GetById(int id)
        {
            using(IDbCommand cmd = _Connection.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Ingredient WHERE Id = @Id";
                AddParameter(cmd, "Id", id);

                _Connection.Open();
                Ingredient? ingredient = null;
                using (IDataReader reader = cmd.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        ingredient = Convert(reader);
                    }
                }
                _Connection.Close();

                return ingredient;
            }
        }

        public int Insert(Ingredient ingredient)
        {
            using(IDbCommand cmd = _Connection.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO Ingredient([Name])" +
                                    " OUTPUT inserted.[Id]" +
                                    " VALUES(@Name);";
                AddParameter(cmd, "Name", ingredient.Name);

                _Connection.Open();
                object? result = cmd.ExecuteScalar();
                _Connection.Close();

                if (result is null || result is DBNull)
                    throw new Exception("Error on ingredient insert !");

                return (int)result;
            }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
