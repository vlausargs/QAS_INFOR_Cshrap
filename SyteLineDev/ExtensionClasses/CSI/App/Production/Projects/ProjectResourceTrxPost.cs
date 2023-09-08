//PROJECT NAME: Production
//CLASS NAME: ProjectResourceTrxPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjectResourceTrxPost : IProjectResourceTrxPost
	{
		readonly IApplicationDB appDB;
		
		
		public ProjectResourceTrxPost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ProjectResourceTrxPostSp(string PProjNum,
		int? PTaskNum,
		int? PSeqNum,
		string PItem,
		decimal? PQty,
		string CurWhse,
		string PCostCode,
		string PLoc1,
		string PLot1,
		DateTime? PTransDate,
		string PTranType,
		string PNonInvAcct,
		string PNonInvAcctUnit1,
		string PNonInvAcctUnit2,
		string PNonInvAcctUnit3,
		string PNonInvAcctUnit4,
		decimal? PNonInvCost,
		string PPoNum,
		int? PPoLine,
		int? PPoRel,
		string PRefType,
		string CallArg = "",
		string ControlPrefix = null,
		string ControlSite = null,
		int? ControlYear = null,
		int? ControlPeriod = null,
		decimal? ControlNumber = null,
		string Infobar = null,
		string PImportDocId1 = null,
		string DocumentNum = null)
		{
			ProjNumType _PProjNum = PProjNum;
			TaskNumType _PTaskNum = PTaskNum;
			ProjmatlSeqType _PSeqNum = PSeqNum;
			ItemType _PItem = PItem;
			QtyUnitType _PQty = PQty;
			WhseType _CurWhse = CurWhse;
			CostCodeType _PCostCode = PCostCode;
			LocType _PLoc1 = PLoc1;
			LotType _PLot1 = PLot1;
			DateTimeType _PTransDate = PTransDate;
			MatlTransTypeType _PTranType = PTranType;
			AcctType _PNonInvAcct = PNonInvAcct;
			UnitCode1Type _PNonInvAcctUnit1 = PNonInvAcctUnit1;
			UnitCode2Type _PNonInvAcctUnit2 = PNonInvAcctUnit2;
			UnitCode3Type _PNonInvAcctUnit3 = PNonInvAcctUnit3;
			UnitCode4Type _PNonInvAcctUnit4 = PNonInvAcctUnit4;
			CostPrcType _PNonInvCost = PNonInvCost;
			PoNumType _PPoNum = PPoNum;
			PoLineType _PPoLine = PPoLine;
			PoReleaseType _PPoRel = PPoRel;
			RefTypeIJKOTType _PRefType = PRefType;
			InfobarType _CallArg = CallArg;
			JourControlPrefixType _ControlPrefix = ControlPrefix;
			SiteType _ControlSite = ControlSite;
			FiscalYearType _ControlYear = ControlYear;
			FinPeriodType _ControlPeriod = ControlPeriod;
			LastTranType _ControlNumber = ControlNumber;
			InfobarType _Infobar = Infobar;
			ImportDocIdType _PImportDocId1 = PImportDocId1;
			DocumentNumType _DocumentNum = DocumentNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjectResourceTrxPostSp";
				
				appDB.AddCommandParameter(cmd, "PProjNum", _PProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaskNum", _PTaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSeqNum", _PSeqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQty", _PQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurWhse", _CurWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCostCode", _PCostCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLoc1", _PLoc1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLot1", _PLot1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransDate", _PTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTranType", _PTranType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNonInvAcct", _PNonInvAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNonInvAcctUnit1", _PNonInvAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNonInvAcctUnit2", _PNonInvAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNonInvAcctUnit3", _PNonInvAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNonInvAcctUnit4", _PNonInvAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNonInvCost", _PNonInvCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoNum", _PPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoLine", _PPoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoRel", _PPoRel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefType", _PRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CallArg", _CallArg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPrefix", _ControlPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlSite", _ControlSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlYear", _ControlYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPeriod", _ControlPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlNumber", _ControlNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PImportDocId1", _PImportDocId1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentNum", _DocumentNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
