using System.Globalization;

namespace SchoolManagement.Domain.Localizations
{
    public class LocalizableEntity
    {
        public string GetLocalized(string textAr, string textEn)
        {
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;
            if (culture.TwoLetterISOLanguageName.ToLower().Equals("ar"))
                return textAr;
            return textEn;

        }

    }
}
