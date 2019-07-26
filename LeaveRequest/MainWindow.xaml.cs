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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void savebtn_Click(object sender, RoutedEventArgs e)
        {
            if (ValidationInsert())
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
                CleaningEmployee();
            }
        }
        private void savebtnLc_Click(object sender, RoutedEventArgs e)
        {
            if (ValidationInsertLc())
            {
                MessageBox.Show("Please Fill Blank Text box");
            }
            else
            {
                var push = new LeaveCategoryVM(nameLctxtBox.Text, Convert.ToInt32(totalDaytxtBox.Text) ,descriptiontxtBox.Text);
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
                CleaningCategories();
            }
        }


        private void updatebtn_Click(object sender, RoutedEventArgs e)
        {
            if (ValidationUpdate())
            {
                MessageBox.Show("Please Fill Blank Box");
            }
            else
            {
                var push = new EmployeeStatusVM(joinDatedtPicker.SelectedDate, endDatedtPicker.SelectedDate, statustxtBox.Text);
                MessageBoxResult messageBox = System.Windows.MessageBox.Show("Are u sure?", "Update Box", System.Windows.MessageBoxButton.YesNo);
                if (messageBox == MessageBoxResult.Yes)
                {
                    var result = employeeStatusesController.Update(Convert.ToInt32(idtxtBox.Text), push);
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
                CleaningEmployee();
            }
        }
        private void updatebtnLc_Click(object sender, RoutedEventArgs e)
        {
            if (ValidationUpdateLc())
            {
                MessageBox.Show("Please Fill Blank Text box");
            }
            else
            {
                var push = new LeaveCategoryVM(nameLctxtBox.Text, Convert.ToInt32(totalDaytxtBox.Text), descriptiontxtBox.Text);
                MessageBoxResult messageBox = System.Windows.MessageBox.Show("Are U Sure?", "Insert Box", System.Windows.MessageBoxButton.YesNo);
                if (messageBox == MessageBoxResult.Yes)
                {
                    var result = leaveCategoryController.Update(Convert.ToInt32(idLctxtBox.Text),push);
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
                CleaningCategories();
            }
        }

        private void deletebtn_Click(object sender, RoutedEventArgs e)
        {
            if (ValidationDelete())
            {
                MessageBox.Show("Please Insert Id Frist");
            }
            else
            {
                MessageBoxResult messageBox = System.Windows.MessageBox.Show("Are u sure?", "Delete Box", System.Windows.MessageBoxButton.YesNo);
                if (messageBox == MessageBoxResult.Yes)
                {
                    var result = employeeStatusesController.Delete(Convert.ToInt32(idtxtBox.Text));
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
                CleaningEmployee();
            }


        }
        public void LoadGrid()
        {
            employeeStatusdtGrid.ItemsSource = employeeStatusesController.Get();
            leaveCategorytGrid.ItemsSource = leaveCategoryController.Get();
            leaveReaquestdtGrid.ItemsSource = leaveRequestController.Get();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadGrid();
            LoadCombo();
        }
        public void LoadCombo()
        {
           
        }
        public void CleaningEmployee()
        {
            idtxtBox.Text = "";
            joinDatedtPicker.Text = "";
            endDatedtPicker.Text = "";
            statustxtBox.Text = "";
        }
        public void CleaningCategories()
        {
            idtxtBox.Text = "";
            nameLctxtBox.Text = "";
            totalDaytxtBox.Text = "";
            descriptiontxtBox.Text = "";
        }
        public bool ValidationUpdate()
        {
            if (string.IsNullOrWhiteSpace(idtxtBox.Text) || string.IsNullOrWhiteSpace(joinDatedtPicker.Text) ||
                string.IsNullOrWhiteSpace(endDatedtPicker.Text) || string.IsNullOrWhiteSpace(statustxtBox.Text))
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        public bool ValidationUpdateLc()
        {
            if (string.IsNullOrWhiteSpace(idtxtBox.Text)||string.IsNullOrWhiteSpace(nameLctxtBox.Text) ||
                string.IsNullOrWhiteSpace(totalDaytxtBox.Text) || string.IsNullOrWhiteSpace(descriptiontxtBox.Text))
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        public bool ValidationInsert()
        {
            if (string.IsNullOrWhiteSpace(joinDatedtPicker.Text) ||
                string.IsNullOrWhiteSpace(endDatedtPicker.Text) || string.IsNullOrWhiteSpace(statustxtBox.Text))
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        public bool ValidationInsertLc()
        {
            if(string.IsNullOrWhiteSpace(nameLctxtBox.Text) ||
                string.IsNullOrWhiteSpace(totalDaytxtBox.Text) || string.IsNullOrWhiteSpace(descriptiontxtBox.Text))
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        public bool ValidationDelete()
        {
            if (string.IsNullOrWhiteSpace(idtxtBox.Text))
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        private void IdValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void employeeStatusdtGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = employeeStatusdtGrid.SelectedItem;
            try
            {
                idtxtBox.Text = (employeeStatusdtGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                joinDatedtPicker.Text = (employeeStatusdtGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                endDatedtPicker.Text = (employeeStatusdtGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                statustxtBox.Text = (employeeStatusdtGrid.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
            }
            catch(Exception ex)
            {

            }
            
        }

        private void leaveCategorytGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = leaveReaquestdtGrid.SelectedItem;
        }

        private void leaveReaquestdtGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = leaveCategorytGrid.SelectedItem;
            try
            {
                idLctxtBox.Text = (leaveCategorytGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                nameLctxtBox.Text = (leaveCategorytGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                totalDaytxtBox.Text = (leaveCategorytGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                descriptiontxtBox.Text = (leaveCategorytGrid.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
            }
            catch(Exception ex)
            {

            }
        }
    }
}
