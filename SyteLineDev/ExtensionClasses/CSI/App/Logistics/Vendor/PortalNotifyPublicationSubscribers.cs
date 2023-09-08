using CSI.Data.SQL.UDDT;
using CSI.MG;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CSI.Logistics.Vendor
{
    public interface IPortalNotifyPublicationSubscribers
    {
        int PortalNotifyPublicationSubscribersSp(string PublicationName,
                                                 string AlertSubject,
                                                 string AlertMsg,
                                                 string AlertHTMLMsg,
                                                 ref string Infobar,
                                                 string KeyValue,
                                                 string AlertSubjectParm1,
                                                 string AlertSubjectParm2,
                                                 string AlertSubjectParm3,
                                                 string AlertSubjectParm4,
                                                 string AlertSubjectParm5,
                                                 string AlertSubjectParm6,
                                                 string AlertSubjectParm7,
                                                 string AlertSubjectParm8,
                                                 string AlertSubjectParm9,
                                                 string AlertSubjectParm10,
                                                 string AlertSubjectParm11,
                                                 string AlertSubjectParm12,
                                                 string AlertSubjectParm13,
                                                 string AlertSubjectParm14,
                                                 string AlertSubjectParm15,
                                                 string AlertMsgParm1,
                                                 string AlertMsgParm2,
                                                 string AlertMsgParm3,
                                                 string AlertMsgParm4,
                                                 string AlertMsgParm5,
                                                 string AlertMsgParm6,
                                                 string AlertMsgParm7,
                                                 string AlertMsgParm8,
                                                 string AlertMsgParm9,
                                                 string AlertMsgParm10,
                                                 string AlertMsgParm11,
                                                 string AlertMsgParm12,
                                                 string AlertMsgParm13,
                                                 string AlertMsgParm14,
                                                 string AlertMsgParm15,
                                                 string Category,
                                                 string AlertEventName,
                                                 string AlertVarName5,
                                                 string AlertVarValue5,
                                                 string AlertVarName6,
                                                 string AlertVarValue6,
                                                 string AlertVarName7,
                                                 string AlertVarValue7,
                                                 string AlertVarName8,
                                                 string AlertVarValue8,
                                                 string AlertVarName9,
                                                 string AlertVarValue9,
                                                 string AlertVarName10,
                                                 string AlertVarValue10,
                                                 string AlertVarName11,
                                                 string AlertVarValue11,
                                                 string AlertVarName12,
                                                 string AlertVarValue12,
                                                 string AlertVarName13,
                                                 string AlertVarValue13,
                                                 string AlertVarName14,
                                                 string AlertVarValue14,
                                                 string AlertVarName15,
                                                 string AlertVarValue15,
                                                 string AlertVarName16,
                                                 string AlertVarValue16,
                                                 string AlertVarName17,
                                                 string AlertVarValue17,
                                                 string AlertVarName18,
                                                 string AlertVarValue18,
                                                 string AlertVarName19,
                                                 string AlertVarValue19,
                                                 string AlertVarName20,
                                                 string AlertVarValue20);
    }

    public class PortalNotifyPublicationSubscribers : IPortalNotifyPublicationSubscribers
    {
        readonly IApplicationDB appDB;

        public PortalNotifyPublicationSubscribers(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int PortalNotifyPublicationSubscribersSp(string PublicationName,
                                                        string AlertSubject,
                                                        string AlertMsg,
                                                        string AlertHTMLMsg,
                                                        ref string Infobar,
                                                        string KeyValue,
                                                        string AlertSubjectParm1,
                                                        string AlertSubjectParm2,
                                                        string AlertSubjectParm3,
                                                        string AlertSubjectParm4,
                                                        string AlertSubjectParm5,
                                                        string AlertSubjectParm6,
                                                        string AlertSubjectParm7,
                                                        string AlertSubjectParm8,
                                                        string AlertSubjectParm9,
                                                        string AlertSubjectParm10,
                                                        string AlertSubjectParm11,
                                                        string AlertSubjectParm12,
                                                        string AlertSubjectParm13,
                                                        string AlertSubjectParm14,
                                                        string AlertSubjectParm15,
                                                        string AlertMsgParm1,
                                                        string AlertMsgParm2,
                                                        string AlertMsgParm3,
                                                        string AlertMsgParm4,
                                                        string AlertMsgParm5,
                                                        string AlertMsgParm6,
                                                        string AlertMsgParm7,
                                                        string AlertMsgParm8,
                                                        string AlertMsgParm9,
                                                        string AlertMsgParm10,
                                                        string AlertMsgParm11,
                                                        string AlertMsgParm12,
                                                        string AlertMsgParm13,
                                                        string AlertMsgParm14,
                                                        string AlertMsgParm15,
                                                        string Category,
                                                        string AlertEventName,
                                                        string AlertVarName5,
                                                        string AlertVarValue5,
                                                        string AlertVarName6,
                                                        string AlertVarValue6,
                                                        string AlertVarName7,
                                                        string AlertVarValue7,
                                                        string AlertVarName8,
                                                        string AlertVarValue8,
                                                        string AlertVarName9,
                                                        string AlertVarValue9,
                                                        string AlertVarName10,
                                                        string AlertVarValue10,
                                                        string AlertVarName11,
                                                        string AlertVarValue11,
                                                        string AlertVarName12,
                                                        string AlertVarValue12,
                                                        string AlertVarName13,
                                                        string AlertVarValue13,
                                                        string AlertVarName14,
                                                        string AlertVarValue14,
                                                        string AlertVarName15,
                                                        string AlertVarValue15,
                                                        string AlertVarName16,
                                                        string AlertVarValue16,
                                                        string AlertVarName17,
                                                        string AlertVarValue17,
                                                        string AlertVarName18,
                                                        string AlertVarValue18,
                                                        string AlertVarName19,
                                                        string AlertVarValue19,
                                                        string AlertVarName20,
                                                        string AlertVarValue20)
        {
            NameType _PublicationName = PublicationName;
            MessageSubjectType _AlertSubject = AlertSubject;
            MessageType _AlertMsg = AlertMsg;
            MessageType _AlertHTMLMsg = AlertHTMLMsg;
            InfobarType _Infobar = Infobar;
            KeyValueType _KeyValue = KeyValue;
            InfobarType _AlertSubjectParm1 = AlertSubjectParm1;
            InfobarType _AlertSubjectParm2 = AlertSubjectParm2;
            InfobarType _AlertSubjectParm3 = AlertSubjectParm3;
            InfobarType _AlertSubjectParm4 = AlertSubjectParm4;
            InfobarType _AlertSubjectParm5 = AlertSubjectParm5;
            InfobarType _AlertSubjectParm6 = AlertSubjectParm6;
            InfobarType _AlertSubjectParm7 = AlertSubjectParm7;
            InfobarType _AlertSubjectParm8 = AlertSubjectParm8;
            InfobarType _AlertSubjectParm9 = AlertSubjectParm9;
            InfobarType _AlertSubjectParm10 = AlertSubjectParm10;
            InfobarType _AlertSubjectParm11 = AlertSubjectParm11;
            InfobarType _AlertSubjectParm12 = AlertSubjectParm12;
            InfobarType _AlertSubjectParm13 = AlertSubjectParm13;
            InfobarType _AlertSubjectParm14 = AlertSubjectParm14;
            InfobarType _AlertSubjectParm15 = AlertSubjectParm15;
            InfobarType _AlertMsgParm1 = AlertMsgParm1;
            InfobarType _AlertMsgParm2 = AlertMsgParm2;
            InfobarType _AlertMsgParm3 = AlertMsgParm3;
            InfobarType _AlertMsgParm4 = AlertMsgParm4;
            InfobarType _AlertMsgParm5 = AlertMsgParm5;
            InfobarType _AlertMsgParm6 = AlertMsgParm6;
            InfobarType _AlertMsgParm7 = AlertMsgParm7;
            InfobarType _AlertMsgParm8 = AlertMsgParm8;
            InfobarType _AlertMsgParm9 = AlertMsgParm9;
            InfobarType _AlertMsgParm10 = AlertMsgParm10;
            InfobarType _AlertMsgParm11 = AlertMsgParm11;
            InfobarType _AlertMsgParm12 = AlertMsgParm12;
            InfobarType _AlertMsgParm13 = AlertMsgParm13;
            InfobarType _AlertMsgParm14 = AlertMsgParm14;
            InfobarType _AlertMsgParm15 = AlertMsgParm15;
            MessageCategoryType _Category = Category;
            InfobarType _AlertEventName = AlertEventName;
            EventVariableNameType _AlertVarName5 = AlertVarName5;
            EventVariableValueType _AlertVarValue5 = AlertVarValue5;
            EventVariableNameType _AlertVarName6 = AlertVarName6;
            EventVariableValueType _AlertVarValue6 = AlertVarValue6;
            EventVariableNameType _AlertVarName7 = AlertVarName7;
            EventVariableValueType _AlertVarValue7 = AlertVarValue7;
            EventVariableNameType _AlertVarName8 = AlertVarName8;
            EventVariableValueType _AlertVarValue8 = AlertVarValue8;
            EventVariableNameType _AlertVarName9 = AlertVarName9;
            EventVariableValueType _AlertVarValue9 = AlertVarValue9;
            EventVariableNameType _AlertVarName10 = AlertVarName10;
            EventVariableValueType _AlertVarValue10 = AlertVarValue10;
            EventVariableNameType _AlertVarName11 = AlertVarName11;
            EventVariableValueType _AlertVarValue11 = AlertVarValue11;
            EventVariableNameType _AlertVarName12 = AlertVarName12;
            EventVariableValueType _AlertVarValue12 = AlertVarValue12;
            EventVariableNameType _AlertVarName13 = AlertVarName13;
            EventVariableValueType _AlertVarValue13 = AlertVarValue13;
            EventVariableNameType _AlertVarName14 = AlertVarName14;
            EventVariableValueType _AlertVarValue14 = AlertVarValue14;
            EventVariableNameType _AlertVarName15 = AlertVarName15;
            EventVariableValueType _AlertVarValue15 = AlertVarValue15;
            EventVariableNameType _AlertVarName16 = AlertVarName16;
            EventVariableValueType _AlertVarValue16 = AlertVarValue16;
            EventVariableNameType _AlertVarName17 = AlertVarName17;
            EventVariableValueType _AlertVarValue17 = AlertVarValue17;
            EventVariableNameType _AlertVarName18 = AlertVarName18;
            EventVariableValueType _AlertVarValue18 = AlertVarValue18;
            EventVariableNameType _AlertVarName19 = AlertVarName19;
            EventVariableValueType _AlertVarValue19 = AlertVarValue19;
            EventVariableNameType _AlertVarName20 = AlertVarName20;
            EventVariableValueType _AlertVarValue20 = AlertVarValue20;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PortalNotifyPublicationSubscribersSp";

                appDB.AddCommandParameter(cmd, "PublicationName", _PublicationName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertSubject", _AlertSubject, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertMsg", _AlertMsg, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertHTMLMsg", _AlertHTMLMsg, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "KeyValue", _KeyValue, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertSubjectParm1", _AlertSubjectParm1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertSubjectParm2", _AlertSubjectParm2, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertSubjectParm3", _AlertSubjectParm3, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertSubjectParm4", _AlertSubjectParm4, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertSubjectParm5", _AlertSubjectParm5, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertSubjectParm6", _AlertSubjectParm6, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertSubjectParm7", _AlertSubjectParm7, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertSubjectParm8", _AlertSubjectParm8, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertSubjectParm9", _AlertSubjectParm9, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertSubjectParm10", _AlertSubjectParm10, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertSubjectParm11", _AlertSubjectParm11, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertSubjectParm12", _AlertSubjectParm12, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertSubjectParm13", _AlertSubjectParm13, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertSubjectParm14", _AlertSubjectParm14, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertSubjectParm15", _AlertSubjectParm15, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertMsgParm1", _AlertMsgParm1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertMsgParm2", _AlertMsgParm2, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertMsgParm3", _AlertMsgParm3, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertMsgParm4", _AlertMsgParm4, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertMsgParm5", _AlertMsgParm5, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertMsgParm6", _AlertMsgParm6, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertMsgParm7", _AlertMsgParm7, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertMsgParm8", _AlertMsgParm8, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertMsgParm9", _AlertMsgParm9, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertMsgParm10", _AlertMsgParm10, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertMsgParm11", _AlertMsgParm11, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertMsgParm12", _AlertMsgParm12, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertMsgParm13", _AlertMsgParm13, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertMsgParm14", _AlertMsgParm14, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertMsgParm15", _AlertMsgParm15, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Category", _Category, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertEventName", _AlertEventName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertVarName5", _AlertVarName5, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertVarValue5", _AlertVarValue5, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertVarName6", _AlertVarName6, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertVarValue6", _AlertVarValue6, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertVarName7", _AlertVarName7, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertVarValue7", _AlertVarValue7, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertVarName8", _AlertVarName8, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertVarValue8", _AlertVarValue8, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertVarName9", _AlertVarName9, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertVarValue9", _AlertVarValue9, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertVarName10", _AlertVarName10, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertVarValue10", _AlertVarValue10, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertVarName11", _AlertVarName11, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertVarValue11", _AlertVarValue11, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertVarName12", _AlertVarName12, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertVarValue12", _AlertVarValue12, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertVarName13", _AlertVarName13, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertVarValue13", _AlertVarValue13, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertVarName14", _AlertVarName14, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertVarValue14", _AlertVarValue14, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertVarName15", _AlertVarName15, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertVarValue15", _AlertVarValue15, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertVarName16", _AlertVarName16, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertVarValue16", _AlertVarValue16, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertVarName17", _AlertVarName17, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertVarValue17", _AlertVarValue17, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertVarName18", _AlertVarName18, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertVarValue18", _AlertVarValue18, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertVarName19", _AlertVarName19, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertVarValue19", _AlertVarValue19, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertVarName20", _AlertVarName20, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlertVarValue20", _AlertVarValue20, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
