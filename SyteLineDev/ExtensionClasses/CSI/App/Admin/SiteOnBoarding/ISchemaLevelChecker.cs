
namespace CSI.Admin.SiteOnBoarding
{
    public interface ISchemaLevelChecker
    {
        bool IsLessOrEqualToTargetDB(int source_database_level);
        string ReadSchemaLevel();
    }
}
