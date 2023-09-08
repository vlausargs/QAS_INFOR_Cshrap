//PROJECT NAME: Production
//CLASS NAME: JobReceiptPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class JobReceiptPost : IJobReceiptPost
	{
		readonly IApplicationDB appDB;
		
		
		public JobReceiptPost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? CanOverride,
		string Infobar) JobReceiptPostSp(string Job,
		int? Suffix,
		string Item,
		int? OperNum,
		decimal? Qty,
		string Loc,
		string Lot,
		DateTime? TransDate,
		int? Override,
		int? CanOverride,
		string Infobar,
		string DocumentNum = null,
		string ImportDocId = null,
		string EmpNum = null,
		string ContainerNum = null)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			ItemType _Item = Item;
			OperNumType _OperNum = OperNum;
			QtyUnitType _Qty = Qty;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			DateType _TransDate = TransDate;
			ListYesNoType _Override = Override;
			IntType _CanOverride = CanOverride;
			InfobarType _Infobar = Infobar;
			DocumentNumType _DocumentNum = DocumentNum;
			ImportDocIdType _ImportDocId = ImportDocId;
			EmpNumType _EmpNum = EmpNum;
			ContainerNumType _ContainerNum = ContainerNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobReceiptPostSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Override", _Override, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CanOverride", _CanOverride, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DocumentNum", _DocumentNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ImportDocId", _ImportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContainerNum", _ContainerNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CanOverride = _CanOverride;
				Infobar = _Infobar;
				
				return (Severity, CanOverride, Infobar);
			}
		}
	}
}
