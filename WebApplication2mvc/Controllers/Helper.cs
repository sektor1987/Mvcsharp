using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace WebApplication2mvc.Controllers
{
    public class Helper
    {

        public class Export
        {
            public void ToExcel(HttpResponseBase Response, object clientsList)
            {   //Hint: https://stackoverflow.com/questions/16346227/export-data-to-excel-file-with-asp-net-mvc-4-c-sharp-is-rendering-into-view
                var grid = new System.Web.UI.WebControls.GridView();
                grid.DataSource = clientsList;
                grid.DataBind();
                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment; filename=FileName.xls"); //seteamos las cabeceras como pieichpi
                Response.ContentType = "application/excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                grid.RenderControl(htw);
                Response.Write(sw.ToString());
                Response.End();
            }
        }
    }
}