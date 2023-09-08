//PROJECT NAME: CSIFinance
//CLASS NAME: GlPostS.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public interface IGlPostS
	{
		(int? ReturnCode, string Infobar) GlPostSp3(byte? DateOpt,
		DateTime? FixDate,
		DateTime? NextPer,
		byte? DelOpt,
		string ExOptacCompressLevel,
		DateTime? TPerStart,
		DateTime? TPerEnd,
		DateTime? TFirstDate,
		DateTime? TLastDate,
		byte? TReadonly,
		DateTime? TPostDate,
		decimal? UserID,
		string CurId,
		string StartingGLVoucher = null,
		string EndingGLVoucher = null,
		Guid? PSessionID = null,
		string Infobar = null,
		DateTime? PostThroughDate = null);
	}
	
	public class GlPostS : IGlPostS
	{
		readonly IApplicationDB appDB;
		
		public GlPostS(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) GlPostSp3(byte? DateOpt,
		DateTime? FixDate,
		DateTime? NextPer,
		byte? DelOpt,
		string ExOptacCompressLevel,
		DateTime? TPerStart,
		DateTime? TPerEnd,
		DateTime? TFirstDate,
		DateTime? TLastDate,
		byte? TReadonly,
		DateTime? TPostDate,
		decimal? UserID,
		string CurId,
		string StartingGLVoucher = null,
		string EndingGLVoucher = null,
		Guid? PSessionID = null,
		string Infobar = null,
		DateTime? PostThroughDate = null)
		{
			ListYesNoType _DateOpt = DateOpt;
			DateType _FixDate = FixDate;
			DateType _NextPer = NextPer;
			ListYesNoType _DelOpt = DelOpt;
			StringType _ExOptacCompressLevel = ExOptacCompressLevel;
			CurrentDateType _TPerStart = TPerStart;
			CurrentDateType _TPerEnd = TPerEnd;
			DateType _TFirstDate = TFirstDate;
			DateType _TLastDate = TLastDate;
			FlagNyType _TReadonly = TReadonly;
			DateType _TPostDate = TPostDate;
			TokenType _UserID = UserID;
			JournalIdType _CurId = CurId;
			InvNumVoucherType _StartingGLVoucher = StartingGLVoucher;
			InvNumVoucherType _EndingGLVoucher = EndingGLVoucher;
			RowPointer _PSessionID = PSessionID;
			InfobarType _Infobar = Infobar;
			DateType _PostThroughDate = PostThroughDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GlPostSp3";
				
				appDB.AddCommandParameter(cmd, "DateOpt", _DateOpt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FixDate", _FixDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NextPer", _NextPer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DelOpt", _DelOpt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacCompressLevel", _ExOptacCompressLevel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TPerStart", _TPerStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TPerEnd", _TPerEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TFirstDate", _TFirstDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TLastDate", _TLastDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TReadonly", _TReadonly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TPostDate", _TPostDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserID", _UserID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurId", _CurId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingGLVoucher", _StartingGLVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingGLVoucher", _EndingGLVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PostThroughDate", _PostThroughDate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
