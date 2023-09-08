//PROJECT NAME: Logistics
//CLASS NAME: ITHACheckWH.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ITHACheckWH
	{
		(int? ReturnCode, int? WithRecord,
		string Infobar) THACheckWHSp(string VendNum,
		int? CheckNum,
		int? CheckSeq,
		DateTime? CheckDate,
		int? WithRecord,
		string Infobar);
	}
}

