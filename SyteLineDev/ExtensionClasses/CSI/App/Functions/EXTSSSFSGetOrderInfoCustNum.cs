//PROJECT NAME: Data
//CLASS NAME: EXTSSSFSGetOrderInfoCustNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EXTSSSFSGetOrderInfoCustNum : IEXTSSSFSGetOrderInfoCustNum
	{
		readonly IApplicationDB appDB;
		
		public EXTSSSFSGetOrderInfoCustNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string EXTSSSFSGetOrderInfoCustNumFn(
			string OrdNum)
		{
			CoProjTrnNumType _OrdNum = OrdNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[EXTSSSFSGetOrderInfoCustNum](@OrdNum)";
				
				appDB.AddCommandParameter(cmd, "OrdNum", _OrdNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
