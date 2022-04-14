using RISHI_WIP.CommonClasses;
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
    /// Interaction logic for ProductMaster.xaml
    /// </summary>
    public partial class ProductMaster : Window
    {
        public ProductMaster()
        {
            InitializeComponent();
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

        private void dispatcherTimer_Tick(object sender, EventArgs e) => this.txtDatetime.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss");

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
                WindowState = WindowState.Maximized;
                this.ShowDateTime();
                this.txtPrdCode.Focus();
                this.Transaction("LoadDetails");
            }
            catch (Exception ex)
            {
                this.obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "PRODUCT_MASTER", CommonVariable.UserID);
                CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonVariable.CustomStriing.Error.ToString());
            }
        }

        private bool ControlValidation()
        {
            if (this.txtPrdCode.Text == "")
            {
                CommonMethods.MessageBoxShow("PLEASE ENTER PRODUCT CODE", CommonVariable.CustomStriing.Information.ToString());
                this.txtPrdCode.Focus();
                return false;
            }
            if (this.txtPrdname.Text == "")
            {
                CommonMethods.MessageBoxShow("PLEASE ENTER PRODUCT NAME", CommonVariable.CustomStriing.Information.ToString());
                this.txtPrdname.Focus();
                return false;
            }
            if (this.txtDescription.Text == "")
            {
                CommonMethods.MessageBoxShow("PLEASE ENTER DESCRIPTION", CommonVariable.CustomStriing.Information.ToString());
                this.txtDescription.Focus();
                return false;
            }
            if (!(this.txtcategory.Text == ""))
                return true;
            CommonMethods.MessageBoxShow("PLEASE ENTER CATEGORY", CommonVariable.CustomStriing.Information.ToString());
            this.txtcategory.Focus();
            return false;
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
                this.obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "PRODUCT_MASTER", CommonVariable.UserID);
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
                this.obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "PRODUCT_MASTER", CommonVariable.UserID);
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
                this.obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "PRODUCT_MASTER", CommonVariable.UserID);
                CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonVariable.CustomStriing.Error.ToString());
            }
        }

        private void Clear()
        {
            this.txtPrdCode.Text = "";
            this.txtPrdname.Text = "";
            this.txtcategory.Text = "";
            this.txtDescription.Text = "";
            this.txtPrdCode.Focus();
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
                this.obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "PRODUCT_MASTER", CommonVariable.UserID);
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
                ENTITY_LAYER.Masters.Masters.ProductCode = this.txtPrdCode.Text;
                ENTITY_LAYER.Masters.Masters.Productname = this.txtPrdname.Text;
                ENTITY_LAYER.Masters.Masters.Description = this.txtDescription.Text;
                ENTITY_LAYER.Masters.Masters.Category = this.txtcategory.Text;
                bool? isChecked = this.chkStatus.IsChecked;
                bool flag = true;
                ENTITY_LAYER.Masters.Masters.Status = !(isChecked.GetValueOrDefault() == flag & isChecked.HasValue) ? CommonVariable.InActive : CommonVariable.Active;
                ENTITY_LAYER.Masters.Masters.RefNo = this.RefNo;
                ENTITY_LAYER.Masters.Masters.Type = Type;
                CommonVariable.Result = this.obj_Mast.BL_ProductMasterTransaction();
                if (CommonVariable.Result == "Saved")
                {
                    CommonMethods.MessageBoxShow(CommonVariable.DataSaved, CommonVariable.CustomStriing.Successfull.ToString());
                    this.Clear();
                }
                else if (CommonVariable.Result == "Updated")
                {
                    CommonMethods.MessageBoxShow(CommonVariable.DataUpdated, CommonVariable.CustomStriing.Successfull.ToString());
                    this.Clear();
                }
                else if (CommonVariable.Result == "Duplicate")
                    CommonMethods.MessageBoxShow(CommonVariable.Duplicate, CommonVariable.CustomStriing.Information.ToString());
                else if (CommonVariable.Result != "Deleted")
                    CommonMethods.MessageBoxShow(CommonVariable.Result, CommonVariable.CustomStriing.Information.ToString());
            }
            if (!(Type == "LoadDetails"))
                return;
            ENTITY_LAYER.Masters.Masters.Type = Type;
            this.dvgMasterDeatils.ItemsSource = this.obj_Mast.BL_ProductMasterDetails().Tables[0].DefaultView;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
                StartUp.MainWindow obj_page = new StartUp.MainWindow();
                obj_page.ShowDialog();
                //this.NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                this.obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "PRODUCT_MASTER", CommonVariable.UserID);
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
                    this.txtPrdCode.Text = selectedItem["ProductCode"].ToString();
                    this.txtPrdname.Text = selectedItem["ProductName"].ToString();
                    this.txtDescription.Text = selectedItem["Description"].ToString();
                    this.txtcategory.Text = selectedItem["Category"].ToString();
                    if (CommonVariable.Active == selectedItem["Status"].ToString())
                        this.chkStatus.IsChecked = new bool?(true);
                    else
                        this.chkStatus.IsChecked = new bool?(false);
                }
                else
                {
                    this.RefNo = 0;
                    this.txtPrdCode.Text = "";
                    this.txtPrdname.Text = "";
                    this.txtDescription.Text = "";
                    this.txtcategory.Text = "";
                    this.txtPrdCode.Focus();
                }
            }
            catch (Exception ex)
            {
                this.obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "PRODUCT_MASTER", CommonVariable.UserID);
                CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonVariable.CustomStriing.Error.ToString());
            }
        }

    }
}
