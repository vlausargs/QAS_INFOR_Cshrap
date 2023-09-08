//PROJECT NAME: Logistics
//CLASS NAME: IPostRem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IPostRem
	{
		(int? ReturnCode, string Infobar) PostRemSP(string PBankCode,
		string PVendNum,
		int? PDraftNum,
		string Infobar);
	}
}

