using LeaveRequest.Controllers;
using LeaveRequest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace LeaveRequest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmployeeStatusesController employeeStatusesController = new EmployeeStatusesController();
        LeaveCategoriesController leaveCategoryController = new LeaveCategoriesController();
        LeaveRequestController leaveRequestController = new LeaveRequestController();
        EmployeesController employeesController = new EmployeesController();
        public MainWindow()
        {
            InitializeComponent();
            LoadGrid();
            LoadCombo();
        }

        private void savebtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(joinDatedtPicker.Text) ||
                string.IsNullOrWhiteSpace(endDatedtPicker.Text) || string.IsNullOrWhiteSpace(statustxtBox.Text))
            {
                MessageBox.Show("Please Fill Blank Text box");
            }
            else
            {
                var push = new EmployeeStatusVM(joinDatedtPicker.SelectedDate, endDatedtPicker.SelectedDate, statustxtBox.Text);
                MessageBoxResult messageBox = System.Windows.MessageBox.Show("Are U Sure?", "Insert Box", System.Windows.MessageBoxButton.YesNo);
                if (messageBox == MessageBoxResult.Yes)
                {
                    var result = employeeStatusesController.Insert(push);
                    if (result)
                    {
                        MessageBox.Show("Insert succesfully");
                        LoadGrid();
                    }
                    else
                    {
                        MessageBox.Show("insert Failed");
                    }
                }
                else
                {
                    MessageBox.Show("Delete Canceled");
                }
                Cleaning();
            }
        }

        private void updatebtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(idEstxtBox.Text) || string.IsNullOrWhiteSpace(joinDatedtPicker.Text) ||
                string.IsNullOrWhiteSpace(endDatedtPicker.Text) || string.IsNullOrWhiteSpace(statustxtBox.Text))
            {
                MessageBox.Show("Please Fill Blank Box");
            }
            else
            {
                var push = new EmployeeStatusVM(joinDatedtPicker.SelectedDate, endDatedtPicker.SelectedDate, statustxtBox.Text);
                MessageBoxResult messageBox = System.Windows.MessageBox.Show("Are u sure?", "Update Box", System.Windows.MessageBoxButton.YesNo);
                if (messageBox == MessageBoxResult.Yes)
                {
                    var result = employeeStatusesController.Update(Convert.ToInt32(idEstxtBox.Text), push);
                    if (result)
                    {
                        MessageBox.Show("Update Succesfully");
                        LoadGrid();
                    }
                    else
                    {
                        MessageBox.Show("Update Failed");
                    }

                }
                else
                {
                    MessageBox.Show("Delete Canceled");
                }
                Cleaning();
            }
        }

        private void deletebtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(idEstxtBox.Text))
            {
                MessageBox.Show("Please Insert Id Frist");
            }
            else
            {
                MessageBoxResult messageBox = System.Windows.MessageBox.Show("Are u sure?", "Delete Box", System.Windows.MessageBoxButton.YesNo);
                if (messageBox == MessageBoxResult.Yes)
                {
                    var result = employeeStatusesController.Delete(Convert.ToInt32(idEstxtBox.Text));
                    if (result)
                    {
                        MessageBox.Show("Delete Succesfully");
                        LoadGrid();
                    }
                    else
                    {
                        MessageBox.Show("Delete Failed");
                    }
                }
                else
                {
                    MessageBox.Show("Delete Canceled");
                }
                Cleaning();
            }
        }

        private void employeeStatusdtGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = employeeStatusdtGrid.SelectedItem;
            try
            {
                idEstxtBox.Text = (employeeStatusdtGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                joinDatedtPicker.Text = (employeeStatusdtGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                endDatedtPicker.Text = (employeeStatusdtGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                statustxtBox.Text = (employeeStatusdtGrid.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
            }
            catch (Exception ex)
            {

            }
        }

        private void savebtnLc_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameLctxtBox.Text) || string.IsNullOrWhiteSpace(totalDayLctxtBox.Text) || string.IsNullOrWhiteSpace(descriptionLctxtBox.Text))
            {
                MessageBox.Show("Please Fill Blank Text box");
            }
            else
            {
                var push = new LeaveCategoryVM(nameLctxtBox.Text, Convert.ToInt32(totalDayLctxtBox.Text), descriptionLctxtBox.Text);
                MessageBoxResult messageBox = System.Windows.MessageBox.Show("Are U Sure?", "Insert Box", System.Windows.MessageBoxButton.YesNo);
                if (messageBox == MessageBoxResult.Yes)
                {
                    var result = leaveCategoryController.Insert(push);
                    if (result)
                    {
                        MessageBox.Show("Insert succesfully");
                        LoadGrid();
                    }
                    else
                    {
                        MessageBox.Show("insert Failed");
                    }
                }
                else
                {
                    MessageBox.Show("Delete Canceled");
                }
                Cleaning();
            }
        }

        private void updatebtnLc_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(idLctxtBox.Text) || string.IsNullOrWhiteSpace(nameLctxtBox.Text) ||
               string.IsNullOrWhiteSpace(totalDayLctxtBox.Text) || string.IsNullOrWhiteSpace(descriptionLctxtBox.Text))
            {
                MessageBox.Show("Please Fill Blank Text box");
            }
            else
            {
                var push = new LeaveCategoryVM(nameLctxtBox.Text, Convert.ToInt32(totalDayLctxtBox.Text), descriptionLctxtBox.Text);
                MessageBoxResult messageBox = System.Windows.MessageBox.Show("Are U Sure?", "Update Box", System.Windows.MessageBoxButton.YesNo);
                if (messageBox == MessageBoxResult.Yes)
                {
                    var result = leaveCategoryController.Update(Convert.ToInt32(idLctxtBox.Text), push);
                    if (result)
                    {
                        MessageBox.Show("Update succesfully");
                        LoadGrid();
                    }
                    else
                    {
                        MessageBox.Show("Update Failed");
                    }
                }
                else
                {
                    MessageBox.Show("Update Canceled");
                }
                Cleaning();
            }
        }

        private void deletebtnLc_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(idLctxtBox.Text))
            {
                MessageBox.Show("Please Insert Id Frist");
            }
            else
            {
                MessageBoxResult messageBox = System.Windows.MessageBox.Show("Are u sure?", "Delete Box", System.Windows.MessageBoxButton.YesNo);
                if (messageBox == MessageBoxResult.Yes)
                {
                    var result = leaveCategoryController.Delete(Convert.ToInt32(idLctxtBox.Text));
                    if (result)
                    {
                        MessageBox.Show("Delete Succesfully");
                        LoadGrid();
                    }
                    else
                    {
                        MessageBox.Show("Delete Failed");
                    }
                }
                else
                {
                    MessageBox.Show("Delete Canceled");
                }
                Cleaning();
            }

        }

        private void leaveCategorytGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = leaveCategorytGrid.SelectedItem;
            try
            {
                idLctxtBox.Text = (leaveCategorytGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                nameLctxtBox.Text = (leaveCategorytGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                totalDayLctxtBox.Text = (leaveCategorytGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                descriptionLctxtBox.Text = (leaveCategorytGrid.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;

    
            }
            catch (Exception ex)
            {

            }
        }

        private void leaveReaquestdtGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = leaveReaquestdtGrid.SelectedItem;
            try
            {
                idLrtxtBox.Text = (leaveReaquestdtGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                fromDatedtPicker.Text = (leaveReaquestdtGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                toDatedtPicker.Text = (leaveReaquestdtGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                reasontxtBox.Text = (leaveReaquestdtGrid.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                //approverCommentstxtBox.Text = (leaveReaquestdtGrid.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                //statusLrtxtBox.Text = (leaveReaquestdtGrid.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
                idEmployeecmbBox.Text = (leaveReaquestdtGrid.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text;
                idLeaveCategorycmbBox.Text = (leaveReaquestdtGrid.SelectedCells[7].Column.GetCellContent(item) as TextBlock).Text;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        private void updatebtnlr_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(idLrtxtBox.Text) || string.IsNullOrWhiteSpace(fromDatedtPicker.Text) ||
            string.IsNullOrWhiteSpace(toDatedtPicker.Text) || string.IsNullOrWhiteSpace(reasontxtBox.Text) ||  string.IsNullOrWhiteSpace(idEmployeecmbBox.Text) || string.IsNullOrWhiteSpace(idLeaveCategorycmbBox.Text))
            {
                MessageBox.Show("Please Fill Blank Text box");
            }
            else
            {
                var push = new LeaveRequestVM(fromDatedtPicker.SelectedDate, toDatedtPicker.SelectedDate, reasontxtBox.Text,
                                                "No Comment", "Pending", Convert.ToInt32(idEmployeecmbBox.SelectedValue), Convert.ToInt32(idLeaveCategorycmbBox.SelectedValue));
                MessageBoxResult messageBox = System.Windows.MessageBox.Show("Are U Sure?", "Update Box", System.Windows.MessageBoxButton.YesNo);
                if (messageBox == MessageBoxResult.Yes)
                {
                    var result = leaveRequestController.Update(Convert.ToInt32(idLrtxtBox.Text), push);
                    if (result)
                    {
                        MessageBox.Show("Update succesfully");
                        LoadGrid();
                    }
                    else
                    {
                        MessageBox.Show("Update Failed");
                    }
                }
                else
                {
                    MessageBox.Show("Udpate Canceled");
                }
                Cleaning();
            }
        }

        private void savebtnlr_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(fromDatedtPicker.Text) ||
            string.IsNullOrWhiteSpace(toDatedtPicker.Text) || string.IsNullOrWhiteSpace(reasontxtBox.Text)|| string.IsNullOrWhiteSpace(idEmployeecmbBox.Text) || string.IsNullOrWhiteSpace(idLeaveCategorycmbBox.Text))
            {
                MessageBox.Show("Please Fill Blank Text box");
            }
            else
            {
                var push = new LeaveRequestVM(fromDatedtPicker.SelectedDate, toDatedtPicker.SelectedDate, reasontxtBox.Text,
                                              "No Comment", "Pending", Convert.ToInt32(idEmployeecmbBox.SelectedValue), Convert.ToInt32(idLeaveCategorycmbBox.SelectedValue));
                MessageBoxResult messageBox = System.Windows.MessageBox.Show("Are U Sure?", "Insert Box", System.Windows.MessageBoxButton.YesNo);
                if (messageBox == MessageBoxResult.Yes)
                {
                    var result = leaveRequestController.Insert(push);
                    if (result)
                    {
                        MessageBox.Show("Insert succesfully");
                        LoadGrid();
                    }
                    else
                    {
                        MessageBox.Show("Insert Failed");
                    }
                }
                else
                {
                    MessageBox.Show("Insert Canceled");
                }
                Cleaning();
            }
        }

        private void deletebtnlr_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(idLrtxtBox.Text))
            {
                MessageBox.Show("Please Insert Id Frist");
            }
            else
            {
                MessageBoxResult messageBox = System.Windows.MessageBox.Show("Are u sure?", "Delete Box", System.Windows.MessageBoxButton.YesNo);
                if (messageBox == MessageBoxResult.Yes)
                {
                    var result = leaveRequestController.Delete(Convert.ToInt32(idLrtxtBox.Text));
                    if (result)
                    {
                        MessageBox.Show("Delete Succesfully");
                        LoadGrid();
                    }
                    else
                    {
                        MessageBox.Show("Delete Failed");
                    }
                }
                else
                {
                    MessageBox.Show("Delete Canceled");
                }
                Cleaning();
            }
        }

        private void idEstxtBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
       
        public void Cleaning()
        {
            idLctxtBox.Text = "";
            nameLctxtBox.Text = "";
            totalDayLctxtBox.Text = "";
            descriptionLctxtBox.Text = "";
            idLrtxtBox.Text = "";
            fromDatedtPicker.Text = "";
            toDatedtPicker.Text = "";
            reasontxtBox.Text = "";
            
            idEstxtBox.Text = "";
            joinDatedtPicker.Text = "";
            endDatedtPicker.Text = "";
            statustxtBox.Text = "";
        }
      
        public void LoadGrid()
        {
            employeeStatusdtGrid.ItemsSource = employeeStatusesController.Get();
            leaveCategorytGrid.ItemsSource = leaveCategoryController.Get();
            leaveReaquestdtGrid.ItemsSource = leaveRequestController.Get();
        }
        public void LoadCombo()
        {
            idEmployeecmbBox.ItemsSource = employeesController.Get();
            idLeaveCategorycmbBox.ItemsSource = leaveCategoryController.Get();
        }
    }
}
