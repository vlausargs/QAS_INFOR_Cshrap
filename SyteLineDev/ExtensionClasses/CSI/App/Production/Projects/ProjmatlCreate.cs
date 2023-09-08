//PROJECT NAME: Production
//CLASS NAME: ProjmatlCreate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjmatlCreate : IProjmatlCreate
	{
		readonly IApplicationDB appDB;
		
		
		public ProjmatlCreate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? TSeqNum,
		string Infobar) ProjmatlCreateSp(string TProjNum,
		int? TTaskNum,
		string TCostCode,
		string TItem,
		string TItemDesc,
		decimal? TQty,
		decimal? TQtyConv,
		string TUM,
		string TWhse,
		decimal? TNonInvCost,
		int? TSeqNum,
		string Infobar)
		{
			ProjNumType _TProjNum = TProjNum;
			TaskNumType _TTaskNum = TTaskNum;
			CostCodeType _TCostCode = TCostCode;
			ItemType _TItem = TItem;
			DescriptionType _TItemDesc = TItemDesc;
			QtyPerType _TQty = TQty;
			QtyPerType _TQtyConv = TQtyConv;
			UMType _TUM = TUM;
			WhseType _TWhse = TWhse;
			CostPrcType _TNonInvCost = TNonInvCost;
			ProjmatlSeqType _TSeqNum = TSeqNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjmatlCreateSp";
				
				appDB.AddCommandParameter(cmd, "TProjNum", _TProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TTaskNum", _TTaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TCostCode", _TCostCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TItem", _TItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TItemDesc", _TItemDesc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TQty", _TQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TQtyConv", _TQtyConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TUM", _TUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TWhse", _TWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TNonInvCost", _TNonInvCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TSeqNum", _TSeqNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TSeqNum = _TSeqNum;
				Infobar = _Infobar;
				
				return (Severity, TSeqNum, Infobar);
			}
		}
	}
}
