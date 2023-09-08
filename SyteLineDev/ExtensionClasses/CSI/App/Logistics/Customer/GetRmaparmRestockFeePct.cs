//PROJECT NAME: CSICustomer
//CLASS NAME: GetRmaparmRestockFeePct.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IGetRmaparmRestockFeePct
	{
		int GetRmaparmRestockFeePctSp(ref decimal? RestockFeePct);
	}
	
	public class GetRmaparmRestockFeePct : IGetRmaparmRestockFeePct
	{
		readonly IApplicationDB appDB;
		
		public GetRmaparmRestockFeePct(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetRmaparmRestockFeePctSp(ref decimal? RestockFeePct)
		{
			RestockFeePercentType _RestockFeePct = RestockFeePct;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetRmaparmRestockFeePctSp";
				
				appDB.AddCommandParameter(cmd, "RestockFeePct", _RestockFeePct, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RestockFeePct = _RestockFeePct;
				
				return Severity;
			}
		}
	}
}
