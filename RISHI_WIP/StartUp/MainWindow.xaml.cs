using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Diagnostics;
using System.Data;
using RISHI_WIP.CommonClasses;
using System.Windows.Threading;
using RISHI_WIP.Masters;

namespace RISHI_WIP.StartUp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private BUSINESS_LAYER.LogCreation.LogCreation obj_Log = new BUSINESS_LAYER.LogCreation.LogCreation();
       

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
                this.txtuserID.Text = "Application is using by " + CommonVariable.UserName;
                this.ShowDateTime();
                // this.WindowState = WindowState.Maximized;

                this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
                WindowState = WindowState.Maximized;
            }
            catch (Exception ex)
            {
                this.obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "MAIN_WINDOW", CommonVariable.UserID);
                CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonVariable.CustomStriing.Error.ToString());
            }
        }

        private void BtnMasters_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.GridSubMenu.Children.RemoveRange(0, 9);
                if (CommonVariable.Rights == "" || CommonVariable.Rights == null)
                {
                    CommonMethods.MessageBoxShow("NO RIGHTS TO ACCESS THE MASTERS", CommonVariable.CustomStriing.Information.ToString());
                }
                else
                {
                    for (int index1 = 0; index1 < this.GridSubMenu.RowDefinitions.Count; ++index1)
                    {
                        int num = 0;
                        if (num != 5)
                        {
                            for (int index2 = 0; index2 < this.GridSubMenu.ColumnDefinitions.Count; ++index2)
                            {
                                if (index2 == 0 && index1 == 0)
                                {
                                    Grid grid = new Grid();
                                    Button button = new Button();
                                    button.Content = (object)"USER MASTER";
                                    button.Style = (Style)null;
                                    button.Style = (Style)this.FindResource((object)"SubMenuButton");
                                    Grid.SetColumn((UIElement)button, index2);
                                    Grid.SetRow((UIElement)button, index1);
                                    this.GridSubMenu.Children.Add((UIElement)button);
                                    ++num;
                                    if (CommonVariable.Rights.Contains("USER MASTER"))
                                    {
                                        button.Click += new RoutedEventHandler(this.UserMaster_Click);
                                    }
                                    else
                                    {
                                        button.Click -= new RoutedEventHandler(this.UserMaster_Click);
                                        button.ToolTip = (object)"Access Denied";
                                    }
                                }
                                if (index2 == 1 && index1 == 0)
                                {
                                    Grid grid = new Grid();
                                    Button button = new Button();
                                    button.Content = (object)"GROUP MASTER";
                                    button.Style = (Style)this.FindResource((object)"SubMenuButton");
                                    Grid.SetColumn((UIElement)button, index2);
                                    Grid.SetRow((UIElement)button, index1);
                                    this.GridSubMenu.Children.Add((UIElement)button);
                                    ++num;
                                    if (CommonVariable.Rights.Contains("GROUP MASTER"))
                                    {
                                        button.Click += new RoutedEventHandler(this.GroupMaster_Click);
                                    }
                                    else
                                    {
                                        button.Click -= new RoutedEventHandler(this.GroupMaster_Click);
                                        button.ToolTip = (object)"Access Denied";
                                    }
                                }
                                //if (index2 == 2 && index1 == 0)
                                //{
                                //    Grid grid = new Grid();
                                //    Button button = new Button();
                                //    button.Content = (object)"PRODUCT MASTER";
                                //    button.Style = (Style)this.FindResource((object)"SubMenuButton");
                                //    Grid.SetColumn((UIElement)button, index2);
                                //    Grid.SetRow((UIElement)button, index1);
                                //    this.GridSubMenu.Children.Add((UIElement)button);
                                //    ++num;
                                //    if (CommonVariable.Rights.Contains("PRODUCT MASTER"))
                                //    {
                                //        button.Click += new RoutedEventHandler(this.ProductMaster_Click);
                                //    }
                                //    else
                                //    {
                                //        button.Click -= new RoutedEventHandler(this.ProductMaster_Click);
                                //        button.ToolTip = (object)"Access Denied";
                                //    }
                                //}
                                if (index2 == 2 && index1 == 0)
                                {
                                    Grid grid = new Grid();
                                    Button button = new Button();
                                    button.Content = (object)"ASSET MASTER";
                                    button.Style = (Style)this.FindResource((object)"SubMenuButton");
                                    Grid.SetColumn((UIElement)button, index2);
                                    Grid.SetRow((UIElement)button, index1);
                                    this.GridSubMenu.Children.Add((UIElement)button);
                                    ++num;
                                    if (CommonVariable.Rights.Contains("ASSET MASTER"))
                                    {
                                        button.Click += new RoutedEventHandler(this.AssetMaster_Click);
                                    }
                                    else
                                    {
                                        button.Click -= new RoutedEventHandler(this.AssetMaster_Click);
                                        button.ToolTip = (object)"Access Denied";
                                    }
                                }
                                if (index2 == 3 && index1 == 0)
                                {
                                    Grid grid = new Grid();
                                    Button button = new Button();
                                    button.Content = (object)"PROCESS MASTER";
                                    button.Style = (Style)this.FindResource((object)"SubMenuButton");
                                    Grid.SetColumn((UIElement)button, index2);
                                    Grid.SetRow((UIElement)button, index1);
                                    this.GridSubMenu.Children.Add((UIElement)button);
                                    ++num;
                                    if (CommonVariable.Rights.Contains("PROCESS MASTER"))
                                    {
                                        button.Click += new RoutedEventHandler(this.ProcessMaster_Click);
                                    }
                                    else
                                    {
                                        button.Click -= new RoutedEventHandler(this.ProcessMaster_Click);
                                        button.ToolTip = (object)"Access Denied";
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "MAIN_WINDOW", CommonVariable.UserID);
                CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonVariable.CustomStriing.Error.ToString());
            }
        }

        private void ProcessMaster_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
                Masters.ProcessMaster obj_page = new Masters.ProcessMaster();
                obj_page.ShowDialog();
              //  this.NavigationService.Navigate((object)new ProcessMaster());
            }
            catch (Exception ex)
            {
                this.obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "MAIN_WINDOW", CommonVariable.UserID);
                CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonVariable.CustomStriing.Error.ToString());
            }
        }

        private void AssetMaster_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
                Masters.AssetMaster obj_page = new Masters.AssetMaster();
                obj_page.ShowDialog();
                //this.NavigationService.Navigate((object)new AssetMaster());
            }
            catch (Exception ex)
            {
                this.obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "MAIN_WINDOW", CommonVariable.UserID);
                CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonVariable.CustomStriing.Error.ToString());
            }
        }

        private void ProductMaster_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
                Masters.ProductMaster obj_page = new Masters.ProductMaster();
                obj_page.ShowDialog();
               // this.NavigationService.Navigate((object)new ProductMaster());
            }
            catch (Exception ex)
            {
                this.obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "MAIN_WINDOW", CommonVariable.UserID);
                CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonVariable.CustomStriing.Error.ToString());
            }
        }

        private void GroupMaster_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
                Masters.GroupMaster obj_page = new Masters.GroupMaster();
                obj_page.ShowDialog();
                //this.NavigationService.Navigate((object)new GroupMaster());
            }
            catch (Exception ex)
            {
                this.obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "MAIN_WINDOW", CommonVariable.UserID);
                CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonVariable.CustomStriing.Error.ToString());
            }
        }

        private void UserMaster_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
                Masters.UserMaster obj_page = new Masters.UserMaster();
                obj_page.ShowDialog();
                //this.NavigationService.Navigate((object)new UserMaster());
            }
            catch (Exception ex)
            {
                this.obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "MAIN_WINDOW", CommonVariable.UserID);
                CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonVariable.CustomStriing.Error.ToString());
            }
        }

        private void BtnTransport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.GridSubMenu.Children.RemoveRange(0, 9);
                if (CommonVariable.Rights == "" || CommonVariable.Rights == null)
                {
                    CommonMethods.MessageBoxShow("NO RIGHTS TO ACCESS THE MASTERS", CommonVariable.CustomStriing.Information.ToString());
                }
                else
                {
                    for (int index1 = 0; index1 < this.GridSubMenu.RowDefinitions.Count; ++index1)
                    {
                        int num = 0;
                        if (num != 5)
                        {
                            for (int index2 = 0; index2 < this.GridSubMenu.ColumnDefinitions.Count; ++index2)
                            {
                                if (index2 == 0 && index1 == 0)
                                {
                                    Grid grid = new Grid();
                                    Button button = new Button();
                                    button.Content = (object)"RE-PRINT";
                                    button.Style = (Style)null;
                                    button.Style = (Style)this.FindResource((object)"SubMenuButton");
                                    Grid.SetColumn((UIElement)button, index2);
                                    Grid.SetRow((UIElement)button, index1);
                                    this.GridSubMenu.Children.Add((UIElement)button);
                                    ++num;
                                    if (CommonVariable.Rights.Contains("RE-PRINT"))
                                    {
                                        button.Click += new RoutedEventHandler(this.Reprint_Click);
                                    }
                                    else
                                    {
                                        button.Click -= new RoutedEventHandler(this.Reprint_Click);
                                        button.ToolTip = (object)"Access Denied";
                                    }
                                }

                                //if (index2 == 1 && index1 == 0)
                                //{
                                //    Grid grid = new Grid();
                                //    Button button = new Button();
                                //    button.Content = (object)"DATA UPLOAD";
                                //    button.Style = (Style)null;
                                //    button.Style = (Style)this.FindResource((object)"SubMenuButton");
                                //    Grid.SetColumn((UIElement)button, index2);
                                //    Grid.SetRow((UIElement)button, index1);
                                //    this.GridSubMenu.Children.Add((UIElement)button);
                                //    ++num;
                                //    if (CommonVariable.Rights.Contains("DATA UPLOAD"))
                                //    {
                                //        button.Click += new RoutedEventHandler(this.Reprint_Click);
                                //    }
                                //    else
                                //    {
                                //        button.Click -= new RoutedEventHandler(this.Reprint_Click);
                                //        button.ToolTip = (object)"Access Denied";
                                //    }
                                //}
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "MAIN_WINDOW", CommonVariable.UserID);
                CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonVariable.CustomStriing.Error.ToString());
            }
        }

        private void Reprint_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
                Transactions.Reprint obj_page = new Transactions.Reprint();
                obj_page.ShowDialog();
               // this.NavigationService.Navigate((object)new Transactions.Reprint());

            }
            catch (Exception ex)
            {
                this.obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "MAIN_WINDOW", CommonVariable.UserID);
                CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonVariable.CustomStriing.Error.ToString());
            }
        }

        private void BtnReport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.GridSubMenu.Children.RemoveRange(0, 9);
                if (CommonVariable.Rights == "" || CommonVariable.Rights == null)
                {
                    CommonMethods.MessageBoxShow("NO RIGHTS TO ACCESS THE MASTERS", CommonVariable.CustomStriing.Information.ToString());
                }
                else
                {
                    for (int index1 = 0; index1 < this.GridSubMenu.RowDefinitions.Count; ++index1)
                    {
                        int num = 0;
                        if (num != 5)
                        {
                            for (int index2 = 0; index2 < this.GridSubMenu.ColumnDefinitions.Count; ++index2)
                            {
                                if (index2 == 0 && index1 == 0)
                                {
                                    Grid grid = new Grid();
                                    Button button = new Button();
                                    button.Content = (object)"TRANSACTION";
                                    button.Style = (Style)null;
                                    button.Style = (Style)this.FindResource((object)"SubMenuButton");
                                    Grid.SetColumn((UIElement)button, index2);
                                    Grid.SetRow((UIElement)button, index1);
                                    this.GridSubMenu.Children.Add((UIElement)button);
                                    ++num;
                                    if (CommonVariable.Rights.Contains("TRANSACTION REPORT"))
                                    {
                                        button.Click += new RoutedEventHandler(this.Dispatch_Click);
                                    }
                                    else
                                    {
                                        button.Click -= new RoutedEventHandler(this.Dispatch_Click);
                                        button.ToolTip = (object)"Access Denied";
                                    }
                                }
                                if (index2 == 1 && index1 == 0)
                                {
                                    Grid grid = new Grid();
                                    Button button = new Button();
                                    button.Content = (object)"FG-STOCK";
                                    button.Style = (Style)null;
                                    button.Style = (Style)this.FindResource((object)"SubMenuButton");
                                    Grid.SetColumn((UIElement)button, index2);
                                    Grid.SetRow((UIElement)button, index1);
                                    this.GridSubMenu.Children.Add((UIElement)button);
                                    ++num;
                                    if (CommonVariable.Rights.Contains("FG-STOCK REPORT"))
                                    {
                                        button.Click += new RoutedEventHandler(this.FgStock_Click);
                                    }
                                    else
                                    {
                                        button.Click -= new RoutedEventHandler(this.FgStock_Click);
                                        button.ToolTip = (object)"Access Denied";
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "MAIN_WINDOW", CommonVariable.UserID);
                CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonVariable.CustomStriing.Error.ToString());
            }
        }

        private void Dispatch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
                Reports.Report.Transaction obj_page = new Reports.Report.Transaction();
                obj_page.ShowDialog();
               // this.NavigationService.Navigate((object)new Reports.Report.Transaction());

            }
            catch (Exception ex)
            {
                this.obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "MAIN_WINDOW", CommonVariable.UserID);
                CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonVariable.CustomStriing.Error.ToString());
            }
        }

        private void FgStock_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
                Reports.Report.FG_Stock obj_page = new Reports.Report.FG_Stock();
                obj_page.ShowDialog();
                //this.NavigationService.Navigate((object)new Reports.Report.FG_Stock());

            }
            catch (Exception ex)
            {
                this.obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "MAIN_WINDOW", CommonVariable.UserID);
                CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonVariable.CustomStriing.Error.ToString());
            }
        }
    }
}
