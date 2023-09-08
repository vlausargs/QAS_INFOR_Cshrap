//PROJECT NAME: CSIVendor
//CLASS NAME: CreatePoAndOrPoitemRow.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface ICreatePoAndOrPoitemRow
	{
		int CreatePoAndOrPoitemRowSp(string PPoNum,
		                             string PVendNum,
		                             string PItem,
		                             string PVendItem,
		                             DateTime? PDueDate,
		                             string PIprId,
		                             decimal? PIprSeq,
		                             decimal? PPriceConv,
		                             decimal? PQtyConv,
		                             string PNonBaseUM,
		                             ref string Infobar);
	}
	
	public class CreatePoAndOrPoitemRow : ICreatePoAndOrPoitemRow
	{
		readonly IApplicationDB appDB;
		
		public CreatePoAndOrPoitemRow(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CreatePoAndOrPoitemRowSp(string PPoNum,
		                                    string PVendNum,
		                                    string PItem,
		                                    string PVendItem,
		                                    DateTime? PDueDate,
		                                    string PIprId,
		                                    decimal? PIprSeq,
		                                    decimal? PPriceConv,
		                                    decimal? PQtyConv,
		                                    string PNonBaseUM,
		                                    ref string Infobar)
		{
			PoNumType _PPoNum = PPoNum;
			VendNumType _PVendNum = PVendNum;
			ItemType _PItem = PItem;
			ItemType _PVendItem = PVendItem;
			DateType _PDueDate = PDueDate;
			ItemPriceRequestIdType _PIprId = PIprId;
			SequenceType _PIprSeq = PIprSeq;
			CostPrcType _PPriceConv = PPriceConv;
			QtyUnitNoNegType _PQtyConv = PQtyConv;
			UMType _PNonBaseUM = PNonBaseUM;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreatePoAndOrPoitemRowSp";
				
				appDB.AddCommandParameter(cmd, "PPoNum", _PPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendItem", _PVendItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDueDate", _PDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PIprId", _PIprId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PIprSeq", _PIprSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPriceConv", _PPriceConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyConv", _PQtyConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNonBaseUM", _PNonBaseUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
