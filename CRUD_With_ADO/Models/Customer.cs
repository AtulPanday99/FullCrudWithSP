using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CRUD_With_ADO.Models
{
    public class Customer:DBManager
    {
        public int CustId {  get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public string Address {  get; set; }
        public string PictueFileName { get; set; }
        public string RegisteredOnDT {  get; set; }
        string msg;
        bool res;
        string CommandText;

        internal string AddNewCustomer()
        {
            CommandText = "Insert into Tbl_Customer values('"+Name+"','"+Gender+"','"+City+"','"+EmailId+"','"+MobileNo+"','"+Address+"','"+PictueFileName+"','"+RegisteredOnDT+"')";
            res=ExecuteMyNonQuery(CommandText);
            msg = res == true ? "Customer record saved successfully." : "Sorry!unable to save customer record.";
            return msg;
        }
        internal string DeleteCustomer(int cid)
        {
            CommandText = "Delete from Tbl_Customer where CustomerId='" + cid + "'";
            res = ExecuteMyNonQuery(CommandText);
            msg = res == true ? "Customer record deleted successfull." : "Sorry!unable to delete customer record.";
            return msg;
        }
        internal string UpdateCustomer(int cid)
        {
            CommandText = "Update Tbl_Customer set Name='" + Name + "',Gender='" + Gender + "',City='"+City+"',EmailId='"+EmailId+"',MobNo='"+MobileNo+"',Address='"+Address+"',PicFileName='"+PictueFileName+"' where CustomerId='"+cid+"'";
            res = ExecuteMyNonQuery(CommandText);
            msg = res == true ? "Customer record updated successfull." : "Sorry!unable to update customer record.";
            return msg;
        }
        internal Customer GetSpecificCustomer(int  cid)
        {
            CommandText="Select * from Tbl_Customer where CustomerId='"+cid+"'";
            DataTable dt=ExecuteMyQuery(CommandText);
            Customer c=new Customer();
            if (dt.Rows.Count > 0)
            {
                c.CustId = int.Parse(dt.Rows[0][0].ToString());
                c.Name = dt.Rows[0][1].ToString();
                c.Gender = dt.Rows[0][2].ToString();
                c.City= dt.Rows[0][3].ToString();
                c.EmailId = dt.Rows[0][4].ToString();
                c.MobileNo= dt.Rows[0][5].ToString();
                c.Address= dt.Rows[0][6].ToString();
                c.PictueFileName= dt.Rows[0][7].ToString();
                c.RegisteredOnDT= dt.Rows[0][8].ToString();
            }
            return c;
        }
        internal List<Customer> ShowAllCustomer()
        {
            CommandText = "Select * from Tbl_Customer order by CustomerId desc";
            DataTable dt=ExecuteMyQuery(CommandText);
            List<Customer> lstcm=new List<Customer>();
            foreach (DataRow dr in dt.Rows)
            {
                Customer c=new Customer();
                c.CustId = int.Parse(dr["CustomerId"].ToString());
                c.Name = dr["Name"].ToString();
                c.Gender = dr["Gender"].ToString();
                c.City = dr["City"].ToString() ;
                c.EmailId = dr["EmailId"].ToString();
                c.MobileNo = dr["MobNo"].ToString();
                c.Address = dr["Address"].ToString();
                c.PictueFileName = dr["PicFileName"].ToString();
                c.RegisteredOnDT = dr["RegisteredOn"].ToString();
                lstcm.Add(c);
            }
            return lstcm;
        }
    }
}