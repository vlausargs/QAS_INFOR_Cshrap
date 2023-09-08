//PROJECT NAME: Data
//CLASS NAME: IGetRmtForSEPAFormat.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetRmtForSEPAFormat
	{
		string GetRmtForSEPAFormatFn(
			string VendNum,
			int? CheckSeq,
			string BankCode);
	}
}

