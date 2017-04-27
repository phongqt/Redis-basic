using DemoWF.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWF.Helpers
{
    class NotificationRepository
    {
        public List<Notification> GetAll()
        {
            return DBHelper.Query<Notification>(@"SELECT ID, Text, UserID, CreatedDate
               FROM [dbo].[NotificationList]",false);
        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
           
        }
    }
}
