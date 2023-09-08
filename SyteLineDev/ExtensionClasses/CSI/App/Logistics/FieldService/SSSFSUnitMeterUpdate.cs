//PROJECT NAME: Logistics
//CLASS NAME: SSSFSUnitMeterUpdate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSUnitMeterUpdate : ISSSFSUnitMeterUpdate
	{
		readonly IApplicationDB appDB;
		
		public SSSFSUnitMeterUpdate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSFSUnitMeterUpdateSp(
			string SerNum,
			string RefType,
			string RefNum,
			int? MeterAmt,
			string Infobar,
			string Item)
		{
			SerNumType _SerNum = SerNum;
			FSRefTypeNSUType _RefType = RefType;
			FSRefNumType _RefNum = RefNum;
			FSMeterAmtType _MeterAmt = MeterAmt;
			Infobar _Infobar = Infobar;
			ItemType _Item = Item;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSUnitMeterUpdateSp";
				
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MeterAmt", _MeterAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
