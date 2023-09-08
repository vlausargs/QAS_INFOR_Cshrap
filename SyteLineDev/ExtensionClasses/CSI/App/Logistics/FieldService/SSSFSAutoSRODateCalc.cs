//PROJECT NAME: Logistics
//CLASS NAME: SSSFSAutoSRODateCalc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSAutoSRODateCalc : ISSSFSAutoSRODateCalc
	{
		readonly IApplicationDB appDB;
		
		public SSSFSAutoSRODateCalc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			DateTime? _oStartDate,
			string Infobar) SSSFSAutoSRODateCalcSp(
			DateTime? _iDate,
			int? _iFrequency,
			int? _iFreqUnits,
			int? _iDirection,
			DateTime? _oStartDate,
			string Infobar)
		{
			GenericDateType __iDate = _iDate;
			GenericIntType __iFrequency = _iFrequency;
			GenericIntType __iFreqUnits = _iFreqUnits;
			GenericIntType __iDirection = _iDirection;
			GenericDate __oStartDate = _oStartDate;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSAutoSRODateCalcSp";
				
				appDB.AddCommandParameter(cmd, "_iDate", __iDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "_iFrequency", __iFrequency, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "_iFreqUnits", __iFreqUnits, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "_iDirection", __iDirection, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "_oStartDate", __oStartDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				_oStartDate = __oStartDate;
				Infobar = _Infobar;
				
				return (Severity, _oStartDate, Infobar);
			}
		}
	}
}
