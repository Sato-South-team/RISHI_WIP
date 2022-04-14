// Decompiled with JetBrains decompiler
// Type: ENTITY_LAYER.Login.Login
// Assembly: ENTITY_LAYER, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A2F29874-B2B0-4D22-BF2E-BE01725E3AD9
// Assembly location: C:\Users\sar.puttaraju.ah\AppData\Local\Apps\2.0\5KHLMZL2.0RZ\VCEW5W2P.PCB\rish..xbap_44475a8cb30b4dba_0001.0000_64e870128fa3b865\ENTITY_LAYER.dll

namespace ENTITY_LAYER.Login
{
    public class Login
    {
        private static string _UserID;
        private static string _UserName;
        private static string _Password;
        private static string _Type;
        private static string _ConfirmPassword;
        private static string _Rights;

        public static string Rights
        {
            get => ENTITY_LAYER.Login.Login._Rights;
            set => ENTITY_LAYER.Login.Login._Rights = value;
        }

        public static string ConfirmPassword
        {
            get => ENTITY_LAYER.Login.Login._ConfirmPassword;
            set => ENTITY_LAYER.Login.Login._ConfirmPassword = value;
        }

        public static string Type
        {
            get => ENTITY_LAYER.Login.Login._Type;
            set => ENTITY_LAYER.Login.Login._Type = value;
        }

        public static string Password
        {
            get => ENTITY_LAYER.Login.Login._Password;
            set => ENTITY_LAYER.Login.Login._Password = value;
        }

        public static string UserName
        {
            get => ENTITY_LAYER.Login.Login._UserName;
            set => ENTITY_LAYER.Login.Login._UserName = value;
        }

        public static string UserID
        {
            get => ENTITY_LAYER.Login.Login._UserID;
            set => ENTITY_LAYER.Login.Login._UserID = value;
        }
    }
}
