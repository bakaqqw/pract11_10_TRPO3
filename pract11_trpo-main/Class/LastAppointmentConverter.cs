using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace pract9_trpo.Class
{
    public class LastAppointmentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value == null)
                return "Первый прием в клинике";

            string lastAppointmentStr = value.ToString();

            if (string.IsNullOrEmpty(lastAppointmentStr))
                return "Первый прием в клинике";

            DateTime lastAppointment;

            if (DateTime.TryParse(lastAppointmentStr, CultureInfo.InvariantCulture, DateTimeStyles.None, out lastAppointment))
            {
                var today = DateTime.Today;
                var difference = today - lastAppointment.Date;
                int days = difference.Days;
                if (days < 0)
                    return "Ошибка в дате (будущее)";
                if (days == 0)
                    return "Прием сегодня";
                if (days == 1)
                    return "1 день назад";
                if (days > 1 && days < 5)
                    return $"{days} дня назад";

                return $"{days} дней назад";
            }

            if (DateTime.TryParseExact(lastAppointmentStr, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out lastAppointment))
            {
                var today = DateTime.Today;
                var difference = today - lastAppointment;
                int days = difference.Days;

                if (days < 0)
                    return "Ошибка в дате (будущее)";
                if (days == 0)
                    return "Прием сегодня";
                if (days == 1)
                    return "1 день назад";
                if (days > 1 && days < 5)
                    return $"{days} дня назад";

                return $"{days} дней назад";
            }

            return "Первый прием в клинике";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
