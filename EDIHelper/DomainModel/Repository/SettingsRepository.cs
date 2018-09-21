namespace DomainModel.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using Model;

    public class SettingsRepository : IRepository<Settings>
    {
        public SettingsRepository()
        {
            this.Context = new Context();
        }

        public bool AddEntity(Settings entity)
        {
            this.Context.Settings.Add(entity);
            return this.SaveChanges();
        }

        public List<Settings> GetAllEntities()
        {
            return this.Context.Settings.ToList();
        }

        public Settings GetEntity(int id)
        {
            return this.Context.Settings.Where(c => c.ID == id).FirstOrDefault();
        }

        public bool RemoveEntity(int id)
        {
            this.Context.Settings.Remove(this.Context.Settings.Where(c => c.ID == id).FirstOrDefault());
            return this.SaveChanges();
        }

        public bool SaveChanges()
        {
            return this.Context.SaveChanges() > 0;
        }

        public bool UpdateEntity(Settings entity)
        {
            if (entity == null)
            {
                return false;
            }

            Settings old = this.GetEntity(entity.ID);

            if (old == null)
            {
                return false;
            }

            old.Reinitialization(entity);

            return this.SaveChanges();
        }

        public Context Context { get; set; }
    }
}
