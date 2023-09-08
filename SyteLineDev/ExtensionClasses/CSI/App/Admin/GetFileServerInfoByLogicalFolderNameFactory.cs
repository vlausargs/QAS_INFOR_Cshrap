//PROJECT NAME: CSIAdmin
//CLASS NAME: GetFileServerInfoByLogicalFolderNameFactory.cs

using CSI.MG;

namespace CSI.Admin
{
    public class GetFileServerInfoByLogicalFolderNameFactory
    {
        public IGetFileServerInfoByLogicalFolderName Create(IApplicationDB appDB)
        {
            var _GetFileServerInfoByLogicalFolderName = new GetFileServerInfoByLogicalFolderName(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetFileServerInfoByLogicalFolderNameExt = timerfactory.Create<IGetFileServerInfoByLogicalFolderName>(_GetFileServerInfoByLogicalFolderName);

            return iGetFileServerInfoByLogicalFolderNameExt;
        }
    }
}
