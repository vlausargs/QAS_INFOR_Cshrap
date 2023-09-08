//PROJECT NAME: Admin
//CLASS NAME: IFireGenericNotifyToGC.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IFireGenericNotifyToGC
	{
		(int? ReturnCode, string Infobar) FireGenericNotifyToGCSp(string GlobalConstants,
		string Subject,
		string Category = null,
		string Body = null,
		string HTMLBody = null,
		string Infobar = null);
	}
}

