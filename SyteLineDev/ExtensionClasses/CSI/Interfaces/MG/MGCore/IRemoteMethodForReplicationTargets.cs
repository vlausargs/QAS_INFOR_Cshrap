//PROJECT NAME: MG.MGCore
//CLASS NAME: IRemoteMethodForReplicationTargets.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface IRemoteMethodForReplicationTargets
    {
        (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) RemoteMethodForReplicationTargetsSp(string IdoName,
        string MethodName,
        string Infobar,
        string Parm1Value = "",
        string Parm2Value = "",
        string Parm3Value = "",
        string Parm4Value = "",
        string Parm5Value = "",
        string Parm6Value = "",
        string Parm7Value = "",
        string Parm8Value = "",
        string Parm9Value = "",
        string Parm10Value = "",
        string Parm11Value = "",
        string Parm12Value = "",
        string Parm13Value = "",
        string Parm14Value = "",
        string Parm15Value = "",
        string Parm16Value = "",
        string Parm17Value = "",
        string Parm18Value = "",
        string Parm19Value = "",
        string Parm20Value = "",
        string Parm21Value = "",
        string Parm22Value = "",
        string Parm23Value = "",
        string Parm24Value = "",
        string Parm25Value = "",
        string Parm26Value = "",
        string Parm27Value = "",
        string Parm28Value = "",
        string Parm29Value = "",
        string Parm30Value = "",
        string Parm31Value = "",
        string Parm32Value = "",
        string Parm33Value = "",
        string Parm34Value = "",
        string Parm35Value = "",
        string Parm36Value = "",
        string Parm37Value = "",
        string Parm38Value = "",
        string Parm39Value = "",
        string Parm40Value = "",
        string Parm41Value = "",
        string Parm42Value = "",
        string Parm43Value = "",
        string Parm44Value = "",
        string Parm45Value = "",
        string Parm46Value = "",
        string Parm47Value = "",
        string Parm48Value = "",
        string Parm49Value = "",
        string Parm50Value = "",
        string Parm51Value = "",
        string Parm52Value = "",
        string Parm53Value = "",
        string Parm54Value = "",
        string Parm55Value = "",
        string Parm56Value = "",
        string Parm57Value = "",
        string Parm58Value = "",
        string Parm59Value = "",
        string Parm60Value = "",
        Guid RefRowPointer = default(Guid));
    }
}

