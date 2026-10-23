using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using pract9_trpo.Class;

namespace pract9_trpo
{
    public class Patient : INotifyPropertyChanged
    {
        public int _ID;
        public string _Name = "";
        public string _LastName = "";
        public string _MiddleName = "";
        public string _Number = "";
        public string _Birthday = "";
        public string _LastAppointment = "";
        public int _LastDoctor;
        public string _Diagnosis = "";
        public string _Recomendations = "";

        public int ID
        {
            get => _ID;
            set
            {
                if (_ID != value)
                {
                    _ID = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Name
        {
            get => _Name;
            set
            {
                if (_Name != value)
                {
                    _Name = value;
                    OnPropertyChanged();
                }
            }
        }

        public string LastName
        {
            get => _LastName;
            set
            {
                if (_LastName != value)
                {
                    _LastName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string MiddleName
        {
            get => _MiddleName;
            set
            {
                if (_MiddleName != value)
                {
                    _MiddleName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Number
        {
            get => _Number;
            set
            {
                if (_Number != value)
                {
                    _Number = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime _birthdayDate;
        public string Birthday
        {
            get => _Birthday;
            set
            {
                if (_Birthday != value)
                {
                    _Birthday = value;
                    if (DateTime.TryParse(value, out DateTime date))
                    {
                        _birthdayDate = date;
                    }
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(Age));
                    OnPropertyChanged(nameof(AgeStatus));
                }
            }
        }

        public int Age
        {
            get
            {
                if (string.IsNullOrEmpty(_Birthday)) return 0;
                if (DateTime.TryParse(_Birthday, out DateTime birthDate))
                {
                    var today = DateTime.Today;
                    var age = today.Year - birthDate.Year;
                    if (birthDate.Date > today.AddYears(-age))
                        age--;
                    return age;
                }
                return 0;
            }
        }
        public string AgeStatus
        {
            get
            {
                if (Age == 0) return "Не указан";
                return Age >= 18 ? "Совершеннолетний" : "Несовершеннолетний";
            }
        }

        public string LastAppointment
        {
            get => _LastAppointment;
            set
            {
                if (_LastAppointment != value)
                {
                    _LastAppointment = value;
                    OnPropertyChanged();
                }
            }
        }

        public int LastDoctor
        {
            get => _LastDoctor;
            set
            {
                if (_LastDoctor != value)
                {
                    _LastDoctor = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Diagnosis
        {
            get => _Diagnosis;
            set
            {
                if (_Diagnosis != value)
                {
                    _Diagnosis = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Recomendations
        {
            get => _Recomendations;
            set
            {
                if (_Recomendations != value)
                {
                    _Recomendations = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<AppointmentStories> _AppointmentStories = new ObservableCollection<AppointmentStories>();
        public ObservableCollection<AppointmentStories> AppointmentStories
        {
            get => _AppointmentStories;
            set
            {
                if (_AppointmentStories != value)
                {
                    _AppointmentStories = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
