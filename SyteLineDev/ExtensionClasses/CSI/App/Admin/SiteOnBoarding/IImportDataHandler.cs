namespace CSI.Admin.SiteOnBoarding
{
    public interface IImportDataHandler
    {
        void InsertData(
            byte[] fileContent,
            string site,
            string tableName,
            int? tableLevel,
            string taskRowPointer);

        void UpdateData(
            byte[] fileContent,
            string site,
            string tableName,
            int? tableLevel,
            string taskRowPointer);
    }
}