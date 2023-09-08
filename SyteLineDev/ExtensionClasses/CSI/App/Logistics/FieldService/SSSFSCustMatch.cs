//PROJECT NAME: Logistics
//CLASS NAME: SSSFSCustMatch.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSCustMatch : ISSSFSCustMatch
	{
		readonly IApplicationDB appDB;
		
		public SSSFSCustMatch(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSCustMatchFn(
			string CustNum,
			string SroCustNum,
			string OperCustNum)
		{
			CustNumType _CustNum = CustNum;
			CustNumType _SroCustNum = SroCustNum;
			CustNumType _OperCustNum = OperCustNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSCustMatch](@CustNum, @SroCustNum, @OperCustNum)";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroCustNum", _SroCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperCustNum", _OperCustNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
