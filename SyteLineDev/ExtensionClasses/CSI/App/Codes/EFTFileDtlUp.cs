//PROJECT NAME: CSICodes
//CLASS NAME: EFTFileDtlUp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
	public interface IEFTFileDtlUp
	{
		int EFTFileDtlUpSp(string FileName,
		                   int? Sequence,
		                   byte? BankRecon,
		                   ref string Infobar);
	}
	
	public class EFTFileDtlUp : IEFTFileDtlUp
	{
		readonly IApplicationDB appDB;
		
		public EFTFileDtlUp(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int EFTFileDtlUpSp(string FileName,
		                          int? Sequence,
		                          byte? BankRecon,
		                          ref string Infobar)
		{
			EFTFileNameType _FileName = FileName;
			IntType _Sequence = Sequence;
			ListYesNoType _BankRecon = BankRecon;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EFTFileDtlUpSp";
				
				appDB.AddCommandParameter(cmd, "FileName", _FileName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Sequence", _Sequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BankRecon", _BankRecon, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
