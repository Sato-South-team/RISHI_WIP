// Decompiled with JetBrains decompiler
// Type: BUSINESS_LAYER.Transaction.Transaction
// Assembly: BUSINESS_LAYER, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 728803F5-BD0B-402E-81F5-F78D3AF29542
// Assembly location: C:\Users\sar.puttaraju.ah\AppData\Local\Apps\2.0\5KHLMZL2.0RZ\VCEW5W2P.PCB\rish..xbap_44475a8cb30b4dba_0001.0000_64e870128fa3b865\BUSINESS_LAYER.dll

using DATA_LAYER.DatabaseConnectivity;
using System;
using System.Data;

namespace BUSINESS_LAYER.Transaction
{
    public class Transaction
    {
        private DatabaseConnections obj_DB = new DatabaseConnections();
        public DataSet BL_ReprintDetails()
        {
            try
            {
                return this.obj_DB.ExecuteDataSetParam("Proc_Reprint", (object)ENTITY_LAYER.Transaction.Transaction.Process, ENTITY_LAYER.Transaction.Transaction.Values, ENTITY_LAYER.Transaction.Transaction.BarcodeValue, (object)ENTITY_LAYER.Login.Login.UserID, (object)ENTITY_LAYER.Transaction.Transaction.Type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string BL_ReprintTransaction()
        {
            try
            {
                return this.obj_DB.ExecuteProcedureParam("Proc_Reprint", (object)ENTITY_LAYER.Transaction.Transaction.Process, ENTITY_LAYER.Transaction.Transaction.Values, ENTITY_LAYER.Transaction.Transaction.BarcodeValue, (object)ENTITY_LAYER.Login.Login.UserID, (object)ENTITY_LAYER.Transaction.Transaction.Type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
