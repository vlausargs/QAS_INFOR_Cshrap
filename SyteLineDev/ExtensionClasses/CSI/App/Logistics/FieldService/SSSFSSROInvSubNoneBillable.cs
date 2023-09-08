//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROInvSubNoneBillable.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSROInvSubNoneBillable : ISSSFSSROInvSubNoneBillable
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROInvSubNoneBillable(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? OFoundNone,
			string Infobar) SSSFSSROInvSubNoneBillableSp(
			string PMode,
			int? InclBillHold,
			string OperationStatus = "I",
			string SRONum = null,
			string CustNum = null,
			int? StartSROLine = null,
			int? EndSROLine = null,
			int? StartSROOper = null,
			int? EndSROOper = null,
			DateTime? StartTransDate = null,
			DateTime? EndTransDate = null,
			string PInvCred = null,
			int? PInclCalculated = null,
			int? PInclProject = null,
			int? OFoundNone = null,
			string Infobar = null)
		{
			StringType _PMode = PMode;
			ListYesNoType _InclBillHold = InclBillHold;
			StringType _OperationStatus = OperationStatus;
			FSSRONumType _SRONum = SRONum;
			CustNumType _CustNum = CustNum;
			FSSROLineType _StartSROLine = StartSROLine;
			FSSROLineType _EndSROLine = EndSROLine;
			FSSROOperType _StartSROOper = StartSROOper;
			FSSROOperType _EndSROOper = EndSROOper;
			DateType _StartTransDate = StartTransDate;
			DateType _EndTransDate = EndTransDate;
			StringType _PInvCred = PInvCred;
			ListYesNoType _PInclCalculated = PInclCalculated;
			ListYesNoType _PInclProject = PInclProject;
			ListYesNoType _OFoundNone = OFoundNone;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROInvSubNoneBillableSp";
				
				appDB.AddCommandParameter(cmd, "PMode", _PMode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InclBillHold", _InclBillHold, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperationStatus", _OperationStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SRONum", _SRONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartSROLine", _StartSROLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndSROLine", _EndSROLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartSROOper", _StartSROOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndSROOper", _EndSROOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartTransDate", _StartTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndTransDate", _EndTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvCred", _PInvCred, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInclCalculated", _PInclCalculated, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInclProject", _PInclProject, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OFoundNone", _OFoundNone, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				OFoundNone = _OFoundNone;
				Infobar = _Infobar;
				
				return (Severity, OFoundNone, Infobar);
			}
		}
	}
}
