//PROJECT NAME: Finance
//CLASS NAME: UpdateUnitToDepr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class UpdateUnitToDepr : IUpdateUnitToDepr
	{
		readonly IApplicationDB appDB;
		
		
		public UpdateUnitToDepr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? UpdateUnitsToDepr,
		string Infobar) UpdateUnitToDeprSp(string FaNum,
		int? UsefulLife,
		int? UsefulLifeMonth,
		int? UpdateUnitsToDepr,
		string Infobar)
		{
			FaNumType _FaNum = FaNum;
			FaUsefulLifeType _UsefulLife = UsefulLife;
			FaUsefulLifeType _UsefulLifeMonth = UsefulLifeMonth;
			ListYesNoType _UpdateUnitsToDepr = UpdateUnitsToDepr;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdateUnitToDeprSp";
				
				appDB.AddCommandParameter(cmd, "FaNum", _FaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UsefulLife", _UsefulLife, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UsefulLifeMonth", _UsefulLifeMonth, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UpdateUnitsToDepr", _UpdateUnitsToDepr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				UpdateUnitsToDepr = _UpdateUnitsToDepr;
				Infobar = _Infobar;
				
				return (Severity, UpdateUnitsToDepr, Infobar);
			}
		}
	}
}
