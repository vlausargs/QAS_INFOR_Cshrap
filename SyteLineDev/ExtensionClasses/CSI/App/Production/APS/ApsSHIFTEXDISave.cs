//PROJECT NAME: Production
//CLASS NAME: ApsSHIFTEXDISave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsSHIFTEXDISave : IApsSHIFTEXDISave
	{
		readonly IApplicationDB appDB;
		
		
		public ApsSHIFTEXDISave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsSHIFTEXDISaveSp(int? InsertFlag,
		int? AltNo,
		string SHIFTEXID,
		string DESCR,
		string SHIFTID,
		string TYPECD,
		string RESORTYPE,
		DateTime? STARTDATE,
		DateTime? ENDDATE,
		string WORKFG)
		{
			ListYesNoType _InsertFlag = InsertFlag;
			ApsAltNoType _AltNo = AltNo;
			ApsShiftexType _SHIFTEXID = SHIFTEXID;
			ApsDescriptType _DESCR = DESCR;
			ApsShiftType _SHIFTID = SHIFTID;
			ApsShiftexTypeCodeType _TYPECD = TYPECD;
			ApsRestypeType _RESORTYPE = RESORTYPE;
			DateTimeType _STARTDATE = STARTDATE;
			DateTimeType _ENDDATE = ENDDATE;
			ApsFlagType _WORKFG = WORKFG;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsSHIFTEXDISaveSp";
				
				appDB.AddCommandParameter(cmd, "InsertFlag", _InsertFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SHIFTEXID", _SHIFTEXID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DESCR", _DESCR, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SHIFTID", _SHIFTID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TYPECD", _TYPECD, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RESORTYPE", _RESORTYPE, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "STARTDATE", _STARTDATE, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ENDDATE", _ENDDATE, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WORKFG", _WORKFG, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
