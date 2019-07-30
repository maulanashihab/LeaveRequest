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

    public partial class MainWindow : Window
    {
        RolesController rolesController = new RolesController();
        EmployeesController employeesController = new EmployeesController();
        AvailableLeavesController availableLeavesController = new AvailableLeavesController();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void savebtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nametxtBox.Text))
            {
                MessageBox.Show("Please Fill Name TextBox");
            }
            else
            {
                var push = new RoleVM(nametxtBox.Text);
                var result = rolesController.Insert(push);
                if (result)
                {
                    MessageBox.Show("Insert Successfully");
                    LoadGrid();
                }
                else
                {
                    MessageBox.Show("Insert Failed");
                }
                clean();
            }
        }
        private void updatebtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(idtxtBox.Text) || string.IsNullOrWhiteSpace(nametxtBox.Text))
            {
                MessageBox.Show("Please Fill");
            }
            else
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you Sure to Update?", "Question", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    var push = new RoleVM(nametxtBox.Text);
                    var result = rolesController.Update(Convert.ToInt32(idtxtBox.Text), push);
                    if (result)
                    {
                        MessageBox.Show("Update Success");
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
                clean();
            }
        }

        private void deletebtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(idtxtBox.Text))
            {
                MessageBox.Show("Please Choose Data to Delete");
            }
            else
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you Sure to Delete?", "Question", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    var result = rolesController.Delete(Convert.ToInt32(idtxtBox.Text));
                    if (result)
                    {
                        MessageBox.Show("Delete Success");
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
                clean();
            }
        }
        public void LoadGrid()
        {
            roledtGrid.ItemsSource = rolesController.Get();
            employeedtGrid.ItemsSource = employeesController.Get();
        }
        public void LoadGridEmployee()
        {
            employeedtGrid.ItemsSource = employeesController.Get();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadGrid();
            LoadCombo();
            LoadGridEmployee();
        }
        public void clean()
        {
            // for Role
            idtxtBox.Text = "";
            nametxtBox.Text = "";
            // for employee
            idetxtBox.Text = "";
            fnametxtBox.Text = "";
            lnametxtBox.Text = "";
            religiontxtBox.Text = "";
            //mstatustxtBox.Text = "";
            childrentxtBox.Text = "";
            managercomboBox.Text = "";
        }
        
        public void LoadCombo()
        {
            managercomboBox.ItemsSource = employeesController.Get();
        }

        private void idtxtBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void roledtGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = roledtGrid.SelectedItem;
            try
            {
                idtxtBox.Text = (roledtGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                nametxtBox.Text = (roledtGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            }
            catch (Exception ex)
            {

            }
        }

        private void deleteebtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(idetxtBox.Text))
            {
                MessageBox.Show("Please Choose Data to Delete");
            }
            else
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you Sure to Delete?", "Question", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    var result = employeesController.Delete(Convert.ToInt32(idetxtBox.Text));
                    if (result)
                    {
                        MessageBox.Show("Delete Success");
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
                clean();
            }
        }

        private void employeedtGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = employeedtGrid.SelectedItem;
            try
            {
                idetxtBox.Text = (employeedtGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                fnametxtBox.Text = (employeedtGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                lnametxtBox.Text = (employeedtGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                //btnmale.IsChecked = (employeedtGrid.SelectedCells[3].Column.GetCellContent(item) as CheckBox).IsChecked;
                //btnfemale.IsChecked = (employeedtGrid.SelectedCells[3].Column.GetCellContent(item) as RadioButton);
                religiontxtBox.Text = (employeedtGrid.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                // mstatustxtBox.Text = (employeedtGrid.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
                childrentxtBox.Text = (employeedtGrid.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text;
                managercomboBox.Text = (employeedtGrid.SelectedCells[7].Column.GetCellContent(item) as TextBlock).Text;
            }
            catch (Exception ex)
            {

            }
        }

        private void updateebtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(idetxtBox.Text) || string.IsNullOrWhiteSpace(fnametxtBox.Text) || string.IsNullOrWhiteSpace(lnametxtBox.Text))
            {
                MessageBox.Show("Please Fill");
            }
            else
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you Sure to Update?", "Question", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    bool gender = false;
                    if (btnmale.IsChecked == true)
                    {
                        gender = false;
                    }
                    else
                    {
                        gender = true;
                    }
                    bool mstatus = false;
                    if(btnsingle.IsChecked == true)
                    {
                        mstatus = false;
                    }else
                    {
                        mstatus = true;
                    }
                    var push = new EmployeeVM(fnametxtBox.Text, lnametxtBox.Text, gender, religiontxtBox.Text, mstatus, Convert.ToInt32(childrentxtBox.Text), Convert.ToInt32(managercomboBox.Text));
                    var result = employeesController.Update(Convert.ToInt32(idetxtBox.Text), push);
                    if (result)
                    {
                        MessageBox.Show("Update Success");
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
                clean();
            }
        }

        private void saveebtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(idetxtBox.Text) && string.IsNullOrWhiteSpace(fnametxtBox.Text) && string.IsNullOrWhiteSpace(religiontxtBox.Text) && string.IsNullOrWhiteSpace(childrentxtBox.Text))
            {
                MessageBox.Show("Please Fill");
            }
            else
            {
                bool gender = false;
                if (btnmale.IsChecked == true)
                {
                    gender = false;
                }
                else
                {
                    gender = true;
                }
                bool mstatus = false;
                if (btnsingle.IsChecked == true)
                {
                    mstatus = false;
                }
                else
                {
                    mstatus = true;
                }
                
                var push = new EmployeeVM(fnametxtBox.Text, lnametxtBox.Text, gender, religiontxtBox.Text, mstatus, Convert.ToInt32(childrentxtBox.Text), Convert.ToInt32(managercomboBox.Text));
                var result = employeesController.Insert(push);
                if (result)
                {
                    MessageBox.Show("Insert Successfully");
                    LoadGrid();
                }
                else
                {
                    MessageBox.Show("Insert Failed");
                }

                clean();
            }
        }

        private void dataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void updatebtnAl_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deletebtnAl_Click(object sender, RoutedEventArgs e)
        {

        }

        private void savebtnAl_Click(object sender, RoutedEventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(thisyeartxtBox.Text) && string.IsNullOrWhiteSpace(lastyeartxtBox.Text))
            //{
            //    MessageBox.Show("Please Fill Name TextBox");
            //}
            //else
            //{
               // var push = new AvailableLeaveVM(Convert.ToInt32(thisyeartxtBox.Text), Convert.ToInt32(lastyeartxtBox));
               // var result = availableLeavesController.Insert(push);
               // if (result)
               // {
               //     MessageBox.Show("Insert Successfully");
                    
               // }
               // else
               // {
               //     MessageBox.Show("Insert Failed");
               //}
                
            }
        }
        }
