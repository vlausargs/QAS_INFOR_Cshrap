//PROJECT NAME: Production
//CLASS NAME: Rpt_RSQC_VRMAPackSlip.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class Rpt_RSQC_VRMAPackSlip : IRpt_RSQC_VRMAPackSlip
	{
		readonly IApplicationDB appDB;
		
		
		public Rpt_RSQC_VRMAPackSlip(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? Rpt_RSQC_VRMAPackSlipSp(int? Vrma = null,
		decimal? Qty = null,
		int? PrintInternal = null,
		int? PrintExternal = null)
		{
			QCRcvrNumType _Vrma = Vrma;
			QtyUnitType _Qty = Qty;
			FlagNyType _PrintInternal = PrintInternal;
			FlagNyType _PrintExternal = PrintExternal;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_RSQC_VRMAPackSlipSp";
				
				appDB.AddCommandParameter(cmd, "Vrma", _Vrma, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintInternal", _PrintInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintExternal", _PrintExternal, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
