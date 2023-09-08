//PROJECT NAME: Production
//CLASS NAME: ProjJlabr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjJlabr : IProjJlabr
	{
		readonly IApplicationDB appDB;
		
		public ProjJlabr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string PCostCode,
			string Infobar) ProjJlabrSp(
			string PProjNum,
			int? PTaskNum,
			string PCostCode,
			string PUnit1,
			string PUnit2,
			Guid? SJobtranRowPointer,
			Guid? SWcRowPointer,
			Guid? MatltranRowPointer,
			string ControlPrefix,
			string ControlSite,
			int? ControlYear,
			int? ControlPeriod,
			decimal? ControlNumber,
			string Infobar)
		{
			ProjNumType _PProjNum = PProjNum;
			TaskNumType _PTaskNum = PTaskNum;
			CostCodeType _PCostCode = PCostCode;
			UnitCode1Type _PUnit1 = PUnit1;
			UnitCode2Type _PUnit2 = PUnit2;
			RowPointerType _SJobtranRowPointer = SJobtranRowPointer;
			RowPointerType _SWcRowPointer = SWcRowPointer;
			RowPointerType _MatltranRowPointer = MatltranRowPointer;
			JourControlPrefixType _ControlPrefix = ControlPrefix;
			SiteType _ControlSite = ControlSite;
			FiscalYearType _ControlYear = ControlYear;
			FinPeriodType _ControlPeriod = ControlPeriod;
			LastTranType _ControlNumber = ControlNumber;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjJlabrSp";
				
				appDB.AddCommandParameter(cmd, "PProjNum", _PProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaskNum", _PTaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCostCode", _PCostCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PUnit1", _PUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUnit2", _PUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SJobtranRowPointer", _SJobtranRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SWcRowPointer", _SWcRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatltranRowPointer", _MatltranRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPrefix", _ControlPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlSite", _ControlSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlYear", _ControlYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPeriod", _ControlPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlNumber", _ControlNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PCostCode = _PCostCode;
				Infobar = _Infobar;
				
				return (Severity, PCostCode, Infobar);
			}
		}
	}
}
