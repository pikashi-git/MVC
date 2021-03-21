using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Test
{
    public partial class static測試A : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("之前值: " + 測試static數值固定.code);
            Response.Write("<br />");
            測試static數值固定.code = "static測試A";
            Response.Write("現在值: " + 測試static數值固定.code);
        }
    }
}