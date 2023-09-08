//PROJECT NAME: Finance
//CLASS NAME: ArpmtGetCrossSiteDist.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AR
{
	public class ArpmtGetCrossSiteDist : IArpmtGetCrossSiteDist
	{
		readonly IApplicationDB appDB;
		
		public ArpmtGetCrossSiteDist(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ArpmtGetCrossSiteDistFn(
			string PBank,
			string PCustNum,
			string PType,
			int? PCheckNum)
		{
			BankCodeType _PBank = PBank;
			CustNumType _PCustNum = PCustNum;
			ArpmtTypeType _PType = PType;
			ArCheckNumType _PCheckNum = PCheckNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ArpmtGetCrossSiteDist](@PBank, @PCustNum, @PType, @PCheckNum)";
				
				appDB.AddCommandParameter(cmd, "PBank", _PBank, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCheckNum", _PCheckNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
