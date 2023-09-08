//PROJECT NAME: Production
//CLASS NAME: DistacctTransferAccountsNoALTGEN.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DistacctTransferAccountsNoALTGEN : IDistacctTransferAccountsNoALTGEN
	{
		readonly IApplicationDB appDB;

		public DistacctTransferAccountsNoALTGEN(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public (int? ReturnCode,
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
			string Infobar)
		{
			RowPointerType _DistacctRowPointer = DistacctRowPointer;
			ListYesNoType _TransferInv = TransferInv;
			ListYesNoType _TransferLbr = TransferLbr;
			ListYesNoType _TransferFovhd = TransferFovhd;
			ListYesNoType _TransferVovhd = TransferVovhd;
			ListYesNoType _TransferOut = TransferOut;
			ListYesNoType _TransferInvInproc = TransferInvInproc;
			ListYesNoType _TransferLbrInproc = TransferLbrInproc;
			ListYesNoType _TransferFovhdInproc = TransferFovhdInproc;
			ListYesNoType _TransferVovhdInproc = TransferVovhdInproc;
			ListYesNoType _TransferOutInproc = TransferOutInproc;
			LocTypeType _LocType = LocType;
			InfobarType _Infobar = Infobar;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DistacctTransferAccountsNoALTGENSp";

				appDB.AddCommandParameter(cmd, "DistacctRowPointer", _DistacctRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferInv", _TransferInv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferLbr", _TransferLbr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferFovhd", _TransferFovhd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferVovhd", _TransferVovhd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferOut", _TransferOut, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferInvInproc", _TransferInvInproc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferLbrInproc", _TransferLbrInproc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferFovhdInproc", _TransferFovhdInproc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferVovhdInproc", _TransferVovhdInproc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferOutInproc", _TransferOutInproc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocType", _LocType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

				var Severity = appDB.ExecuteNonQuery(cmd);

				Infobar = _Infobar;

				return (Severity, Infobar);
			}
		}
	}
}
