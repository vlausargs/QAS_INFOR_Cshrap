//PROJECT NAME: Production
//CLASS NAME: ApsJobmatlEffDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsJobmatlEffDate : IApsJobmatlEffDate
	{
		readonly IApplicationDB appDB;
		
		public ApsJobmatlEffDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public DateTime? ApsJobmatlEffDateFn(
			DateTime? PriEffDate,
			DateTime? AltEffDate)
		{
			DateType _PriEffDate = PriEffDate;
			DateType _AltEffDate = AltEffDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsJobmatlEffDate](@PriEffDate, @AltEffDate)";
				
				appDB.AddCommandParameter(cmd, "PriEffDate", _PriEffDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltEffDate", _AltEffDate, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<DateTime?>(cmd);
				
				return Output;
			}
		}
	}
}
