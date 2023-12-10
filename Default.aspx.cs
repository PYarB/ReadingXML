using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("Data.xml"));
            GridView1.DataSource = ds.Tables[0].DefaultView;
            GridView1.DataBind();
        }
    }

    void BindGrid(string tableName)
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("Data.xml"));
        GridView1.DataSource = ds.Tables[tableName].DefaultView;
        GridView1.DataBind();
    }
    void BindGrid(string xmlFile, string tableName)
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath(xmlFile));
        GridView1.DataSource = ds.Tables[tableName].DefaultView;
        GridView1.DataBind();
    }

    void BindGridFileInput(string xmlFile)
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath(xmlFile));
        GridView1.DataSource = ds.Tables[0].DefaultView;
        GridView1.DataBind();
    }

    protected void btnGo_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            string fileName = FileUpload1.PostedFile.FileName;
            FileUpload1.SaveAs("~/" + fileName);
        }
    }
}