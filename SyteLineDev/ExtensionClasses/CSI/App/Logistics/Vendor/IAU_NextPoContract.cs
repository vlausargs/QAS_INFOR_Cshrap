//PROJECT NAME: Logistics
//CLASS NAME: IAU_NextPoContract.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IAU_NextPoContract
	{
		(int? ReturnCode,
			string Key,
			string Infobar) AU_NextPoContractSp(
			string Context,
			string Prefix,
			int? KeyLength,
			string Key,
			string Infobar);
	}
}

