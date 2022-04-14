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

namespace RISHI_WIP.Reports.Report
{
    /// <summary>
    /// Interaction logic for Dispatch.xaml
    /// </summary>
    public partial class Transaction : Window
    {
        public Transaction()
        {
            InitializeComponent();
        }
        private BUSINESS_LAYER.LogCreation.LogCreation obj_Log = new BUSINESS_LAYER.LogCreation.LogCreation();
        private BUSINESS_LAYER.Reports.Reports obj_Rpt = new BUSINESS_LAYER.Reports.Reports();

        private void ShowDateTime()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(this.dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e) => this.txtDatetime.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss");

        private void BtnShow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(ControlValidation())
                Transactions("Report");
            }
            catch (Exception ex)
            {
                this.obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "DISPATCH_REPORT", CommonVariable.UserID);
                CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonVariable.CustomStriing.Error.ToString());
            }
        }

        private void Clear()
        {
            txtFGNo.Text = "";
            dtpFrom.Text = "";
            dtpTo.Text = "";
            cmbwrkno.Text = "";
        }
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Clear();
            }
            catch (Exception ex)
            {
                this.obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "DISPATCH_REPORT", CommonVariable.UserID);
                CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonVariable.CustomStriing.Error.ToString());
            }
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
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
                this.obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "DISPATCH_REPORT", CommonVariable.UserID);
                CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonVariable.CustomStriing.Error.ToString());
            }
        }
        private bool ControlValidation()
        {
            bool Falg = false;
            if (dtpFrom.Text != "" && dtpTo.Text != "")
            {
                Falg = true;
                //CommonClasses.CommonMethods.MessageBoxShow("PLEASE SELECT DATE", CommonClasses.CommonVariable.CustomStriing.Information.ToString());
                //return;
            }
            if (cmbwrkno.SelectedIndex > -1 || txtFGNo.Text != "")
            {
                Falg = true;
                //CommonClasses.CommonMethods.MessageBoxShow("PLEASE SELECT TO DATE", CommonClasses.CommonVariable.CustomStriing.Information.ToString());
                //return;
            }
            if(cmbReportType.SelectedIndex==-1)
            {
                CommonClasses.CommonMethods.MessageBoxShow("PLEASE SELECT REPORT TYPE", CommonClasses.CommonVariable.CustomStriing.Information.ToString());
                return false;
            }
            if (Falg == false)
            {
                CommonClasses.CommonMethods.MessageBoxShow("PLEASE SELECT ANY INFORMATION", CommonClasses.CommonVariable.CustomStriing.Information.ToString());
                return false;
            }
            return true;
        }
        private void Transactions(string Type)
        {
            if (Type == "GetProcess")
            {
                ENTITY_LAYER.Reports.Reports.Type = Type;
                DataTable dt = obj_Rpt.BL_ReprintDetails().Tables[0];
                CommonClasses.CommonMethods.FillComboBox(cmbReportType, dt, "ProcessName", "ProcessName");
            }
            if (Type== "GetWorkOrder")
            {
                ENTITY_LAYER.Reports.Reports.Type = Type;
                ENTITY_LAYER.Reports.Reports.ReportType = cmbReportType.SelectedValue.ToString();
                DataTable dt = obj_Rpt.BL_ReprintDetails().Tables[0];
                CommonClasses.CommonMethods.FillComboBox(cmbwrkno, dt, "WorkOrderNo", "WorkOrderNo");
            }
            
            if (Type == "Report")
            {
                if (cmbReportType.SelectedValue.ToString() != "")
                {
                    if (dtpFrom.Text != "" && dtpTo.Text != "")
                    {
                        ENTITY_LAYER.Reports.Reports.FromDate = dtpFrom.SelectedDate.Value.ToString("dd MMM yyyy HH:mm:ss");
                        ENTITY_LAYER.Reports.Reports.Todate = dtpTo.SelectedDate.Value.ToString("dd MMM yyyy HH:mm:ss");
                    }
                    ENTITY_LAYER.Reports.Reports.Type = Type;
                    ENTITY_LAYER.Reports.Reports.WorkOrderNo = cmbwrkno.Text;
                    ENTITY_LAYER.Reports.Reports.Value = txtFGNo.Text;
                    ENTITY_LAYER.Reports.Reports.ReportType = cmbReportType.Text;
                    DataTable dt = obj_Rpt.BL_ReprintDetails().Tables[0];

                    Report.ReportViewer.dtReport = dt;
                    Report.ReportViewer.ReportName = ENTITY_LAYER.Reports.Reports.ReportType;
                    this.Close();
                    Report.ReportViewer obj_page = new Report.ReportViewer();
                    obj_page.ShowDialog();
                }
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
                WindowState = WindowState.Maximized;
                this.ShowDateTime();
                Transactions("GetProcess");
            }
            catch (Exception ex)
            {
                this.obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "DISPATCH_REPORT", CommonVariable.UserID);
                CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonVariable.CustomStriing.Error.ToString());
            }
        }

        private void Cmbwrkno_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cmbwrkno.SelectedIndex > -1)
                    txtFGNo.Text = "";

            }
            catch (Exception ex)
            {
                this.obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "DISPATCH_REPORT", CommonVariable.UserID);
                CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonVariable.CustomStriing.Error.ToString());
            }
        }

        private void CmbReportType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cmbReportType.SelectedIndex > -1)
                    Transactions("GetWorkOrder");


            }
            catch (Exception ex)
            {
                this.obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "DISPATCH_REPORT", CommonVariable.UserID);
                CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonVariable.CustomStriing.Error.ToString());
            }
        }
    }
}
