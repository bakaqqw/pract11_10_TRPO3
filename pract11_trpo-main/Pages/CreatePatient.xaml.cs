using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.IO;

namespace pract9_trpo
{
  
    public partial class CreatePatient : Page
    {
        public Patient patient = new Patient();

        public CreatePatient()
        {
            Random rnd = new Random();
            patient.ID = rnd.Next(1000000, 10000000);
            DataContext = patient;
            InitializeComponent();
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(patient.Birthday))
                {
                    DateTime birthDate;
                    if (DateTime.TryParse(patient.Birthday, out birthDate))
                    {
                        patient.Birthday = birthDate.ToString("dd.MM.yyyy");
                    }
                }

                var options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                };

                string jsonString = JsonSerializer.Serialize(patient, options);
                File.WriteAllText($"P_{patient.ID}.json", jsonString);

                MessageBox.Show($"Регистрация успешна!\nID пациента: {patient.ID}");
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при регистрации: {ex.Message}");
            }
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    
    }
}