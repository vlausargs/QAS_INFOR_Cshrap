//PROJECT NAME: Production
//CLASS NAME: ValidateJobDemandId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class ValidateJobDemandId : IValidateJobDemandId
	{
		readonly IApplicationDB appDB;
		
		
		public ValidateJobDemandId(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Job,
		int? Suffix,
		string Item,
		decimal? QtyReleased,
		DateTime? EndDate,
		string PSNum,
		string Ppjob) ValidateJobDemandIdSp(string PDemandType,
		string DemandID,
		string Job,
		int? Suffix,
		string Item,
		decimal? QtyReleased,
		DateTime? EndDate,
		string PSNum,
		string Ppjob)
		{
			RefType _PDemandType = PDemandType;
			ApsOrderType _DemandID = DemandID;
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			ItemType _Item = Item;
			QtyUnitType _QtyReleased = QtyReleased;
			DateType _EndDate = EndDate;
			PsNumType _PSNum = PSNum;
			JobType _Ppjob = Ppjob;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateJobDemandIdSp";
				
				appDB.AddCommandParameter(cmd, "PDemandType", _PDemandType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DemandID", _DemandID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyReleased", _QtyReleased, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSNum", _PSNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Ppjob", _Ppjob, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Job = _Job;
				Suffix = _Suffix;
				Item = _Item;
				QtyReleased = _QtyReleased;
				EndDate = _EndDate;
				PSNum = _PSNum;
				Ppjob = _Ppjob;
				
				return (Severity, Job, Suffix, Item, QtyReleased, EndDate, PSNum, Ppjob);
			}
		}
	}
}
