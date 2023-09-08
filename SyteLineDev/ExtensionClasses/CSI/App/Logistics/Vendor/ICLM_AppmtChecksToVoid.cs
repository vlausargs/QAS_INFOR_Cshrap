//PROJECT NAME: Logistics
//CLASS NAME: ICLM_AppmtChecksToVoid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ICLM_AppmtChecksToVoid
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_AppmtChecksToVoidSp(string PPayCode,
		string PBankCode,
		string PStartingVendNum,
		string PEndingVendNum,
		string PStartingVendName,
		string PEndingVendName,
		int? PStartingCheckNum,
		int? PEndingCheckNum);
	}
}

