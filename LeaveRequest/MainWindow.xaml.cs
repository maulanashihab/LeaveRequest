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
        HolidaysController holidayController = new HolidaysController();
        ParametersController parameterController = new ParametersController();
        UsersController userController = new UsersController();
        RolesController roleController = new RolesController();
        EmployeesController employeeController = new EmployeesController();
        

        public MainWindow()
        {
            InitializeComponent();
        }


        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public void LoadGrid()
        {
            holidaydtGrid.ItemsSource = holidayController.Get();
            paramdtGrid.ItemsSource = parameterController.Get();
            userdtGrid.ItemsSource = userController.Get();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadGrid();
            LoadCombo();
        }

        public void Cleaning()
        {
            idtxtHolidayBox.Text = "";
            holidayNametxtBox.Text = "";
            holidayDatedtPicker.Text = "";
            idparamtxtBox.Text = "";
            paramnametxtBox.Text = "";
            paramvaluetxtBox.Text = "";
        }

        //Table Holidays
        private void saveholidaybtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(holidayNametxtBox.Text) || string.IsNullOrWhiteSpace(holidayDatedtPicker.Text))
            {
                MessageBox.Show("Please Fill Blank TextBox");
            }
            else
            {
                var push = new HolidayVM(holidayNametxtBox.Text, holidayDatedtPicker.SelectedDate);
                var result = holidayController.Insert(push);
                if (result)
                {
                    MessageBox.Show("Insert Succesfully");
                    LoadGrid();
                }
                else
                {
                    MessageBox.Show("Insert Failed");
                }
                Cleaning();
            }
        }

        private void updateholidaybtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(holidayNametxtBox.Text) || string.IsNullOrWhiteSpace(holidayDatedtPicker.Text))
            {
                MessageBox.Show("Please Fill Blank TextBox");
            }
            else
            {
                var push = new HolidayVM(holidayNametxtBox.Text, holidayDatedtPicker.SelectedDate);
                var result = holidayController.Update(Convert.ToInt32(idtxtHolidayBox.Text), push);
                if (result)
                {
                    MessageBox.Show("Update Succesfully");
                    LoadGrid();
                }
                else
                {
                    MessageBox.Show("Update Failed");
                }
                Cleaning();
            }
        }

        private void deleteholidaybtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(idtxtHolidayBox.Text))
            {
                MessageBox.Show("Please Fill Blank Id");
            }
            else
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Data", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    var result = holidayController.Delete(Convert.ToInt32(idtxtHolidayBox.Text));
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
                Cleaning();
            }
        }

        private void holidaydtGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            //Error Handling
            object item = holidaydtGrid.SelectedItem;
            try
            {
                idtxtHolidayBox.Text = (holidaydtGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                holidayNametxtBox.Text = (holidaydtGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                holidayDatedtPicker.Text = (holidaydtGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
            }
            catch(Exception ex)
            {

            }
        }

        //Table Parameters
        private void saveparambtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(paramnametxtBox.Text) || string.IsNullOrWhiteSpace(paramvaluetxtBox.Text))
            {
                MessageBox.Show("Please Fill Blank TextBox");
            }
            else
            {
                var push = new ParameterVM(paramnametxtBox.Text, Convert.ToInt32(paramvaluetxtBox.Text));
                var result = parameterController.Insert(push);
                if (result)
                {
                    MessageBox.Show("Insert Succesfully");
                    LoadGrid();
                }
                else
                {
                    MessageBox.Show("Insert Failed");
                }
                Cleaning();
            }
        }

        private void updateparambtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(paramnametxtBox.Text) || string.IsNullOrWhiteSpace(paramvaluetxtBox.Text))
            {
                MessageBox.Show("Please Fill Blank TextBox");
            }
            else
            {
                var push = new ParameterVM(paramnametxtBox.Text, Convert.ToInt32(paramvaluetxtBox.Text));
                var result = parameterController.Update(Convert.ToInt32(idparamtxtBox.Text), push);
                if (result)
                {
                    MessageBox.Show("Update Succesfully");
                    LoadGrid();
                }
                else
                {
                    MessageBox.Show("Update Failed");
                }
                Cleaning();
            }
        }

        private void deleteparambtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(idparamtxtBox.Text))
            {
                MessageBox.Show("Please Fill Blank Id");
            }
            else
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Data", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    var result = parameterController.Delete(Convert.ToInt32(idparamtxtBox.Text));
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
                Cleaning();
            }
        }

        private void paramdtGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            //Error Handling
            object item = paramdtGrid.SelectedItem;
            try
            {
                idparamtxtBox.Text = (paramdtGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                paramnametxtBox.Text = (paramdtGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                paramvaluetxtBox.Text = (paramdtGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
            }
            catch (Exception ex)
            {

            }
        }

        //Table Users
        private void saveuserbtn_Click(object sender, RoutedEventArgs e)
        {
            if (/*string.IsNullOrWhiteSpace(idusercmbBox.Text) || */string.IsNullOrWhiteSpace(userEmailtxtBox.Text) || string.IsNullOrWhiteSpace(userpwdBox.Password) || string.IsNullOrWhiteSpace(rolecmbBox.Text))
            {
                MessageBox.Show("Please Fill in the Blank");
            }
            else
            {
                var push = new UserVM(Convert.ToInt32(idusertxtBox.Text), userEmailtxtBox.Text, userpwdBox.Password, Convert.ToInt32(rolecmbBox.SelectedValue));
                var result = userController.Insert(push);
                if (result) 
                {
                    MessageBox.Show("Insert Succesfully");
                    LoadGrid();
                }
                else
                {
                    MessageBox.Show("Insert Failed");
                }
                Cleaning();
            }
        }

        private void updateuserbtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deleteuserbtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoadCombo()
        {
            rolecmbBox.ItemsSource = roleController.Get();
            //idusercmbBox.ItemsSource = employeeController.Get();
        }

        private void userdtGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = userdtGrid.SelectedItem;
            try
            {
                idusertxtBox.Text = (userdtGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                userEmailtxtBox.Text = (userdtGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                userpwdBox.Password = (userdtGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                rolecmbBox.Text = (userdtGrid.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
