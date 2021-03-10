using System.Collections.Generic;
//using System.Data;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System;
using System.Data;
using System.Dynamic;

namespace ConsoleApp
{
    class Program
    {
        static List<Customer> customerList;
        static List<CustomerDetail> customerDetailList;
        static List<Product> productList;

        static void Main(string[] args)
        {
            customerList = new List<Customer>();
            customerDetailList = new List<CustomerDetail>();
            productList = new List<Product>();
            GetData(ref customerList, ref customerDetailList, ref productList);

            //Test1();

            //Test2();

            //Test3();

            //Test4();

            //Test5();

            //Test6();

            //Test7();

            //TestVSConnectDB();

            //Test8();

            //Test9();

            //Test10();

            //Test11();

            //Test12();

            //Test13();

            Test14();

            System.Console.ReadKey();

        }

        protected class Customer
        {
            public int CustomerID { get; set; }
            public string Name { get; set; }
            public string Product { get; set; }
            public List<CustomerDetail> CustomerDetails { get; set; }
        }

        protected class CustomerDetail
        {
            public int CustomerID { get; set; }
            public int Age { get; set; }
            public AddreesMap Address { get; set; }
            public string Gender { get; set; }
            public bool Married { get; set; }
        }
        protected class Product
        {
            public int CustomerID { get; set; }
            public string ProductName { get; set; }
            public string ProductDescript { get; set; }
        }
        protected class AddreesMap 
        { 
            public string NO1 { get; set; }
            public string NO2 { get; set; }
            public string NO3 { get; set; }
        }
        static void GetData(ref List<Customer> customerList, ref List<CustomerDetail> customerDetailList, ref List<Product> productList)
        {
            var c1_detail = new CustomerDetail
            {
                CustomerID = 1,
                Age = 22,
                Address = new AddreesMap{ NO1 = "台北市", NO2 = "新北市", NO3 = "" },
                Gender = "男",
                Married = false
            };
            var c1_Product = new Product
            {
                CustomerID = 1,
                ProductName = "手機",
                ProductDescript = "Samgsang手機"
            };
            var c1 = new Customer
            {
                CustomerID = 1,
                Name = "Amy",
                Product = "手機",
                CustomerDetails = new List<CustomerDetail>() { c1_detail }
            };

            var c2_detail = new CustomerDetail
            {
                CustomerID = 2,
                Age = 32,
                Address = new AddreesMap { NO1 = "新北市", NO2 = "板橋區", NO3 = "美國" },
                Gender = "女",
                Married = true
            };
            var c2_Product = new Product
            {
                CustomerID = 2,
                ProductName = "平板",
                ProductDescript = "華碩平板"
            };
            var c2 = new Customer
            {
                CustomerID = 2,
                Name = "Alex",
                Product = "平板",
                CustomerDetails = new List<CustomerDetail>() { c2_detail }
            };

            var c3_detail = new CustomerDetail
            {
                CustomerID = 3,
                Age = 25,
                Address = new AddreesMap { NO1 = "高雄市", NO2 = "", NO3 = "" },
                Gender = "男",
                Married = true
            };
            var c3_Product = new Product
            {
                CustomerID = 3,
                ProductName = "清淨機",
                ProductDescript = "大同清淨機"
            };
            var c3 = new Customer
            {
                CustomerID = 3,
                Name = "Tony",
                Product = "清淨機",
                CustomerDetails = new List<CustomerDetail>() { c3_detail }
            };

            var c4_detail = new CustomerDetail
            {
                CustomerID = 4,
                Age = 32,
                Address = new AddreesMap { NO1 = "永和", NO2 = "", NO3 = "新北市" },
                Gender = "女",
                Married = true
            };
            var c4_Product = new Product
            {
                CustomerID = 4,
                ProductName = "珠寶",
                ProductDescript = "綠寶石"
            };
            var c4 = new Customer
            {
                CustomerID = 4,
                Name = "Alex",
                Product = "珠寶",
                CustomerDetails = new List<CustomerDetail>() { c4_detail }
            };

            var c5_detail = new CustomerDetail
            {
                CustomerID = 5,
                Age = 45,
                Address = new AddreesMap { NO1 = "基隆市", NO2 = "金山區", NO3 = "" },
                Gender = "男",
                Married = true
            };
            var c5_1_detail = new CustomerDetail
            {
                CustomerID = 5,
                Age = 22,
                Address = new AddreesMap { NO1 = "高雄市", NO2 = "高雄縣", NO3 = "三重區" },
                Gender = "不明",
                Married = true
            };
            var c5_Product = new Product
            {
                CustomerID = 5,
                ProductName = "房子",
                ProductDescript = "忠孝東路4段6樓"
            };
            var c5 = new Customer
            {
                CustomerID = 5,
                Name = "Vincent",
                Product = "房子",
                CustomerDetails = new List<CustomerDetail>() { c5_detail, c5_1_detail }
            };

            var c6_detail = new CustomerDetail
            {
                CustomerID = 5,
                Age = 35,
                Address = new AddreesMap { NO1 = "基隆市", NO2 = "金山區", NO3 = "" },
                Gender = "男",
                Married = true
            };
            var c6_1_detail = new CustomerDetail
            {
                CustomerID = 5,
                Age = 21,
                Address = new AddreesMap { NO1 = "高雄市", NO2 = "高雄縣", NO3 = "三重區" },
                Gender = "不明",
                Married = true
            };
            var c6_Product = new Product
            {
                CustomerID = 5,
                ProductName = "房子",
                ProductDescript = "忠孝東路4段6樓"
            };
            var c6 = new Customer
            {
                CustomerID = 5,
                Name = "Vincent",
                Product = "房子",
                CustomerDetails = new List<CustomerDetail>() { c6_detail, c6_1_detail }
            };

            customerList.Add(c1);
            customerList.Add(c2);
            customerList.Add(c3);
            customerList.Add(c4);
            customerList.Add(c5);
            customerList.Add(c6);
            productList.Add(c1_Product);
            productList.Add(c2_Product);
            productList.Add(c3_Product);
            productList.Add(c4_Product);
            productList.Add(c5_Product);
            productList.Add(c6_Product);
            customerDetailList.Add(c1_detail);
            customerDetailList.Add(c2_detail);
            customerDetailList.Add(c3_detail);
            customerDetailList.Add(c4_detail);
            customerDetailList.Add(c5_detail);
            customerDetailList.Add(c6_detail);
        }
        
        static void Test14()
        {
            var list = new List<dynamic>
            {
                new { 編號=1,名稱 = "他們是否個性有問題?", 是否為題目 = 1, 次數 = 0 },
                new { 編號=1,名稱 = "非常滿意", 是否為題目 = 0, 次數 = 100 },
                new { 編號=1,名稱 = "滿意", 是否為題目 = 0, 次數 = 70 },
                new { 編號=1,名稱 = "普通", 是否為題目 = 0, 次數 = 22 },
                new { 編號=1,名稱 = "不滿意", 是否為題目 = 0, 次數 = 2 },
                new { 編號=1,名稱 = "非常不滿意", 是否為題目 = 0, 次數 = 1 },

                new { 編號=2,名稱 = "他們是不是太閒?", 是否為題目 = 1, 次數 = 0 },
                new { 編號=2,名稱 = "非常滿意", 是否為題目 = 0, 次數 = 123 },
                new { 編號=2,名稱 = "滿意", 是否為題目 = 0, 次數 = 53 },
                new { 編號=2,名稱 = "普通", 是否為題目 = 0, 次數 = 12 },
                new { 編號=2,名稱 = "不滿意", 是否為題目 = 0, 次數 = 1 },
                new { 編號=2,名稱 = "非常不滿意", 是否為題目 = 0, 次數 = 1 },

                new { 編號=3,名稱 = "他們是不是有毛病?", 是否為題目 = 1, 次數 = 0 },
                new { 編號=3,名稱 = "非常滿意", 是否為題目 = 0, 次數 = 99 },
                new { 編號=3,名稱 = "滿意", 是否為題目 = 0, 次數 = 50 },
                new { 編號=3,名稱 = "普通", 是否為題目 = 0, 次數 = 11 },
                new { 編號=3,名稱 = "不滿意", 是否為題目 = 0, 次數 = 2 },
                new { 編號=3,名稱 = "非常不滿意", 是否為題目 = 0, 次數 = 2 }
            };

            //DataTable dtReport = new DataTable();
            //dtReport.Columns.Add(new DataColumn("編號", typeof(int)));
            //dtReport.Columns.Add(new DataColumn("名稱", typeof(string)));
            //dtReport.Columns.Add(new DataColumn("是否為題目", typeof(int)));
            //dtReport.Columns.Add(new DataColumn("次數", typeof(int)));
            //foreach (var o in list)
            //{
            //    DataRow row = dtReport.NewRow();
            //    row["編號"] = o.編號;
            //    row["名稱"] = o.名稱;
            //    row["是否為題目"] = o.是否為題目;
            //    row["次數"] = o.次數;
            //    dtReport.Rows.Add(row);
            //}

            //var q1 = from o in dtReport.AsEnumerable()
            //         select new { 編號 = o.Field<int>("編號"), 名稱 = o.Field<string>("名稱"), 是否為題目 = o.Field<int>("是否為題目"), 次數 = o.Field<int>("次數") };

            var q1 = from o in list
                     group o by o.編號 into g
                     where g.Key>=2
                     orderby g.Key descending
                     select new
                     {
                         KEY = g.Key
                         ,Max = g.Max(p=>p.次數)
                         ,Min = g.Min(p=>p.次數)
                         ,Average = g.Average(p=>p.次數)
                         ,Sum=g.Sum(p=>p.次數)
                         ,Count=g.Count(p => p.次數>50)
                     };

            System.Console.WriteLine(q1.Count());
            
            foreach (var o in q1)
                System.Console.WriteLine((o.KEY + ", " + o.Max + ", " + o.Min + ", " + o.Average + ", " + o.Sum
                     + ", " + o.Count));
           
        }
        static void Test13()
        {
            var list = new List<dynamic>
            {
                new { 編號=1,名稱 = "他們是否個性有問題?", 是否為題目 = 1, 次數 = 0 },
                new { 編號=1,名稱 = "非常滿意", 是否為題目 = 0, 次數 = 100 },
                new { 編號=1,名稱 = "滿意", 是否為題目 = 0, 次數 = 70 },
                new { 編號=1,名稱 = "普通", 是否為題目 = 0, 次數 = 22 },
                new { 編號=1,名稱 = "不滿意", 是否為題目 = 0, 次數 = 2 },
                new { 編號=1,名稱 = "非常不滿意", 是否為題目 = 0, 次數 = 1 },

                new { 編號=2,名稱 = "他們是不是太閒?", 是否為題目 = 1, 次數 = 0 },
                new { 編號=2,名稱 = "非常滿意", 是否為題目 = 0, 次數 = 123 },
                new { 編號=2,名稱 = "滿意", 是否為題目 = 0, 次數 = 53 },
                new { 編號=2,名稱 = "普通", 是否為題目 = 0, 次數 = 12 },
                new { 編號=2,名稱 = "不滿意", 是否為題目 = 0, 次數 = 1 },
                new { 編號=2,名稱 = "非常不滿意", 是否為題目 = 0, 次數 = 1 },

                new { 編號=3,名稱 = "他們是不是有毛病?", 是否為題目 = 1, 次數 = 0 },
                new { 編號=3,名稱 = "非常滿意", 是否為題目 = 0, 次數 = 99 },
                new { 編號=3,名稱 = "滿意", 是否為題目 = 0, 次數 = 50 },
                new { 編號=3,名稱 = "普通", 是否為題目 = 0, 次數 = 11 },
                new { 編號=3,名稱 = "不滿意", 是否為題目 = 0, 次數 = 2 },
                new { 編號=3,名稱 = "非常不滿意", 是否為題目 = 0, 次數 = 2 }
            };

            DataTable dtReport = new DataTable();
            dtReport.Columns.Add(new DataColumn("編號", typeof(int)));
            dtReport.Columns.Add(new DataColumn("名稱", typeof(string)));
            dtReport.Columns.Add(new DataColumn("是否為題目", typeof(int)));
            dtReport.Columns.Add(new DataColumn("次數", typeof(int)));
            foreach (var o in list)
            {
                DataRow row = dtReport.NewRow();
                row["編號"] = o.編號;
                row["名稱"] = o.名稱;
                row["是否為題目"] = o.是否為題目;
                row["次數"] = o.次數;
                dtReport.Rows.Add(row);
            }

            
            var q1 = from o in dtReport.AsEnumerable()
                    select new { 編號 = o.Field<int>("編號"), 名稱 = o.Field<string>("名稱"), 是否為題目 = o.Field<int>("是否為題目"), 次數 = o.Field<int>("次數") };


            var q = from o1 in q1
                    join o2 in q1 on o1.編號 equals o2.編號 into 非常滿意
                    from o2 in 非常滿意
                    join o3 in q1 on o1.編號 equals o3.編號 into 滿意
                    from o3 in 滿意
                    join o4 in q1 on o1.編號 equals o4.編號 into 普通
                    from o4 in 普通
                    join o5 in q1 on o1.編號 equals o5.編號 into 不滿意
                    from o5 in 不滿意
                    join o6 in q1 on o1.編號 equals o6.編號 into 非常不滿意
                    from o6 in 非常不滿意
                    where o1.是否為題目 == 1 && o2.名稱 == "非常滿意" && o3.名稱 == "滿意"
                    && o4.名稱 == "普通" && o5.名稱 == "不滿意" && o6.名稱 == "非常不滿意"
                    select new { 編號 = o1.編號, 題目 = o1.名稱, 非常滿意次數 = o2.次數, 滿意次數 = o3.次數, 普通次數 = o4.次數, 不滿意次數 = o5.次數, 非常不滿意次數 = o6.次數 };

            foreach (var o in q1)
                System.Console.WriteLine(("第" + o.編號.ToString() + "題") + ", " + o.是否為題目 + ", " + o.名稱 + ", " + o.次數);
            System.Console.WriteLine("==============================");
            System.Console.WriteLine("count:" + q.Count());
            foreach (var o in q)
                System.Console.WriteLine(("第" + o.編號.ToString() + "題") + ", " + o.題目 + ", " + o.非常滿意次數 + ", " + o.滿意次數 + ", " + o.普通次數 + ", " + o.不滿意次數 + ", " + o.非常不滿意次數);

        }
        static string ID { get; set; }
        static string GetID(int 是否為題目)
        {
            if(是否為題目 == 1)
                ID= Guid.NewGuid().ToString();
            return ID;
        }
        class 題目
        {
            string 編號 { get; set; }
            string 名稱 { get; set; }
            int 是否為題目 { get; set; }
            int 次數 { get; set; }
        }
        static void Test12()
        {
            var q = customerList.Select(o => new { o.CustomerID, o.Name, o.Product, o.CustomerDetails}).OrderByDescending(o => o.CustomerID).ThenByDescending(o => o.CustomerDetails[0].Age).ToList();
            foreach (var o in q)
                System.Console.WriteLine(o.CustomerID + ", " + o.Name + ", " + o.Product + ", " + o.CustomerDetails[0].Age);
        }

        static void Test11()
        {
            var q = from o1 in customerList
                    from o2 in customerDetailList
                    join o3 in productList 
                    on  new
                    {
                        o1.Product,
                        o2.CustomerID
                    }
                    equals 
                    new
                    {
                        Product = o3.ProductName,
                        o3.CustomerID
                    }
                    //on o1.CustomerID equals o3.CustomerID
                    into products
                    from o3 in products
                    orderby o3.ProductName descending
                    select new
                    {
                        o1.CustomerID,
                        o3.ProductDescript
                    };
            foreach(var i in q)
                System.Console.WriteLine(i.CustomerID + ", " + i.ProductDescript);

        }

        static void Test10()
        {
            var q = from o in customerList
                    join o1 in customerDetailList
                    on o.CustomerID equals o1.CustomerID
                    into details
                    let z=o.CustomerID+@"\"+o.Name
                    //from o1 in details.DefaultIfEmpty()
                    select new
                    {
                        o.CustomerID,
                        o.Name,
                        Detail = details,
                        Counts = details.Count(),
                        AgeMax = details.Max(i => i.Age),
                        z
                    };

            foreach (var i in q)
            {
                System.Console.WriteLine(i.CustomerID + ", " + i.Name + ", " + i.Counts + ", " + i.AgeMax+","+i.z);
                foreach(var j in i.Detail)
                    System.Console.WriteLine(j.Age + "," + j.Gender);
            }

            //var q = from o in customerList
            //        join o1 in customerDetailList 
            //        on o.CustomerID equals o1.CustomerID
            //        into details
            //        select new
            //        {
            //            o.CustomerID,
            //            o.Name,
            //            Counts = details.Count()
            //        };

            //foreach (var i in q)
            //    System.Console.WriteLine(i.CustomerID + ", " + i.Name + ", " +  i.Counts);
        }

        static void Test9()
        {
            var q = from o in customerList
                    from o1 in customerDetailList
                    where o.CustomerID == o1.CustomerID && o.Name.Equals("Vincent")
                    select new
                    {
                        o.CustomerID,
                        o.Name,
                        o1.Age,
                        o1.Address
                    };

            foreach (var i in q)
                System.Console.WriteLine(i.CustomerID + ", " + i.Name + ", " + i.Age + ", " + i.Address.NO1);
        }

        static void Test8()
        {
            var q = from o in customerList
                    from o1 in o.CustomerDetails
                    where o.Product.Equals(@"珠寶")
                    select new {
                        o1.CustomerID,
                        o1.Age,
                        o1.Address
                    };

            foreach (var i in q)
                System.Console.WriteLine(i.CustomerID + ", " + i.Age + ", " + i.Address.NO1);
        }

        static void Test7()
        {
            List<dynamic> sportList = new List<dynamic>();
            sportList.Add(new { name = "籃球", people = 10, hard = 7, type = 1 });
            sportList.Add(new { name = "游泳", people = 1, hard = 7, type = 2 });
            sportList.Add(new { name = "足球", people = 14, hard = 9, type = 1 });
            sportList.Add(new { name = "羽球", people = 2, hard = 8, type = 1 });
            sportList.Add(new { name = "熱氣球", people = 10, hard = 5, type = 3 });
            sportList.Add(new { name = "潛水", people = 1, hard = 9, type = 2 });
            sportList.Add(new { name = "滑翔翼", people = 1, hard = 10, type = 3 });


            var q = from item in sportList
                    group item by item.type into g
                    select new
                    {
                        TypeID = g.Key,
                        MaxPeo = (from item2 in g
                                  select item2.people)
                    };


            System.Console.WriteLine(q);

            /*
            foreach (var i in q)
            {
                Console.WriteLine(i.TypeID);
                System.Console.WriteLine(i.MaxPeo);

                /*
                foreach (var j in i)
                    System.Console.WriteLine(j.type + ", " + j.name + ", " + j.people);
                    */
            //}

        }

        static void Test6()
        {
            var q = (from item in customerList
                     select item.Name).Distinct();//.Count();

            //System.Console.WriteLine(q);

            //foreach (var i in q)
            //{
            //    System.Console.WriteLine(i);
            //}
        }

        static void Test5()
        {
            //var q = dt.AsEnumerable().Where(p => p.Field<int>("Age") > 20);
        }

        static void Test4()
        {
            var q = customerList.Where(p => p.CustomerID > 0).Max(p => p.CustomerID);

            System.Console.WriteLine(q);

            /*
            foreach (var i in q)
            {
                System.Console.WriteLine(i);
            }
            */
        }

        static void Test3()
        {
            XDocument doc = new XDocument(new XElement("Customers"
                , from item in customerList
                  where item.CustomerID > 1
                  select new XElement("Customer"
                  , item.Name
                  , new XAttribute("CustomerID", item.CustomerID)
                  , new XAttribute("Product", item.Product)
                  )
                  )
                );
            System.Console.WriteLine(doc.Document.ToString());
        }

        static void Test2()
        {
            var q = (from item in customerList
                     where item.CustomerID > 0
                     select new
                     {
                         item.CustomerID,
                         item.Name,
                         ProductType = string.Format(@"顧客產品:{0}", item.Product),
                         Detail = from item2 in customerDetailList
                                  where item2.CustomerID == item.CustomerID
                                  select item2
                     }).Select(p => p.Name).Distinct();

            foreach (var i in q)
            {
                System.Console.WriteLine(i);

                //System.Console.WriteLine(i.CustomerID + ", " + i.Name + ", " + i.ProductType + ": ");
                //    foreach (var j in i.Detail)
                //        System.Console.WriteLine(j.CustomerID + ", " + j.Address);
            }
        }

        static void Test1()
        {
            List<dynamic> sportList = new List<dynamic>();
            sportList.Add(new { name = "籃球", people = 10, hard = 7 });
            sportList.Add(new { name = "足球", people = 14, hard = 9, scop = 2 });
            sportList.Add(new { name = "羽球", people = 2, hard = 8, scop = 4 });

            foreach (var i in sportList)
            {
                System.Console.WriteLine(i.name + ", " + i.people + ", " + i.hard);
                if (string.Compare(i.name.ToString(), "籃球") == -1)
                {
                    System.Console.WriteLine(i.scop);
                }
            }
        }
    }
}
