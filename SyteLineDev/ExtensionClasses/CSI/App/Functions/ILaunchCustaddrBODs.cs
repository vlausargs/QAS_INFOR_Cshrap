//PROJECT NAME: Data
//CLASS NAME: ILaunchCustaddrBODs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ILaunchCustaddrBODs
	{
		(int? ReturnCode,
			string Infobar) LaunchCustaddrBODsSP(
			string PActionExpression,
			int? PBillToPartyMaster,
			int? PPayFromPartyMaster,
			int? PCustomerPartyMaster,
			int? PShipToPartyMaster,
			string PCustNum,
			int? PCustSeq,
			Guid? PCustRowPointer,
			string Infobar);
	}
}

