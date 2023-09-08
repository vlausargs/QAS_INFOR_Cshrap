//PROJECT NAME: CSIProduct
//CLASS NAME: CalcSubJobDates.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
	public interface ICalcSubJobDates
	{
		int CalcSubJobDatesSp(ref byte? CalcBOMSubJobDates);
		int? CalcSubJobDatesFn();
	}
	
	public class CalcSubJobDates : ICalcSubJobDates
	{
		readonly IApplicationDB appDB;
		
		public CalcSubJobDates(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CalcSubJobDatesSp(ref byte? CalcBOMSubJobDates)
		{
			ListYesNoType _CalcBOMSubJobDates = CalcBOMSubJobDates;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CalcSubJobDatesSp";
				
				appDB.AddCommandParameter(cmd, "CalcBOMSubJobDates", _CalcBOMSubJobDates, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CalcBOMSubJobDates = _CalcBOMSubJobDates;
				
				return Severity;
			}
		}

		public int? CalcSubJobDatesFn()
		{

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[CalcSubJobDates]()";

				var Output = appDB.ExecuteScalar<int?>(cmd);

				return Output;
			}
		}
	}
}
