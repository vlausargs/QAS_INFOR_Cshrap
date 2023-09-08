//PROJECT NAME: Material
//CLASS NAME: MrpParmChkLowSet.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class MrpParmChkLowSet : IMrpParmChkLowSet
	{
		readonly IApplicationDB appDB;
		
		
		public MrpParmChkLowSet(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? MrpParmChkLowSetSp(int? ChkLow)
		{
			ListYesNoType _ChkLow = ChkLow;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MrpParmChkLowSetSp";
				
				appDB.AddCommandParameter(cmd, "ChkLow", _ChkLow, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
