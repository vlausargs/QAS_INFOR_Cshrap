//PROJECT NAME: Production
//CLASS NAME: ShopCalendarUpdate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ShopCalendarUpdate : IShopCalendarUpdate
	{
		readonly IApplicationDB appDB;
		
		
		public ShopCalendarUpdate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ShopCalendarUpdateSp(string ShiftId,
		string Descr,
		int? AltNo)
		{
			ApsShiftType _ShiftId = ShiftId;
			ApsDescriptType _Descr = Descr;
			ApsAltNoType _AltNo = AltNo;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ShopCalendarUpdateSp";
				
				appDB.AddCommandParameter(cmd, "ShiftId", _ShiftId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Descr", _Descr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
