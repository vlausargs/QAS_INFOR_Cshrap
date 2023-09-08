//PROJECT NAME: Data
//CLASS NAME: INotifyPublicationSubscribersWithBOD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface INotifyPublicationSubscribersWithBOD
	{
		(int? ReturnCode,
			string Infobar) NotifyPublicationSubscribersWithBODSp(
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
			string AlertMsgDescription = null);
	}
}

