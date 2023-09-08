//PROJECT NAME: MG.MGCore
//CLASS NAME: IFireEvent.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface IFireEvent
    {
        (int? ReturnCode, Guid? eventParmId,
        bool? anyHandlersFailed,
        string result,
        string Infobar) FireEventSp(string eventName,
        string initiator,
        string configName,
        Guid? sessionID,
        Guid? eventTrxId,
        Guid? eventParmId,
        bool? transactional,
        Guid? generatingEventActionStateRowPointer,
        bool? anyHandlersFailed,
        string result,
        string Infobar,
        string site = null);
    }
}

