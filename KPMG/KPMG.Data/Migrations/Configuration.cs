using System.Data.Entity.Migrations;
using KPMG.Data.Infrastructure;

namespace KPMG.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ContentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ContentContext context)
        {
        }
    }
}
