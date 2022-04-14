using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Data;
using System.Reflection;
using SAPBusinessObjects.WPF.Viewer;

namespace RISHI_WIP.Reports.Report
{
    /// <summary>
    /// Interaction logic for ReportViewer.xaml
    /// </summary>
    public partial class ReportViewer : Window
    {
        #region Variables and Objects
        BUSINESS_LAYER.LogCreation.LogCreation obj_Log = new BUSINESS_LAYER.LogCreation.LogCreation();
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();

        public static DataTable dtReport = new DataTable();
        public static string ReportName = "";
        //[DllImport("Winspool.drv")]
        //private static extern bool SetDefaultPrinter(string printerName);
        //ReportDocument Doc = new ReportDocument();
        #endregion
        public ReportViewer()
        {
            InitializeComponent();
        }
        private void ShowDateTime()
        {
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            txtDatetime.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss");
        }
        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                
                dispatcherTimer.Stop();
            }
            catch (Exception ex)
            {
                obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "REPORT_VIEWER", CommonClasses.CommonVariable.UserID);
                CommonClasses.CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonClasses.CommonVariable.CustomStriing.Error.ToString());
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
                WindowState = WindowState.Maximized;
                switch (ReportName)
                {

                    case "DISPATCH":
                        Reports.CrystallReports.Dispatch objDispatch = new CrystallReports.Dispatch(); ;
                        objDispatch.SetDataSource(dtReport);
                        crystalReportsViewer1.ViewerCore.ReportSource = objDispatch;
                        crystalReportsViewer1.ToggleSidePanel = Constants.SidePanelKind.None;
                        break;
                    case "FGStockReport":
                        Reports.CrystallReports.FG_Stock objFG_Stock = new CrystallReports.FG_Stock(); ;
                        objFG_Stock.SetDataSource(dtReport);
                        crystalReportsViewer1.ViewerCore.ReportSource = objFG_Stock;
                        crystalReportsViewer1.ToggleSidePanel = Constants.SidePanelKind.None;
                        break;
                    case "EXTRUSION":
                        Reports.CrystallReports.EXTRUSION objEXTRUSION = new CrystallReports.EXTRUSION(); ;
                        objEXTRUSION.SetDataSource(dtReport);
                        crystalReportsViewer1.ViewerCore.ReportSource = objEXTRUSION;
                        crystalReportsViewer1.ToggleSidePanel = Constants.SidePanelKind.None;
                        break;
                    case "INSPECTION":
                        Reports.CrystallReports.INSPECTION objINSPECTION = new CrystallReports.INSPECTION(); ;
                        objINSPECTION.SetDataSource(dtReport);
                        crystalReportsViewer1.ViewerCore.ReportSource = objINSPECTION;
                        crystalReportsViewer1.ToggleSidePanel = Constants.SidePanelKind.None;
                        break;
                    case "KNITTING":
                        Reports.CrystallReports.KNITTING objKNITTING = new CrystallReports.KNITTING(); ;
                        objKNITTING.SetDataSource(dtReport);
                        crystalReportsViewer1.ViewerCore.ReportSource = objKNITTING;
                        crystalReportsViewer1.ToggleSidePanel = Constants.SidePanelKind.None;
                        break;
                    case "WARPING":
                        Reports.CrystallReports.WARPING objWARPING = new CrystallReports.WARPING(); ;
                        objWARPING.SetDataSource(dtReport);
                        crystalReportsViewer1.ViewerCore.ReportSource = objWARPING;
                        crystalReportsViewer1.ToggleSidePanel = Constants.SidePanelKind.None;
                        break;
                    case "WEAVING":
                        Reports.CrystallReports.WEAVING objWEAVING = new CrystallReports.WEAVING(); ;
                        objWEAVING.SetDataSource(dtReport);
                        crystalReportsViewer1.ViewerCore.ReportSource = objWEAVING;
                        crystalReportsViewer1.ToggleSidePanel = Constants.SidePanelKind.None;
                        break;

                }
            }
            catch (Exception ex)
            {
                obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "REPORT_VIEWER", CommonClasses.CommonVariable.UserID);
                CommonClasses.CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonClasses.CommonVariable.CustomStriing.Error.ToString());

            }
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
                StartUp.MainWindow obj_page = new StartUp.MainWindow();
                obj_page.ShowDialog();
                //   NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "REPORT_VIEWER", CommonClasses.CommonVariable.UserID);
                CommonClasses.CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonClasses.CommonVariable.CustomStriing.Error.ToString());
            }
        }
        private void ImgSmily3_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.Close();
                StartUp.MainWindow obj_page = new StartUp.MainWindow();
                obj_page.ShowDialog();
                //NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "REPORT_VIEWER", CommonClasses.CommonVariable.UserID);
                CommonClasses.CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonClasses.CommonVariable.CustomStriing.Error.ToString());
            }
        }
    }
}
