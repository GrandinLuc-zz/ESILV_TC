using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESILV_TC_1
{
    interface ISalaire
    {
        double salaire
        {
            get;
            set;
        }
        string infoBancaires
        {
            get;
            set;
        }
        DateTime dateEntree
        {
            get;
            set;
        }
    }
}
