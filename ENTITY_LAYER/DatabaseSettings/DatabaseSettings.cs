// Decompiled with JetBrains decompiler
// Type: ENTITY_LAYER.DatabaseSettings.DatabaseSettings
// Assembly: ENTITY_LAYER, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A2F29874-B2B0-4D22-BF2E-BE01725E3AD9
// Assembly location: C:\Users\sar.puttaraju.ah\AppData\Local\Apps\2.0\5KHLMZL2.0RZ\VCEW5W2P.PCB\rish..xbap_44475a8cb30b4dba_0001.0000_64e870128fa3b865\ENTITY_LAYER.dll

namespace ENTITY_LAYER.DatabaseSettings
{
    public class DatabaseSettings
    {
        private static string _SqldbServer;
        private static string _SqlDBName;
        private static string _SqlDBUserID;
        private static string _SqlDBPassword;

        public static string SqlDBPassword
        {
            get => ENTITY_LAYER.DatabaseSettings.DatabaseSettings._SqlDBPassword;
            set => ENTITY_LAYER.DatabaseSettings.DatabaseSettings._SqlDBPassword = value;
        }

        public static string SqlDBUserID
        {
            get => ENTITY_LAYER.DatabaseSettings.DatabaseSettings._SqlDBUserID;
            set => ENTITY_LAYER.DatabaseSettings.DatabaseSettings._SqlDBUserID = value;
        }

        public static string SqlDBName
        {
            get => ENTITY_LAYER.DatabaseSettings.DatabaseSettings._SqlDBName;
            set => ENTITY_LAYER.DatabaseSettings.DatabaseSettings._SqlDBName = value;
        }

        public static string SqldbServer
        {
            get => ENTITY_LAYER.DatabaseSettings.DatabaseSettings._SqldbServer;
            set => ENTITY_LAYER.DatabaseSettings.DatabaseSettings._SqldbServer = value;
        }
    }
}
