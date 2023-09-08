//PROJECT NAME: Logistics
//CLASS NAME: ArCalcdisc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ArCalcdisc : IArCalcdisc
	{
		readonly IApplicationDB appDB;
		
		
		public ArCalcdisc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? TDisc,
		decimal? TBal,
		decimal? TaxDiscount) ArCalcdiscSp(string PCurApplyCustNum,
		string PCurInvNum,
		DateTime? PPaymentReceiptDate,
		string Site = null,
		decimal? TDisc = null,
		decimal? TBal = null,
		decimal? TaxDiscount = 0)
		{
			CustNumType _PCurApplyCustNum = PCurApplyCustNum;
			InvNumType _PCurInvNum = PCurInvNum;
			DateType _PPaymentReceiptDate = PPaymentReceiptDate;
			SiteType _Site = Site;
			AmountType _TDisc = TDisc;
			AmountType _TBal = TBal;
			AmountType _TaxDiscount = TaxDiscount;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ArCalcdiscSp";
				
				appDB.AddCommandParameter(cmd, "PCurApplyCustNum", _PCurApplyCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurInvNum", _PCurInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPaymentReceiptDate", _PPaymentReceiptDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TDisc", _TDisc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TBal", _TBal, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxDiscount", _TaxDiscount, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TDisc = _TDisc;
				TBal = _TBal;
				TaxDiscount = _TaxDiscount;
				
				return (Severity, TDisc, TBal, TaxDiscount);
			}
		}
	}
}
