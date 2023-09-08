//PROJECT NAME: Material
//CLASS NAME: MrpCreateMpwRecord.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class MrpCreateMpwRecord : IMrpCreateMpwRecord
	{
		readonly IApplicationDB appDB;
		
		public MrpCreateMpwRecord(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) MrpCreateMpwRecordSp(
			string Item,
			string RefTab,
			decimal? ReqdQty,
			DateTime? DueDate,
			string RefType,
			string RefNum,
			int? RefLineSuf,
			int? RefRelease,
			int? RefSeq,
			string Whse,
			string MpwRecType,
			DateTime? ReleaseDate,
			decimal? UserId,
			string Infobar,
			string ItemVend = null,
			string FromSite = null,
			string FromWhse = null,
			int? MrpParmShrinkFlag = null)
		{
			ItemType _Item = Item;
			MrpWbTabType _RefTab = RefTab;
			QtyUnitType _ReqdQty = ReqdQty;
			DateType _DueDate = DueDate;
			RefTypeIJKMNOTType _RefType = RefType;
			UnknownRefNumLastTranType _RefNum = RefNum;
			UnknownRefLineType _RefLineSuf = RefLineSuf;
			UnknownRefReleaseType _RefRelease = RefRelease;
			JobmatlProjmatlSeqType _RefSeq = RefSeq;
			WhseType _Whse = Whse;
			StringType _MpwRecType = MpwRecType;
			DateType _ReleaseDate = ReleaseDate;
			TokenType _UserId = UserId;
			InfobarType _Infobar = Infobar;
			VendNumType _ItemVend = ItemVend;
			SiteType _FromSite = FromSite;
			WhseType _FromWhse = FromWhse;
			ListYesNoType _MrpParmShrinkFlag = MrpParmShrinkFlag;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MrpCreateMpwRecordSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefTab", _RefTab, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReqdQty", _ReqdQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefSeq", _RefSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MpwRecType", _MpwRecType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReleaseDate", _ReleaseDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserId", _UserId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemVend", _ItemVend, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSite", _FromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromWhse", _FromWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MrpParmShrinkFlag", _MrpParmShrinkFlag, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
