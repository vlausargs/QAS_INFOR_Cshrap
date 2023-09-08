//PROJECT NAME: Production
//CLASS NAME: PmfIsNumeric.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfIsNumeric : IPmfIsNumeric
	{
		readonly IApplicationDB appDB;
		
		public PmfIsNumeric(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public bool? PmfIsNumericFn(
			string num)
		{
			StringType _num = num;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[PmfIsNumeric](@num)";
				
				appDB.AddCommandParameter(cmd, "num", _num, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<bool?>(cmd);
				
				return Output;
			}
		}
	}
}
