//PROJECT NAME: Logistics
//CLASS NAME: AddTmpPickList.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class AddTmpPickList : IAddTmpPickList
	{
		readonly IApplicationDB appDB;
		
		
		public AddTmpPickList(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) AddTmpPickListSp(Guid? ProcessID,
		string CoNum,
		int? CoLIne,
		int? CoRelease,
		DateTime? DueDate,
		string Item,
		string UM,
		decimal? PickQty,
		string CustNum,
		int? CustSeq,
		int? Group,
		string Whse,
		string PackLoc,
		string Picker,
		string Infobar)
		{
			RowPointerType _ProcessID = ProcessID;
			CoNumType _CoNum = CoNum;
			CoLineType _CoLIne = CoLIne;
			CoReleaseType _CoRelease = CoRelease;
			DateType _DueDate = DueDate;
			ItemType _Item = Item;
			UMType _UM = UM;
			QtyUnitNoNegType _PickQty = PickQty;
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			PickGroupType _Group = Group;
			WhseType _Whse = Whse;
			LocType _PackLoc = PackLoc;
			UsernameType _Picker = Picker;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AddTmpPickListSp";
				
				appDB.AddCommandParameter(cmd, "ProcessID", _ProcessID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLIne", _CoLIne, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PickQty", _PickQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Group", _Group, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PackLoc", _PackLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Picker", _Picker, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
