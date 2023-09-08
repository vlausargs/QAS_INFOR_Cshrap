using CSI.Data.CRUD;
using System;

namespace CSI.Data
{
    public interface ICSIRemoteMethodForReplicationTargets
    {
        (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CSIRemoteMethodForReplicationTargetsSp(string IdoName, string MethodName, string Infobar, Guid? RefRowPointer, params object[] parms);
    }
}