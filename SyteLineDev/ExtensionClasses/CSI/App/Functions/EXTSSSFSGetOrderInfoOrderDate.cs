//PROJECT NAME: Data
//CLASS NAME: EXTSSSFSGetOrderInfoOrderDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EXTSSSFSGetOrderInfoOrderDate : IEXTSSSFSGetOrderInfoOrderDate
	{
		readonly IApplicationDB appDB;
		
		public EXTSSSFSGetOrderInfoOrderDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public DateTime? EXTSSSFSGetOrderInfoOrderDateFn(
			string OrdNum)
		{
			CoProjTrnNumType _OrdNum = OrdNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[EXTSSSFSGetOrderInfoOrderDate](@OrdNum)";
				
				appDB.AddCommandParameter(cmd, "OrdNum", _OrdNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<DateTime?>(cmd);
				
				return Output;
			}
		}
	}
}
