using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;

namespace LeaveRequest
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //var client = new HttpClient
            //{
            //    BaseAddress = new Uri("http://localhost:12280/api/")
            //};
            //var responseTask = client.GetAsync("Employee/" + id);
            //responseTask.Wait();
            //var result = responseTask.Result;
            //if (result.IsSuccessStatusCode)
            //{
            //    var readTask = result.Content.ReadAsAsync<>();
            //    readTask.Wait();
            //    loginVM = readTask.Result;
            //}
            //else
            //{
            //    // try to find something
            //}
            //return Json(religionVM, JsonRequestBehavior.AllowGet);

            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("http://192.168.128.1:80/");
            //    LoginClass lgn = new LoginClass { Email = emailtxtBox.Text.ToString(), Password = passwordBox.Password.ToString() };
            //    var response = client.GetAsync("api/Login/"+ lgn).Result;
            //    var a = response.Content.ReadAsStringAsync();
            //    if (a.Result.ToString().Trim() == "0")
            //    {
            //        lblErrorMessage.Content = "Invalid login credentials.";
            //    }
            //    else
            //    {
            //        lblErrorMessage.Content = "Loggedin successfully.";
            //    }
            //}
        }

        //public class LoginClass
        //{
        //    public int ApplicationId { get; set; }
        //    public string Email { get; set; }
        //    public string Password { get; set; }
        //}
    }
    
}
