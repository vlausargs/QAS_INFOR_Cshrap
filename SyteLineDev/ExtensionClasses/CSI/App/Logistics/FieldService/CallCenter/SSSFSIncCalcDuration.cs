//PROJECT NAME: CSIFSPlusCallCenter
//CLASS NAME: SSSFSIncCalcDuration.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.CallCenter
{
	public interface ISSSFSIncCalcDuration
	{
		int SSSFSIncCalcDurationSp(string iIncNum,
		                           byte? iUpdateInc,
		                           ref decimal? oDuration,
		                           ref string oDurationUnits,
		                           ref string Infobar);
	}
	
	public class SSSFSIncCalcDuration : ISSSFSIncCalcDuration
	{
		readonly IApplicationDB appDB;
		
		public SSSFSIncCalcDuration(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSIncCalcDurationSp(string iIncNum,
		                                  byte? iUpdateInc,
		                                  ref decimal? oDuration,
		                                  ref string oDurationUnits,
		                                  ref string Infobar)
		{
			FSIncNumType _iIncNum = iIncNum;
			ListYesNoType _iUpdateInc = iUpdateInc;
			FixedHoursType _oDuration = oDuration;
			FSDurationTypeType _oDurationUnits = oDurationUnits;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSIncCalcDurationSp";
				
				appDB.AddCommandParameter(cmd, "iIncNum", _iIncNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iUpdateInc", _iUpdateInc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "oDuration", _oDuration, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oDurationUnits", _oDurationUnits, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				oDuration = _oDuration;
				oDurationUnits = _oDurationUnits;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
