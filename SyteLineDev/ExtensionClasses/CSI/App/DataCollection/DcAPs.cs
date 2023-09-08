//PROJECT NAME: DataCollection
//CLASS NAME: DcAPs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DcAPs : IDcAPs
	{
		readonly IApplicationDB appDB;
		
		
		public DcAPs(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) DcAPsSp(string TermId,
		string PTransType,
		string EmpNum,
		DateTime? TTransDate,
		string PsItem,
		string PsNum,
		string Wc,
		int? OperNum,
		decimal? Qty,
		string Loc,
		string Lot,
		string Infobar)
		{
			DcTermIdType _TermId = TermId;
			DcTransTypeType _PTransType = PTransType;
			EmpNumType _EmpNum = EmpNum;
			DateTimeType _TTransDate = TTransDate;
			ItemType _PsItem = PsItem;
			PsNumType _PsNum = PsNum;
			WcType _Wc = Wc;
			OperNumType _OperNum = OperNum;
			QtyUnitType _Qty = Qty;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcAPsSp";
				
				appDB.AddCommandParameter(cmd, "TermId", _TermId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransType", _PTransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TTransDate", _TTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PsItem", _PsItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PsNum", _PsNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Wc", _Wc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
