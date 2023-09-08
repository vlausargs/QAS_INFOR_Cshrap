//PROJECT NAME: Logistics
//CLASS NAME: SSSFSContractValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSContractValid : ISSSFSContractValid
	{
		readonly IApplicationDB appDB;
		
		public SSSFSContractValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSContractValidFn(
			string Contract,
			int? ContLine,
			DateTime? TestDate)
		{
			FSContractType _Contract = Contract;
			FSContLineType _ContLine = ContLine;
			DateType _TestDate = TestDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSContractValid](@Contract, @ContLine, @TestDate)";
				
				appDB.AddCommandParameter(cmd, "Contract", _Contract, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContLine", _ContLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TestDate", _TestDate, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
