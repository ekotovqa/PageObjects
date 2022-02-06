namespace Locales
{
    /// <summary>
    /// Вспомогательный класс, для работы тестов в разных локализациях
    /// </summary>
    public static class Locales
    {
        public static string Company(Localization localization)
        {
            string phrase = "";
            return (phrase == "" ? localization.ToString() : phrase) switch
            {
                "ru" => "Компания",
                "com" => "Company",
                "de" => "Unternehmen",
                _ => "Компания",
            };
        }

        public static string Careers(Localization localization)
        {
            string phrase = "";
            return (phrase == "" ? localization.ToString() : phrase) switch
            {
                "ru" => "Вакансии",
                "com" => "Careers",
                "de" => "Karriere",
                _ => "Компания",
            };
        }

        public static string ViewJobs(Localization localization)
        {
            string phrase = "";
            return (phrase == "" ? localization.ToString() : phrase) switch
            {
                "ru" => "Все вакансии",
                "com" => "View jobs",
                "de" => "View jobs",
                _ => "Компания",
            };
        }
    }

    public enum Localization
    {
        ru,
        com,
        de,
    }
}