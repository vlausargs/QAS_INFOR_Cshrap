//PROJECT NAME: Data
//CLASS NAME: IEvent_HRSendHRStatusActivityEmail.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEvent_HRSendHRStatusActivityEmail
	{
		(int? ReturnCode,
			string Infobar) Event_HRSendHRStatusActivityEmailSp(
			string EmpNum,
			string EmpName,
			int? IsNew,
			string PrevHRStatus = null,
			string HRStatus = null,
			string Infobar = null);
	}
}

