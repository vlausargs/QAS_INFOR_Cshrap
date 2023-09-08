//PROJECT NAME: Codes
//CLASS NAME: IDistacctTransferAccounts.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IDistacctTransferAccounts
	{
		(int? ReturnCode, string Infobar) DistacctTransferAccountsSp(Guid? DistacctRowPointer,
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

