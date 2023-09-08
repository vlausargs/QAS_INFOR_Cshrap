//PROJECT NAME: CSIFSPlus
//CLASS NAME: SSSFSGetAwaitingPartsParms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSGetAwaitingPartsParms
	{
		int SSSFSGetAwaitingPartsParmsSp(ref string PartsWaitStatCode,
		                                 ref string PartsWaitPriorCode,
		                                 ref byte? PartsWaitScheduleFlag,
		                                 ref string PartsRecStatCode,
		                                 ref string PartsRecPriorCode,
		                                 ref byte? PartsRecScheduleFlag,
		                                 ref byte? PartsRecEmailSRO,
		                                 ref byte? PartsRecEmailIncident,
		                                 ref string PartsRecEmailContent,
		                                 ref string PartsWaitMode);
	}
	
	public class SSSFSGetAwaitingPartsParms : ISSSFSGetAwaitingPartsParms
	{
		readonly IApplicationDB appDB;
		
		public SSSFSGetAwaitingPartsParms(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSGetAwaitingPartsParmsSp(ref string PartsWaitStatCode,
		                                        ref string PartsWaitPriorCode,
		                                        ref byte? PartsWaitScheduleFlag,
		                                        ref string PartsRecStatCode,
		                                        ref string PartsRecPriorCode,
		                                        ref byte? PartsRecScheduleFlag,
		                                        ref byte? PartsRecEmailSRO,
		                                        ref byte? PartsRecEmailIncident,
		                                        ref string PartsRecEmailContent,
		                                        ref string PartsWaitMode)
		{
			FSStatCodeType _PartsWaitStatCode = PartsWaitStatCode;
			FSIncPriorCodeType _PartsWaitPriorCode = PartsWaitPriorCode;
			ListYesNoType _PartsWaitScheduleFlag = PartsWaitScheduleFlag;
			FSStatCodeType _PartsRecStatCode = PartsRecStatCode;
			FSIncPriorCodeType _PartsRecPriorCode = PartsRecPriorCode;
			ListYesNoType _PartsRecScheduleFlag = PartsRecScheduleFlag;
			ListYesNoType _PartsRecEmailSRO = PartsRecEmailSRO;
			ListYesNoType _PartsRecEmailIncident = PartsRecEmailIncident;
			StringType _PartsRecEmailContent = PartsRecEmailContent;
			FSListManAutoType _PartsWaitMode = PartsWaitMode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSGetAwaitingPartsParmsSp";
				
				appDB.AddCommandParameter(cmd, "PartsWaitStatCode", _PartsWaitStatCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PartsWaitPriorCode", _PartsWaitPriorCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PartsWaitScheduleFlag", _PartsWaitScheduleFlag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PartsRecStatCode", _PartsRecStatCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PartsRecPriorCode", _PartsRecPriorCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PartsRecScheduleFlag", _PartsRecScheduleFlag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PartsRecEmailSRO", _PartsRecEmailSRO, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PartsRecEmailIncident", _PartsRecEmailIncident, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PartsRecEmailContent", _PartsRecEmailContent, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PartsWaitMode", _PartsWaitMode, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PartsWaitStatCode = _PartsWaitStatCode;
				PartsWaitPriorCode = _PartsWaitPriorCode;
				PartsWaitScheduleFlag = _PartsWaitScheduleFlag;
				PartsRecStatCode = _PartsRecStatCode;
				PartsRecPriorCode = _PartsRecPriorCode;
				PartsRecScheduleFlag = _PartsRecScheduleFlag;
				PartsRecEmailSRO = _PartsRecEmailSRO;
				PartsRecEmailIncident = _PartsRecEmailIncident;
				PartsRecEmailContent = _PartsRecEmailContent;
				PartsWaitMode = _PartsWaitMode;
				
				return Severity;
			}
		}
	}
}
