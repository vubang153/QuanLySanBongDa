using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSBD.Class
{
    class clBooking
    {
        private int id;
        private int user_id;
        private int pitch_id;
        private DateTime date;
        private double price;

        public int Id { get => id; set => id = value; }
        public int User_id { get => user_id; set => user_id = value; }
        public int Pitch_id { get => pitch_id; set => pitch_id = value; }
        public DateTime Date { get => date; set => date = value; }
        public double Price { get => price; set => price = value; }
    }
}
