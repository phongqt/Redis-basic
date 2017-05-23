using DemoWF.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

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
