//PROJECT NAME: Data
//CLASS NAME: GetCoItemTotals.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetCoItemTotals : IGetCoItemTotals
	{
		readonly IApplicationDB appDB;
		
		public GetCoItemTotals(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? QtyOrderedConv,
			decimal? QtyShippedConv,
			decimal? QtyRsvdConv,
			decimal? QtyInvoicedConv,
			decimal? QtyReturnedConv,
			string Infobar) GetCoItemTotalsSp(
			string CoNum,
			int? CoLine,
			int? CoRelease,
			decimal? QtyOrderedConv,
			decimal? QtyShippedConv,
			decimal? QtyRsvdConv,
			decimal? QtyInvoicedConv,
			decimal? QtyReturnedConv,
			string Infobar,
			string Site = null)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			CoReleaseType _CoRelease = CoRelease;
			QtyUnitType _QtyOrderedConv = QtyOrderedConv;
			QtyUnitType _QtyShippedConv = QtyShippedConv;
			QtyUnitType _QtyRsvdConv = QtyRsvdConv;
			QtyUnitType _QtyInvoicedConv = QtyInvoicedConv;
			QtyUnitType _QtyReturnedConv = QtyReturnedConv;
			Infobar _Infobar = Infobar;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetCoItemTotalsSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyOrderedConv", _QtyOrderedConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyShippedConv", _QtyShippedConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyRsvdConv", _QtyRsvdConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyInvoicedConv", _QtyInvoicedConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyReturnedConv", _QtyReturnedConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				QtyOrderedConv = _QtyOrderedConv;
				QtyShippedConv = _QtyShippedConv;
				QtyRsvdConv = _QtyRsvdConv;
				QtyInvoicedConv = _QtyInvoicedConv;
				QtyReturnedConv = _QtyReturnedConv;
				Infobar = _Infobar;
				
				return (Severity, QtyOrderedConv, QtyShippedConv, QtyRsvdConv, QtyInvoicedConv, QtyReturnedConv, Infobar);
			}
		}
	}
}
