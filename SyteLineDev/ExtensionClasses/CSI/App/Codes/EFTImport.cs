//PROJECT NAME: CSICodes
//CLASS NAME: EFTImport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
	public interface IEFTImport
	{
		int EFTImportSp(string MapId,
		                string FileName,
		                string FileContent,
		                int? TaskId,
		                ref string Infobar);
	}
	
	public class EFTImport : IEFTImport
	{
		readonly IApplicationDB appDB;
		
		public EFTImport(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int EFTImportSp(string MapId,
		                       string FileName,
		                       string FileContent,
		                       int? TaskId,
		                       ref string Infobar)
		{
			EFTMappingIdType _MapId = MapId;
			NameType _FileName = FileName;
			VeryLongListType _FileContent = FileContent;
			TaskNumType _TaskId = TaskId;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EFTImportSp";
				
				appDB.AddCommandParameter(cmd, "MapId", _MapId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FileName", _FileName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FileContent", _FileContent, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
