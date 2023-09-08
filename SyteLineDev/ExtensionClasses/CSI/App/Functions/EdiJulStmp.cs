//PROJECT NAME: Data
//CLASS NAME: EdiJulStmp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EdiJulStmp : IEdiJulStmp
	{
		readonly IApplicationDB appDB;
		
		public EdiJulStmp(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string EdiJulStmpFn(
			DateTime? Date)
		{
			DateType _Date = Date;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[EdiJulStmp](@Date)";
				
				appDB.AddCommandParameter(cmd, "Date", _Date, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
