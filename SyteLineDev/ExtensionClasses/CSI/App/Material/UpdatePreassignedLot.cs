//PROJECT NAME: Material
//CLASS NAME: UpdatePreassignedLot.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class UpdatePreassignedLot : IUpdatePreassignedLot
	{
		readonly IApplicationDB appDB;
		
		
		public UpdatePreassignedLot(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) UpdatePreassignedLotSp(int? Select,
		string Lot,
		string sQtyRec,
		string RefType,
		string RefNum,
		int? RefLineSuf,
		int? RefRelease,
		string Item,
		string Infobar)
		{
			ListYesNoType _Select = Select;
			LotType _Lot = Lot;
			StringType _sQtyRec = sQtyRec;
			RefTypeIJKPRTType _RefType = RefType;
			JobPoProjReqTrnNumType _RefNum = RefNum;
			SuffixPoLineProjTaskReqTrnLineType _RefLineSuf = RefLineSuf;
			OperNumPoReleaseType _RefRelease = RefRelease;
			ItemType _Item = Item;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdatePreassignedLotSp";
				
				appDB.AddCommandParameter(cmd, "Select", _Select, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "sQtyRec", _sQtyRec, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
