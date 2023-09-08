//PROJECT NAME: Data
//CLASS NAME: SalespersonCodes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class SalespersonCodes : ISalespersonCodes
	{
		readonly IApplicationDB appDB;
		
		public SalespersonCodes(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string SalespersonCodesFn(
			string RefNum,
			int? Outside)
		{
			EmpVendNumType _RefNum = RefNum;
			ListYesNoType _Outside = Outside;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SalespersonCodes](@RefNum, @Outside)";
				
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Outside", _Outside, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
