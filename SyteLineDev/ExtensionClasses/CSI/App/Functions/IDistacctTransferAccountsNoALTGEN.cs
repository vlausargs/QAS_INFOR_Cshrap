//PROJECT NAME: Production
//CLASS NAME: IDistacctTransferAccountsNoALTGEN.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDistacctTransferAccountsNoALTGEN
	{
		(int? ReturnCode,
			string Infobar) DistacctTransferAccountsNoALTGENSp(
			Guid? DistacctRowPointer,
			int? TransferInv,
			int? TransferLbr,
			int? TransferFovhd,
			int? TransferVovhd,
			int? TransferOut,
			int? TransferInvInproc,
			int? TransferLbrInproc,
			int? TransferFovhdInproc,
			int? TransferVovhdInproc,
			int? TransferOutInproc,
			string LocType,
			string Infobar);
	}
}

