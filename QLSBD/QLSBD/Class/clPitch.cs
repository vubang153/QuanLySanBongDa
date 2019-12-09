using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSBD.Class
{
    class clPitch
    {
        private int id;
        private string name;
        private string introduction;
        private string address;
        private int number;
        private DateTime start_time;
        private DateTime end_time;
        private int status;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Introduction { get => introduction; set => introduction = value; }
        public string Address { get => address; set => address = value; }
        public int Number { get => number; set => number = value; }
        public DateTime Start_time { get => start_time; set => start_time = value; }
        public DateTime End_time { get => end_time; set => end_time = value; }
        public int Status { get => status; set => status = value; }
    }
}
