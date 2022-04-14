// Decompiled with JetBrains decompiler
// Type: BUSINESS_LAYER.Masters.Masters
// Assembly: BUSINESS_LAYER, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 728803F5-BD0B-402E-81F5-F78D3AF29542
// Assembly location: C:\Users\sar.puttaraju.ah\AppData\Local\Apps\2.0\5KHLMZL2.0RZ\VCEW5W2P.PCB\rish..xbap_44475a8cb30b4dba_0001.0000_64e870128fa3b865\BUSINESS_LAYER.dll

using DATA_LAYER.DatabaseConnectivity;
using System;
using System.Data;

namespace BUSINESS_LAYER.Masters
{
    public class Masters
    {
        private DatabaseConnections obj_DB = new DatabaseConnections();

        public string BL_GroupMasterTransaction()
        {
            try
            {
                return this.obj_DB.ExecuteProcedureParam("Proc_GroupMaster", (object)ENTITY_LAYER.Masters.Masters.GroupID, (object)ENTITY_LAYER.Masters.Masters.Rights, (object)ENTITY_LAYER.Masters.Masters.Type, (object)ENTITY_LAYER.Login.Login.UserID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet BL_GroupMasterDetails()
        {
            try
            {
                return this.obj_DB.ExecuteDataSetParam("Proc_GroupMaster", (object)ENTITY_LAYER.Masters.Masters.GroupID, (object)ENTITY_LAYER.Masters.Masters.Rights, (object)ENTITY_LAYER.Masters.Masters.Type, (object)ENTITY_LAYER.Login.Login.UserID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string BL_UserMasterTransaction()
        {
            try
            {
                return this.obj_DB.ExecuteProcedureParam("Proc_UserMaster", (object)ENTITY_LAYER.Masters.Masters.RefNo, (object)ENTITY_LAYER.Masters.Masters.UserID, (object)ENTITY_LAYER.Masters.Masters.UserName, (object)ENTITY_LAYER.Masters.Masters.Password, (object)ENTITY_LAYER.Masters.Masters.GroupID, (object)ENTITY_LAYER.Login.Login.UserID, (object)ENTITY_LAYER.Masters.Masters.Type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet BL_UserMasterDetails()
        {
            try
            {
                return this.obj_DB.ExecuteDataSetParam("Proc_UserMaster", (object)ENTITY_LAYER.Masters.Masters.RefNo, (object)ENTITY_LAYER.Masters.Masters.UserID, (object)ENTITY_LAYER.Masters.Masters.UserName, (object)ENTITY_LAYER.Masters.Masters.Password, (object)ENTITY_LAYER.Masters.Masters.GroupID, (object)ENTITY_LAYER.Login.Login.UserID, (object)ENTITY_LAYER.Masters.Masters.Type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string BL_AssetMasterTransaction()
        {
            try
            {
                return this.obj_DB.ExecuteProcedureParam("Proc_AssetMaster", (object)ENTITY_LAYER.Masters.Masters.RefNo, (object)ENTITY_LAYER.Masters.Masters.Assetname, (object)ENTITY_LAYER.Masters.Masters.Serialno, (object)ENTITY_LAYER.Masters.Masters.Status, (object)ENTITY_LAYER.Masters.Masters.AssetBarcode, (object)ENTITY_LAYER.Masters.Masters.TareWeight, (object)ENTITY_LAYER.Masters.Masters.AssetType, (object)ENTITY_LAYER.Login.Login.UserID, (object)ENTITY_LAYER.Masters.Masters.Type, (object)ENTITY_LAYER.Masters.Masters.Processname);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet BL_AssetMasterDetails()
        {
            try
            {
                return this.obj_DB.ExecuteDataSetParam("Proc_AssetMaster", (object)ENTITY_LAYER.Masters.Masters.RefNo, (object)ENTITY_LAYER.Masters.Masters.Assetname, (object)ENTITY_LAYER.Masters.Masters.Serialno, (object)ENTITY_LAYER.Masters.Masters.Status, (object)ENTITY_LAYER.Masters.Masters.AssetBarcode, (object)ENTITY_LAYER.Masters.Masters.TareWeight, (object)ENTITY_LAYER.Masters.Masters.AssetType, (object)ENTITY_LAYER.Login.Login.UserID, (object)ENTITY_LAYER.Masters.Masters.Type, (object)ENTITY_LAYER.Masters.Masters.Processname);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string BL_ProductMasterTransaction()
        {
            try
            {
                return this.obj_DB.ExecuteProcedureParam("Proc_ProductMaster", (object)ENTITY_LAYER.Masters.Masters.RefNo, (object)ENTITY_LAYER.Masters.Masters.ProductCode, (object)ENTITY_LAYER.Masters.Masters.Productname, (object)ENTITY_LAYER.Masters.Masters.Description, (object)ENTITY_LAYER.Masters.Masters.Category, (object)ENTITY_LAYER.Masters.Masters.Status, (object)ENTITY_LAYER.Login.Login.UserID, (object)ENTITY_LAYER.Masters.Masters.Type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet BL_ProductMasterDetails()
        {
            try
            {
                return this.obj_DB.ExecuteDataSetParam("Proc_ProductMaster", (object)ENTITY_LAYER.Masters.Masters.RefNo, (object)ENTITY_LAYER.Masters.Masters.ProductCode, (object)ENTITY_LAYER.Masters.Masters.Productname, (object)ENTITY_LAYER.Masters.Masters.Description, (object)ENTITY_LAYER.Masters.Masters.Category, (object)ENTITY_LAYER.Masters.Masters.Status, (object)ENTITY_LAYER.Login.Login.UserID, (object)ENTITY_LAYER.Masters.Masters.Type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string BL_ProcessMasterTransaction()
        {
            try
            {
                return this.obj_DB.ExecuteProcedureParam("Proc_ProcessMaster", (object)ENTITY_LAYER.Masters.Masters.RefNo, (object)ENTITY_LAYER.Masters.Masters.Processname, (object)ENTITY_LAYER.Masters.Masters.Sequenceno, (object)ENTITY_LAYER.Masters.Masters.Status, (object)ENTITY_LAYER.Login.Login.UserID, (object)ENTITY_LAYER.Masters.Masters.Type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet BL_ProcessMasterDetails()
        {
            try
            {
                return this.obj_DB.ExecuteDataSetParam("Proc_ProcessMaster", (object)ENTITY_LAYER.Masters.Masters.RefNo, (object)ENTITY_LAYER.Masters.Masters.Processname, (object)ENTITY_LAYER.Masters.Masters.Sequenceno, (object)ENTITY_LAYER.Masters.Masters.Status, (object)ENTITY_LAYER.Login.Login.UserID, (object)ENTITY_LAYER.Masters.Masters.Type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
