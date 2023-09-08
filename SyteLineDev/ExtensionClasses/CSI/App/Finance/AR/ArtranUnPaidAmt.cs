//PROJECT NAME: Finance
//CLASS NAME: ArtranUnPaidAmt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AR
{
	public class ArtranUnPaidAmt : IArtranUnPaidAmt
	{
		readonly IApplicationDB appDB;
		
		public ArtranUnPaidAmt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? ArtranUnPaidAmtFn(
			string CustNum,
			string InvNum,
			string SiteRef)
		{
			CustNumType _CustNum = CustNum;
			InvNumType _InvNum = InvNum;
			SiteType _SiteRef = SiteRef;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ArtranUnPaidAmt](@CustNum, @InvNum, @SiteRef)";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
