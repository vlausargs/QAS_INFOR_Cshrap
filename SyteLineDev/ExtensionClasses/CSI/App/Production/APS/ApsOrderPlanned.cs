//PROJECT NAME: Production
//CLASS NAME: ApsOrderPlanned.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsOrderPlanned : IApsOrderPlanned
	{
		readonly IApplicationDB appDB;
		
		public ApsOrderPlanned(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsOrderPlannedSp(
			int? AltNo,
			string Item)
		{
			ShortType _AltNo = AltNo;
			ApsMaxIDType _Item = Item;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsOrderPlannedSp";
				
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
