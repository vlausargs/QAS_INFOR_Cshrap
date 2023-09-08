//PROJECT NAME: Data
//CLASS NAME: IEdiOutObDriver2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEdiOutObDriver2
	{
		(int? ReturnCode,
			int? PFlag,
			string Infobar) EdiOutObDriver2Sp(
			string PTranType,
			string POrderType,
			string PVendNum,
			string PPoNum,
			string PPoItemStat,
			int? PFlag,
			string Infobar);
	}
}

