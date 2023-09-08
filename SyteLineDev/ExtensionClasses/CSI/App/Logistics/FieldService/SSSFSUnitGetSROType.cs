//PROJECT NAME: CSIFSPlusUnit
//CLASS NAME: SSSFSUnitGetSROType.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSUnitGetSROType
	{
		int SSSFSUnitGetSROTypeSp(string iSRONum,
		                          string iSROType,
		                          ref string PromptMsgBadType,
		                          ref string Infobar);
	}
	
	public class SSSFSUnitGetSROType : ISSSFSUnitGetSROType
	{
		readonly IApplicationDB appDB;
		
		public SSSFSUnitGetSROType(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSUnitGetSROTypeSp(string iSRONum,
		                                 string iSROType,
		                                 ref string PromptMsgBadType,
		                                 ref string Infobar)
		{
			FSSRONumType _iSRONum = iSRONum;
			FSSROTypeType _iSROType = iSROType;
			Infobar _PromptMsgBadType = PromptMsgBadType;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSUnitGetSROTypeSp";
				
				appDB.AddCommandParameter(cmd, "iSRONum", _iSRONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSROType", _iSROType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptMsgBadType", _PromptMsgBadType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PromptMsgBadType = _PromptMsgBadType;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
