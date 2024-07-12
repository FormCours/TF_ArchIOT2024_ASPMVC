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
    public class RecipeRepository : RepositoryBase<int, Recipe>, IRecipeRepository
    {
        public RecipeRepository(IDbConnection connection) : base(connection) { }

        protected override Recipe Convert(IDataRecord record)
        {
            return new Recipe
            {
                Id = (int)record["Id"],
                Name = (string)record["Name"],
                Desc = (string)record["Desc"]
            };
        }


        public IEnumerable<Recipe> GetAll()
        {
            using (IDbCommand cmd = _Connection.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Recipe";

                _Connection.Open();
                using (IDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return Convert(reader);
                    }
                }
                _Connection.Close();
            }
        }

        public Recipe? GetById(int id)
        {
            using (IDbCommand cmd = _Connection.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Recipe WHERE Id = @Id";
                AddParameter(cmd, "Id", id);

                _Connection.Open();
                Recipe? recipe = null;
                using (IDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        recipe = Convert(reader);
                    }
                }
                _Connection.Close();

                return recipe;
            }
        }

        public int Insert(Recipe recipe)
        {
            using (IDbCommand cmd = _Connection.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO Recipe([Name], [Desc])" +
                                    " OUTPUT inserted.[Id] " +
                                    " VALUES(@Name, @Desc);";
                AddParameter(cmd, "Name", recipe.Name);
                AddParameter(cmd, "Desc", recipe.Desc);

                _Connection.Open();
                object? result = cmd.ExecuteScalar();
                _Connection.Close();

                if (result is null || result is DBNull)
                    throw new Exception("Error on recipe insert !");

                return (int)result;
            }
        }
        public bool Update(int id, Recipe data)
        {
            throw new NotImplementedException();
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }


        public bool AddIngredient(int recipeId, int ingredientId, string quantity)
        {
            using (IDbCommand cmd = _Connection.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO Recipe_Ingredient([Recipe_Id], [Ingredient_Id], [Quantity])" +
                                    " VALUES(@RecipeId, @IngredientId, @Quantity);";
                AddParameter(cmd, "RecipeId", recipeId);
                AddParameter(cmd, "IngredientId", ingredientId);
                AddParameter(cmd, "Quantity", quantity);

                _Connection.Open();
                int nbRow = cmd.ExecuteNonQuery();
                _Connection.Close();

                return nbRow == 1;
            }
        }

        public bool RemoveIngredient(int recipeId, int ingredientId)
        {
            using (IDbCommand cmd = _Connection.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Recipe_Ingredient " +
                                  "WHERE Recipe_Id = @RecipeId AND Ingredient_Id = @IngredientId);";
                AddParameter(cmd, "RecipeId", recipeId);
                AddParameter(cmd, "IngredientId", ingredientId);

                _Connection.Open();
                int nbRow = cmd.ExecuteNonQuery();
                _Connection.Close();

                return nbRow == 1;
            }
        }

        public IEnumerable<IngredientWithQuantity> GetIngredients(int recipeId)
        {
            using (IDbCommand cmd = _Connection.CreateCommand())
            {
                cmd.CommandText = "SELECT I.[Id], I.[Name], RI.[Quantity] " +
                                  "FROM [Recipe_Ingredient] RI " +
                                  " JOIN [Ingredient] I ON I.[ID] = RI.[Ingredient_Id] " +
                                  "WHERE RI.[Recipe_Id] = @recipeId";
                AddParameter(cmd, "recipeId", recipeId);

                _Connection.Open();
                using (IDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new IngredientWithQuantity
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            Quantity = (string)reader["Quantity"]
                        };
                    }
                }
                _Connection.Close();
            }
        }
    }
}
