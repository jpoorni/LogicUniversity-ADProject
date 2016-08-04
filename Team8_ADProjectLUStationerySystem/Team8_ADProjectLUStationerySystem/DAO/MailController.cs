using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net;
using System.Net.Mail;

namespace Team8_ADProjectLUStationerySystem.DAO
{
    public class MailController
    {
        string sub = "Your have a new Notifaction.(DO NOT REPLY)";
        string NewOrder = "You got a new Order request.";
        string Approve = "Your request has been approve.";
        string NotApprove = "Your request has not been approve.";
        string NewRequisition = "You got a new Requisition.";
        string Fullfill = "Your requisition is already process without outstanding.";
        string Outstanding = "Your requisition is already process, but some item is outstanding.";
        string collect = "Your can collect the item at:";
        string adjustment = "You got new adjustment.";


        logicUniversityEntities lue = new logicUniversityEntities();

        public void NewOrderNoti()
        {
            int role = 11001;
            int id = lue.userDetails.Where(x =>
                x.roleId == role).First().userId;
            employee e = lue.employees.Where(x =>
                x.employeeId == id).First();


            MailAddress messagefrom = new MailAddress("eshely@163.com", "Logic Univ. Stationery ");
            string messageto = e.email;
            string messagesub = sub;
            string messagebody = NewOrder;

            SmtpClient smtp = new SmtpClient();
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = false;

            smtp.Host = "smtp.163.com";
            smtp.Port = 25;

            smtp.UseDefaultCredentials = true;
            smtp.Credentials = new NetworkCredential("eshely@163.com", "eshely.1105");

            MailMessage mm = new MailMessage();
            mm.Priority = MailPriority.High;
            mm.From = messagefrom;

            //mm.ReplyTo = new MailAddress("eshely.ho@gmail.com", "receiver");
            mm.To.Add(messageto);
            mm.Subject = messagesub;
            mm.IsBodyHtml = false;
            mm.Body = messagebody;

            try
            {
                smtp.Send(mm);

            }
            catch
            {

            }

        }//finish
        public void orderStatusNoti(int orderId, string Status)
        {
            string body = Approve;
            if (Status == "rejected")
            {
                body=NotApprove;
            }
            purchaseOrder po = lue.purchaseOrders.Where(x =>
                x.purchaseorderno == orderId).First();
            int id = 0;
            if (po.userId.HasValue)
            {
                id = po.userId.Value;
            }
            employee e = lue.employees.Where(x =>
                x.employeeId == id).First();

            MailAddress messagefrom = new MailAddress("eshely@163.com", "Logic Univ. Stationery ");
            string messageto = e.email;
            string messagesub = body;
            string messagebody = Approve;

            SmtpClient smtp = new SmtpClient();
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = false;

            smtp.Host = "smtp.163.com";
            smtp.Port = 25;

            smtp.UseDefaultCredentials = true;
            smtp.Credentials = new NetworkCredential("eshely@163.com", "eshely.1105");

            MailMessage mm = new MailMessage();
            mm.Priority = MailPriority.High;
            mm.From = messagefrom;

            //mm.ReplyTo = new MailAddress("eshely.ho@gmail.com", "receiver");
            mm.To.Add(messageto);
            mm.Subject = messagesub;
            mm.IsBodyHtml = false;
            mm.Body = messagebody;

            try
            {
                smtp.Send(mm);

            }
            catch
            {

            }

        }//finish
        public void newRequisitionNotiForDH(string did)
        {
            department d = lue.departments.Where(x =>
                x.departmentCode == did).First();
            employee dh = lue.employees.Where(x =>
                x.employeeName == d.headName).First();
            string emailAdd = dh.email;



            MailAddress messagefrom = new MailAddress("eshely@163.com", "Logic Univ. Stationery ");
            string messageto = emailAdd;
            string messagesub = sub;
            string messagebody = NewRequisition;

            SmtpClient smtp = new SmtpClient();
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = false;

            smtp.Host = "smtp.163.com";
            smtp.Port = 25;

            smtp.UseDefaultCredentials = true;
            smtp.Credentials = new NetworkCredential("eshely@163.com", "eshely.1105");

            MailMessage mm = new MailMessage();
            mm.Priority = MailPriority.High;
            mm.From = messagefrom;

            //mm.ReplyTo = new MailAddress("eshely.ho@gmail.com", "receiver");
            mm.To.Add(messageto);
            mm.Subject = messagesub;
            mm.IsBodyHtml = false;
            mm.Body = messagebody;

            try
            {
                smtp.Send(mm);

            }
            catch
            {

            }
        }//finish
        public void newRequisitionNotiForClerk()
        {
            List<userDetail> cu = lue.userDetails.Where(x =>
                x.roleId == 11000).ToList();
            List<employee> clerk = new List<employee>();
            foreach (userDetail result in cu)
            {
                clerk.Add(lue.employees.Where(x =>
                    x.employeeId == result.userId).First());
            }

            foreach (employee c in clerk)
            {

                MailAddress messagefrom = new MailAddress("eshely@163.com", "Logic Univ. Stationery ");
                string messageto = c.email;
                string messagesub = sub;
                string messagebody = NewRequisition;

                SmtpClient smtp = new SmtpClient();
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.EnableSsl = false;

                smtp.Host = "smtp.163.com";
                smtp.Port = 25;

                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new NetworkCredential("eshely@163.com", "eshely.1105");

                MailMessage mm = new MailMessage();
                mm.Priority = MailPriority.High;
                mm.From = messagefrom;

                //mm.ReplyTo = new MailAddress("eshely.ho@gmail.com", "receiver");
                mm.To.Add(messageto);
                mm.Subject = messagesub;
                mm.IsBodyHtml = false;
                mm.Body = messagebody;

                try
                {
                    smtp.Send(mm);

                }
                catch
                {

                }
            }

        }//finish
        public void approveRequisitionNoti(int rid)
        {
            requisition r = lue.requisitions.Where(x =>
                x.requisitionId == rid).First();
            employee ey = lue.employees.Where(x =>
                    x.employeeId == r.employeeId).First();


           
                MailAddress messagefrom = new MailAddress("eshely@163.com", "Logic Univ. Stationery ");
                string messageto = ey.email;
                string messagesub = sub;
                string messagebody = Approve;

                SmtpClient smtp = new SmtpClient();
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.EnableSsl = false;

                smtp.Host = "smtp.163.com";
                smtp.Port = 25;

                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new NetworkCredential("eshely@163.com", "eshely.1105");

                MailMessage mm = new MailMessage();
                mm.Priority = MailPriority.High;
                mm.From = messagefrom;

                //mm.ReplyTo = new MailAddress("eshely.ho@gmail.com", "receiver");
                mm.To.Add(messageto);
                mm.Subject = messagesub;
                mm.IsBodyHtml = false;
                mm.Body = messagebody;

                try
                {
                    smtp.Send(mm);

                }
                catch
                {

                }
            
        }//finish
        public void noapproveRequisitionNoti(int rid)
        {
            requisition r = lue.requisitions.Where(x =>
                x.requisitionId == rid).First();
            employee ey = lue.employees.Where(x =>
                    x.employeeId == r.employeeId).First();

                MailAddress messagefrom = new MailAddress("eshely@163.com", "Logic Univ. Stationery ");
                string messageto = ey.email;
                string messagesub = sub;
                string messagebody = NotApprove;

                SmtpClient smtp = new SmtpClient();
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.EnableSsl = false;

                smtp.Host = "smtp.163.com";
                smtp.Port = 25;

                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new NetworkCredential("eshely@163.com", "eshely.1105");

                MailMessage mm = new MailMessage();
                mm.Priority = MailPriority.High;
                mm.From = messagefrom;

                //mm.ReplyTo = new MailAddress("eshely.ho@gmail.com", "receiver");
                mm.To.Add(messageto);
                mm.Subject = messagesub;
                mm.IsBodyHtml = false;
                mm.Body = messagebody;

                try
                {
                    smtp.Send(mm);

                }
                catch
                {

                }
            
        }//finish
        public void fullfillRequisitionNoti(List<requisition> r)
        {
            List<requisition> full = r.Where(x =>
                x.statusId == 2003).ToList();
            List<employee> e = new List<employee>();
            foreach (requisition result in full)
            {
                e.Add(lue.employees.Where(x =>
                    x.employeeId == result.employeeId).First());
            }


            foreach (employee ey in e)
            {

                MailAddress messagefrom = new MailAddress("eshely@163.com", "Logic Univ. Stationery ");
                string messageto = ey.email;
                string messagesub = sub;
                string messagebody = Fullfill;

                SmtpClient smtp = new SmtpClient();
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.EnableSsl = false;

                smtp.Host = "smtp.163.com";
                smtp.Port = 25;

                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new NetworkCredential("eshely@163.com", "eshely.1105");

                MailMessage mm = new MailMessage();
                mm.Priority = MailPriority.High;
                mm.From = messagefrom;

                //mm.ReplyTo = new MailAddress("eshely.ho@gmail.com", "receiver");
                mm.To.Add(messageto);
                mm.Subject = messagesub;
                mm.IsBodyHtml = false;
                mm.Body = messagebody;

                try
                {
                    smtp.Send(mm);

                }
                catch
                {

                }
            }
        }//finsih
        public void outstandingRequisitionNoti(List<requisition> r)
        {
            List<requisition> full = r.Where(x =>
               x.statusId == 2008).ToList();
            List<employee> e = new List<employee>();
            foreach (requisition result in full)
            {
                e.Add(lue.employees.Where(x =>
                    x.employeeId == result.employeeId).First());
            }


            foreach (employee ey in e)
            {

                MailAddress messagefrom = new MailAddress("eshely@163.com", "Logic Univ. Stationery ");
                string messageto = ey.email;
                string messagesub = sub;
                string messagebody = Outstanding;

                SmtpClient smtp = new SmtpClient();
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.EnableSsl = false;

                smtp.Host = "smtp.163.com";
                smtp.Port = 25;

                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new NetworkCredential("eshely@163.com", "eshely.1105");

                MailMessage mm = new MailMessage();
                mm.Priority = MailPriority.High;
                mm.From = messagefrom;

                //mm.ReplyTo = new MailAddress("eshely.ho@gmail.com", "receiver");
                mm.To.Add(messageto);
                mm.Subject = messagesub;
                mm.IsBodyHtml = false;
                mm.Body = messagebody;

                try
                {
                    smtp.Send(mm);

                }
                catch
                {

                }
            }
        }//finish
        public void canCollectionNoti(string did)
        {
            department dp = lue.departments.Where(x =>
                x.departmentCode == did).First();
            employee rep = lue.employees.Where(x =>
                x.employeeId == dp.RepresentativeID).First();
            collectionPoint cp = lue.collectionPoints.Where(x =>
                x.collectionPointId == dp.collectionPointId).First();

            string body = collect + cp.collectionPointName + "(" + cp.collectionTime + ")";

            MailAddress messagefrom = new MailAddress("eshely@163.com", "Logic Univ. Stationery ");
            string messageto = rep.email;
            string messagesub = sub;
            string messagebody = collect;

            SmtpClient smtp = new SmtpClient();
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = false;

            smtp.Host = "smtp.163.com";
            smtp.Port = 25;

            smtp.UseDefaultCredentials = true;
            smtp.Credentials = new NetworkCredential("eshely@163.com", "eshely.1105");

            MailMessage mm = new MailMessage();
            mm.Priority = MailPriority.High;
            mm.From = messagefrom;

            //mm.ReplyTo = new MailAddress("eshely.ho@gmail.com", "receiver");
            mm.To.Add(messageto);
            mm.Subject = messagesub;
            mm.IsBodyHtml = false;
            mm.Body = messagebody;

            try
            {
                smtp.Send(mm);

            }
            catch
            {

            }
        }//finish
        public void newAdjustment(int cost)
        {
            int role = 11001;
            if (cost >= 250)
            {
                role = 11002;
            }

            int id = lue.userDetails.Where(x =>
                x.roleId == role).First().userId;
            employee e = lue.employees.Where(x =>
                x.employeeId == id).First();


            MailAddress messagefrom = new MailAddress("eshely@163.com", "Logic Univ. Stationery ");
            string messageto = e.email;
            string messagesub = sub;
            string messagebody = adjustment;

            SmtpClient smtp = new SmtpClient();
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = false;

            smtp.Host = "smtp.163.com";
            smtp.Port = 25;

            smtp.UseDefaultCredentials = true;
            smtp.Credentials = new NetworkCredential("eshely@163.com", "eshely.1105");

            MailMessage mm = new MailMessage();
            mm.Priority = MailPriority.High;
            mm.From = messagefrom;

            //mm.ReplyTo = new MailAddress("eshely.ho@gmail.com", "receiver");
            mm.To.Add(messageto);
            mm.Subject = messagesub;
            mm.IsBodyHtml = false;
            mm.Body = messagebody;

            try
            {
                smtp.Send(mm);

            }
            catch
            {

            }
        }//finish
    }
}