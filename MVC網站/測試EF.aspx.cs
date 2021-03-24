using MVC網站.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MVC網站
{
    public partial class 測試EF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            testDBEntities ef = new testDBEntities();

            DoSelectByKey2(ef, 1, name: "group1");

            DoSelectByKey(ef, 3);
            DoSelectByArgs(ef, "JOJO");
            DoSelect(ef);

            //DoUpdate(ef);
            //DoSelect(ef);

            //DoInsert(ef);
            //DoSelect(ef);

            //DoDelete(ef);
            //DoSelect(ef);
        }
        void DoSelectByKey2(testDBEntities ef,int id,string name)
        {
            groups _groups = ef.groups.Find(id,name);
            Response.Write(_groups.groupID + ", " + _groups.groupName + ", " + _groups.area + ", " + _groups.misc);
            Response.Write("<br />");
            Response.Write("<br />");
        }
        void DoDelete(testDBEntities ef)
        {
            users _users = ef.users.Find(4);
            ef.users.Remove(_users);
            ef.SaveChanges();
        }
        void DoUpdate(testDBEntities ef)
        {
            users _users = ef.users.Find(2);
            _users.userName = "JOJO";
            _users.age = 101;
            _users.address = "JOJO_address";
            ef.SaveChanges();
        }
        void DoInsert(testDBEntities ef)
        {
            users _users = new users();
            _users.userID = 6;
            _users.userName = "Robert";
            _users.age = 23;
            _users.address = "Robert_address";
            ef.users.Add(_users);
            ef.SaveChanges();
        }
        void DoSelectByArgs(testDBEntities ef, string key)
        {
            //List<users> _users = ef.users.Where(x => x.userName == key).ToList();
            List<users> _users = ef.users.Where(x => x.age == 23).ToList();
            foreach (users _u in _users)
            {
                Response.Write(_u.userID + ", " + _u.userName + ", " + _u.age + ", " + _u.address);
                Response.Write("<br />");
            }
            Response.Write("<br />");
        }
        void DoSelect(testDBEntities ef)
        {
            List<users> _users1 = ef.users.ToList();
            foreach (users _u in _users1)
            {
                Response.Write(_u.userID + ", " + _u.userName + ", " + _u.age + ", " + _u.address);
                Response.Write("<br />");
            }
            Response.Write("<br />");
        }
        void DoSelectByKey(testDBEntities ef, int key)
        {
            users _users2 = ef.users.Find(key);
            Response.Write(_users2.userID + ", " + _users2.userName + ", " + _users2.age + ", " + _users2.address);
            Response.Write("<br />");
            Response.Write("<br />");
        }
    }
}