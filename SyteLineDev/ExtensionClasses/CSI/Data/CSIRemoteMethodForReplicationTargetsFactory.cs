using CSI.Data.RecordSets;
using CSI.Data.Utilities;
using CSI.MG;

namespace CSI.Data
{
    public class CSIRemoteMethodForReplicationTargetsFactory
    {
        public ICSIRemoteMethodForReplicationTargets Create(IApplicationDB appDB)
        {
            var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
            IConvertToUtil convertToUtil = new ConvertToUtilFactory().Create();

            return new CSIRemoteMethodForReplicationTargets(appDB, dataTableToCollectionLoadResponse, convertToUtil);
        }
    }
}
