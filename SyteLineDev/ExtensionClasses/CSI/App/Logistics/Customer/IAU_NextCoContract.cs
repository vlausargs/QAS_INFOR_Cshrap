//PROJECT NAME: Logistics
//CLASS NAME: IAU_NextCoContract.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IAU_NextCoContract
	{
		(int? ReturnCode,
			string Key,
			string Infobar) AU_NextCoContractSp(
			string Context,
			string Prefix,
			int? KeyLength,
			string Key,
			string Infobar);
	}
}

