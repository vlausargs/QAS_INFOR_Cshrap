//PROJECT NAME: Finance
//CLASS NAME: ArpmtdGetUpdateRate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AR
{
	public class ArpmtdGetUpdateRate : IArpmtdGetUpdateRate
	{
		readonly IApplicationDB appDB;
		
		public ArpmtdGetUpdateRate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ArpmtdGetUpdateRateFn(
			string PArpmtdSite,
			string PArpmtdType,
			string PArpmtCustNum,
			string PArpmtdInvNum)
		{
			SiteType _PArpmtdSite = PArpmtdSite;
			StringType _PArpmtdType = PArpmtdType;
			CustNumType _PArpmtCustNum = PArpmtCustNum;
			InvNumType _PArpmtdInvNum = PArpmtdInvNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ArpmtdGetUpdateRate](@PArpmtdSite, @PArpmtdType, @PArpmtCustNum, @PArpmtdInvNum)";
				
				appDB.AddCommandParameter(cmd, "PArpmtdSite", _PArpmtdSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtdType", _PArpmtdType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtCustNum", _PArpmtCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtdInvNum", _PArpmtdInvNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
