//PROJECT NAME: Finance
//CLASS NAME: CHSDetailLeftOverGenAcctUnit.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Chinese
{
	public class CHSDetailLeftOverGenAcctUnit : ICHSDetailLeftOverGenAcctUnit
	{
		readonly IApplicationDB appDB;
		
		public CHSDetailLeftOverGenAcctUnit(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CHSDetailLeftOverGenAcctUnitSP(
			DateTime? PEndDate)
		{
			DateType _PEndDate = PEndDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CHSDetailLeftOverGenAcctUnitSP";
				
				appDB.AddCommandParameter(cmd, "PEndDate", _PEndDate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
