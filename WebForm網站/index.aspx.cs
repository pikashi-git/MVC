using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Test
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<customer> cusList = new List<customer>();
            cusList.Add(new customer { Name="大非", PetName="滾滾", PetAge=2 });
            cusList.Add(new customer { Name = "小屁", PetName = "白白", PetAge = 11 });
            cusList.Add(new customer { Name = "中忠", PetName = "小號", PetAge = 8 });
            cusList.Add(new customer { Name = "Alex", PetName = "粉粉", PetAge = 3 });


            //var data = from item in (
            //                from item in cusList
            //                where item.PetAge % 2 == 0
            //                select item
            //            )
            //            where item.PetAge < 9
            //            select item;

            var data = cusList.Where(p => p.PetAge % 2 == 0).First(p => p.PetAge < 9);

            Response.Write(data.Name + ", " + data.PetName + "<br />");


            //foreach (customer d in data)
            //    Response.Write((d as customer).Name + ", " + (d as customer).PetName + "<br />");

            //foreach (customer d in data2)
            //    Response.Write((d as customer).Name + ", " + (d as customer).PetName + "<br />");

        }
        class customer
        {
            public string Name { get; set; }
            public string PetName { get; set; }
            public int PetAge { get; set; }
        }

    }
}