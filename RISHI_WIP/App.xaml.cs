using RISHI_WIP.CommonClasses;
using RISHI_WIP.StartUp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace RISHI_WIP
{ 
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private BUSINESS_LAYER.LogCreation.LogCreation obj_Log = new BUSINESS_LAYER.LogCreation.LogCreation();

        private void StartUP(object sender, StartupEventArgs e)
        {
            try
            {
               // Thread.Sleep()

               // System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory + "\\ApplicationDownload.exe");
                //System.Diagnostics.Process.GetCurrentProcess().Kill();


                if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Log"))
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\Log");
                string str = ConfigurationManager.AppSettings["ConnectionString"].ToString();
                if (str != "")
                {
                    string[] strArray = str.Split(',');
                    if ((uint)strArray.Length > 0U)
                    {
                        ENTITY_LAYER.DatabaseSettings.DatabaseSettings.SqldbServer = strArray[0].ToString();
                        ENTITY_LAYER.DatabaseSettings.DatabaseSettings.SqlDBUserID = strArray[1].ToString();
                        ENTITY_LAYER.DatabaseSettings.DatabaseSettings.SqlDBPassword = strArray[2].ToString();
                        ENTITY_LAYER.DatabaseSettings.DatabaseSettings.SqlDBName = strArray[3].ToString();
                        CommonVariable.obj_Login = new Login();
                        CommonVariable.obj_Login.ShowDialog();
                      //  Application.Current.MainWindow.Content = (object)CommonVariable.obj_Login;
                    }
                    else
                        CommonMethods.MessageBoxShow("INCORRECT DATABASE SETTING!!", CommonVariable.CustomStriing.Information.ToString());
                }
               
            }
            catch (Exception ex)
            {
                this.obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "MAINWINDOW", CommonVariable.UserID);
                CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonVariable.CustomStriing.Error.ToString());
            }
        }

        private void Grid_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Process.GetProcessesByName("RISHI_WIP")[0].Kill();
            }
            catch (Exception ex)
            {
                this.obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "MAINWINDOW", CommonVariable.UserID);
                CommonClasses.CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonVariable.CustomStriing.Error.ToString());
            }
        }
    }
}
