//PROJECT NAME: Data
//CLASS NAME: GetArAmountToPay.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetArAmountToPay : IGetArAmountToPay
	{
		readonly IApplicationDB appDB;
		
		public GetArAmountToPay(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? GetArAmountToPaySp(
			string CustNum,
			string InvNum,
			string Site = null)
		{
			CustNumType _CustNum = CustNum;
			InvNumType _InvNum = InvNum;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetArAmountToPaySp](@CustNum, @InvNum, @Site)";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
