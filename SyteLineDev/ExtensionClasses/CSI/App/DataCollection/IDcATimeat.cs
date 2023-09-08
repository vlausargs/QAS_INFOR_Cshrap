//PROJECT NAME: DataCollection
//CLASS NAME: IDcATimeat.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcATimeat
	{
		(int? ReturnCode, string Infobar) DcATimeatSp(string TTermId,
		int? TTransType,
		string TEmpNum,
		DateTime? TDate,
		int? TTime,
		string Infobar);
	}
}

