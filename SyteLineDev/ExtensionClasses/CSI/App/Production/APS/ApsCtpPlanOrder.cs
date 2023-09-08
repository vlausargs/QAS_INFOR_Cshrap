//PROJECT NAME: Production
//CLASS NAME: ApsCtpPlanOrder.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsCtpPlanOrder : IApsCtpPlanOrder
	{
		readonly IApplicationDB appDB;
		
		
		public ApsCtpPlanOrder(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsCtpPlanOrderSp(string PSite,
		string POrder,
		int? AltNo)
		{
			SiteType _PSite = PSite;
			ApsOrderType _POrder = POrder;
			ApsAltNoType _AltNo = AltNo;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsCtpPlanOrderSp";
				
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POrder", _POrder, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
