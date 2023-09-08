//PROJECT NAME: Data
//CLASS NAME: ISupplyWEBInPoAckPost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISupplyWEBInPoAckPost
	{
		(int? ReturnCode,
			Guid? PoRowPointer,
			int? VendorActiveForDataIntegration,
			string Infobar) SupplyWEBInPoAckPostSp(
			Guid? TmpAckPoRowPointer,
			Guid? PoRowPointer,
			int? VendorActiveForDataIntegration,
			string Infobar);
	}
}

