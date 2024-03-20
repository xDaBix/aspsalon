using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Security.Cryptography;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Data.SqlClient;

namespace Salon_Management_System
{
    
    public class OTPGenerator
    {
        public static string GenerateOTP(int length = 6)
        {
            const string validChars = "0123456789";
            char[] chars = new char[length];

            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] bytes = new byte[length];
                rng.GetBytes(bytes);
                for (int i = 0; i < length; i++)
                {
                    chars[i] = validChars[bytes[i] % validChars.Length];
                }
            }

            return new string(chars);
        }
    }
    public class EmailSender : System.Web.UI.Page
    {
        String otp;
        public  void SendOTPEmail(string toEmail, string otp)

        {
            try
            {
                
                string senderEmail = "21bmiit105@gmail.com";
                string senderPassword = "zqsnotvhhjggnzjv";

                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
              
                mail.From = new MailAddress(senderEmail);
                mail.To.Add(toEmail);
                mail.Subject = "OTP Verification";
                mail.Body = $"Your OTP for password recovery: {otp}";

                smtpServer.Port = 587;
                smtpServer.Credentials = new NetworkCredential(senderEmail, senderPassword);
                smtpServer.EnableSsl = true;

                smtpServer.Send(mail);
                HttpContext.Current.Response.Write("OTP sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
            }
        }
    }

    public partial class forgetPassword : System.Web.UI.Page
    {
        string otp;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void btnSendOtp_Click(object sender, EventArgs e)
        {
            
            
            string connectionString = "Data Source=DESKTOP-OE4JH70\\SQLEXPRESS;Initial Catalog=Salon;Integrated Security=True ";
            //int id = (int)Session["uid"];
            String email = txtemail.Text;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    object count = null;

                    con.Close();
                    con.Open();
                    string qry = "select * from tblRegistration where email=@email";

                    using (SqlCommand cmd = new SqlCommand(qry, con))
                    {

                        cmd.Parameters.AddWithValue("@email", email);

                        // Execute the query
                        try
                        {
                            count = cmd.ExecuteScalar();
                        }
                        catch (Exception ex) { Response.Write("Ex:Incorrect Old Password!"); }
                        if (count == null)
                        {
                            lblReg.Visible = true;
                            hlReg.Visible = true;
                        }
                        else
                        {
                            lblReg.Visible = false;
                            hlReg.Visible = false;
                             otp = OTPGenerator.GenerateOTP();
                            Session["expectedOTP"] = otp;
                                
                            //Response.Write(email);
                            //Response.Write(otp);
                            EmailSender es = new EmailSender();
                            es.SendOTPEmail(email, otp);
                            
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception ex) { }
                
                        
        }

        protected void btnOTP_Click(object sender, EventArgs e)
        {
            string expectedOTP = Session["expectedOTP"] as string;
            Response.Write("og:"+expectedOTP);
            Response.Write("txt:"+txtOTP.Text);
            if (txtOTP.Text.ToString() == expectedOTP)
            {
                Response.Redirect("~/changepass.aspx");
            }
            else
            {
                Response.Write("Incorrect OTP!");
            }
        }
    }
   

}