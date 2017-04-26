using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChattMob
{
    public class ClientRecord
    {

        private String customerId;
        private DateTime dateCreated;

        public String Lastname { get; set; }
        public String FirstName { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public String ProductType { get; set; }
        public String Manufacturer { get; set; }
        public String DescriptionOfProblem { get; set; }

    }
}
