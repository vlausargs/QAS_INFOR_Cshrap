using System.Data;


namespace CSI.Data.RecordSets
{
    public interface IRecordCollectionToDataTable
    {
        DataTable ToDataTable(IRecordCollection recordCollection);
    }
}
