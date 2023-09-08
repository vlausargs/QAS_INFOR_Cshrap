//PROJECT NAME: Data
//CLASS NAME: IGenericSendEmail.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGenericSendEmail
	{
		(int? ReturnCode,
			string Infobar) GenericSendEmailSp(
			string EmailToAddrs,
			string EmailCCAddrs,
			string EmailSubject,
			string EmailContent,
			string Infobar);
	}
}

