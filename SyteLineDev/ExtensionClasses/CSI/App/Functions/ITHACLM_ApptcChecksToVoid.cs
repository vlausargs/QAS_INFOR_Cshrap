//PROJECT NAME: Data
//CLASS NAME: ITHACLM_ApptcChecksToVoid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITHACLM_ApptcChecksToVoid
	{
		int? THACLM_ApptcChecksToVoidSp(
			string PPayCode,
			string PBankCode,
			string PStartingVendNum,
			string PEndingVendNum,
			string PStartingVendName,
			string PEndingVendName,
			int? PStartingCheckNum,
			int? PEndingCheckNum);
	}
}

