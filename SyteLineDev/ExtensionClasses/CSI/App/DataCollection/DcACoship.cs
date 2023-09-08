//PROJECT NAME: DataCollection
//CLASS NAME: DcACoship.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DcACoship : IDcACoship
	{
		readonly IApplicationDB appDB;
		
		
		public DcACoship(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) DcACoshipSp(string PTermId,
		int? PTransType,
		string PEmpNum,
		DateTime? TTransDate,
		string PCoNum,
		int? PCoLine,
		int? PCoRel,
		string TItem,
		decimal? Qty,
		string TUm,
		string PLoc,
		string PLot,
		string PCurWhse,
		string PReasonCode,
		string Infobar)
		{
			DcTermIdType _PTermId = PTermId;
			DcTransNumType _PTransType = PTransType;
			EmpNumType _PEmpNum = PEmpNum;
			DateTimeType _TTransDate = TTransDate;
			CoNumType _PCoNum = PCoNum;
			CoLineType _PCoLine = PCoLine;
			CoReleaseType _PCoRel = PCoRel;
			ItemType _TItem = TItem;
			QtyUnitType _Qty = Qty;
			UMType _TUm = TUm;
			LocType _PLoc = PLoc;
			LotType _PLot = PLot;
			WhseType _PCurWhse = PCurWhse;
			ReasonCodeType _PReasonCode = PReasonCode;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcACoshipSp";
				
				appDB.AddCommandParameter(cmd, "PTermId", _PTermId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransType", _PTransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEmpNum", _PEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TTransDate", _TTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoLine", _PCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoRel", _PCoRel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TItem", _TItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TUm", _TUm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLoc", _PLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLot", _PLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurWhse", _PCurWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReasonCode", _PReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
