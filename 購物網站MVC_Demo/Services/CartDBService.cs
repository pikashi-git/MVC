using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using 購物網站MVC_Demo.App_Code;
using 購物網站MVC_Demo.Interfaces;
using 購物網站MVC_Demo.Models;

namespace 購物網站MVC_Demo.Services
{
    public class CartDBService
    {
        // 檢查購物車商品
        public bool checkCartItem(string cartID, int itemID)
        {
            bool inCart = false;
            if (cartID != null)
            {
                string sql = @" select * from cartItem where cart_id=@cartID and itemID=@itemID; ";
                IDB DB = new GuestbookDB(sql);
                List<SqlParameter> paraList = new List<SqlParameter>();
                paraList.Add(new SqlParameter("cartID", SqlDbType.VarChar) { Value = cartID });
                paraList.Add(new SqlParameter("itemID", SqlDbType.Int) { Value = itemID });
                DB.ParameterList = paraList.ToArray();
                inCart = DB.ActionScalar() != null ? true : false;
            }
            return inCart;
        }

        //取得購物車商品
        public List<CartItem> GetCartItems(string cartID) 
        {
            List<CartItem> dataList = new List<CartItem>();
            string sql = @" select c.cart_id,c.itemID,i.name,i.price,i.image from cartItem c inner join items i on c.itemID=i.itemID where c.cart_id=@cartID ";
            IDB DB = new GuestbookDB(sql);
            List<SqlParameter> paraList = new List<SqlParameter>();
            paraList.Add(new SqlParameter("cartID", SqlDbType.VarChar) { Value = cartID });
            DB.ParameterList = paraList.ToArray();
            using (SqlDataReader reader = DB.ActionReader())
            {
                while (reader.Read())
                {
                    CartItem _cartBuy = new CartItem()
                    {
                        CartId = Convert.ToString(reader["cart_id"]),
                        ItemID = Convert.ToInt32(reader["itemID"]),
                        Item = new Item()
                        {
                            Name = Convert.ToString(reader["name"]),
                            Price = Convert.ToInt32(reader["price"]),
                            Image = Convert.ToString(reader["image"])
                        }
                    };
                    dataList.Add(_cartBuy);
                }
            }
            return dataList;
        }

        //新增購物車商品
        public bool AddCartItem(string cartID, int itemID, out string msg)
        {
            msg = string.Empty;
            bool rtv = false;
            string sql = @" insert into cartItem(cart_id,itemID) values(@cartID, @itemID); ";
            IDB DB = new GuestbookDB(sql);
            List<SqlParameter> sqlparaList = new List<SqlParameter>();
            sqlparaList.Add(new SqlParameter("cartID", SqlDbType.VarChar) { Value = cartID });
            sqlparaList.Add(new SqlParameter("itemID", SqlDbType.Int) { Value = itemID });
            DB.ParameterList = sqlparaList.ToArray();
            if (DB.Action() > 0)
                rtv = true;
            else
                msg = @"新增購物車商品失敗";
            return rtv;
        }

        //刪除購物車商品
        public bool RemovedCartItem(string cartID, int itemID, out string msg)
        {
            msg = string.Empty;
            bool rtv = false;
            string sql = @" delete from cartItem where cart_id=@cartID and itemID=@itemID; ";
            IDB DB = new GuestbookDB(sql);
            List<SqlParameter> sqlparaList = new List<SqlParameter>();
            sqlparaList.Add(new SqlParameter("cartID", SqlDbType.VarChar) { Value = cartID });
            sqlparaList.Add(new SqlParameter("itemID", SqlDbType.Int) { Value = itemID });
            DB.ParameterList = sqlparaList.ToArray();
            if (DB.Action() > 0)
                rtv = true;
            else
                msg = @"刪除購物車商品失敗";
            return rtv;
        }

        // 檢查購物車
        public bool CheckCart(string account, string cartID)
        {
            bool rtv = false;
            string sql = @" select count(*) from cart where cart_id=@cartID and userID=(select userID from users where account=@account); ";
            IDB DB = new GuestbookDB(sql);
            List<SqlParameter> paraList = new List<SqlParameter>();
            paraList.Add(new SqlParameter("cartID", SqlDbType.VarChar) { Value = cartID });
            paraList.Add(new SqlParameter("account", SqlDbType.NVarChar) { Value = account });
            DB.ParameterList = paraList.ToArray();
            string count = DB.ActionScalar();
            try
            {
                if (Convert.ToInt32(count) > 0)
                    rtv = true;
            }
            catch
            { }
            return rtv;
        }

        //取得購物車
        public Cart GetCart(string account)
        {
            Cart _cart = null;
            string sql = @" select c.userID,c.cart_id,u.account,u.names from cart c inner join users u on c.userID=u.userID where u.account=@account; ";
            IDB DB = new GuestbookDB(sql);
            List<SqlParameter> paraList = new List<SqlParameter>();
            paraList.Add(new SqlParameter("account", SqlDbType.NVarChar) { Value = account });
            DB.ParameterList = paraList.ToArray();
            using (SqlDataReader reader = DB.ActionReader())
            {
                if (reader.Read())
                {
                    _cart = new Cart()
                    {
                        UserID = Convert.ToInt32(reader["userID"]),
                        CartId = Convert.ToString(reader["cart_id"]),
                        User = new Users()
                        {
                            Account = Convert.ToString(reader["account"]),
                            Names = Convert.ToString(reader["names"])
                        }
                    };
                }
            }
            return _cart;
        }

        //新增購物車
        public bool AddCart(string account, string cartID, out string msg)
        {
            msg = string.Empty;
            bool rtv = false;
            string sql = @" insert into cart(userID, cart_id) values((select userID from users where account=@account), @cartID); ";
            IDB DB = new GuestbookDB(sql);
            List<SqlParameter> sqlparaList = new List<SqlParameter>();
            sqlparaList.Add(new SqlParameter("account", SqlDbType.NVarChar) { Value = account });
            sqlparaList.Add(new SqlParameter("cartID", SqlDbType.VarChar) { Value = cartID });
            DB.ParameterList = sqlparaList.ToArray();
            if (DB.Action() > 0)
                rtv = true;
            else
                msg = @"新增購物車失敗";
            return rtv;
        }

        //刪除購物車
        public bool RemovedCart(string account, out string msg)
        {
            msg = string.Empty;
            bool rtv = false;
            string sql = @" delete from cart where userID=(select userID from users where account=@account); ";
            IDB DB = new GuestbookDB(sql);
            List<SqlParameter> sqlparaList = new List<SqlParameter>();
            sqlparaList.Add(new SqlParameter("cartID", SqlDbType.NVarChar) { Value = account });
            DB.ParameterList = sqlparaList.ToArray();
            if (DB.Action() > 0)
                rtv = true;
            else
                msg = @"刪除購物車失敗";
            return rtv;
        }
    }
}