//PROJECT NAME: DataCollection
//CLASS NAME: DcAJobmat.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DcAJobmat : IDcAJobmat
	{
		readonly IApplicationDB appDB;
		
		
		public DcAJobmat(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) DcAJobmatSp(string TermId,
		string EmpNum,
		DateTime? TTransDate,
		string TransType,
		string JobNum,
		int? JobSuffix = 0,
		int? OperNum = null,
		string Item = null,
		string UM = null,
		string CurWhse = null,
		decimal? TcQtuQty = null,
		string Location = null,
		string Lot = null,
		string Infobar = null)
		{
			DcTermIdType _TermId = TermId;
			EmpNumType _EmpNum = EmpNum;
			DateTimeType _TTransDate = TTransDate;
			DcTransTypeType _TransType = TransType;
			JobType _JobNum = JobNum;
			SuffixType _JobSuffix = JobSuffix;
			OperNumType _OperNum = OperNum;
			ItemType _Item = Item;
			UMType _UM = UM;
			WhseType _CurWhse = CurWhse;
			QtyUnitType _TcQtuQty = TcQtuQty;
			LocType _Location = Location;
			LotType _Lot = Lot;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcAJobmatSp";
				
				appDB.AddCommandParameter(cmd, "TermId", _TermId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TTransDate", _TTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransType", _TransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobNum", _JobNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobSuffix", _JobSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurWhse", _CurWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TcQtuQty", _TcQtuQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Location", _Location, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
