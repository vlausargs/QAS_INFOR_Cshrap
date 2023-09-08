//PROJECT NAME: Production
//CLASS NAME: CreatePckItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class CreatePckItem : ICreatePckItem
	{
		readonly IApplicationDB appDB;
		
		
		public CreatePckItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) CreatePckItemSp(int? PackNum,
		string ProjNum,
		int? TaskNum,
		int? Seq,
		string Item,
		string UM,
		decimal? PackQty,
		string Infobar)
		{
			PackNumType _PackNum = PackNum;
			ProjNumType _ProjNum = ProjNum;
			TaskNumType _TaskNum = TaskNum;
			ProjmatlSeqType _Seq = Seq;
			ItemType _Item = Item;
			UMType _UM = UM;
			QtyUnitType _PackQty = PackQty;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreatePckItemSp";
				
				appDB.AddCommandParameter(cmd, "PackNum", _PackNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjNum", _ProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskNum", _TaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Seq", _Seq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PackQty", _PackQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
