//PROJECT NAME: Production
//CLASS NAME: ApsCalcSubJobDates.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class ApsCalcSubJobDates : IApsCalcSubJobDates
	{
		readonly IApplicationDB appDB;
		
		
		public ApsCalcSubJobDates(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? ApsCalcSubJobDates) ApsCalcSubJobDatesSp(int? ApsCalcSubJobDates)
		{
			SmallintType _ApsCalcSubJobDates = ApsCalcSubJobDates;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsCalcSubJobDatesSp";
				
				appDB.AddCommandParameter(cmd, "ApsCalcSubJobDates", _ApsCalcSubJobDates, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ApsCalcSubJobDates = _ApsCalcSubJobDates;
				
				return (Severity, ApsCalcSubJobDates);
			}
		}

		public int? ApsCalcSubJobDatesFn()
		{

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsCalcSubJobDatesSp]()";

				var Output = appDB.ExecuteNonQuery(cmd);

				return Output;
			}
		}
	}
}
