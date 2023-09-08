//PROJECT NAME: Logistics
//CLASS NAME: IVchPreRegisterVar.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IVchPreRegisterVar
	{
		(int? ReturnCode, string SuspenseAcct,
		string SuspenseAcctDesc,
		string SuspenseAcctUnit1,
		string SuspenseAcctUnit2,
		string SuspenseAcctUnit3,
		string SuspenseAcctUnit4,
		string UnMatchedAcct,
		string UnMatchedAcctDesc,
		string UnMatchedAcctUnit1,
		string UnMatchedAcctUnit2,
		string UnMatchedAcctUnit3,
		string UnMatchedAcctUnit4,
		string FreightAcct,
		string FreightAcctDesc,
		string FreightAcctUnit1,
		string FreightAcctUnit2,
		string FreightAcctUnit3,
		string FreightAcctUnit4,
		string MiscAcct,
		string MiscAcctDesc,
		string MiscAcctUnit1,
		string MiscAcctUnit2,
		string MiscAcctUnit3,
		string MiscAcctUnit4) VchPreRegisterVarSP(string SuspenseAcct,
		string SuspenseAcctDesc,
		string SuspenseAcctUnit1,
		string SuspenseAcctUnit2,
		string SuspenseAcctUnit3,
		string SuspenseAcctUnit4,
		string UnMatchedAcct,
		string UnMatchedAcctDesc,
		string UnMatchedAcctUnit1,
		string UnMatchedAcctUnit2,
		string UnMatchedAcctUnit3,
		string UnMatchedAcctUnit4,
		string FreightAcct,
		string FreightAcctDesc,
		string FreightAcctUnit1,
		string FreightAcctUnit2,
		string FreightAcctUnit3,
		string FreightAcctUnit4,
		string MiscAcct,
		string MiscAcctDesc,
		string MiscAcctUnit1,
		string MiscAcctUnit2,
		string MiscAcctUnit3,
		string MiscAcctUnit4);
	}
}

