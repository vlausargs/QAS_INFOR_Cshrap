//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROGenSub.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSROGenSub : ISSSFSSROGenSub
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROGenSub(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSFSSROGenSubSp(
			string CalledFrom,
			int? CreateSROs,
			string Contract,
			string SerNum,
			string Item,
			int? UnitLastMeterAmt,
			int? StartMeterAmt,
			string SroType,
			int? MntSeq,
			DateTime? ThroughDate,
			string LastSroNum,
			DateTime? StartDate,
			DateTime? StartTime,
			string Frequency,
			int? Duration,
			string DurationType,
			int? Month,
			int? Day,
			int? LeadTime,
			string LeadType,
			decimal? DownTime,
			int? ScheduleFuture,
			string ScheduleBasis,
			string SroNum,
			int? SroLine,
			string CustNum,
			int? CustSeq,
			string SroDescription,
			string Infobar,
			string LeadPartner = null,
			string CustPo = null,
			string ShiftID = null,
			int? KeepOperNums = 0,
			string CustItem = null,
			int? SchedDownTime = 0,
			int? CreateIncident = 0,
			string UsrNum = null,
			int? UsrSeq = null)
		{
			StringType _CalledFrom = CalledFrom;
			ListYesNoType _CreateSROs = CreateSROs;
			FSContractType _Contract = Contract;
			SerNumType _SerNum = SerNum;
			ItemType _Item = Item;
			FSMeterAmtType _UnitLastMeterAmt = UnitLastMeterAmt;
			FSMeterAmtType _StartMeterAmt = StartMeterAmt;
			FSSROTypeType _SroType = SroType;
			FSSeqType _MntSeq = MntSeq;
			DateType _ThroughDate = ThroughDate;
			FSSRONumType _LastSroNum = LastSroNum;
			DateType _StartDate = StartDate;
			DateTimeType _StartTime = StartTime;
			FSMaintFreqType _Frequency = Frequency;
			FSDurationType _Duration = Duration;
			FSDurationTypeType _DurationType = DurationType;
			FSMonthType _Month = Month;
			FSDayOfMonthType _Day = Day;
			FSDurationType _LeadTime = LeadTime;
			FSDurationTypeType _LeadType = LeadType;
			FixedHoursType _DownTime = DownTime;
			ListYesNoType _ScheduleFuture = ScheduleFuture;
			FSSchedBasisType _ScheduleBasis = ScheduleBasis;
			FSSRONumType _SroNum = SroNum;
			FSSROLineType _SroLine = SroLine;
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			DescriptionType _SroDescription = SroDescription;
			Infobar _Infobar = Infobar;
			FSPartnerType _LeadPartner = LeadPartner;
			CustPoType _CustPo = CustPo;
			ApsShiftType _ShiftID = ShiftID;
			ListYesNoType _KeepOperNums = KeepOperNums;
			CustItemType _CustItem = CustItem;
			ListYesNoType _SchedDownTime = SchedDownTime;
			ListYesNoType _CreateIncident = CreateIncident;
			FSUsrNumType _UsrNum = UsrNum;
			FSUsrSeqType _UsrSeq = UsrSeq;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROGenSubSp";
				
				appDB.AddCommandParameter(cmd, "CalledFrom", _CalledFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreateSROs", _CreateSROs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Contract", _Contract, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitLastMeterAmt", _UnitLastMeterAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartMeterAmt", _StartMeterAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroType", _SroType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MntSeq", _MntSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ThroughDate", _ThroughDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LastSroNum", _LastSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartTime", _StartTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Frequency", _Frequency, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Duration", _Duration, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DurationType", _DurationType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Month", _Month, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Day", _Day, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LeadTime", _LeadTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LeadType", _LeadType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DownTime", _DownTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ScheduleFuture", _ScheduleFuture, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ScheduleBasis", _ScheduleBasis, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroLine", _SroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroDescription", _SroDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LeadPartner", _LeadPartner, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustPo", _CustPo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShiftID", _ShiftID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "KeepOperNums", _KeepOperNums, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustItem", _CustItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SchedDownTime", _SchedDownTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreateIncident", _CreateIncident, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UsrNum", _UsrNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UsrSeq", _UsrSeq, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
