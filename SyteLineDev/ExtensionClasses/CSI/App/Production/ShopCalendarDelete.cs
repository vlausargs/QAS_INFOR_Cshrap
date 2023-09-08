//PROJECT NAME: Production
//CLASS NAME: ShopCalendarDelete.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class ShopCalendarDelete : IShopCalendarDelete
	{
		readonly IApplicationDB appDB;
		
		
		public ShopCalendarDelete(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ShopCalendarDeleteSp(string ShiftId,
		int? AltNo,
		string Infobar)
		{
			ApsShiftType _ShiftId = ShiftId;
			ApsAltNoType _AltNo = AltNo;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ShopCalendarDeleteSp";
				
				appDB.AddCommandParameter(cmd, "ShiftId", _ShiftId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
