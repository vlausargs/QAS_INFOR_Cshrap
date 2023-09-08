namespace CSI.Admin.SiteOnBoarding
{
    public interface IExportHeaderInfo
    {
        (string export_logical_folder,
            string email, 
            string file_type)
            GetExportHeaderInfo(string site);
    }
}
