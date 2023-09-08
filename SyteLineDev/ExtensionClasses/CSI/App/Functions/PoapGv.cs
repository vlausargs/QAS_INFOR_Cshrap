//PROJECT NAME: Data
//CLASS NAME: PoapGv.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PoapGv : IPoapGv
	{
		readonly IApplicationDB appDB;
		
		public PoapGv(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? DateSeq,
			string Infobar) PoapGvSp(
			string PoNum,
			int? PoLine,
			int? PoRelease,
			string Type,
			DateTime? PostDate,
			decimal? QtyReceived = 0,
			decimal? QtyReturned = 0,
			decimal? QtyVouchered = 0,
			decimal? ItemCost = null,
			decimal? ExchRate = null,
			int? Voucher = 0,
			string GrnNum = null,
			string PackNum = null,
			int? DateSeq = null,
			string Infobar = null)
		{
			PoNumType _PoNum = PoNum;
			PoLineType _PoLine = PoLine;
			PoReleaseType _PoRelease = PoRelease;
			PoVchTypeType _Type = Type;
			DateType _PostDate = PostDate;
			QtyUnitType _QtyReceived = QtyReceived;
			QtyUnitType _QtyReturned = QtyReturned;
			QtyUnitType _QtyVouchered = QtyVouchered;
			CostPrcType _ItemCost = ItemCost;
			ExchRateType _ExchRate = ExchRate;
			VoucherType _Voucher = Voucher;
			GrnNumType _GrnNum = GrnNum;
			GrnPackNumType _PackNum = PackNum;
			DateSeqType _DateSeq = DateSeq;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PoapGvSp";
				
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoLine", _PoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoRelease", _PoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostDate", _PostDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyReceived", _QtyReceived, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyReturned", _QtyReturned, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyVouchered", _QtyVouchered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemCost", _ItemCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Voucher", _Voucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GrnNum", _GrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PackNum", _PackNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateSeq", _DateSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DateSeq = _DateSeq;
				Infobar = _Infobar;
				
				return (Severity, DateSeq, Infobar);
			}
		}
	}
}
