//PROJECT NAME: CSICodes
//CLASS NAME: EFTMappedImportsDefineVar.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
	public interface IEFTMappedImportsDefineVar
	{
		int EFTMappedImportsDefineVarSp(string EFTFileName,
		                                string EFTMapId,
		                                string EFTReturnFormat,
		                                ref string Infobar);
	}
	
	public class EFTMappedImportsDefineVar : IEFTMappedImportsDefineVar
	{
		readonly IApplicationDB appDB;
		
		public EFTMappedImportsDefineVar(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int EFTMappedImportsDefineVarSp(string EFTFileName,
		                                       string EFTMapId,
		                                       string EFTReturnFormat,
		                                       ref string Infobar)
		{
			EFTFileNameType _EFTFileName = EFTFileName;
			EFTMappingIdType _EFTMapId = EFTMapId;
			LongListType _EFTReturnFormat = EFTReturnFormat;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EFTMappedImportsDefineVarSp";
				
				appDB.AddCommandParameter(cmd, "EFTFileName", _EFTFileName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EFTMapId", _EFTMapId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EFTReturnFormat", _EFTReturnFormat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
