using AdoDotNetDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace AdoDotNetDemo.Controllers
{
    public class ProductCategoryController : Controller
    {
        public IActionResult Index()
        {
            string connection =
                "server=.\\sqlexpress; database=MVCtask; integrated security=true";
            SqlConnection con = new SqlConnection(connection);
            string query = "select * from Products; select * from Categories";
            SqlDataAdapter adapter = new SqlDataAdapter(query,con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            ProductCategory productCategory = new ProductCategory();
            if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
            {
                productCategory.product = new List<Product>();
                for (int i=0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow rows = ds.Tables[0].Rows[i];
                    productCategory.product.Add(new Product()
                    {
                        Id = (int)rows["ProductId"],
                        ProductName = (string)rows["ProductName"],
                        UnitPrice = (int)rows["UnitPrice"]
                    });
                }

                productCategory.categories = new List<Category>();
                for (int i =0; i < ds.Tables[1].Rows.Count; i++)
                {
                    DataRow rows = ds.Tables[1].Rows[i];
                    productCategory.categories.Add(new Category()
                    {
                        Id = (int)rows["CategoryId"],
                        Name = (string)rows["CategoryName"]
                    });
                }

            }


            return View(productCategory);
        }
    }
}
