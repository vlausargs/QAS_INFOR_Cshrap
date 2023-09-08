//PROJECT NAME: DataCollection
//CLASS NAME: IAutoLunch.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IAutoLunch
	{
		(int? ReturnCode, string PError) AutoLunchSp(string PEmpNum,
		DateTime? PTransDate,
		int? PTransTime,
		string PTransType,
		int? PTransNum,
		string PTermid,
		string PIndCode,
		string PJob,
		int? PSuffix,
		int? POperNum,
		string PWc,
		string PWhse,
		string PDcModule,
		string PError);
	}
}

