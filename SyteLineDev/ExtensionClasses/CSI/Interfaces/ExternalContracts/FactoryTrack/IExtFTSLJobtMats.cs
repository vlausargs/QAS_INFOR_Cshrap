using System;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTSLJobtMats
    {
        int PostAllJobtMatVB(string StartTransNum, string EndTransNum, string StartJob, string EndJob, string StartSuffix, string EndSuffix, DateTime? StartTransDate, DateTime? EndTransDate, string StartEmpNum, string EndEmpNum, string StartLoc, string EndLoc, string StartItem, string EndItem, string ValidTransClass, string SessionID, ref string Infobar);
    }
}