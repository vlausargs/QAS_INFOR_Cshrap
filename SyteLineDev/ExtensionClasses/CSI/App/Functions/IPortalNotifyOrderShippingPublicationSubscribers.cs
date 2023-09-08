//PROJECT NAME: Data
//CLASS NAME: IPortalNotifyOrderShippingPublicationSubscribers.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPortalNotifyOrderShippingPublicationSubscribers
	{
		(int? ReturnCode,
			string Infobar) PortalNotifyOrderShippingPublicationSubscribersSp(
			string PublicationName = null,
			string AlertSubject = null,
			string AlertMsg = null,
			string AlertHTMLMsg = null,
			string Infobar = null,
			string KeyValue = null,
			string AlertSubjectParm1 = null,
			string AlertSubjectParm2 = null,
			string AlertSubjectParm3 = null,
			string AlertSubjectParm4 = null,
			string AlertSubjectParm5 = null,
			string AlertSubjectParm6 = null,
			string AlertSubjectParm7 = null,
			string AlertSubjectParm8 = null,
			string AlertSubjectParm9 = null,
			string AlertSubjectParm10 = null,
			string AlertSubjectParm11 = null,
			string AlertSubjectParm12 = null,
			string AlertSubjectParm13 = null,
			string AlertSubjectParm14 = null,
			string AlertSubjectParm15 = null,
			string AlertMsgParm1 = null,
			string AlertMsgParm2 = null,
			string AlertMsgParm3 = null,
			string AlertMsgParm4 = null,
			string AlertMsgParm5 = null,
			string AlertMsgParm6 = null,
			string AlertMsgParm7 = null,
			string AlertMsgParm8 = null,
			string AlertMsgParm9 = null,
			string AlertMsgParm10 = null,
			string AlertMsgParm11 = null,
			string AlertMsgParm12 = null,
			string AlertMsgParm13 = null,
			string AlertMsgParm14 = null,
			string AlertMsgParm15 = null,
			string Category = null,
			string AlertEventName = null,
			string AlertVarName5 = null,
			string AlertVarValue5 = null,
			string AlertVarName6 = null,
			string AlertVarValue6 = null,
			string AlertVarName7 = null,
			string AlertVarValue7 = null,
			string AlertVarName8 = null,
			string AlertVarValue8 = null,
			string AlertVarName9 = null,
			string AlertVarValue9 = null,
			string AlertVarName10 = null,
			string AlertVarValue10 = null,
			string AlertVarName11 = null,
			string AlertVarValue11 = null,
			string AlertVarName12 = null,
			string AlertVarValue12 = null,
			string AlertVarName13 = null,
			string AlertVarValue13 = null,
			string AlertVarName14 = null,
			string AlertVarValue14 = null,
			string AlertVarName15 = null,
			string AlertVarValue15 = null,
			string AlertVarName16 = null,
			string AlertVarValue16 = null,
			string AlertVarName17 = null,
			string AlertVarValue17 = null,
			string AlertVarName18 = null,
			string AlertVarValue18 = null,
			string AlertVarName19 = null,
			string AlertVarValue19 = null,
			string AlertVarName20 = null,
			string AlertVarValue20 = null);
	}
}

