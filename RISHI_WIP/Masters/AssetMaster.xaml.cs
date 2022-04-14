using RISHI_WIP.CommonClasses;
using SATOPrinterAPI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
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
using System.Windows.Threading;

namespace RISHI_WIP.Masters
{
    /// <summary>
    /// Interaction logic for AssetMaster.xaml
    /// </summary>
    public partial class AssetMaster : Window
    {
        public AssetMaster()
        {
            InitializeComponent(); //test
        }
        private BUSINESS_LAYER.LogCreation.LogCreation obj_Log = new BUSINESS_LAYER.LogCreation.LogCreation();
        private BUSINESS_LAYER.Masters.Masters obj_Mast = new BUSINESS_LAYER.Masters.Masters();
        private int RefNo = 0;
     

        private void ShowDateTime()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(this.dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private bool ControlValidation()
        {
            if (this.CmbAssetType.SelectedIndex == -1)
            {
                CommonMethods.MessageBoxShow("PLEASE SELECT ASSET TYPE", CommonVariable.CustomStriing.Information.ToString());
                this.CmbAssetType.Focus();
                return false;
            }
            if (this.CmbProcess.SelectedIndex == -1)
            {
                CommonMethods.MessageBoxShow("PLEASE SELECT PROCESS", CommonVariable.CustomStriing.Information.ToString());
                this.CmbProcess.Focus();
                return false;
            }
            if (this.txtAssetName.Text == "")
            {
                CommonMethods.MessageBoxShow("PLEASE ENTER ASSET NAME", CommonVariable.CustomStriing.Information.ToString());
                this.txtAssetName.Focus();
                return false;
            }
            if (this.txtSerialnO.Text == "")
            {
                CommonMethods.MessageBoxShow("PLEASE ENTER SERIAL NO", CommonVariable.CustomStriing.Information.ToString());
                this.txtSerialnO.Focus();
                return false;
            }
            if (!(this.txtTareWeight.Text == ""))
                return true;
            CommonMethods.MessageBoxShow("PLEASE ENTER TARE WEIGHT", CommonVariable.CustomStriing.Information.ToString());
            this.txtTareWeight.Focus();
            return false;
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e) => this.txtDatetime.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss");

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.ShowDateTime();
                this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
                WindowState = WindowState.Maximized;
                this.CmbAssetType.Focus();
                this.Transaction("LoadDetails");
                Transaction("GetProcessName");
            }
            catch (Exception ex)
            {
                this.obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "ASSET_MASTER", CommonVariable.UserID);
                CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonVariable.CustomStriing.Error.ToString());
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.dvgMasterDeatils.SelectedItems.Count == 0)
                {
                    if (!this.ControlValidation())
                        return;
                    this.Transaction("Save");
                }
                else
                    CommonMethods.MessageBoxShow("YOU CAN NOT SAVE THE RECORDS PLEASE GO FOR DELETION OR UPDATION", CommonVariable.CustomStriing.Information.ToString());
            }
            catch (Exception ex)
            {
                this.obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "ASSET_MASTER", CommonVariable.UserID);
                CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonVariable.CustomStriing.Error.ToString());
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.dvgMasterDeatils.SelectedItems.Count > 0)
                {
                    if (this.dvgMasterDeatils.SelectedItems.Count == 1)
                    {
                        if (!this.ControlValidation())
                            return;
                        this.Transaction("Update");
                    }
                    else
                        CommonMethods.MessageBoxShow("MULTIPLE SELECTION WILL NOT SUPPORT FOR UPDATE", CommonVariable.CustomStriing.Information.ToString());
                }
                else
                    CommonMethods.MessageBoxShow(CommonVariable.RowSelection, CommonVariable.CustomStriing.Information.ToString());
            }
            catch (Exception ex)
            {
                this.obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "ASSET_MASTER", CommonVariable.UserID);
                CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonVariable.CustomStriing.Error.ToString());
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.dvgMasterDeatils.SelectedItems.Count > 0)
                {
                    CommonMethods.MessageBoxShow(CommonVariable.DeleteConfirm, CommonVariable.CustomStriing.Question.ToString());
                    if (!(CommonVariable.Result == "YES"))
                        return;
                    for (int index = 0; index < this.dvgMasterDeatils.SelectedItems.Count; ++index)
                    {
                        this.RefNo = Convert.ToInt32(((DataRowView)this.dvgMasterDeatils.SelectedItems[index])["RefNo"]);
                        this.Transaction("Delete");
                    }
                    if (CommonVariable.Result == "Deleted")
                    {
                        CommonMethods.MessageBoxShow(CommonVariable.DataDeleted, CommonVariable.CustomStriing.Successfull.ToString());
                        this.Clear();
                    }
                    else
                        CommonMethods.MessageBoxShow(CommonVariable.Result, CommonVariable.CustomStriing.Information.ToString());
                }
                else
                    CommonMethods.MessageBoxShow(CommonVariable.RowSelection, CommonVariable.CustomStriing.Information.ToString());
            }
            catch (Exception ex)
            {
                this.obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "ASSET_MASTER", CommonVariable.UserID);
                CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonVariable.CustomStriing.Error.ToString());
            }
        }

        private void Clear()
        {
            this.txtAssetName.Text = "";
            this.txtSerialnO.Text = "";
            this.txtTareWeight.Text = "0";
            this.CmbAssetType.Text = "";
            CmbProcess.Text = "";
            this.CmbAssetType.Focus();
            this.chkStatus.IsChecked = new bool?(false);
            this.Transaction("LoadDetails");
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Clear();
            }
            catch (Exception ex)
            {
                this.obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "ASSET_MASTER", CommonVariable.UserID);
                CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonVariable.CustomStriing.Error.ToString());
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.S) || Keyboard.IsKeyDown(Key.RightAlt) && Keyboard.IsKeyDown(Key.S))
                this.btnSave_Click(sender, (RoutedEventArgs)e);
            if (Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.U) || Keyboard.IsKeyDown(Key.RightAlt) && Keyboard.IsKeyDown(Key.U))
                this.btnUpdate_Click(sender, (RoutedEventArgs)e);
            if (Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.C) || Keyboard.IsKeyDown(Key.RightAlt) && Keyboard.IsKeyDown(Key.C))
                this.btnClear_Click(sender, (RoutedEventArgs)e);
            if (Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.B) || Keyboard.IsKeyDown(Key.RightAlt) && Keyboard.IsKeyDown(Key.B) || Keyboard.IsKeyDown(Key.Escape) && Keyboard.IsKeyDown(Key.Escape))
                this.btnExit_Click(sender, (RoutedEventArgs)e);
            if ((!Keyboard.IsKeyDown(Key.LeftAlt) || !Keyboard.IsKeyDown(Key.D)) && (!Keyboard.IsKeyDown(Key.RightAlt) || !Keyboard.IsKeyDown(Key.D)))
                return;
            this.btnDelete_Click(sender, (RoutedEventArgs)e);
        }

        private void Transaction(string Type)
        {
            if (Type == "Save" || Type == "Update" || Type == "Delete")
            {
                ENTITY_LAYER.Masters.Masters.Assetname = this.txtAssetName.Text;
                ENTITY_LAYER.Masters.Masters.AssetType = this.CmbAssetType.Text;
                ENTITY_LAYER.Masters.Masters.Serialno = this.txtSerialnO.Text;
                ENTITY_LAYER.Masters.Masters.Processname = this.CmbProcess.Text;
                bool? isChecked = this.chkStatus.IsChecked;
                bool flag = true;
                ENTITY_LAYER.Masters.Masters.Status = !(isChecked.GetValueOrDefault() == flag & isChecked.HasValue) ? CommonVariable.InActive : CommonVariable.Active;
                ENTITY_LAYER.Masters.Masters.RefNo = this.RefNo;
                ENTITY_LAYER.Masters.Masters.Type = Type;
                ENTITY_LAYER.Masters.Masters.TareWeight = this.txtTareWeight.Text;
                ENTITY_LAYER.Masters.Masters.AssetBarcode = this.txtAssetName.Text + "|" + this.txtSerialnO.Text + "|" + this.txtTareWeight.Text;
                CommonVariable.Result = this.obj_Mast.BL_AssetMasterTransaction();
                if (CommonVariable.Result.Contains("Saved"))
                {
                    if (this.CmbAssetType.Text != "Bobbins")
                    {
                        string[] strArray = CommonVariable.Result.Split('|');
                        Driver driver = new Driver();
                        string Data = strArray[2].ToString().Replace("{ASSETNAME}", this.txtAssetName.Text).Replace("{Barcode}", ENTITY_LAYER.Masters.Masters.AssetBarcode).Replace("{Len}", ENTITY_LAYER.Masters.Masters.AssetBarcode.Length.ToString());
                        driver.SendRawData(strArray[1], Data);
                    }
                    CommonMethods.MessageBoxShow(CommonVariable.DataSaved, CommonVariable.CustomStriing.Successfull.ToString());
                    this.Clear();
                }
                else if (CommonVariable.Result.Contains("Updated"))
                {
                    if (this.CmbAssetType.Text != "Bobbins")
                    {
                        string[] strArray = CommonVariable.Result.Split('|');
                        Driver driver = new Driver();
                        string Data = strArray[2].ToString().Replace("{ASSETNAME}", this.txtAssetName.Text).Replace("{Barcode}", ENTITY_LAYER.Masters.Masters.AssetBarcode).Replace("{Len}", ENTITY_LAYER.Masters.Masters.AssetBarcode.Length.ToString());
                        driver.SendRawData(strArray[1], Data);
                    }
                    CommonMethods.MessageBoxShow(CommonVariable.DataUpdated, CommonVariable.CustomStriing.Successfull.ToString());
                    this.Clear();
                }
                else if (CommonVariable.Result == "Duplicate")
                    CommonMethods.MessageBoxShow(CommonVariable.Duplicate, CommonVariable.CustomStriing.Information.ToString());
                else if (CommonVariable.Result != "Deleted")
                    CommonMethods.MessageBoxShow(CommonVariable.Result, CommonVariable.CustomStriing.Information.ToString());
            }
            if (Type == "LoadDetails")
            {
                ENTITY_LAYER.Masters.Masters.Type = Type;
                this.dvgMasterDeatils.ItemsSource = obj_Mast.BL_AssetMasterDetails().Tables[0].DefaultView;
            }
            if (Type == "GetProcessName")
            {
                ENTITY_LAYER.Masters.Masters.Type = Type;
                
                CommonClasses.CommonMethods.FillComboBox(CmbProcess, obj_Mast.BL_AssetMasterDetails().Tables[0], "ProcessName", "ProcessName");
}
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //StartUp.lo
                //this.NavigationService.GoBack();
                this.Close();
                StartUp.MainWindow obj_page = new StartUp.MainWindow();
                obj_page.ShowDialog();
               // System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            catch (Exception ex)
            {
                this.obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "ASSET_MASTER", CommonVariable.UserID);
                CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonVariable.CustomStriing.Error.ToString());
            }
        }

        private void dvgMasterDeatils_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (this.dvgMasterDeatils.SelectedItems.Count == 1)
                {
                    DataRowView selectedItem = (DataRowView)this.dvgMasterDeatils.SelectedItems[0];
                    this.RefNo = Convert.ToInt32(selectedItem["RefNo"]);
                    this.txtAssetName.Text = selectedItem["AssetName"].ToString();
                    this.txtSerialnO.Text = selectedItem["SerialNo"].ToString();
                    this.CmbAssetType.Text = selectedItem["AssetType"].ToString();
                    this.txtTareWeight.Text = selectedItem["TareWeight"].ToString();
                    this.CmbProcess.Text = selectedItem["Process"].ToString();
                    if (CommonVariable.Active == selectedItem["Status"].ToString())
                        this.chkStatus.IsChecked = new bool?(true);
                    else
                        this.chkStatus.IsChecked = new bool?(false);
                }
                else
                {
                    this.RefNo = 0;
                    this.txtAssetName.Text = "";
                    this.txtSerialnO.Text = "";
                    this.txtAssetName.Focus();
                }
            }
            catch (Exception ex)
            {
                this.obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "ASSET_MASTER", CommonVariable.UserID);
                CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonVariable.CustomStriing.Error.ToString());
            }
        }

        private void CmbAssetType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (this.CmbAssetType.SelectedIndex <= -1)
                    return;
                if (this.CmbAssetType.SelectedItem.ToString().Split(':')[1].Trim() == "Machine")
                {
                    this.txtTareWeight.IsReadOnly = true;
                    this.txtTareWeight.Text = "0";
                }
                else
                {
                    this.txtTareWeight.IsReadOnly = false;
                    this.txtTareWeight.Text = "0";
                }
            }
            catch (Exception ex)
            {
                this.obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "ASSET_MASTER", CommonVariable.UserID);
                CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonVariable.CustomStriing.Error.ToString());
            }
        }

    }
}