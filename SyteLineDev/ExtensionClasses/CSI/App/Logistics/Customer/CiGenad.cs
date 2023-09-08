//PROJECT NAME: Logistics
//CLASS NAME: CiGenad.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CiGenad : ICiGenad
	{
		readonly IApplicationDB appDB;
		
		
		public CiGenad(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? NewHdr,
		string Infobar) CiGenadSp(string DoInvoice,
		string DoNum,
		int? DoLine,
		int? DoSeq,
		string CustPo,
		decimal? QtyToInvoice,
		string CoNum,
		int? CoLine,
		int? CoRelease,
		int? NewHdr,
		string Infobar,
		decimal? ShipmentId = null)
		{
			DoInvoiceType _DoInvoice = DoInvoice;
			DoNumType _DoNum = DoNum;
			DoLineType _DoLine = DoLine;
			DoSeqType _DoSeq = DoSeq;
			CustPoType _CustPo = CustPo;
			QtyUnitType _QtyToInvoice = QtyToInvoice;
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			CoReleaseType _CoRelease = CoRelease;
			FlagNyType _NewHdr = NewHdr;
			InfobarType _Infobar = Infobar;
			ShipmentIDType _ShipmentId = ShipmentId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CiGenadSp";
				
				appDB.AddCommandParameter(cmd, "DoInvoice", _DoInvoice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DoNum", _DoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DoLine", _DoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DoSeq", _DoSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustPo", _CustPo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyToInvoice", _QtyToInvoice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewHdr", _NewHdr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipmentId", _ShipmentId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NewHdr = _NewHdr;
				Infobar = _Infobar;
				
				return (Severity, NewHdr, Infobar);
			}
		}
	}
}
