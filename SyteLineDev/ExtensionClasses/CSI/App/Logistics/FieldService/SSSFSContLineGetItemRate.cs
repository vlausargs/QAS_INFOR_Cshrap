//PROJECT NAME: Logistics
//CLASS NAME: SSSFSContLineGetItemRate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSContLineGetItemRate : ISSSFSContLineGetItemRate
	{
		readonly IApplicationDB appDB;
		
		
		public SSSFSContLineGetItemRate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? Rate,
		decimal? MeterRate,
		int? MeterAllow,
		decimal? ProrateRate,
		DateTime? DueDate,
		DateTime? MinBillThru,
		string ProrateUnitOfRate,
		string Infobar) SSSFSContLineGetItemRateSp(string Contract,
		string Item,
		string UnitOfRate,
		DateTime? StartDate = null,
		decimal? Rate = null,
		decimal? MeterRate = null,
		int? MeterAllow = null,
		decimal? ProrateRate = null,
		DateTime? DueDate = null,
		DateTime? MinBillThru = null,
		string ProrateUnitOfRate = null,
		string Infobar = null)
		{
			FSContractType _Contract = Contract;
			ItemType _Item = Item;
			FSContUnitOfRateType _UnitOfRate = UnitOfRate;
			DateTimeType _StartDate = StartDate;
			CostPrcType _Rate = Rate;
			CostPrcType _MeterRate = MeterRate;
			FSMeterAmtType _MeterAllow = MeterAllow;
			CostPrcType _ProrateRate = ProrateRate;
			DateTimeType _DueDate = DueDate;
			DateType _MinBillThru = MinBillThru;
			FSContUnitOfRateType _ProrateUnitOfRate = ProrateUnitOfRate;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSContLineGetItemRateSp";
				
				appDB.AddCommandParameter(cmd, "Contract", _Contract, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitOfRate", _UnitOfRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Rate", _Rate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MeterRate", _MeterRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MeterAllow", _MeterAllow, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProrateRate", _ProrateRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MinBillThru", _MinBillThru, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProrateUnitOfRate", _ProrateUnitOfRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Rate = _Rate;
				MeterRate = _MeterRate;
				MeterAllow = _MeterAllow;
				ProrateRate = _ProrateRate;
				DueDate = _DueDate;
				MinBillThru = _MinBillThru;
				ProrateUnitOfRate = _ProrateUnitOfRate;
				Infobar = _Infobar;
				
				return (Severity, Rate, MeterRate, MeterAllow, ProrateRate, DueDate, MinBillThru, ProrateUnitOfRate, Infobar);
			}
		}
	}
}
