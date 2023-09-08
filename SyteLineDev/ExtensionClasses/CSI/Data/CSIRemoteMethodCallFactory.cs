using CSI.Data.RecordSets;
using CSI.Data.Utilities;
using CSI.MG;

namespace CSI.Data
{
    public class CSIRemoteMethodCallFactory
    {
        public ICSIRemoteMethodCall Create(IApplicationDB appDB)
        {
            var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
            IConvertToUtil convertToUtil = new ConvertToUtilFactory().Create();

            return new CSIRemoteMethodCall(appDB, dataTableToCollectionLoadResponse, convertToUtil);
        }
    }
}
