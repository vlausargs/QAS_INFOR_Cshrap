//PROJECT NAME: Reporting
//CLASS NAME: WBCanInventoryTurnsGetRecs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting.CriticalNumber
{
	public class WBCanInventoryTurnsGetRecs : IWBCanInventoryTurnsGetRecs
	{
		readonly IApplicationDB appDB;
		
		public WBCanInventoryTurnsGetRecs(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? WBCanInventoryTurnsGetRecsSp(
			int? KPINum,
			DateTime? AsOfDate,
			string Item = null,
			string Whse = null,
			string ProductCode = null,
			string FamilyCode = null)
		{
			WBKPINumType _KPINum = KPINum;
			DateType _AsOfDate = AsOfDate;
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			ProductCodeType _ProductCode = ProductCode;
			FamilyCodeType _FamilyCode = FamilyCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "WBCanInventoryTurnsGetRecsSp";
				
				appDB.AddCommandParameter(cmd, "KPINum", _KPINum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AsOfDate", _AsOfDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCode", _ProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FamilyCode", _FamilyCode, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
