//PROJECT NAME: Production
//CLASS NAME: ProjmatlTransaction.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjmatlTransaction : IProjmatlTransaction
	{
		readonly IApplicationDB appDB;
		
		
		public ProjmatlTransaction(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? TSeqNum,
		string Infobar) ProjmatlTransactionSp(string PProjNum,
		int? PTaskNum,
		int? PSeqNum,
		string PItem,
		string PItemDesc,
		decimal? PQty,
		decimal? PQtyConv,
		string PUM,
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
		int? CreateMatl,
		int? TSeqNum,
		string Infobar,
		string PImportDocId1,
		string DocumentNum = null)
		{
			ProjNumType _PProjNum = PProjNum;
			TaskNumType _PTaskNum = PTaskNum;
			ProjmatlSeqType _PSeqNum = PSeqNum;
			ItemType _PItem = PItem;
			DescriptionType _PItemDesc = PItemDesc;
			QtyPerType _PQty = PQty;
			QtyPerType _PQtyConv = PQtyConv;
			UMType _PUM = PUM;
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
			ListYesNoType _CreateMatl = CreateMatl;
			ProjmatlSeqType _TSeqNum = TSeqNum;
			InfobarType _Infobar = Infobar;
			ImportDocIdType _PImportDocId1 = PImportDocId1;
			DocumentNumType _DocumentNum = DocumentNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjmatlTransactionSp";
				
				appDB.AddCommandParameter(cmd, "PProjNum", _PProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaskNum", _PTaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSeqNum", _PSeqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemDesc", _PItemDesc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQty", _PQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyConv", _PQtyConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUM", _PUM, ParameterDirection.Input);
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
				appDB.AddCommandParameter(cmd, "CreateMatl", _CreateMatl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TSeqNum", _TSeqNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PImportDocId1", _PImportDocId1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentNum", _DocumentNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TSeqNum = _TSeqNum;
				Infobar = _Infobar;
				
				return (Severity, TSeqNum, Infobar);
			}
		}
	}
}
