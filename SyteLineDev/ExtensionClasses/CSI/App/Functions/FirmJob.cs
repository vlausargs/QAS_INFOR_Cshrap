//PROJECT NAME: Data
//CLASS NAME: FirmJob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FirmJob : IFirmJob
	{
		readonly IApplicationDB appDB;
		
		public FirmJob(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar,
			int? CheckInsertPermission) FirmJobSp(
			string Item,
			string Job,
			int? Suffix,
			string RefNum,
			int? FromWorkbench,
			DateTime? ReleaseDate = null,
			DateTime? DueDate = null,
			decimal? ReqdQty = 0,
			string RefType = null,
			int? RefLineSuf = 0,
			int? RefRelease = 0,
			int? RefSeq = 0,
			string Whse = null,
			int? CopyCurrentBOM = 0,
			int? CopyIndentedBOM = 0,
			Guid? SessionID = null,
			string Infobar = null,
			int? CheckInsertPermission = null)
		{
			ItemType _Item = Item;
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			UnknownRefNumLastTranType _RefNum = RefNum;
			ListYesNoType _FromWorkbench = FromWorkbench;
			DateType _ReleaseDate = ReleaseDate;
			DateType _DueDate = DueDate;
			QtyUnitType _ReqdQty = ReqdQty;
			RefTypeIJKMNOTType _RefType = RefType;
			UnknownRefLineType _RefLineSuf = RefLineSuf;
			UnknownRefReleaseType _RefRelease = RefRelease;
			JobmatlProjmatlSeqType _RefSeq = RefSeq;
			WhseType _Whse = Whse;
			ListYesNoType _CopyCurrentBOM = CopyCurrentBOM;
			ListYesNoType _CopyIndentedBOM = CopyIndentedBOM;
			RowPointerType _SessionID = SessionID;
			InfobarType _Infobar = Infobar;
			ListYesNoType _CheckInsertPermission = CheckInsertPermission;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FirmJobSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromWorkbench", _FromWorkbench, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReleaseDate", _ReleaseDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReqdQty", _ReqdQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefSeq", _RefSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CopyCurrentBOM", _CopyCurrentBOM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CopyIndentedBOM", _CopyIndentedBOM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CheckInsertPermission", _CheckInsertPermission, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				CheckInsertPermission = _CheckInsertPermission;
				
				return (Severity, Infobar, CheckInsertPermission);
			}
		}
	}
}
