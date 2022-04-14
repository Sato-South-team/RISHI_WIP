// Decompiled with JetBrains decompiler
// Type: BUSINESS_LAYER.Login.Login
// Assembly: BUSINESS_LAYER, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 728803F5-BD0B-402E-81F5-F78D3AF29542
// Assembly location: C:\Users\sar.puttaraju.ah\AppData\Local\Apps\2.0\5KHLMZL2.0RZ\VCEW5W2P.PCB\rish..xbap_44475a8cb30b4dba_0001.0000_64e870128fa3b865\BUSINESS_LAYER.dll

using DATA_LAYER.DatabaseConnectivity;
using System;

namespace BUSINESS_LAYER.Login
{
    public class Login
    {
        private DatabaseConnections obj_DB = new DatabaseConnections();

        public string BL_Login()
        {
            try
            {
                return this.obj_DB.ExecuteProcedureParam("Proc_Login", (object)ENTITY_LAYER.Login.Login.UserID, (object)ENTITY_LAYER.Login.Login.Password, (object)ENTITY_LAYER.Login.Login.ConfirmPassword, (object)ENTITY_LAYER.Login.Login.Type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
