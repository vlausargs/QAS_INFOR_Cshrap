//PROJECT NAME: DataCollection
//CLASS NAME: IDcATimeatI.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcATimeatI
	{
		(int? ReturnCode, string Infobar) DcATimeatISp(string TTermId,
		int? TTransType,
		string TEmpNum,
		DateTime? TDate,
		int? TTime,
		string Infobar);
	}
}

