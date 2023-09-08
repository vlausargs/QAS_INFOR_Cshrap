//PROJECT NAME: Data
//CLASS NAME: ITHAptcpost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITHAptcpost
	{
		(ICollectionLoadResponse Data, int? ReturnCode) THAptcpostSp(
			string PSessionID = null,
			string PSBankCode = null,
			string PEBankCode = null,
			string PStartingVendNum = null,
			string PEndingVendNum = null,
			int? PStartingCheckNum = null,
			int? PEndingCheckNum = null,
			DateTime? PStartingCheckDate = null,
			DateTime? PEndingCheckDate = null);
	}
}

