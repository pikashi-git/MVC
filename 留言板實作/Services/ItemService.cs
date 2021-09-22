using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using 留言板實作.App_Code;
using 留言板實作.Interfaces;
using 留言板實作.Models;

namespace 留言板實作.Services
{
    public class ItemService
    {
        //取得商品內容
        public Item GetItemByID(int itemID)
        {
            Item item = null;
            string sql = @" select * from items where itemID=@itemID ";
            IDB DB = new GuestbookDB(sql);
            List<SqlParameter> paraList = new List<SqlParameter>();
            paraList.Add(new SqlParameter("itemID", SqlDbType.Int) { Value = itemID });
            DB.ParameterList = paraList.ToArray();
            using (SqlDataReader reader = DB.ActionReader())
            {
                if (reader.Read())
                {
                    item = new Item()
                    {
                        Name = Convert.ToString(reader["name"]),
                        Price = Convert.ToInt32(reader["price"]),
                        Image = Convert.ToString(reader["image"])
                    };
                }
            }
            return item;
        }

        //新增商品
        public void AddItem(Item Data)
        {
            string sql = @" insert into items(name,price,image) values(@name,@price,@image); ";
            IDB DB = new GuestbookDB(sql);
            List<SqlParameter> sqlparaList = new List<SqlParameter>();
            sqlparaList.Add(new SqlParameter("name", SqlDbType.NVarChar) { Value = Data.Name });
            sqlparaList.Add(new SqlParameter("price", SqlDbType.Int) { Value = Data.Price });
            sqlparaList.Add(new SqlParameter("image", SqlDbType.VarChar) { Value = Data.Image });
            DB.ParameterList = sqlparaList.ToArray();
            DB.Action();
        }

        //刪除商品
        public void RemoveItem(int itemID)
        {
            string sql = @" delete from items where itemID=@itemID; ";
            IDB DB = new GuestbookDB(sql);
            List<SqlParameter> sqlparaList = new List<SqlParameter>();
            sqlparaList.Add(new SqlParameter("itemID", SqlDbType.Int) { Value = itemID });
            DB.ParameterList = sqlparaList.ToArray();
            DB.Action();
        }

        //取得商品編號清單
        public List<int> GetIDList(Paging page)
        {
            List<int> itemIDList = new List<int>();
            try
            {
                string sql = @"
select * from 
(
	select row_number() over (order by itemID desc) as 序號, *
	from items
) t
where 序號 > (@currentpage-1)*@itemNum and 序號 < @currentpage*@itemNum + 1
 ";
                IDB DB = new GuestbookDB(sql);
                List<SqlParameter> sqlParaList = new List<SqlParameter>();
                sqlParaList.Add(new SqlParameter("currentpage", SqlDbType.Int) { SqlValue = page.CurrentPage });
                sqlParaList.Add(new SqlParameter("itemNum", SqlDbType.Int) { SqlValue = page.ItemCount });
                DB.ParameterList = sqlParaList.ToArray();
                using (SqlDataReader reader = DB.ActionReader())
                {
                    while (reader.Read())
                    {
                        itemIDList.Add(Convert.ToInt32(reader["itemID"]));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itemIDList;
        }
    }
}