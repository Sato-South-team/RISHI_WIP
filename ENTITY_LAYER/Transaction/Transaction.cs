using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY_LAYER.Transaction
{
    public class Transaction
    {

        #region Variables
        static string  _Type,_Process,_Values,_BarcodeValue;

        public static string Type { get => _Type; set => _Type = value; }
        public static string Process { get => _Process; set => _Process = value; }
        public static string Values { get => _Values; set => _Values = value; }
        public static string BarcodeValue { get => _BarcodeValue; set => _BarcodeValue = value; }
        #endregion

        #region Properties

        #endregion
    }
}
