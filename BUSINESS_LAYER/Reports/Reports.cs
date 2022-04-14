// Decompiled with JetBrains decompiler
// Type: BUSINESS_LAYER.Reports.Reports
// Assembly: BUSINESS_LAYER, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 728803F5-BD0B-402E-81F5-F78D3AF29542
// Assembly location: C:\Users\sar.puttaraju.ah\AppData\Local\Apps\2.0\5KHLMZL2.0RZ\VCEW5W2P.PCB\rish..xbap_44475a8cb30b4dba_0001.0000_64e870128fa3b865\BUSINESS_LAYER.dll

using DATA_LAYER.DatabaseConnectivity;
using System;
using System.Data;

namespace BUSINESS_LAYER.Reports
{
    public class Reports
    {
        private DatabaseConnections obj_DB = new DatabaseConnections();

        public DataSet BL_ReprintDetails()
        {
            try
            {
                return this.obj_DB.ExecuteDataSetParam("Proc_Report", (object)ENTITY_LAYER.Reports.Reports.FromDate, ENTITY_LAYER.Reports.Reports.Todate, ENTITY_LAYER.Reports.Reports.Type, (object)ENTITY_LAYER.Reports.Reports.ReportType, (object)ENTITY_LAYER.Reports.Reports.WorkOrderNo, (object)ENTITY_LAYER.Reports.Reports.Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
