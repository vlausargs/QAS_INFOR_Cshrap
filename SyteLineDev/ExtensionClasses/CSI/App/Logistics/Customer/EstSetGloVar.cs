//PROJECT NAME: Logistics
//CLASS NAME: EstSetGloVar.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class EstSetGloVar : IEstSetGloVar
	{
		readonly IApplicationDB appDB;
		
		
		public EstSetGloVar(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? EstSetGloVarSp(int? EstSetLineStat)
		{
			ListYesNoType _EstSetLineStat = EstSetLineStat;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EstSetGloVarSp";
				
				appDB.AddCommandParameter(cmd, "EstSetLineStat", _EstSetLineStat, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
