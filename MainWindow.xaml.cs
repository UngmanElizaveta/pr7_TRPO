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
        public Pacient pacient;
        public MainWindow()
        {
            
            InitializeComponent();
            doctor = new Doctor();
            pacient = new Pacient();
            Panel_1.DataContext = doctor;
            Panel_2.DataContext = doctor;
            Panel_6.DataContext = pacient;
            Panel_7.DataContext = pacient;
            Panel_8.DataContext = doctor;
           ;
        }
        //вход
        bool vhod = false;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
            

            if (!Catch_Entrance())
                return;

            string fileName = $"{doctor.Id}.json";

            
            if (!File.Exists(fileName))
            {
                MessageBox.Show($"Доктор с ID={doctor.Id} не найден");
                return;
            }

            try
            {
               
                string jsonString = File.ReadAllText(fileName);
                var newDoctor = JsonSerializer.Deserialize<Doctor>(jsonString);

                
                if (newDoctor.Password != doctor.Password)
                {
                    MessageBox.Show("Неверный пароль.");
                    return;
                }

               
                Panel_3.DataContext = newDoctor;
                doctor = newDoctor;
                MessageBox.Show($"Вы вошли {newDoctor.LastName} {newDoctor.Name} {newDoctor.MiddleName}");
                vhod = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при входе: {ex.Message}");
            }

        }
        private bool Catch_Entrance()
        {
            if (doctor.Id == 0)
            {
                MessageBox.Show("Поле 'ID' обязательно для заполнения.");
                return false;
            }
            if (doctor.Password == 0)
            {
                MessageBox.Show("Поле 'Password' обязательно для заполнения.");
                return false;
            }
            return true;
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

   
       public void File_get()
        {
            Random random = new Random();
            doctor.Id = random.Next(10000, 100000);
            var jsonString = JsonSerializer.Serialize(doctor);
            string fileName = $"{doctor.Id}.json";
            File.WriteAllText(fileName, jsonString);
            MessageBox.Show($"Ваш ID-{doctor.Id}");
            doctor.count_user++;
            Panel_8.DataContext = doctor;
        }
        public void File_Set()
        {
            string filename = $"{doctor.Id}.json";
            var jsonString = File.ReadAllText(filename);
            var newDoctor = JsonSerializer.Deserialize<Doctor>(jsonString);
            MessageBox.Show($"Вы вошли-{newDoctor.Id}");
            doctor=newDoctor;
            Panel_3.DataContext = newDoctor;
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
                File_get();
               
                
            }
        }
        public void File_get_pacient(Pacient savefile2)
        {
            try
            {
                var jsonString = JsonSerializer.Serialize(savefile2);
                string fileName = $"{savefile2.Id2}.json";
                File.WriteAllText(fileName, jsonString);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}");
            }
        
        }
        public bool Validation_Pacient()
        {
            if (pacient.Name2 == null) { MessageBox.Show("заполните поле имени"); return false; ; }

            if (pacient.LastName2 == null) { MessageBox.Show("заполните поле фамилии"); return false; ; }

            if (pacient.MiddleName2 == null) { MessageBox.Show("заполните поле отчества");   return false;  }

            if (pacient.Diagnosis2 == null) { MessageBox.Show("заполните поле диагноза"); return false; }

            if (pacient.LastDoctor2 == null) { MessageBox.Show("заполните поле идентефикаотора первого доктора"); return false;  }

            if (pacient.Recomendations2 == null) { MessageBox.Show("заполните поле рекомендации");   return false; }
            else
            {
              
                MessageBox.Show("Пациент успешно сохранен!");
            }
            return true;
        }
       
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
        

            if (!vhod)
            { MessageBox.Show("Сначала войдите"); }
            else
            {
                Validation_Pacient();
                
                
                
                    Random random = new Random();
                    pacient.Id2 = random.Next(1000000, 10000000);
                    if (!Validation_Pacient())
                        return;
                    File_get_pacient(pacient);
                    var jsonString = JsonSerializer.Serialize(pacient);
                    var newPacient = JsonSerializer.Deserialize<Pacient>(jsonString);

                    MessageBox.Show($"ID Пациента-{newPacient.Id2}");
                    doctor.count_pacient++;
                    Panel_8.DataContext = doctor;
                
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            
            string filename = $"{pacient.Id2}.json";
            var jsonString = File.ReadAllText(filename);
            var newPacient = JsonSerializer.Deserialize<Pacient>(jsonString);
            Panel_5.DataContext = newPacient ;

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Panel_6.DataContext = null;
            
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            File_get_pacient(pacient);
            var jsonString = JsonSerializer.Serialize(pacient);
            var newPacient = JsonSerializer.Deserialize<Pacient>(jsonString);

            MessageBox.Show("Информация успешно изменена!");
        }
    }
}