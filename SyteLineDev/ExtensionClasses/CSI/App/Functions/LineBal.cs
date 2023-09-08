//PROJECT NAME: Data
//CLASS NAME: LineBal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class LineBal : ILineBal
	{
		readonly IApplicationDB appDB;
		
		public LineBal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? LineBalSp(
			decimal? QtyOrdered,
			decimal? QtyInvoiced,
			decimal? QtyReturned,
			decimal? Price,
			decimal? Disc,
			decimal? PrgBillTot,
			decimal? PrgBillApp,
			int? Places)
		{
			QtyUnitType _QtyOrdered = QtyOrdered;
			QtyUnitType _QtyInvoiced = QtyInvoiced;
			QtyUnitType _QtyReturned = QtyReturned;
			AmountType _Price = Price;
			OrderDiscType _Disc = Disc;
			AmountType _PrgBillTot = PrgBillTot;
			AmountType _PrgBillApp = PrgBillApp;
			DecimalPlacesType _Places = Places;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[LineBalSp](@QtyOrdered, @QtyInvoiced, @QtyReturned, @Price, @Disc, @PrgBillTot, @PrgBillApp, @Places)";
				
				appDB.AddCommandParameter(cmd, "QtyOrdered", _QtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyInvoiced", _QtyInvoiced, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyReturned", _QtyReturned, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Price", _Price, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Disc", _Disc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrgBillTot", _PrgBillTot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrgBillApp", _PrgBillApp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Places", _Places, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
