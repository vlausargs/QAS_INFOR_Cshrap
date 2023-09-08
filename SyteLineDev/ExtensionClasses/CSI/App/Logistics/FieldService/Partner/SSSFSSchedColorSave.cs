//PROJECT NAME: CSIFSPlusPartner
//CLASS NAME: SSSFSSchedColorSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public interface ISSSFSSchedColorSave
	{
		int SSSFSSchedColorSaveSp(string RefType,
		                          string RefNum,
		                          int? BackColor,
		                          int? ForeColor);
	}
	
	public class SSSFSSchedColorSave : ISSSFSSchedColorSave
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSchedColorSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSSchedColorSaveSp(string RefType,
		                                 string RefNum,
		                                 int? BackColor,
		                                 int? ForeColor)
		{
			StringType _RefType = RefType;
			StringType _RefNum = RefNum;
			IntType _BackColor = BackColor;
			IntType _ForeColor = ForeColor;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSchedColorSaveSp";
				
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BackColor", _BackColor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ForeColor", _ForeColor, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return Severity;
			}
		}
	}
}
