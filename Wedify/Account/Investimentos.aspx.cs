using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wedify.Models;

namespace Wedify.Account
{
    public partial class Investimentos : System.Web.UI.Page
    {
        #region Page Load event  
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // info.  
                Console.Write("test");
            }
            catch (Exception ex)
            {
                // info.  
                Console.Write(ex);
            }
        }

        #endregion

        #region Get data method.  

        /// <summary>  
        /// GET: Default.aspx/GetData  
        /// </summary>  
        /// <returns>Return data</returns>  
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public static List<GraphData> GetData()
        {
            // Initialization.  
            List<GraphData> result = new List<GraphData>();

            try
            {
                // Loading.  
                List<SalesOrderDetail> data = Investimentos.LoadData();

                // Setting.  
                var graphData = data.GroupBy(p => new
                {
                    p.ProductName,
                    p.Quantity,
                    p.UnitPrice
                })
                    .Select(g => new
                    {
                        g.Key.ProductName,
                        g.Key.Quantity,
                        g.Key.UnitPrice
                    }).OrderByDescending(q => q.Quantity).ToList();

                // Top 10  
                graphData = graphData.Take(10).Select(p => p).ToList();

                // Loading.  
                result = graphData.Select(p => new GraphData
                {
                    ProductName = p.ProductName,
                    Quantity = p.Quantity,
                    UnitPrice = p.UnitPrice
                }).ToList();
            }
            catch (Exception ex)
            {
                // Info  
                Console.Write(ex);
            }

            // Return info.  
            return result;
        }

        #endregion

        #region Helpers  

        #region Load Data  

        /// <summary>  
        /// Load data method.  
        /// </summary>  
        /// <returns>Returns - Data</returns>  
        private static List<SalesOrderDetail> LoadData()
        {
            // Initialization.  
            List<SalesOrderDetail> lst = new List<SalesOrderDetail>() {
                new SalesOrderDetail()
            {
                Sr = 1, OrderTrackNumber = "123",Quantity = 3, ProductName = "Test 1", SpecialOffer = null,UnitPrice = 10, UnitPriceDiscount = 2
            }
            ,new SalesOrderDetail()
                {
                    Sr = 2, OrderTrackNumber = "234",Quantity = 3, ProductName = "Test 2", SpecialOffer = "Offer 1",UnitPrice = 20, UnitPriceDiscount = 0
                }};

            try
            {
                // Initialization.  
                string line = string.Empty;
                string srcFilePath = "Content/files/SalesOrderDetail.txt";
                var rootPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
                var fullPath = Path.Combine(rootPath, srcFilePath);
                string filePath = new Uri(fullPath).LocalPath;
                StreamReader sr = new StreamReader(new FileStream(filePath, FileMode.Open, FileAccess.Read));

                // Read file.  
                while ((line = sr.ReadLine()) != null)
                {
                    // Initialization.  
                    SalesOrderDetail infoObj = new SalesOrderDetail();
                    string[] info = line.Split(',');

                    // Setting.  
                    infoObj.Sr = Convert.ToInt32(info[0].ToString());
                    infoObj.OrderTrackNumber = info[1].ToString();
                    infoObj.Quantity = Convert.ToInt32(info[2].ToString());
                    infoObj.ProductName = info[3].ToString();
                    infoObj.SpecialOffer = info[4].ToString();
                    infoObj.UnitPrice = Convert.ToDouble(info[5].ToString());
                    infoObj.UnitPriceDiscount = Convert.ToDouble(info[6].ToString());

                    // Adding.  
                    lst.Add(infoObj);
                }

                // Closing.  
                sr.Dispose();
                sr.Close();
            }
            catch (Exception ex)
            {
                // info.  
                Console.Write(ex);
            }

            // info.  
            return lst;
        }

        #endregion

        #endregion
    }
}