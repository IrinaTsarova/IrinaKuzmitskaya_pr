/*
 *
 */

using IrinaKuzmitskaya_pr.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrinaKuzmitskaya_pr.Models {
    internal class CartProduct {

        private static readonly string DATABASE_TABLE_NAME = "dbo.CartProduct";

        public int CartID { get; set; }

        public int Productid { get; set; }
        public int ProductQuantity { get; set; }


        public CartProduct(int cartId, int productId) : this(cartId, productId,1) { 
        }

        public CartProduct(int cartId, int productId, int productQuantity) {
            this.CartID = cartId;
            this.Productid = productId;
            this.ProductQuantity = productQuantity;
        }


        #region Methods


        public static CartProduct GetByIds(int cartId, int productId) {
            using (SqlConnection connection = DbUtils.GetDefaultConnection()) {
                string statement = $"SELECT * FROM {DATABASE_TABLE_NAME} " +
                    $"WHERE cartId = @cartId AND productId = @productId;";
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = statement;

                SqlParameter cartIdParam = cmd.CreateParameter();
                cartIdParam.ParameterName = "@catId";
                cartIdParam.DbType = DbType.Int32;
                cartIdParam.Value = cartId;
                cmd.Parameters.Add(cartIdParam);

                SqlParameter productIdParam = cmd.CreateParameter();
                productIdParam.ParameterName = "@productId";
                productIdParam.DbType = DbType.Int32;
                productIdParam.Value = productId;
                cmd.Parameters.Add(productIdParam);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows) {
                    reader.Read();

                    int productQuantity = reader.GetInt32(2);
                    return new CartProduct(cartId, productId, productQuantity);

                } else {
                    throw new Exception($"Failed to retrieve {typeof(CartProduct)}: no database entry found for CartId# {cartId} and ProductId# {productId}.");
                }

            }
        }

        public static List<CartProduct> GetAllByCartId(int cartId) {
            using (SqlConnection connection = DbUtils.GetDefaultConnection()) {
                string statement = $"SELECT * FROM {DATABASE_TABLE_NAME} " +
                    $"WHERE cartId = @cartId;";
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = statement;

                SqlParameter cartIdParam = cmd.CreateParameter();
                cartIdParam.ParameterName = "@catId";
                cartIdParam.DbType = DbType.Int32;
                cartIdParam.Value = cartId;
                cmd.Parameters.Add(cartIdParam);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<CartProduct> cartProducts = new List<CartProduct>();
                while (reader.Read()) {
                    int productId = reader.GetInt32(1);
                    int productQuantity = reader.GetInt32(2);
                    cartProducts.Add(new CartProduct(cartId, productId, productQuantity));

                }
                return cartProducts;
            }
        }

        public static List<CartProduct> GetAllByProductId(int productId) {
            using (SqlConnection connection = DbUtils.GetDefaultConnection()) {
                string statement = $"SELECT * FROM {DATABASE_TABLE_NAME} " +
                    $"WHERE productId = @productId;";
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = statement;

                SqlParameter productIdParam = cmd.CreateParameter();
                productIdParam.ParameterName = "@productId";
                productIdParam.DbType = DbType.Int32;
                productIdParam.Value = productId;
                cmd.Parameters.Add(productIdParam);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<CartProduct> cartProducts = new List<CartProduct>();
                while (reader.Read()) {
                    int cartId = reader.GetInt32(0);
                    int productQuantity = reader.GetInt32(2);
                    cartProducts.Add(new CartProduct(cartId, productId, productQuantity));

                }
                return cartProducts;
            }
        }

        public void Delete() {
            if (this.CartID == 0 ) {
                // CartId has not been set, it is initialized by default at 0;
                throw new Exception($"Cannot use method {this.GetType().FullName}.Delete() : CartId value is 0.");
            } else if (this.Productid == 0) {
                // ProductId has not been set, it is initialized by default at 0;
                throw new Exception($"Cannot use method {this.GetType().FullName}.Delete() : ProductId value is 0.");
            }

            using (SqlConnection connection = DbUtils.GetDefaultConnection()) {
                string statement = $"DELETE FROM {DATABASE_TABLE_NAME} " +
                    $"WHERE cartId = @cartId AND productId = @productId;";
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = statement;

                SqlParameter cartIdParam = cmd.CreateParameter();
                cartIdParam.ParameterName = "@catId";
                cartIdParam.DbType = DbType.Int32;
                cartIdParam.Value = this.CartID;
                cmd.Parameters.Add(cartIdParam);

                SqlParameter productIdParam = cmd.CreateParameter();
                productIdParam.ParameterName = "@productId";
                productIdParam.DbType = DbType.Int32;
                productIdParam.Value = this.Productid;
                cmd.Parameters.Add(productIdParam);

                connection.Open();
                int affectedRows = cmd.ExecuteNonQuery();

                if (!(affectedRows > 0)) {
                    // No affected rows: no deletion occured -> row with matching Id not found
                    throw new Exception($"Failed to delete {this.GetType().FullName}: no database entry found for CartId# {this.CartID} and ProductId# {this.Productid}.");
                }
            }
        }

        public CartProduct Insert() {
            if (this.CartID == 0) {
                // CartId has not been set, it is initialized by default at 0;
                throw new Exception($"Cannot use method {this.GetType().FullName}.Delete() : CartId value is 0.");
            } else if (this.Productid == 0) {
                // ProductId has not been set, it is initialized by default at 0;
                throw new Exception($"Cannot use method {this.GetType().FullName}.Delete() : ProductId value is 0.");
            }

            using (SqlConnection sqlConnection = DbUtils.GetDefaultConnection()) {


                string insertCommandText = $"INSERT INTO {DATABASE_TABLE_NAME} (cartId, " +
                    "productId, productQuantity) " +
                    $"VALUES (@cartId, @productId, @productQuantity);";

                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandText = insertCommandText;

                // Create and add parameters
                SqlParameter cartIdParam = cmd.CreateParameter();
                cartIdParam.ParameterName = "@cartId";
                cartIdParam.DbType = DbType.Int32;
                cartIdParam.Value = this.CartID;
                cmd.Parameters.Add(cartIdParam);

                SqlParameter productIdParam = cmd.CreateParameter();
                productIdParam.ParameterName = "@productId";
                productIdParam.DbType = DbType.Int32;
                productIdParam.Value = this.Productid;
                cmd.Parameters.Add(productIdParam);

                SqlParameter productQuantityParam = cmd.CreateParameter();
                productQuantityParam.ParameterName = "@productQuantity";
                productQuantityParam.DbType = DbType.Int32;
                productQuantityParam.Value = this.ProductQuantity;
                cmd.Parameters.Add(productQuantityParam);


                sqlConnection.Open();
                cmd.ExecuteNonQuery();

                return this;
            }
        }

        public CartProduct Update() {
            if (this.CartID == 0) {
                // CartId has not been set, it is initialized by default at 0;
                throw new Exception($"Cannot use method {this.GetType().FullName}.Delete() : CartId value is 0.");
            } else if (this.Productid == 0) {
                // ProductId has not been set, it is initialized by default at 0;
                throw new Exception($"Cannot use method {this.GetType().FullName}.Delete() : ProductId value is 0.");
            }

            using (SqlConnection connection = DbUtils.GetDefaultConnection()) {
                string statement = $"UPDATE {DATABASE_TABLE_NAME} " +
                    "SET productQuantity = @productQuantity" +
                    "WHERE cartId = @cartId AND productId = @productId;";
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = statement;

                // Create and add parameters
                SqlParameter cartIdParam = cmd.CreateParameter();
                cartIdParam.ParameterName = "@cartId";
                cartIdParam.DbType = DbType.Int32;
                cartIdParam.Value = this.CartID;
                cmd.Parameters.Add(cartIdParam);

                SqlParameter productIdParam = cmd.CreateParameter();
                productIdParam.ParameterName = "@productId";
                productIdParam.DbType = DbType.Int32;
                productIdParam.Value = this.Productid;
                cmd.Parameters.Add(productIdParam);

                SqlParameter productQuantityParam = cmd.CreateParameter();
                productQuantityParam.ParameterName = "@productQuantity";
                productQuantityParam.DbType = DbType.Int32;
                productQuantityParam.Value = this.ProductQuantity;
                cmd.Parameters.Add(productQuantityParam);

                connection.Open();
                int affectedRows = cmd.ExecuteNonQuery();

                if (affectedRows < 1) {
                    // No affected rows: no update occured -> row with matching Ids not found
                    throw new Exception($"Failed to update {this.GetType().FullName}: no database entry found for CartId# {this.CartID} and ProductId# {this.Productid}.");
                }

                return this;
            }
        }


        #endregion


    }
}
