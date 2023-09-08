//PROJECT NAME: Logistics
//CLASS NAME: GeneratePickListTmp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GeneratePickListTmp : IGeneratePickListTmp
	{
		readonly IApplicationDB appDB;
		
		
		public GeneratePickListTmp(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar) GeneratePickListTmpSp(Guid? ProcessId,
		int? Select,
		decimal? PickListId,
		string CustNum,
		int? CustSeq,
		string Whse,
		int? Group,
		string Packer,
		string ParentContainerNum,
		string InfoBar,
		string RefNum = null,
		int? RefLine = null,
		int? RefRelease = null,
		string RefType = null,
		decimal? Qty = 0,
		string Loc = null,
		string Lot = null)
		{
			RowPointerType _ProcessId = ProcessId;
			ListYesNoType _Select = Select;
			PickListIDType _PickListId = PickListId;
			CustNumType _CustNum = CustNum;
			IntType _CustSeq = CustSeq;
			WhseType _Whse = Whse;
			ShortType _Group = Group;
			UsernameType _Packer = Packer;
			ContainerNumType _ParentContainerNum = ParentContainerNum;
			InfobarType _InfoBar = InfoBar;
			CoNumType _RefNum = RefNum;
			CoLineType _RefLine = RefLine;
			CoReleaseType _RefRelease = RefRelease;
			RefTypeIJOPRSTType _RefType = RefType;
			QtyUnitNoNegType _Qty = Qty;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GeneratePickListTmpSp";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Select", _Select, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PickListId", _PickListId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Group", _Group, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Packer", _Packer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParentContainerNum", _ParentContainerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLine", _RefLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
