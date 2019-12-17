using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSBD.Commons
{
    class FORM
    {
        QLSBDataContext db = new QLSBDataContext();
        public void setTypeOfPitch(System.Windows.Forms.ComboBox cbb)
        {
            var query = from t_pitch in db.categories
                        select t_pitch;
            cbb.DisplayMember = "category";
            cbb.ValueMember = "id";
        }
    }
}
