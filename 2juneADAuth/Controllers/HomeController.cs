using _2juneADAuth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using static System.Formats.Asn1.AsnWriter;
using System.Threading;

namespace _2juneADAuth.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PurchaseRequisitionForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PurchaseRequisitionForm(LRSUserDetailViewModel data)
        {
            ViewBag.LRSUserDataId = "111111";


            SendMailToAdmin();
            //return View("");
            string button = "Submitted";
            return RedirectToAction("Response", "Home", new { button });
        }
        public IActionResult Response(string button)
        {
            if (button == "Submitted")
            {
                ViewBag.LRSUserDataId = "Submitted";

            }
            if (button == "Approve")
            {
                ViewBag.LRSUserDataId = "Approve";

            }
            if (button == "Reject")
            {
                ViewBag.LRSUserDataId = "Reject";

            }
            return View();
        }
        public async Task SendMailToAdmin1()
        {
            string adminmail = "srisanjeev123@gmail.com;premkadari31092@gmail.com";
            //string adminmail = "srisanjeev123@gmail.com;";
            //string pwd = "awapqlisrijqdjym";
            string pwd = "bvlcfxdvyufuxddc";
            string name = "sanjeev";
            string Budget = "5656";
            string District = "Karimnagar";
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    //Credentials = new NetworkCredential("srisanjeev321@gmail.com", pwd),
                    Credentials = new NetworkCredential("premkumark3434@gmail.com", pwd),

                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
                //string htmlString = @"

                // ";
                //smtpClient.Send("srisanjeev321@gmail.com", adminmail, "Approve LRS Detail for below Users ", htmlString);
                string body = @"<html lang=""en"">
                    <head>
                      <meta charset=""utf-8"">
                      <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"">
                      <script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js""></script>
                      <script src=""https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js""></script>
                     <style>
                        table {
                          font-family: arial, sans-serif;
                          border-collapse: collapse;
                          width: 100%;
                        }
                        
                        td, th {
                          border: 1px solid #dddddd;
                          text-align: left;
                          padding: 8px;
                        }                       
                        
                        </style>
                    </head> " +
            ////    <body><p>Dear Admin,</p>
            ////    <p>Please find file number: 1234.</p>
            ////    <p>Approve this User Request</p>
            ////    <div class=""d-grid gap-2 d-md-block"">
            ////      <a href=""https://adauthprform.azurewebsites.net/Home/AdminView"" target=""_parent""><button class=""btn btn-primary"">Approve</button></a>
            ////      <a href=""https://adauthprform.azurewebsites.net/Home/AdminView"" target=""_parent""><button class=""btn btn-primary"">Reject</Reject></a>
            ////    </div>                  
            ////    <div class=""container"">" 
            //    "<br>" +
            //    "<table class=\"table table-striped\">\r\n  <thead>\r\n    <tr>\r\n      <th scope=\"col\">#</th>\r\n      <th scope=\"col\">Name</th>\r\n      " +
            //    "<th scope=\"col\">Email</th>\r\n      <th scope=\"col\">Cost Center</th>\r\n " +
            //    "</tr>\r\n  </thead>\r\n  <tbody>\r\n    <tr>\r\n     " +
            //    " <th scope=\"row\">1</th>\r\n      " +
            //    "<td>sanjeev</td>\r\n      " +
            //    "<td>sanjeev@gmail.com</td>\r\n      " +
            //    "<td>C1212 </td>\r\n    </tr>\r\n    <tr>\r\n      " +
            //    "</tr><tr></tr><tr></tr>\r\n  </tbody>\r\n</table>";

            ////"<h2 href=\"https://www.w3schools.com\">Approve this User Request!</h2>";
            //body += "</div></body></html>";


            //prem coe
            "<body>\r\n\t\t\t<p>Dear Admin,</p>\r\n\t\t\t<p>You have received a purchase requisition order from a Vendor</p>\r\n\t\t\t<p>Kindly check and approve or reject this request using the link below</p>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\r\n\t\t\t<div class=\"\" container\"\">\" +\"<br>\" +\"<table class=\\\" table table-striped\\\">\\r\\n\r\n\t\t\t<thead>\\r\\n    <tr>\\r\\n      <th scope=\\\"col\\\">#</th>\\r\\n      <th scope=\\\"col\\\">Name</th>\\r\\n      \" +\r\n                \"<th scope=\\\"col\\\">Email</th>\\r\\n      <th scope=\\\"col\\\">Cost Center</th>\\r\\n \" +\r\n                \"</tr>\\r\\n  </thead>\\r\\n  <tbody>\\r\\n    <tr>\\r\\n     \" +\r\n                \" <th scope=\\\"row\\\">1</th>\\r\\n      \" +\r\n                \"<td>prem</td>\\r\\n      \" +\r\n                \"<td>premkadari31092@gmail.com</td>\\r\\n      \" +\r\n                \"<td>C1212 </td>\\r\\n    </tr>\\r\\n    <tr>\\r\\n      \" +\r\n                \"</tr>\r\n\t\t\t\t<tr/>\r\n\t\t\t\t<tr/>\\r\\n  </tbody>\\r\\n</table>\" +\r\n                \"<div class=\\\"d-grid gap-2 d-md-block\\\">\\r\\n               \" +\r\n                \"<br/>   \" +\r\n                \"    <a href=\\\"https://localhost:7290/Home/AdminView\\\" target=\\\"_parent\\\">\r\n\t\t\t\t<button class=\\\"btn btn-primary\\\">Approve</button>\r\n\t\t\t</a>\\r\\n       \" +\r\n                \"          <a href=\\\"https://localhost:7290/Home/AdminView\\\" target=\\\"_parent\\\">\r\n\t\t\t\t<button class=\\\"btn btn-primary\\\">Reject</Reject>\r\n\t\t\t</a>\\r\\n           \" +\r\n                \"         </div>  \";\r\n\r\n                //\"<h2 href=\\\"https://www.w3schools.com\\\">Approve this User Request!</h2>\";\r\n                body += \"</div>\r\n</body>\r\n</html>\";";






                foreach (var item in adminmail.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    //MailMessage message = new MailMessage("srisanjeev321@gmail.com", item);
                    MailMessage message = new MailMessage("premkumark3434@gmail.com", item);
                    message.IsBodyHtml = true;
                    message.Subject = "Approval notifcation for Vendor Purchase Requisition - 1234";
                    message.Body = body;
                    smtpClient.Send(message);
                }



            }
            catch (Exception e)
            {
                Console.WriteLine("Could not send e-mail. Exception caught: " + e);
            }

        }


        public async Task SendMailToAdmin()
        {
            string adminmail = "srisanjeev123@gmail.com;premkadari31092@gmail.com";
            //string adminmail = "srisanjeev123@gmail.com;";
            string pwd = "bvlcfxdvyufuxddc";
            string name = "Premkumar";
            string Budget = "5656";
            string District = "Karimnagar";
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("premkumark3434@gmail.com", pwd),
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
                //string htmlString = @"

                // ";
                //smtpClient.Send("srisanjeev321@gmail.com", adminmail, "Approve LRS Detail for below Users ", htmlString);
                string body = @"<html lang=""en"">
                    <head>
                      <meta charset=""utf-8"">
                      <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"">
                      <script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js""></script>
                      <script src=""https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js""></script>
                     <style>
                        table {
                          font-family: arial, sans-serif;
                          border-collapse: collapse;
                          width: 100%;
                        }
                        
                        td, th {
                          border: 1px solid #dddddd;
                          text-align: left;
                          padding: 8px;
                        }                       
                        
                        </style>
                    </head>
                    <body><p>Dear Admin,</p>
                    <p>You have received a purchase requisition order from a Vendor</p>
                    <p>Kindly check and approve or reject this request using the link below</p>
                                    
																																																																								 
																																																																								
											
                    <div class=""container"">" +
                "<br>" +
                "<table class=\"table table-striped\">\r\n  <thead>\r\n    <tr>\r\n      <th scope=\"col\">#</th>\r\n      <th scope=\"col\">Name</th>\r\n      " +
                "<th scope=\"col\">Email</th>\r\n      <th scope=\"col\">Cost Center</th>\r\n " +
                "</tr>\r\n  </thead>\r\n  <tbody>\r\n    <tr>\r\n     " +
                " <th scope=\"row\">1</th>\r\n      " +
                "<td>prem</td>\r\n      " +
                "<td>premkadari31092@gmail.com</td>\r\n      " +
                "<td>C1212 </td>\r\n    </tr>\r\n    <tr>\r\n      " +
                "</tr><tr></tr><tr></tr>\r\n  </tbody>\r\n</table>" +
                "<div class=\"d-grid gap-2 d-md-block\">\r\n               " +
                "<br></br>   " +
                "    <a href=\"https://adauthprform.azurewebsites.net/Home/AdminView\" target=\"_parent\"><button class=\"btn btn-primary\">Approve</button></a>\r\n       " +
                "          <a href=\"https://adauthprform.azurewebsites.net/Home/AdminView\" target=\"_parent\"><button class=\"btn btn-primary\">Reject</Reject></a>\r\n           " +
                "         </div>  ";

                //"<h2 href=\"https://www.w3schools.com\">Approve this User Request!</h2>";
                body += "</div></body></html>";
                foreach (var item in adminmail.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    MailMessage message = new MailMessage("premkadari31092@gmail.com", item);
                    message.IsBodyHtml = true;
                    message.Subject = " Approval notifcation for Vendor Purchase Requisition - 1234 ";
                    message.Body = body;
                    smtpClient.Send(message);
                }



            }
            catch (Exception e)
            {
                Console.WriteLine("Could not send e-mail. Exception caught: " + e);
            }

        }




        public async Task SendMailToUser1()
        {
            string adminmail = "srisanjeev123@gmail.com;premkadari31092@gmail.com";
            //string adminmail = "srisanjeev123@gmail.com;";
            //string pwd = "awapqlisrijqdjym";
            string pwd = "bvlcfxdvyufuxddc";
            string name = "sanjeev";
            string Budget = "5656";
            string District = "Karimnagar";
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    //Credentials = new NetworkCredential("srisanjeev321@gmail.com", pwd),
                    Credentials = new NetworkCredential("premkumark3434@gmail.com", pwd),
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
                //string htmlString = @"

                // ";
                //smtpClient.Send("srisanjeev321@gmail.com", adminmail, "Approve LRS Detail for below Users ", htmlString);
                string body = @"<html lang=""en"">
                    <head>
                      <meta charset=""utf-8"">
                      <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"">
                      <script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js""></script>
                      <script src=""https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js""></script>
                     <style>
                        table {
                          font-family: arial, sans-serif;
                          border-collapse: collapse;
                          width: 100%;
                        }
                        
                        td, th {
                          border: 1px solid #dddddd;
                          text-align: left;
                          padding: 8px;
                        }                       
                        
                        </style>
                    </head>
                    <body>
                    
                    <p>Dear Admin,</p>

<p>You have received a purchase requisition order from a Vendor</p>

<p>Kindly check and approve or reject this request using the link below</p>
                                    
                    <div class=""container"">" +
                "<br>" +
                "<table class=\"table table-striped\">\r\n  <thead>\r\n    <tr>\r\n      <th scope=\"col\">#</th>\r\n      <th scope=\"col\">Name</th>\r\n      " +
                "<th scope=\"col\">Email</th>\r\n      <th scope=\"col\">Cost Center</th>\r\n " +
                "</tr>\r\n  </thead>\r\n  <tbody>\r\n    <tr>\r\n     " +
                " <th scope=\"row\">1</th>\r\n      <td>sanjeev</td>\r\n      <td>sanjeev@gmail.com</td>\r\n      <td>C1212 </td>\r\n    </tr>\r\n    <tr>\r\n      " +
                "</tr><tr></tr><tr></tr>\r\n  </tbody>\r\n</table>";

                //"<h2 href=\"https://www.w3schools.com\">Approve this User Request!</h2>";
                foreach (var item in adminmail.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    body += "</div></body></html>";






                    MailMessage message = new MailMessage("premkumark3434@gmail.com", item);
                    message.IsBodyHtml = true;
                    message.Subject = "Status of LRS Detail for below Users ";
                    message.Body = body;
                    smtpClient.Send(message);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Could not send e-mail. Exception caught: " + e);
            }

        }


        public async Task SendMailToUser2()
        {
            string adminmail = "srisanjeev123@gmail.com;premkadari31092@gmail.com";
            //string adminmail = "srisanjeev123@gmail.com;";
            string pwd = "bvlcfxdvyufuxddc";
            string name = "Prem";
            string Budget = "5656";
            string District = "Karimnagar";
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("premkumark3434@gmail.com", pwd),
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
                //string htmlString = @"

                // ";
                //smtpClient.Send("srisanjeev321@gmail.com", adminmail, "Approve LRS Detail for below Users ", htmlString);
                string body = @"<html lang="" en"">
<head>
	<meta charset="" utf-8"">
	<link rel="" stylesheet"" href="" https: maxcdn.bootstrapcdn.com bootstrap 3.4.1 css bootstrap.min.css"">
	<script src="" https: ajax.googleapis.com ajax libs jquery 3.6.4 jquery.min.js"">< script>
	<script src="" https: maxcdn.bootstrapcdn.com bootstrap 3.4.1 js bootstrap.min.js"">< script>
	<style>
                        table {
                          font-family: arial, sans-serif;
                          border-collapse: collapse;
                          width: 100%;
                        }
                        
                        td, th {
                          border: 1px solid #dddddd;
                          text-align: left;
                          padding: 8px;
                        }                       
                        
                        </style>
</head>
<body>
	<p>Dear User,</p>
	<p>Your Request has been Approved. Please wait for sometime to get this processed in the Backend.</p>
									
												
						
	<div class="" container"">" + "<br>" + "<table class=\" table table-striped\">\r\n    < thead >\r\n < tr >\r\n < th scope =\"col\">#</th>\r\n      <th scope=\"col\">Name</th>\r\n      " +
                "<th scope=\"col\">Email</th>\r\n      <th scope=\"col\">Cost Center</th>\r\n " +
                "</tr>\r\n  </thead>\r\n  <tbody>\r\n    <tr>\r\n     " +
                " <th scope=\"row\">1</th>\r\n      <td>prem</td>\r\n      <td>premkadari31092@gmail.com</td>\r\n      <td>C1212 </td>\r\n    </tr>\r\n    <tr>\r\n      " +
                "</tr>        < tr />        < tr />\r\n </ tbody >\r\n </ table > ";

                //"<h2 href=\"https://www.w3schools.com\">Approve this User Request!</h2>";
                foreach (var item in adminmail.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    body += "</div></ body ></ html > ";
                    MailMessage message = new MailMessage("premkadari31092@gmail.com", item);
                    message.IsBodyHtml = true;
                    message.Subject = "Monat PR: Status of your request is Changed";
                    message.Body = body;
                    smtpClient.Send(message);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Could not send e-mail. Exception caught: " + e);
            }

        }

        public async Task SendMailToUser()
        {
            string adminmail = "srisanjeev123@gmail.com;premkadari31092@gmail.com";
            //string adminmail = "srisanjeev123@gmail.com;";
            string pwd = "bvlcfxdvyufuxddc";
            string name = "Prem";
            string Budget = "5656";
            string District = "Karimnagar";
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("premkumark3434@gmail.com", pwd),
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
                //string htmlString = @"

                // ";
                //smtpClient.Send("srisanjeev321@gmail.com", adminmail, "Approve LRS Detail for below Users ", htmlString);
                string body = @"<html lang=""en"">
                    <head>
                      <meta charset=""utf-8"">
                      <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"">
                      <script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js""></script>
                      <script src=""https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js""></script>
                     <style>
                        table {
                          font-family: arial, sans-serif;
                          border-collapse: collapse;
                          width: 100%;
                        }
                        
                        td, th {
                          border: 1px solid #dddddd;
                          text-align: left;
                          padding: 8px;
                        }                       
                        
                        </style>
                    </head>
                    <body><p>Dear User,</p>
                    
                    <p>Your Request has been Approved. Please wait for sometime to get this processed in the Backend.</p>
                    
                                    
                    <div class=""container"">" +
                "<br>" +
                "<table class=\"table table-striped\">\r\n  <thead>\r\n    <tr>\r\n      <th scope=\"col\">#</th>\r\n      <th scope=\"col\">Name</th>\r\n      " +
                "<th scope=\"col\">Email</th>\r\n      <th scope=\"col\">Cost Center</th>\r\n " +
                "</tr>\r\n  </thead>\r\n  <tbody>\r\n    <tr>\r\n     " +
                " <th scope=\"row\">1</th>\r\n      <td>prem</td>\r\n      <td>premkadari31092@gmail.com</td>\r\n      <td>C1212 </td>\r\n    </tr>\r\n    <tr>\r\n      " +
                "</tr><tr></tr><tr></tr>\r\n  </tbody>\r\n</table>";

                //"<h2 href=\"https://www.w3schools.com\">Approve this User Request!</h2>";
                foreach (var item in adminmail.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    body += "</div></body></html>";
                    MailMessage message = new MailMessage("premkadari31092@gmail.com", item);
                    message.IsBodyHtml = true;
                    message.Subject = "Monat PR: Status of your request is Changed";
                    message.Body = body;
                    smtpClient.Send(message);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Could not send e-mail. Exception caught: " + e);
            }

        }



        public async Task SendMailToUser_Rejected1()
        {
            string adminmail = "srisanjeev123@gmail.com;premkadari31092@gmail.com";
            //string adminmail = "srisanjeev123@gmail.com;";
            string pwd = "awapqlisrijqdjym";
            string name = "sanjeev";
            string Budget = "5656";
            string District = "Karimnagar";
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("srisanjeev321@gmail.com", pwd),
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
                //string htmlString = @"

                // ";
                //smtpClient.Send("srisanjeev321@gmail.com", adminmail, "Approve LRS Detail for below Users ", htmlString);
                string body = @"<html lang=""en"">
                    <head>
                      <meta charset=""utf-8"">
                      <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"">
                      <script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js""></script>
                      <script src=""https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js""></script>
                     <style>
                        table {
                          font-family: arial, sans-serif;
                          border-collapse: collapse;
                          width: 100%;
                        }
                        
                        td, th {
                          border: 1px solid #dddddd;
                          text-align: left;
                          padding: 8px;
                        }                       
                        
                        </style>
                    </head>
                    <body><p>Dear Sanjeev,</p>
                    
                    <p>Your Request has been Rejected</p>
                                    
                    <div class=""container"">" +
                "<br>" +
                "<table class=\"table table-striped\">\r\n  <thead>\r\n    <tr>\r\n      <th scope=\"col\">#</th>\r\n      <th scope=\"col\">Name</th>\r\n      " +
                "<th scope=\"col\">Email</th>\r\n      <th scope=\"col\">Cost Center</th>\r\n " +
                "</tr>\r\n  </thead>\r\n  <tbody>\r\n    <tr>\r\n     " +
                " <th scope=\"row\">1</th>\r\n      <td>sanjeev</td>\r\n      <td>sanjeev@gmail.com</td>\r\n      <td>C1212 </td>\r\n    </tr>\r\n    <tr>\r\n      " +
                "</tr><tr></tr><tr></tr>\r\n  </tbody>\r\n</table><br />\r\n                    <br />" +
                "<table><tr><tr></tr></tr></table>";

                //"<h2 href=\"https://www.w3schools.com\">Approve this User Request!</h2>";
                foreach (var item in adminmail.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    body += "</div></body></html>";
                    MailMessage message = new MailMessage("srisanjeev321@gmail.com", item);
                    message.IsBodyHtml = true;
                    message.Subject = "Status of LRS Detail for below Users ";
                    message.Body = body;
                    smtpClient.Send(message);
                }



            }
            catch (Exception e)
            {
                Console.WriteLine("Could not send e-mail. Exception caught: " + e);
            }

        }

        public async Task SendMailToUser_Rejected2()
        {
            string adminmail = "srisanjeev123@gmail.com;premkadari31092@gmail.com";
            //string adminmail = "srisanjeev123@gmail.com;";
            string pwd = "bvlcfxdvyufuxddc";
            string name = "Prem";
            string Budget = "5656";
            string District = "USA";
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("premkumark3434@gmail.com", pwd),
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
                //string htmlString = @"

                // ";
                //smtpClient.Send("srisanjeev321@gmail.com", adminmail, "Approve LRS Detail for below Users ", htmlString);
                string body = @"<html lang="" en"">
<head>
	<meta charset="" utf-8"">
	<link rel="" stylesheet"" href="" https: maxcdn.bootstrapcdn.com bootstrap 3.4.1 css bootstrap.min.css"">
	<script src="" https: ajax.googleapis.com ajax libs jquery 3.6.4 jquery.min.js"">< script>
	<script src="" https: maxcdn.bootstrapcdn.com bootstrap 3.4.1 js bootstrap.min.js"">< script>
	<style>
                        table {
                          font-family: arial, sans-serif;
                          border-collapse: collapse;
                          width: 100%;
                        }
                        
                        td, th {
                          border: 1px solid #dddddd;
                          text-align: left;
                          padding: 8px;
                        }                       
                        
                        </style>
</head>
<body>
	<p>Dear User,</p>
					
	<p>Your Request has been Rejected</p>
									
												
						
	<div class="" container"">" + "<br>" + "<table class=\" table table-striped\">\r\n    < thead >\r\n < tr >\r\n < th scope =\"col\">#</th>\r\n      <th scope=\"col\">Name</th>\r\n      " +
                "<th scope=\"col\">Email</th>\r\n      <th scope=\"col\">Cost Center</th>\r\n " +
                "</tr>\r\n  </thead>\r\n  <tbody>\r\n    <tr>\r\n     " +
                " <th scope=\"row\">1</th>\r\n      <td>premkumar</td>\r\n      <td>premkadari31092@gmail.com</td>\r\n      <td>C1212 </td>\r\n    </tr>\r\n    <tr>\r\n      " +
                "</tr>        < tr />        < tr />\r\n </ tbody >\r\n </ table >< br />\r\n < br /> " +                "<table>    < tr >        < tr />    </ tr ></ table > ";

                //"<h2 href=\"https://www.w3schools.com\">Approve this User Request!</h2>";
                foreach (var item in adminmail.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    body += "</div></ body ></ html > ";
                    MailMessage message = new MailMessage("premkadari31092@gmail.com", item);
                    message.IsBodyHtml = true;
                    message.Subject = "Monat PR: Status of your request is Changed";
                    message.Body = body;
                    smtpClient.Send(message);
                }



            }
            catch (Exception e)
            {
                Console.WriteLine("Could not send e-mail. Exception caught: " + e);
            }

        }

        public async Task SendMailToUser_Rejected()
        {
            string adminmail = "srisanjeev123@gmail.com;premkadari31092@gmail.com";
            //string adminmail = "srisanjeev123@gmail.com;";
            string pwd = "bvlcfxdvyufuxddc";
            string name = "Prem";
            string Budget = "5656";
            string District = "USA";
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("premkumark3434@gmail.com", pwd),
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
                //string htmlString = @"

                // ";
                //smtpClient.Send("srisanjeev321@gmail.com", adminmail, "Approve LRS Detail for below Users ", htmlString);
                string body = @"<html lang=""en"">
                    <head>
                      <meta charset=""utf-8"">
                      <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"">
                      <script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js""></script>
                      <script src=""https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js""></script>
                     <style>
                        table {
                          font-family: arial, sans-serif;
                          border-collapse: collapse;
                          width: 100%;
                        }
                        
                        td, th {
                          border: 1px solid #dddddd;
                          text-align: left;
                          padding: 8px;
                        }                       
                        
                        </style>
                    </head>
                    <body><p>Dear User,</p>
                    
                    <p>Your Request has been Rejected</p>
                                    
                    <div class=""container"">" +
                "<br>" +
                "<table class=\"table table-striped\">\r\n  <thead>\r\n    <tr>\r\n      <th scope=\"col\">#</th>\r\n      <th scope=\"col\">Name</th>\r\n      " +
                "<th scope=\"col\">Email</th>\r\n      <th scope=\"col\">Cost Center</th>\r\n " +
                "</tr>\r\n  </thead>\r\n  <tbody>\r\n    <tr>\r\n     " +
                " <th scope=\"row\">1</th>\r\n      <td>premkumar</td>\r\n      <td>premkadari31092@gmail.com</td>\r\n      <td>C1212 </td>\r\n    </tr>\r\n    <tr>\r\n      " +
                "</tr><tr></tr><tr></tr>\r\n  </tbody>\r\n</table><br />\r\n                    <br />" +
                "<table><tr><tr></tr></tr></table>";

                //"<h2 href=\"https://www.w3schools.com\">Approve this User Request!</h2>";
                foreach (var item in adminmail.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    body += "</div></body></html>";
                    MailMessage message = new MailMessage("premkadari31092@gmail.com", item);
                    message.IsBodyHtml = true;
                    message.Subject = "Monat PR: Status of your request is Changed";
                    message.Body = body;
                    smtpClient.Send(message);
                }



            }
            catch (Exception e)
            {
                Console.WriteLine("Could not send e-mail. Exception caught: " + e);
            }

        }


        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [AllowAnonymous]
        public IActionResult ADLogin()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Testview()
        {
            return View();
        }
        [Authorize]
        public IActionResult AdminView()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminView(string button)
        {
            if (button == "Approve")
            {
                ViewBag.LRSUserDataId = "Approve";
                SendMailToUser();
                return RedirectToAction("Response", "Home", new { button });

            }
            if (button == "Reject")
            {
                ViewBag.LRSUserDataId = "Reject";
                SendMailToUser_Rejected();
                return RedirectToAction("Response", "Home", new { button });
            }
            return View();
        }
        public IActionResult TrackRequest()
        {
            return View();
        }





    }
}