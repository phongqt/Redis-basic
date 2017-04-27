using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWF.Models
{
    [Serializable()]
    public class Notification
    {
        public int ID { get; set; }

        public string Text { get; set; }

        public string UserID { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
