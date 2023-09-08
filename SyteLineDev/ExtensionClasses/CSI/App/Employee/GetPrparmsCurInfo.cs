//PROJECT NAME: CSIEmployee
//CLASS NAME: GetPrparmsCurInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public interface IGetPrparmsCurInfo
	{
		(int? ReturnCode, DateTime? PrparmsCurStart, DateTime? PrparmsCurEnd) GetPrparmsCurInfoSp(DateTime? PrparmsCurStart = null,
		DateTime? PrparmsCurEnd = null);
	}
	
	public class GetPrparmsCurInfo : IGetPrparmsCurInfo
	{
		readonly IApplicationDB appDB;
		
		public GetPrparmsCurInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, DateTime? PrparmsCurStart, DateTime? PrparmsCurEnd) GetPrparmsCurInfoSp(DateTime? PrparmsCurStart = null,
		DateTime? PrparmsCurEnd = null)
		{
			DateType _PrparmsCurStart = PrparmsCurStart;
			DateType _PrparmsCurEnd = PrparmsCurEnd;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetPrparmsCurInfoSp";
				
				appDB.AddCommandParameter(cmd, "PrparmsCurStart", _PrparmsCurStart, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrparmsCurEnd", _PrparmsCurEnd, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PrparmsCurStart = _PrparmsCurStart;
				PrparmsCurEnd = _PrparmsCurEnd;
				
				return (Severity, PrparmsCurStart, PrparmsCurEnd);
			}
		}
	}
}
