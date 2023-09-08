//PROJECT NAME: Data
//CLASS NAME: VATAcctTransfer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class VATAcctTransfer : IVATAcctTransfer
	{
		readonly IApplicationDB appDB;
		
		public VATAcctTransfer(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) VATAcctTransferSp(
			string BankCode,
			Guid? RowPointer,
			string Infobar)
		{
			BankCodeType _BankCode = BankCode;
			RowPointerType _RowPointer = RowPointer;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VATAcctTransferSp";
				
				appDB.AddCommandParameter(cmd, "BankCode", _BankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
