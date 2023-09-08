namespace CSI.Admin.SiteOnBoarding
{
    public interface ILogicalFolderCRUD
    {
        (string ServerName, string FolderTemplate) ReadLogicalFolderInfo(string logicalFolderName);
    }
}