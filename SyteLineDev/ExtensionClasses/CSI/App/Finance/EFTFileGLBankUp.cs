//PROJECT NAME: Finance
//CLASS NAME: EFTFileGLBankUp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class EFTFileGLBankUp : IEFTFileGLBankUp
	{
		readonly IApplicationDB appDB;
		
		
		public EFTFileGLBankUp(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) EFTFileGLBankUpSp(int? BankRecon,
		Guid? RowPointer,
		string Infobar)
		{
			ListYesNoType _BankRecon = BankRecon;
			RowPointerType _RowPointer = RowPointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EFTFileGLBankUpSp";
				
				appDB.AddCommandParameter(cmd, "BankRecon", _BankRecon, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
