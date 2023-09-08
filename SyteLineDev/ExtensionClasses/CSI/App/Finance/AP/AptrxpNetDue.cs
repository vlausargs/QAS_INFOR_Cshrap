//PROJECT NAME: Finance
//CLASS NAME: AptrxpNetDue.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AP
{
	public class AptrxpNetDue : IAptrxpNetDue
	{
		readonly IApplicationDB appDB;
		
		public AptrxpNetDue(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? AptrxpNetDueFn(
			string Site,
			string PVendNum,
			int? PVoucher,
			int? VouchSeq,
			DateTime? CompareDate)
		{
			SiteType _Site = Site;
			VendNumType _PVendNum = PVendNum;
			VoucherType _PVoucher = PVoucher;
			VouchSeqType _VouchSeq = VouchSeq;
			DateType _CompareDate = CompareDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[AptrxpNetDue](@Site, @PVendNum, @PVoucher, @VouchSeq, @CompareDate)";
				
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVoucher", _PVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VouchSeq", _VouchSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CompareDate", _CompareDate, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
