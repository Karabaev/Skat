namespace DomainModel.Logic
{
    using System.Linq;
    using Repository;
    using Model;

    public static class SettingsContainer
    {
        static SettingsContainer()
        {
            SettingsRepository = new SettingsRepository();
        }

        public static Settings GetSettings()
        {
            var settings = SettingsRepository.GetAllEntities();
            return settings.Where(set => set.ID == settings.Max(s => s.ID)).FirstOrDefault();
        }

        public static bool SetSettings(Settings settings)
        {
            return SettingsRepository.AddEntity(settings);
        }

        private static SettingsRepository SettingsRepository { get; set; }
    }


}
