//PROJECT NAME: Material
//CLASS NAME: BolItemSetGloVar.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class BolItemSetGloVar : IBolItemSetGloVar
	{
		readonly IApplicationDB appDB;
		
		
		public BolItemSetGloVar(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? BolItemSetGloVarSp(int? UpdateASNWeight,
		int? UpdateASNCharges)
		{
			ListYesNoType _UpdateASNWeight = UpdateASNWeight;
			ListYesNoType _UpdateASNCharges = UpdateASNCharges;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "BolItemSetGloVarSp";
				
				appDB.AddCommandParameter(cmd, "UpdateASNWeight", _UpdateASNWeight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UpdateASNCharges", _UpdateASNCharges, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
