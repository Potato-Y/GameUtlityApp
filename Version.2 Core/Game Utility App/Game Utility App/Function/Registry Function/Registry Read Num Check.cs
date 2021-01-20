using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameUtilityApp.Function.Registry_Funtion
{
    class Registry_Read_Num_Check
    {
        public string NumChackAndChange(string getValue)
        {
            Int64 value = Convert.ToInt64(getValue);
            if (value < 0)
            {
                return Convert.ToString(2147483647 + (2147483648 + value) + 1);
            }
            return getValue;
        }
    }
}
