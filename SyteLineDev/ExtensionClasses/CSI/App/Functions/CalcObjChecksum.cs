//PROJECT NAME: Data
//CLASS NAME: CalcObjChecksum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CalcObjChecksum : ICalcObjChecksum
	{
		readonly IApplicationDB appDB;
		
		public CalcObjChecksum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CalcObjChecksumFn(
			string ObjectName)
		{
			StringType _ObjectName = ObjectName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[CalcObjChecksum](@ObjectName)";
				
				appDB.AddCommandParameter(cmd, "ObjectName", _ObjectName, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
