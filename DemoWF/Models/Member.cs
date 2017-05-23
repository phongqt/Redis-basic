using System;

namespace DemoWF.Models
{
    [Serializable()]
    public class Member
    {
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
