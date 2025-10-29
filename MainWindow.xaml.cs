using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pr_7_ungman
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public Doctor doctor;
        public MainWindow()
        {
            
            InitializeComponent();
            doctor = new Doctor();
            Panel_1.DataContext = doctor;
            Panel_2.DataContext = doctor;
            Panel_3.DataContext = doctor;
        }
        //вход
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            /*var jsonString = JsonSerializer.Serialize(doctor);
            var newDoctor = JsonSerializer.Deserialize<Doctor>(jsonString);*/
            if (doctor.Id == null)
            {
                MessageBox.Show("Заполните все поля");
            }
            else if (doctor.Password==null)
             {
                 MessageBox.Show("ВВедите пароль");
             }
            else 
            {
                MessageBox.Show($"Вы вошли-{doctor.Id}");
            }
            
            /* else if (doctor.Password != newDoctor.Password)
            {

            }*/
            
        }
        private bool Catch_Regist()
        {

            if (doctor.Name == null)
            {
                MessageBox.Show("Введите Имя");
                return false;
            }
             if (doctor.LastName == null)
            {
                MessageBox.Show("Введите Фамилию");
                return false;
            }
             if (doctor.MiddleName == null)
            {
                MessageBox.Show("Введите Отчество");
                return false;
            }
             if (doctor.Specialisation == null)
            {
                MessageBox.Show("Введите Специализацию");
                return false;
            }
             if (doctor.Password == null)
            {
                MessageBox.Show("Введите Пароль");
                return false;
            }
             if (doctor.Password_catch == null)
            {
                MessageBox.Show("Подтвердите Пароль");
                return false;
            }
             if (doctor.Password != doctor.Password_catch)
            {
                MessageBox.Show("Подтвержение не совпадает с паролем");
                return false;
            }
           
            return true;
        }
       
        //регистрация
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            /*  doctor = new Doctor();
              DataContext = doctor;*/

            if (!Catch_Regist())
                return;
            else
            {
                Random random = new Random();
                doctor.Id = random.Next(10000, 100000);



                var jsonString = JsonSerializer.Serialize(doctor);
                var newDoctor = JsonSerializer.Deserialize<Doctor>(jsonString);
                string fileName=  $"{doctor.Id}.json";
                File.WriteAllText(fileName, jsonString);
                /* var sw_main = File.CreateText($"{doctor.Id}.json");
                 string[] sw = new string[6];

                 for (int i = 0; i < sw.Length; i++)
                 {
                     sw_main.WriteLine(sw);
                 }
                 sw_main.Close();*/
                // var sw_main2 = File.OpenText("1.json");
                //Panel_3.Label_3= sw_main2.ToString();
                //
                MessageBox.Show($"Ваш ID-{newDoctor.Id}");
            }
        }
    }
}