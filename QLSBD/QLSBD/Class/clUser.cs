using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSBD.Class
{
    class clUser
    {
        private int id;
        private string full_name;
        private int phone_number;
        private string address;
        private int user_type;

        public int Id { get => id; set => id = value; }
        public string Full_name { get => full_name; set => full_name = value; }
        public int Phone_number { get => phone_number; set => phone_number = value; }
        public string Address { get => address; set => address = value; }
        public int User_type { get => user_type; set => user_type = value; }
    }
}
