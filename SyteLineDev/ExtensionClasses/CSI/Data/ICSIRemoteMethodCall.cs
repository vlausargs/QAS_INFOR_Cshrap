using CSI.Data.CRUD;
using System;

namespace CSI.Data
{
    public interface ICSIRemoteMethodCall
    {
        (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) RemoteMethodCallSp(string Site, string IdoName, string MethodName, string StoredProcName, string Infobar, Guid? RefRowPointer, params object[] parms);
    }
}