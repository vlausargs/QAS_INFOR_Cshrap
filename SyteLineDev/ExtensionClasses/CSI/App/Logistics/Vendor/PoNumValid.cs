//PROJECT NAME: Logistics
//CLASS NAME: PoNumValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class PoNumValid : IPoNumValid
	{
		readonly IApplicationDB appDB;
		
		
		public PoNumValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string OutType) PoNumValidSp(string PoNum,
		string OutType)
		{
			PoNumType _PoNum = PoNum;
			StringType _OutType = OutType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PoNumValidSp";
				
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OutType", _OutType, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				OutType = _OutType;
				
				return (Severity, OutType);
			}
		}
	}
}
