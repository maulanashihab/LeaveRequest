using LeaveRequest.Controllers;
using LeaveRequest.ViewModels;
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
using System.Windows.Shapes;

namespace LeaveRequest
{
    /// <summary>
    /// Interaction logic for Approval.xaml
    /// </summary>
    public partial class Approval : Window
    {
        HolidaysController holidayController = new HolidaysController();
        ParametersController parameterController = new ParametersController();
        UsersController userController = new UsersController();
        RolesController roleController = new RolesController();
        EmployeesController employeeController = new EmployeesController();
        EmployeeStatusesController employeeStatusesController = new EmployeeStatusesController();
        LeaveCategoriesController leaveCategoryController = new LeaveCategoriesController();
        LeaveRequestController leaveRequestController = new LeaveRequestController();
        public Approval()
        {
            InitializeComponent();
            LoadGrid();
            LoadCombo();
        }
        public void LoadGrid()
        {
            lrapprovedtGrid.ItemsSource = leaveRequestController.Get();
        }

        public void LoadCombo()
        {
            employeecmb.ItemsSource = employeeController.Get();
            categorycmb.ItemsSource = leaveCategoryController.Get();
        }

        private void lrapprovedtGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = lrapprovedtGrid.SelectedItem;
            try
            {
                idleavetxtBox.Text = (lrapprovedtGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                fromdateleave.Text = (lrapprovedtGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                todateleave.Text = (lrapprovedtGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                reasonleavetxtBox.Text = (lrapprovedtGrid.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                approvecomment.Text = (lrapprovedtGrid.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                statusleavetxt.Text = (lrapprovedtGrid.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
                employeecmb.Text = (lrapprovedtGrid.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text;
                categorycmb.Text = (lrapprovedtGrid.SelectedCells[7].Column.GetCellContent(item) as TextBlock).Text;
            }
            catch (Exception ex)
            {

            }
        }

        private void approvebtn_Click(object sender, RoutedEventArgs e)
        {
            var push = new LeaveRequestVM(fromdateleave.SelectedDate, todateleave.SelectedDate, reasonleavetxtBox.Text,approvecomment.Text,
                                           "Approved", Convert.ToInt32(employeecmb.SelectedValue), Convert.ToInt32(categorycmb.SelectedValue));
            MessageBoxResult messageBox = System.Windows.MessageBox.Show("Are U Sure?", "Approved Box", System.Windows.MessageBoxButton.YesNo);
            if (messageBox == MessageBoxResult.Yes)
            {
                var result = leaveRequestController.Update(Convert.ToInt32(idleavetxtBox.Text), push);
                if (result)
                {
                    MessageBox.Show("Leave Request Approved");
                    LoadGrid();
                }
                else
                {
                    MessageBox.Show("Leave Request Canceled");
                }
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }

        private void declinebtn_Click(object sender, RoutedEventArgs e)
        {
            var push = new LeaveRequestVM(fromdateleave.SelectedDate, todateleave.SelectedDate, reasonleavetxtBox.Text, approvecomment.Text,
                                          "Decline", Convert.ToInt32(employeecmb.SelectedValue), Convert.ToInt32(categorycmb.SelectedValue));
            MessageBoxResult messageBox = System.Windows.MessageBox.Show("Are U Sure?", "Decline Box", System.Windows.MessageBoxButton.YesNo);
            if (messageBox == MessageBoxResult.Yes)
            {
                var result = leaveRequestController.Update(Convert.ToInt32(idleavetxtBox.Text), push);
                if (result)
                {
                    MessageBox.Show("Leave Request Decline");
                    LoadGrid();
                }
                else
                {
                    MessageBox.Show("Leave Request Canceled");
                }
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }
        public void Cleaning()
        {
            idleavetxtBox.Text = "";
            fromdateleave.Text = "";
            todateleave.Text = "";
            reasonleavetxtBox.Text = "";
            statusleavetxt.Text = "";
         
            approvecomment.Text = "";
        }

        
    }
}
