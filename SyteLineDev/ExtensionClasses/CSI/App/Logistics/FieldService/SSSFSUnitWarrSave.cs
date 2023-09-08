//PROJECT NAME: Logistics
//CLASS NAME: SSSFSUnitWarrSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSUnitWarrSave : ISSSFSUnitWarrSave
	{
		readonly IApplicationDB appDB;
		
		
		public SSSFSUnitWarrSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SSSFSUnitWarrSaveSp(int? CompId,
		string WarrCode,
		DateTime? StartDate,
		DateTime? EndDate,
		int? StartMeterAmt,
		int? EndMeterAmt,
		string Infobar)
		{
			FSCompIdType _CompId = CompId;
			FSWarrCodeType _WarrCode = WarrCode;
			DateType _StartDate = StartDate;
			DateType _EndDate = EndDate;
			FSMeterAmtType _StartMeterAmt = StartMeterAmt;
			FSMeterAmtType _EndMeterAmt = EndMeterAmt;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSUnitWarrSaveSp";
				
				appDB.AddCommandParameter(cmd, "CompId", _CompId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WarrCode", _WarrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartMeterAmt", _StartMeterAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndMeterAmt", _EndMeterAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
