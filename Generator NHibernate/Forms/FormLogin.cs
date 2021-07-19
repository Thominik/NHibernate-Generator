using DownloadAPP.Models;
using DownloadAPP.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace Generator_NHibernate
{
    public partial class FormLogin : Form
    {
        TableService globalTableService = new TableService();
        InformationSchemaService globalInfSchemaService = new InformationSchemaService();
        private string textPV = "public virtual ";
        private string textGetSet = " { get; set; }";
        private string emptySpaceFormat4 = "    ";
        private string emptySpaceFormat8 = "        ";
        private string emptySpaceFormat12 = "            ";
        private string textSchema = @"Schema(""dbo"");";
        private string textTable = @"Tabe(""Account"");";
        private string textPropertyStart = "Property(x => x.";
        private string textPropertyStop = ");";
        private IList<InformationSchemaModel> myProps = new List<InformationSchemaModel>();
        public static string serv;
        public static string login;
        public static string pass;

        //DESKTOP-58DQKAR\MSSQLSERVER2
        public FormLogin()
        {
            InitializeComponent();

            buttonMapping.Visible = false;
            buttonModel.Visible = false;
            panel4.Visible = false;
            comboBoxDatabase.Visible = false;
            pictureBoxDatabase.Visible = false;

            string server = textBoxDatabaseServer.Text.ToString();
        }

        //private readonly string connectionString = $"Server={server};Database = SzybkaSzamka;User Id = {userId}; Password={password}";

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            serv = textBoxDatabaseServer.Text.ToString();
            login = textBoxUserId.Text.ToString();
            pass = textBoxPassword.Text.ToString();
            string connectionString = $"Server={serv};User Id ={login}; Password={pass}";
            NHService.Init(connectionString);
        }

        //public void CreateMapping()
        //{
        //    TableModel table = bsAllTables.Current as TableModel;
        //    myProps = globalInfSchemaService.GetSelectedTableData(table);

        //    using (var sw = new StreamWriter(saveFileDialog.FileName, append: true))
        //    {
        //        sw.WriteLine("using System; \r\nusing System.Collections.Generic; \r\nusing System.Linq; \r\nusing System.Text; " +
        //            "\r\nusing system.Threading.Tasks; \r\nusing LogAPP.Models; \r\nusing NHibernate.Mapping.ByCode; \r\nusing NHibernate.Mapping.ByCode.Conformist;\r\n");
        //        sw.WriteLine("namespace App.Mappings \r\n{ \r\n" + emptySpaceFormat4 + $"public class {table.name} : ClassMapping<{table.name}> \r\n" + emptySpaceFormat4 + "{");
        //        sw.WriteLine(emptySpaceFormat8 + $"public {table.name}() \r\n" + emptySpaceFormat8 + "{ \r\n" + emptySpaceFormat12 + textSchema + "\r\n\r\n" + emptySpaceFormat12 + textTable + "\r\n");

        //        if (myProps.Any(x => x.is_identity))
        //        {
        //            string id = myProps.Where(x => x.is_identity == true).FirstOrDefault().COLUMN_NAME;
        //            sw.WriteLine(emptySpaceFormat12 + $"Id(x => x.{id}, map => map.Generator(Generators.Identity)); \r\n");
        //        }

        //        for (int i = 1; i < myProps.Count; i++)
        //        {
        //            string colName = myProps[i].COLUMN_NAME;
        //            sw.WriteLine(emptySpaceFormat12 + textPropertyStart + colName + textPropertyStop + "\r\n");
        //        }

        //        sw.WriteLine(emptySpaceFormat8 + "} \r\n" + emptySpaceFormat4 + "} \r\n}");
        //        sw.Close();
        //    }
        //    MessageBox.Show("The file has been saved!");
        //}

        //public void CreateModel()
        //{
        //    TableModel table = bsAllTables.Current as TableModel;
        //    myProps = globalInfSchemaService.GetSelectedTableData(table);

        //    using (var sw = new StreamWriter(saveFileDialog.FileName, append: true))
        //    {
        //        sw.WriteLine("using System; \r\nusing System.Collections.Generic; \r\nusing System.Linq; \r\nusing System.Text; \r\nusing system.Threading.Tasks; \r\n");
        //        sw.WriteLine("namespace YourName.Models \r\n{ \r\n" + emptySpaceFormat4 + $"public class {table.name} \r\n" + emptySpaceFormat4 + "{ \r\n");

        //        for (int i = 0; i < myProps.Count; i++)
        //        {
        //            string colName = myProps[i].COLUMN_NAME;
        //            var typeDT = ConvertTypesSqlToC(myProps[i].DATA_TYPE);
        //            sw.WriteLine(emptySpaceFormat8 + textPV + typeDT + " " + colName + textGetSet + "\r\n");
        //        }
        //        sw.WriteLine(emptySpaceFormat4 + "} \r\n }");
        //        sw.Close();
        //    }
        //    MessageBox.Show("Plik został zapisany!");
        //}

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.ExitThread();
        }

        private void textBoxDatabaseServer_Enter(object sender, EventArgs e)
        {
            if (textBoxDatabaseServer.Text.Equals("server"))
            {
                textBoxDatabaseServer.Text = "";
            }
        }

        private void textBoxDatabaseServer_Leave(object sender, EventArgs e)
        {
            if (textBoxDatabaseServer.Text.Equals(""))
            {
                textBoxDatabaseServer.Text = "server";
            }
        }

        private void textBoxUserId_Enter(object sender, EventArgs e)
        {
            if (textBoxUserId.Text.Equals("user"))
            {
                textBoxUserId.Text = "";
            }
        }

        private void textBoxUserId_Leave(object sender, EventArgs e)
        {
            if (textBoxUserId.Text.Equals(""))
            {
                textBoxUserId.Text = "user";
            }
        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            if (textBoxPassword.Text.Equals("password"))
            {
                textBoxPassword.Text = "";
            }
        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            if (textBoxPassword.Text.Equals(""))
            {
                textBoxPassword.Text = "password";
            }
        }

        private string ConvertTypesSqlToC(string type)
        {
            if (type == "varchar")
                type = "string";
            else if (type == "bit")
                type = "bool";
            else if (type == "bigint")
                type = "long";
            else if (type == "binary")
                type = "byte[]";
            else if (type == "char")
                type = "string";
            else if (type == "date")
                type = "DateTime";
            else if (type == "datetime2")
                type = "DateTime";
            else if (type == "datetimeoffset")
                type = "DateTimeOffset";
            else if (type == "float")
                type = "double";
            else if (type == "image")
                type = "byte";
            else if (type == "money")
                type = "decimal";
            else if (type == "nchar")
                type = "string";
            else if (type == "ntext")
                type = "string";
            else if (type == "numeric")
                type = "decimal";
            else if (type == "nvarchar")
                type = "string";
            else if (type == "real")
                type = "float";
            else if (type == "smalldatetime")
                type = "DateTime";
            else if (type == "smallint")
                type = "short";
            else if (type == "smallmoney")
                type = "decimal";
            else if (type == "text")
                type = "string";
            else if (type == "time")
                type = "TimeSpan";
            else if (type == "timestamp")
                type = "long";
            else if (type == "tinyint")
                type = "byte";
            else if (type == "uniqueindetifier")
                type = "Guild";
            else if (type == "varbinary")
                type = "byte[]";

            return type;
        }

        private void buttonMapping_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                CreateMapping();
            }
        }

        private void buttonModel_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                CreateModel();
            }
        }
    }
}
