//PROJECT NAME: Logistics
//CLASS NAME: Update1099PaymentForVendorAfterPosted.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class Update1099PaymentForVendorAfterPosted : IUpdate1099PaymentForVendorAfterPosted
	{
		readonly IApplicationDB appDB;
		
		
		public Update1099PaymentForVendorAfterPosted(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Inforbar) Update1099PaymentForVendorAfterPostedSp(string VendNum,
		int? Curr1099Reportable = 0,
		decimal? AmtPaid = null,
		DateTime? DistDate = null,
		string Inforbar = null)
		{
			VendNumType _VendNum = VendNum;
			ListYesNoType _Curr1099Reportable = Curr1099Reportable;
			AmountType _AmtPaid = AmtPaid;
			DateType _DistDate = DistDate;
			InfobarType _Inforbar = Inforbar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Update1099PaymentForVendorAfterPostedSp";
				
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Curr1099Reportable", _Curr1099Reportable, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AmtPaid", _AmtPaid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DistDate", _DistDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Inforbar", _Inforbar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Inforbar = _Inforbar;
				
				return (Severity, Inforbar);
			}
		}
	}
}
