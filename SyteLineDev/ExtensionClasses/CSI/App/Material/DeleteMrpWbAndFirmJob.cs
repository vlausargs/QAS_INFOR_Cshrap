//PROJECT NAME: CSIMaterial
//CLASS NAME: DeleteMrpWbAndFirmJob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IDeleteMrpWbAndFirmJob
	{
		(int? ReturnCode, string Infobar) DeleteMrpWbAndFirmJobSp(string Item,
		string Job,
		short? Suffix,
		string RefNum,
		byte? FromWorkbench,
		DateTime? ReleaseDate = null,
		DateTime? DueDate = null,
		decimal? ReqdQty = 0,
		string RefType = null,
		short? RefLineSuf = 0,
		short? RefRelease = 0,
		int? RefSeq = 0,
		string Whse = null,
		byte? CopyCurrentBOM = (byte)0,
		byte? CopyIndentedBOM = (byte)0,
		Guid? SessionID = null,
		string Infobar = null);
	}
	
	public class DeleteMrpWbAndFirmJob : IDeleteMrpWbAndFirmJob
	{
		readonly IApplicationDB appDB;
		
		public DeleteMrpWbAndFirmJob(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) DeleteMrpWbAndFirmJobSp(string Item,
		string Job,
		short? Suffix,
		string RefNum,
		byte? FromWorkbench,
		DateTime? ReleaseDate = null,
		DateTime? DueDate = null,
		decimal? ReqdQty = 0,
		string RefType = null,
		short? RefLineSuf = 0,
		short? RefRelease = 0,
		int? RefSeq = 0,
		string Whse = null,
		byte? CopyCurrentBOM = (byte)0,
		byte? CopyIndentedBOM = (byte)0,
		Guid? SessionID = null,
		string Infobar = null)
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
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DeleteMrpWbAndFirmJobSp";
				
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
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
