using RISHI_WIP.CommonClasses;
using Sato_Network_Client_DLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RISHI_WIP.Transactions
{
    /// <summary>
    /// Interaction logic for Reprint.xaml
    /// </summary>
    public partial class Reprint : Window
    {
        public Reprint()
        {
            InitializeComponent();
        }
        private BUSINESS_LAYER.Transaction.Transaction obj_Trans = new BUSINESS_LAYER.Transaction.Transaction();
        private BUSINESS_LAYER.LogCreation.LogCreation obj_Log = new BUSINESS_LAYER.LogCreation.LogCreation();
        DataSet dataSet = new DataSet();
        private void BtnReprint_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Transaction("Reprint");
            }
            catch (Exception ex)
            {
                this.obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "RE-PRINT", CommonVariable.UserID);
                CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonVariable.CustomStriing.Error.ToString());
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Clear();
            }
            catch (Exception ex)
            {
                this.obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "RE-PRINT", CommonVariable.UserID);
                CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonVariable.CustomStriing.Error.ToString());
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
                StartUp.MainWindow obj_page = new StartUp.MainWindow();
                obj_page.ShowDialog();
               // this.NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                this.obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "RE-PRINT", CommonVariable.UserID);
                CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonVariable.CustomStriing.Error.ToString());
            }
        }
        private void Transaction(string Type)
        {
            if (Type == "ProcessDetails")
            {
                ENTITY_LAYER.Transaction.Transaction.Type = Type;
                CommonClasses.CommonMethods.FillComboBox(cmbProcess, obj_Trans.BL_ReprintDetails().Tables[0], "ProcessName", "ProcessName");
            }
            if (Type == "Values")
            {
                ENTITY_LAYER.Transaction.Transaction.Type = Type;
                ENTITY_LAYER.Transaction.Transaction.Process = cmbProcess.SelectedValue.ToString();
                CommonClasses.CommonMethods.FillComboBox(cmbValues, obj_Trans.BL_ReprintDetails().Tables[0], "Values", "Values");
            }
            if (Type == "GetReprintDetails")
            {
                ENTITY_LAYER.Transaction.Transaction.Type = Type;
                ENTITY_LAYER.Transaction.Transaction.Process = cmbProcess.SelectedValue.ToString();
                ENTITY_LAYER.Transaction.Transaction.Values = cmbValues.SelectedValue.ToString();
                dataSet = obj_Trans.BL_ReprintDetails();
                dvgMasterDeatils.ItemsSource = dataSet.Tables[0].DefaultView;
            }
            if (Type == "Reprint")
            {
                NetworkClient networkClient = new NetworkClient();
                networkClient.connection(dataSet.Tables[1].Rows[0]["PrinterIP"].ToString(), Convert.ToInt32(dataSet.Tables[1].Rows[0]["PrinterPort"]));
                if (cmbProcess.SelectedValue.ToString() == "EXTRUSION")
                {
                    string str1 = dataSet.Tables[1].Rows[0]["PRNFile"].ToString();
                    for (int index = 0; index < this.dvgMasterDeatils.SelectedItems.Count; ++index)
                    {
                        ENTITY_LAYER.Transaction.Transaction.Type = Type;
                        ENTITY_LAYER.Transaction.Transaction.Process = cmbProcess.SelectedValue.ToString();
                        ENTITY_LAYER.Transaction.Transaction.Values = cmbValues.SelectedValue.ToString();
                        ENTITY_LAYER.Transaction.Transaction.BarcodeValue = Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["BobbinBarcode"]);
                        CommonVariable.Result = obj_Trans.BL_ReprintTransaction();
                        if (CommonVariable.Result == "Saved")
                        {

                            str1 = str1.Replace("{Date}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["Date"]));
                            str1 = str1.Replace("{Shift}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["Time"]));
                            str1 = str1.Replace("{BatchNo}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["BatchNo"]));
                            str1 = str1.Replace("{Dofflength}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["Dofflength"]));
                            str1 = str1.Replace("{YarnDiameter}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["YarnDiameter"]));
                            str1 = str1.Replace("{Noofbobbins}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["Noofbobbins"]));
                            str1 = str1.Replace("{TrolleyNumber}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["TrolleyBarcode"]).Split('|')[1].ToString());
                            str1 = str1.Replace("{TotalTrolleyWeight}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["TotalTrolleyWeight"]));
                            str1 = str1.Replace("{MachineNo}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["MachineBarcode"]).Split('|')[1].ToString());
                            str1 = str1.Replace("{YarnID}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["YarnID"]));
                            str1 = str1.Replace("{DoffNo}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["DoffNo"]));
                            str1 = str1.Replace("{Denier}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["Denier"]));
                            str1 = str1.Replace("{YarnColour}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["YarnColour"]));
                            str1 = str1.Replace("{Tareweight}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["Tareweight"]));
                            str1 = str1.Replace("{Netweightofyarn}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["Netweightofyarn"]));
                            str1 = str1.Replace("{Barcode}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["BobbinBarcode"]));
                            str1 = str1.Replace("{Len}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["BobbinBarcode"]).Length.ToString());
                             networkClient.Write(str1);
                        }
                    }
                }


                if (cmbProcess.SelectedValue.ToString() == "WARPING")
                {
                    string ProductCode = "", ProductCode1 = "";
                    for (int index = 0; index < this.dvgMasterDeatils.SelectedItems.Count; ++index)
                    {
                        ENTITY_LAYER.Transaction.Transaction.Type = Type;
                        ENTITY_LAYER.Transaction.Transaction.Process = cmbProcess.SelectedValue.ToString();
                        ENTITY_LAYER.Transaction.Transaction.Values = cmbValues.SelectedValue.ToString();
                        ENTITY_LAYER.Transaction.Transaction.BarcodeValue = Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["BeamSequanceNo"]);
                        CommonVariable.Result = obj_Trans.BL_ReprintTransaction();
                        if (CommonVariable.Result == "Saved")
                        {
                            string str1 = dataSet.Tables[1].Rows[0]["PRNFile"].ToString();
                            str1 = str1.Replace("{Date}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["Date"]));
                            str1 = str1.Replace("{Shift}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["Time"]));
                            str1 = str1.Replace("{WorkOrderNo}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["WorkOrderNo"]));
                            str1 = str1.Replace("{Machine No}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["Machine"]).Split('|')[1].ToString());
                            str1 = str1.Replace("{BeamNo}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["BeamAssetBarcode"]).Split('|')[1].ToString());
                            str1 = str1.Replace("{BeamSQNo}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["BeamSequanceNo"]));
                            if (Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["ProductCode"]) != "")
                            {
                                string[] str = Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["ProductCode"]).Split('/');
                                for (int j = 0; j < str.Length; j++)
                                {
                                    string[] str2 = str[j].Split('-');
                                    if (str2.Length > 0)
                                    {
                                        if (ProductCode == "")
                                            ProductCode = str2[0] + "-" + str2[1] + "-" + str2[2] + "-" + str2[4] + "-" + str2[5];
                                        if (ProductCode1 == "")
                                            ProductCode1 = str2[3];
                                        else
                                            ProductCode1 = ProductCode1 + "/" + str2[3];
                                    }
                                }
                            }

                            str1 = str1.Replace("{ProductCode}", ProductCode);
                            str1 = str1.Replace("{ProductCode1}", ProductCode1);
                            str1 = str1.Replace("{Width}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["Width"]));
                            str1 = str1.Replace("{Length}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["Length"]));
                            str1 = str1.Replace("{NoofEnds}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["NoofEnds"]));
                            str1 = str1.Replace("{Barcode}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["BeamSequanceNo"]));
                            str1 = str1.Replace("{Len}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["BeamSequanceNo"]).Length.ToString());
                            networkClient.Write(str1);
                        }
                    }
                }
                if (cmbProcess.SelectedValue.ToString() == "WEAVING")
                {
                    for (int index = 0; index < this.dvgMasterDeatils.SelectedItems.Count; ++index)
                    {
                        ENTITY_LAYER.Transaction.Transaction.Type = Type;
                        ENTITY_LAYER.Transaction.Transaction.Process = cmbProcess.SelectedValue.ToString();
                        ENTITY_LAYER.Transaction.Transaction.Values = cmbValues.SelectedValue.ToString();
                        ENTITY_LAYER.Transaction.Transaction.BarcodeValue = Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["JumboRollNo"]);
                        CommonVariable.Result = obj_Trans.BL_ReprintTransaction();
                        if (CommonVariable.Result == "Saved")
                        {
                            string str1 = dataSet.Tables[1].Rows[0]["PRNFile"].ToString();
                            string ProductCode = "", ProductCode1 = "";
                            str1 = str1.Replace("{Date}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["Date"]));
                            str1 = str1.Replace("{Shift}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["Time"]));
                            str1 = str1.Replace("{WorkOrderNo}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["WorkOrderNo"]));
                            str1 = str1.Replace("{FabricID}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["FabricID"]));
                            if (Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["ProductCode"]) != "")
                            {
                                string[] str = Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["ProductCode"]).Split('-');
                                if (str.Length > 0)
                                {
                                    if (ProductCode == "")
                                        ProductCode = str[0] + "-" + str[1] + "-" + str[2] + "-" + str[4] + "-" + str[5];
                                    if (ProductCode1 == "")
                                        ProductCode1 = str[3];
                                }
                            }

                            str1 = str1.Replace("{ProductCode}", ProductCode);
                            str1 = str1.Replace("{ProductCode1}", ProductCode1);
                            str1 = str1.Replace("{NoofPanels}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["NoofPanel"]));
                            str1 = str1.Replace("{Length}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["Length"]));
                            str1 = str1.Replace("{JumboRollNo}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["JumboRollNo"]));
                            str1 = str1.Replace("{Barcode}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["JumboRollNo"]));
                            str1 = str1.Replace("{Len}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["JumboRollNo"]).Length.ToString());
                            networkClient.Write(str1);
                        }
                    }
                }
                if (cmbProcess.SelectedValue.ToString() == "KNITTING")
                {
                    for (int index = 0; index < this.dvgMasterDeatils.SelectedItems.Count; ++index)
                    {
                        ENTITY_LAYER.Transaction.Transaction.Type = Type;
                        ENTITY_LAYER.Transaction.Transaction.Process = cmbProcess.SelectedValue.ToString();
                        ENTITY_LAYER.Transaction.Transaction.Values = cmbValues.SelectedValue.ToString();
                        ENTITY_LAYER.Transaction.Transaction.BarcodeValue = Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["JumboRollNo"]);
                        CommonVariable.Result = obj_Trans.BL_ReprintTransaction();
                        if (CommonVariable.Result == "Saved")
                        {
                            string str1 = dataSet.Tables[1].Rows[0]["PRNFile"].ToString();
                            string ProductCode = "", ProductCode1 = "";
                            str1 = str1.Replace("{Date}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["Date"]));
                            str1 = str1.Replace("{Shift}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["Time"]));
                            str1 = str1.Replace("{WorkOrderNo}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["WorkOrderNo"]));
                            str1 = str1.Replace("{FabricID}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["FabricID"]));
                            if (Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["ProductCode"]) != "")
                            {
                                string[] str = Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["ProductCode"]).Split('-');
                                if (str.Length > 0)
                                {
                                    if (ProductCode == "")
                                        ProductCode = str[0] + "-" + str[1] + "-" + str[2] + "-" + str[4] + "-" + str[5] + "-";
                                    if (ProductCode1 == "")
                                        ProductCode1 = str[3];
                                }
                            }

                            str1 = str1.Replace("{ProductCode}", ProductCode);
                            str1 = str1.Replace("{ProductCode1}", ProductCode1);
                            str1 = str1.Replace("{NoofPanels}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["NoofPanel"]));
                            str1 = str1.Replace("{Length}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["Length"]));
                            str1 = str1.Replace("{JumboRollNo}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["JumboRollNo"]));
                            str1 = str1.Replace("{Barcode}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["JumboRollNo"]));
                            str1 = str1.Replace("{Len}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["JumboRollNo"]).Length.ToString());
                            networkClient.Write(str1);
                        }
                    }

                }
                if (cmbProcess.SelectedValue.ToString() == "INSPECTION")
                {
                    for (int index = 0; index < this.dvgMasterDeatils.SelectedItems.Count; ++index)
                    {
                        ENTITY_LAYER.Transaction.Transaction.Type = Type;
                        ENTITY_LAYER.Transaction.Transaction.Process = cmbProcess.SelectedValue.ToString();
                        ENTITY_LAYER.Transaction.Transaction.Values = cmbValues.SelectedValue.ToString();
                        ENTITY_LAYER.Transaction.Transaction.BarcodeValue = Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["FGNo"]);
                        CommonVariable.Result = obj_Trans.BL_ReprintTransaction();
                        if (CommonVariable.Result == "Saved")
                        {
                            string str1 = dataSet.Tables[1].Rows[0]["PRNFile"].ToString();
                            str1 = str1.Replace("{Date}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["Date"]));
                            str1 = str1.Replace("{Shift}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["Time"]));
                            str1 = str1.Replace("{WorkOrderNo}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["WorkOrderNo"]));
                            str1 = str1.Replace("{FabricID}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["FabricID"]));
                            str1 = str1.Replace("{ProductCode}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["ProductCode"]));
                            str1 = str1.Replace("{FGNo}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["FGNo"]));
                            str1 = str1.Replace("{Mesh}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["Mesh"]));
                            str1 = str1.Replace("{Colour}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["Color"]));
                            str1 = str1.Replace("{GSM}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["GSM"]));
                            str1 = str1.Replace("{Width}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["Width"]));
                            str1 = str1.Replace("{Length}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["Length"]));
                            if (dataSet.Tables[0].Rows[0]["Remarks"].ToString() == "")
                            {
                                str1 = str1.Replace("Importing Company Name and Address", "");
                            }

                            str1 = str1.Replace("{Remarks}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["Remarks"]));
                            str1 = str1.Replace("{Remarks1}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["Remarks1"]));
                            str1 = str1.Replace("{Remarks2}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["Remarks2"]));
                            str1 = str1.Replace("{Remarks3}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["Remarks3"]));
                            str1 = str1.Replace("{Remarks4}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["Remarks4"]));

                            str1 = str1.Replace("{Barcode}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["FGNo"]));
                            str1 = str1.Replace("{Len}", Convert.ToString(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["FGNo"]).Length.ToString());
                            Thread.Sleep(500);
                            networkClient.Write(str1);
                        }
                    }
                }
                networkClient.Dispose();
            }
        }
    
        
        private void Clear()
        {
            cmbValues.Text = "";
            cmbProcess.Text = "";
            dvgMasterDeatils.ItemsSource = null;
            cmbProcess.Focus();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
                WindowState = WindowState.Maximized;
                Transaction("ProcessDetails");
            }
            catch (Exception ex)
            {
                this.obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "RE-PRINT", CommonVariable.UserID);
                CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonVariable.CustomStriing.Error.ToString());
            }
        }

        private void CmbProcess_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cmbProcess.SelectedIndex > -1)
                {
                    dvgMasterDeatils.ItemsSource = null;
                    Transaction("Values");
                }
            }
            catch (Exception ex)
            {
                this.obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "RE-PRINT", CommonVariable.UserID);
                CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonVariable.CustomStriing.Error.ToString());
            }
        }

        private void CmbValues_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cmbValues.SelectedIndex > -1)
                    Transaction("GetReprintDetails");
            }
            catch (Exception ex)
            {
                this.obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "RE-PRINT", CommonVariable.UserID);
                CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonVariable.CustomStriing.Error.ToString());
            }
        }
    }
}
