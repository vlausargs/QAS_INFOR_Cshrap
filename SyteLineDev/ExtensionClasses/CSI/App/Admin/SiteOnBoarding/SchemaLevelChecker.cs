using CSI.Data.CRUD;

namespace CSI.Admin.SiteOnBoarding
{
    public class SchemaLevelChecker : ISchemaLevelChecker
    {
        readonly ISchemaLevelCRUD schemaLevelCRUD;
        public SchemaLevelChecker(ISchemaLevelCRUD schemaLevelCRUD)
        {
            this.schemaLevelCRUD = schemaLevelCRUD;
        }
        public bool IsLessOrEqualToTargetDB(int source_database_level)
        {
            ICollectionLoadResponse targetSchemaLevelCollection = schemaLevelCRUD.GetTargetSchemaLevel();
            int targetSchemaLevel = 0;
            if (targetSchemaLevelCollection.Items.Count != 0)
                targetSchemaLevel = targetSchemaLevelCollection.Items[0].GetValue<int>("SchemaLevel");

            if (targetSchemaLevel >= source_database_level)
                return true;
            else
                return false;
        }

        public string ReadSchemaLevel()
        {
            ICollectionLoadResponse targetSchemaLevelCollection = schemaLevelCRUD.GetTargetSchemaLevel();
            if (targetSchemaLevelCollection.Items.Count > 0)
                return targetSchemaLevelCollection.Items[0].GetValue<string>("SchemaLevel");
            return string.Empty;
        }
    }
}
