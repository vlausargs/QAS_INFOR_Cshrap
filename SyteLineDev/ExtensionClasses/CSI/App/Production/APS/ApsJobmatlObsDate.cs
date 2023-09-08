//PROJECT NAME: Production
//CLASS NAME: ApsJobmatlObsDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsJobmatlObsDate : IApsJobmatlObsDate
	{
		readonly IApplicationDB appDB;
		
		public ApsJobmatlObsDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public DateTime? ApsJobmatlObsDateFn(
			DateTime? PriObsDate,
			DateTime? AltObsDate)
		{
			DateType _PriObsDate = PriObsDate;
			DateType _AltObsDate = AltObsDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsJobmatlObsDate](@PriObsDate, @AltObsDate)";
				
				appDB.AddCommandParameter(cmd, "PriObsDate", _PriObsDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltObsDate", _AltObsDate, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<DateTime?>(cmd);
				
				return Output;
			}
		}
	}
}
