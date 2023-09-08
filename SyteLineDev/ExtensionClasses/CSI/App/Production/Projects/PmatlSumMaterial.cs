//PROJECT NAME: Production
//CLASS NAME: PmatlSumMaterial.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class PmatlSumMaterial : IPmatlSumMaterial
	{
		readonly IApplicationDB appDB;
		
		public PmatlSumMaterial(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string TItemDesc,
			decimal? TRequired,
			decimal? TIssued,
			decimal? TOnHand,
			string TUM,
			decimal? TRequiredConv,
			decimal? TIssuedConv,
			decimal? TOnHandConv,
			decimal? TQty,
			decimal? TQtyConv,
			string Infobar) PmatlSumMaterialSp(
			string ProjNum,
			int? TaskNum,
			int? Seq,
			string Item,
			string Whse,
			string TItemDesc,
			decimal? TRequired,
			decimal? TIssued,
			decimal? TOnHand,
			string TUM,
			decimal? TRequiredConv,
			decimal? TIssuedConv,
			decimal? TOnHandConv,
			decimal? TQty,
			decimal? TQtyConv,
			string Infobar)
		{
			ProjNumType _ProjNum = ProjNum;
			TaskNumType _TaskNum = TaskNum;
			ProjmatlSeqType _Seq = Seq;
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			DescriptionType _TItemDesc = TItemDesc;
			QtyPerType _TRequired = TRequired;
			QtyPerType _TIssued = TIssued;
			QtyPerType _TOnHand = TOnHand;
			UMType _TUM = TUM;
			QtyPerType _TRequiredConv = TRequiredConv;
			QtyPerType _TIssuedConv = TIssuedConv;
			QtyPerType _TOnHandConv = TOnHandConv;
			QtyPerType _TQty = TQty;
			QtyPerType _TQtyConv = TQtyConv;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmatlSumMaterialSp";
				
				appDB.AddCommandParameter(cmd, "ProjNum", _ProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskNum", _TaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Seq", _Seq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TItemDesc", _TItemDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TRequired", _TRequired, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TIssued", _TIssued, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TOnHand", _TOnHand, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TUM", _TUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TRequiredConv", _TRequiredConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TIssuedConv", _TIssuedConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TOnHandConv", _TOnHandConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TQty", _TQty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TQtyConv", _TQtyConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TItemDesc = _TItemDesc;
				TRequired = _TRequired;
				TIssued = _TIssued;
				TOnHand = _TOnHand;
				TUM = _TUM;
				TRequiredConv = _TRequiredConv;
				TIssuedConv = _TIssuedConv;
				TOnHandConv = _TOnHandConv;
				TQty = _TQty;
				TQtyConv = _TQtyConv;
				Infobar = _Infobar;
				
				return (Severity, TItemDesc, TRequired, TIssued, TOnHand, TUM, TRequiredConv, TIssuedConv, TOnHandConv, TQty, TQtyConv, Infobar);
			}
		}
	}
}
