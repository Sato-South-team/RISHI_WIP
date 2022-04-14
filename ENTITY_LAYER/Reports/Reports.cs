// Decompiled with JetBrains decompiler
// Type: ENTITY_LAYER.Reports.Reports
// Assembly: ENTITY_LAYER, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A2F29874-B2B0-4D22-BF2E-BE01725E3AD9
// Assembly location: C:\Users\sar.puttaraju.ah\AppData\Local\Apps\2.0\5KHLMZL2.0RZ\VCEW5W2P.PCB\rish..xbap_44475a8cb30b4dba_0001.0000_64e870128fa3b865\ENTITY_LAYER.dll

namespace ENTITY_LAYER.Reports
{
    public class Reports
    {
        private static string _FromDate;
        private static string _Todate;
        private static string _Type,_ReportType,_WorkOrderNo,_Value;
        public static string FromDate
        {
            get => ENTITY_LAYER.Reports.Reports._FromDate;
            set => ENTITY_LAYER.Reports.Reports._FromDate = value;
        }

        public static string Todate
        {
            get => ENTITY_LAYER.Reports.Reports._Todate;
            set => ENTITY_LAYER.Reports.Reports._Todate = value;
        }

        public static string Type
        {
            get => ENTITY_LAYER.Reports.Reports._Type;
            set => ENTITY_LAYER.Reports.Reports._Type = value;
        }
        public static string ReportType { get => _ReportType; set => _ReportType = value; }
        public static string WorkOrderNo { get => _WorkOrderNo; set => _WorkOrderNo = value; }
        public static string Value { get => _Value; set => _Value = value; }
    }
}
