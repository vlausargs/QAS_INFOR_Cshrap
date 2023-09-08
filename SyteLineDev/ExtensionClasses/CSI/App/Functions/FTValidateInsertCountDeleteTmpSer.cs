//PROJECT NAME: Data
//CLASS NAME: FTValidateInsertCountDeleteTmpSer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FTValidateInsertCountDeleteTmpSer : IFTValidateInsertCountDeleteTmpSer
	{
		readonly IApplicationDB appDB;
		
		public FTValidateInsertCountDeleteTmpSer(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? SerCount,
			string Infobar) FTValidateInsertCountDeleteTmpSerSp(
			Guid? SessionID,
			string Site,
			string RefStr = "",
			string Item = "",
			string Whse = "",
			string Loc = "",
			string Lot = "",
			string Ser_num = "",
			int? FlagExpiryCheck = 1,
			int? FlagIONCheck210 = 0,
			int? FlagRsvdCheck = 1,
			string FTUser = "",
			string FTAutomationUser = "",
			string CoNumber = "",
			int? CoLine = 0,
			int? CoRelease = 0,
			string Container = "",
			int? FlagRestricSerialMovement = 0,
			decimal? PickListID = 0,
			int? PickListSeq = 0,
			int? SerCount = null,
			string Infobar = null)
		{
			RowPointerType _SessionID = SessionID;
			SiteType _Site = Site;
			NameType _RefStr = RefStr;
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			SerNumType _Ser_num = Ser_num;
			ListYesNoType _FlagExpiryCheck = FlagExpiryCheck;
			ListYesNoType _FlagIONCheck210 = FlagIONCheck210;
			ListYesNoType _FlagRsvdCheck = FlagRsvdCheck;
			UsernameType _FTUser = FTUser;
			UsernameType _FTAutomationUser = FTAutomationUser;
			CoNumType _CoNumber = CoNumber;
			CoLineType _CoLine = CoLine;
			CoReleaseType _CoRelease = CoRelease;
			ContainerNumType _Container = Container;
			ListYesNoType _FlagRestricSerialMovement = FlagRestricSerialMovement;
			PickListIDType _PickListID = PickListID;
			PickListSequenceType _PickListSeq = PickListSeq;
			IntType _SerCount = SerCount;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTValidateInsertCountDeleteTmpSerSp";
				
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefStr", _RefStr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Ser_num", _Ser_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FlagExpiryCheck", _FlagExpiryCheck, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FlagIONCheck210", _FlagIONCheck210, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FlagRsvdCheck", _FlagRsvdCheck, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FTUser", _FTUser, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FTAutomationUser", _FTAutomationUser, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNumber", _CoNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Container", _Container, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FlagRestricSerialMovement", _FlagRestricSerialMovement, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PickListID", _PickListID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PickListSeq", _PickListSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerCount", _SerCount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SerCount = _SerCount;
				Infobar = _Infobar;
				
				return (Severity, SerCount, Infobar);
			}
		}
	}
}
