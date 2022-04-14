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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RISHI_WIP.Transactions
{
    /// <summary>
    /// Interaction logic for DataUpload.xaml
    /// </summary>
    public partial class DataUpload : Window
    {
        public DataUpload()
        {
            InitializeComponent();
        }
        private BUSINESS_LAYER.LogCreation.LogCreation obj_Log = new BUSINESS_LAYER.LogCreation.LogCreation();

        private void LinkTemplate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                SaveFileDialog obj_SD = new SaveFileDialog();
                obj_SD.Filter = "Excel files (*.xlsx)|*.xlsx|Excel files(*.xls)|*.xls";
                obj_SD.ShowDialog();
                if (obj_SD.FileName != "")
                {
                    //                  [YarnID],[Dofflength],[DoffNo],[YarnDiameter],[Denier],[Noofbobbins],[YarnColour],
                    //[BatchNo],[Tareweight],[TotalTrolleyWeight],[Netweightofyarn],[MachineBarcode],[TrolleyBarcode],BobbinBarcode,[CreatedBY],[CreatedOn],[UsedBobbins]
                    //                  if(cmbProcess.SelectedIndex==0)
                    //                  {
                    //                      dt.Columns.Add("YarnID");
                    //                      dt.Columns.Add("Dofflength");
                    //                      dt.Columns.Add("DoffNo");
                    //                      dt.Columns.Add("YarnDiameter");

                    //                      dt.Columns.Add("Denier");
                    //                      dt.Columns.Add("Noofbobbins");
                    //                      dt.Columns.Add("YarnColour");
                    //                      dt.Columns.Add("BatchNo");

                    //                      dt.Columns.Add("TotalTrolleyWeight");
                    //                      dt.Columns.Add("MachineNo");
                    //                      dt.Columns.Add("TrolleyBarcode");

                    //                  }

                    //                  if (cmbProcess.SelectedIndex == 1)
                    //                  {
                    //                      dt.Columns.Add("SL_NO");
                    //                      dt.Columns.Add("TR_PART_NUMBER");
                    //                      dt.Columns.Add("TOTAL_QTY");
                    //                      dt.Columns.Add("LABEL_TYPE");
                    //                  }

                    //                  if (cmbProcess.SelectedIndex == 2)
                    //                  {
                    //                      dt.Columns.Add("SL_NO");
                    //                      dt.Columns.Add("TR_PART_NUMBER");
                    //                      dt.Columns.Add("TOTAL_QTY");
                    //                      dt.Columns.Add("LABEL_TYPE");
                    //                  }
                    //                  if (cmbProcess.SelectedIndex == 3)
                    //                  {
                    //                      dt.Columns.Add("SL_NO");
                    //                      dt.Columns.Add("TR_PART_NUMBER");
                    //                      dt.Columns.Add("TOTAL_QTY");
                    //                      dt.Columns.Add("LABEL_TYPE");
                    //                  }
                    //                  if (cmbProcess.SelectedIndex == 4)
                    //                  {
                    //                      dt.Columns.Add("SL_NO");
                    //                      dt.Columns.Add("TR_PART_NUMBER");
                    //                      dt.Columns.Add("TOTAL_QTY");
                    //                      dt.Columns.Add("LABEL_TYPE");
                    //                  }
                    //                  CommonClasses.CommonMethods.CreateExcellFile(dt, obj_SD.FileName, "UploadData");
                    //                  CommonMethods.MessageBoxShow("TEMPLATE CREATED SUCCESSFULLY", CommonVariable.CustomStriing.Successfull.ToString());
                    //              }
                }
            }
            catch (Exception ex)
            {
                obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "KANBAN_PRINT", CommonClasses.CommonVariable.UserID);
                CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonVariable.CustomStriing.Error.ToString());
            }

        }

        private void BtnReprint_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnBrowse_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
