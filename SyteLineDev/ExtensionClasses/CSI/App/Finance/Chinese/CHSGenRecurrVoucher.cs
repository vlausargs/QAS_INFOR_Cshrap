//PROJECT NAME: Finance
//CLASS NAME: CHSGenRecurrVoucher.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Chinese
{
	public class CHSGenRecurrVoucher : ICHSGenRecurrVoucher
	{
		readonly IApplicationDB appDB;
		
		
		public CHSGenRecurrVoucher(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string VoucherNumber,
		string Infobar) CHSGenRecurrVoucherSp(DateTime? TransDate,
		int? ID,
		string PreviewYN,
		string UserName,
		string VoucherNumber,
		string Infobar)
		{
			DateType _TransDate = TransDate;
			GenericIntType _ID = ID;
			DeTypeType _PreviewYN = PreviewYN;
			UsernameType _UserName = UserName;
			GenericMedCodeType _VoucherNumber = VoucherNumber;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CHSGenRecurrVoucherSp";
				
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ID", _ID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PreviewYN", _PreviewYN, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserName", _UserName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VoucherNumber", _VoucherNumber, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				VoucherNumber = _VoucherNumber;
				Infobar = _Infobar;
				
				return (Severity, VoucherNumber, Infobar);
			}
		}
	}
}
