namespace CSI.Admin.SiteOnBoarding
{
    public interface ISiteTaskListener
    {
        void UpdateStateInfoAfterFinished(string site, string emailAddress);
    }
}