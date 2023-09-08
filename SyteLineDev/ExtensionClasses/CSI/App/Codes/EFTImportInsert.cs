//PROJECT NAME: CSICodes
//CLASS NAME: EFTImportInsert.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
	public interface IEFTImportInsert
	{
		int EFTImportInsertSp(string FileName,
		                      string AppGroup,
		                      ref string Infobar);
	}
	
	public class EFTImportInsert : IEFTImportInsert
	{
		readonly IApplicationDB appDB;
		
		public EFTImportInsert(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int EFTImportInsertSp(string FileName,
		                             string AppGroup,
		                             ref string Infobar)
		{
			NameType _FileName = FileName;
			EFTBatchGroupType _AppGroup = AppGroup;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EFTImportInsertSp";
				
				appDB.AddCommandParameter(cmd, "FileName", _FileName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppGroup", _AppGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
