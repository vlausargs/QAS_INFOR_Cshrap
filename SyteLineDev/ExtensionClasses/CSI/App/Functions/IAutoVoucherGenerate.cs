//PROJECT NAME: Data
//CLASS NAME: IAutoVoucherGenerate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IAutoVoucherGenerate
	{
		(int? ReturnCode,
			string Infobar) AutoVoucherGenerateSp(
			string VendNum,
			string Site,
			Guid? SessionID,
			string Infobar,
			string PoNum = null);
	}
}

