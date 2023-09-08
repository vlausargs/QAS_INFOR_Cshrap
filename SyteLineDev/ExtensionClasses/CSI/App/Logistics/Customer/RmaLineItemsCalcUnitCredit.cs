//PROJECT NAME: CSICustomer
//CLASS NAME: RmaLineItemsCalcUnitCredit.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IRmaLineItemsCalcUnitCredit
	{
		int RmaLineItemsCalcUnitCreditSp(string PRmaNum,
		                                 string PCoNum,
		                                 short? PCoLine,
		                                 short? PCoRelease,
		                                 string PItem,
		                                 string PUM,
		                                 decimal? PQtyToReturnConv,
		                                 string PPricecode,
		                                 ref decimal? PUnitCreditConv,
		                                 ref string Infobar);
	}
	
	public class RmaLineItemsCalcUnitCredit : IRmaLineItemsCalcUnitCredit
	{
		readonly IApplicationDB appDB;
		
		public RmaLineItemsCalcUnitCredit(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int RmaLineItemsCalcUnitCreditSp(string PRmaNum,
		                                        string PCoNum,
		                                        short? PCoLine,
		                                        short? PCoRelease,
		                                        string PItem,
		                                        string PUM,
		                                        decimal? PQtyToReturnConv,
		                                        string PPricecode,
		                                        ref decimal? PUnitCreditConv,
		                                        ref string Infobar)
		{
			RmaNumType _PRmaNum = PRmaNum;
			CoNumType _PCoNum = PCoNum;
			CoLineType _PCoLine = PCoLine;
			CoReleaseType _PCoRelease = PCoRelease;
			ItemType _PItem = PItem;
			UMType _PUM = PUM;
			QtyUnitNoNegType _PQtyToReturnConv = PQtyToReturnConv;
			PriceCodeType _PPricecode = PPricecode;
			CostPrcNoNegType _PUnitCreditConv = PUnitCreditConv;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RmaLineItemsCalcUnitCreditSp";
				
				appDB.AddCommandParameter(cmd, "PRmaNum", _PRmaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoLine", _PCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoRelease", _PCoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUM", _PUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyToReturnConv", _PQtyToReturnConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPricecode", _PPricecode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUnitCreditConv", _PUnitCreditConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PUnitCreditConv = _PUnitCreditConv;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
