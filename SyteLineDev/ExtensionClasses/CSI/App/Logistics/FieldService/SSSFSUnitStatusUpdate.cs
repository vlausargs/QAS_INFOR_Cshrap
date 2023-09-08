//PROJECT NAME: Logistics
//CLASS NAME: SSSFSUnitStatusUpdate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSUnitStatusUpdate : ISSSFSUnitStatusUpdate
	{
		readonly IApplicationDB appDB;
		
		public SSSFSUnitStatusUpdate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSFSUnitStatusUpdateSp(
			string SerNum,
			string RefType,
			string RefNum,
			string UnitStatCode,
			string Infobar,
			DateTime? StatDate = null,
			string Item = null)
		{
			SerNumType _SerNum = SerNum;
			FSRefTypeNSUType _RefType = RefType;
			FSRefNumType _RefNum = RefNum;
			FSUnitStatCodeType _UnitStatCode = UnitStatCode;
			Infobar _Infobar = Infobar;
			DateType _StatDate = StatDate;
			ItemType _Item = Item;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSUnitStatusUpdateSp";
				
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitStatCode", _UnitStatCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StatDate", _StatDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
