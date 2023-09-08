using CSI.Data.CRUD;

namespace CSI.Finance
{
    public interface ICLM_JournalDetailTran
    {
        (ICollectionLoadResponse Data, int? ReturnCode) CLM_JournalDetailTranSp(string Type = "E", string JournalId = null, string ControlPrefix = null, string ControlSite = null, int? ControlYear = null, int? ControlPeriod = null, decimal? ControlNumber = null);
    }
}