using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
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

namespace pract9_trpo
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Doctor doctor = new Doctor();
        public Registration()
        {
            InitializeComponent();
        }

        private void Regestration_Click(object sender, RoutedEventArgs e)
        {
            doctor = (Doctor)Resources["DoctorLogin"];
            Random rnd = new Random();
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            doctor.ID = rnd.Next(10000, 100000);
            string jsonString = JsonSerializer.Serialize(doctor, options);

            File.WriteAllText($"D_{doctor.ID}.json", jsonString);

            MessageBox.Show($"Регистрация успешна.\nID:{doctor.ID}");
          
            NavigationService.GoBack();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
