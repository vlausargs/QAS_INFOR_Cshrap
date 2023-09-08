//PROJECT NAME: MG.MGCore
//CLASS NAME: FireEvent.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
    public class FireEvent : IFireEvent
    {
        IApplicationDB appDB;


        public FireEvent(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode, Guid? eventParmId,
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
        string site = null)
        {
            StringType _eventName = eventName;
            StringType _initiator = initiator;
            StringType _configName = configName;
            GuidType _sessionID = sessionID;
            GuidType _eventTrxId = eventTrxId;
            GuidType _eventParmId = eventParmId;
            BooleanType _transactional = transactional;
            GuidType _generatingEventActionStateRowPointer = generatingEventActionStateRowPointer;
            BooleanType _anyHandlersFailed = anyHandlersFailed;
            StringType _result = result;
            StringType _Infobar = Infobar;
            StringType _site = site;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "FireEventSp";

                appDB.AddCommandParameter(cmd, "eventName", _eventName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "initiator", _initiator, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "configName", _configName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "sessionID", _sessionID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "eventTrxId", _eventTrxId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "eventParmId", _eventParmId, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "transactional", _transactional, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "generatingEventActionStateRowPointer", _generatingEventActionStateRowPointer, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "anyHandlersFailed", _anyHandlersFailed, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "result", _result, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "site", _site, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                eventParmId = _eventParmId;
                anyHandlersFailed = _anyHandlersFailed;
                result = _result;
                Infobar = _Infobar;

                return (Severity, eventParmId, anyHandlersFailed, result, Infobar);
            }
        }
    }
}
