//PROJECT NAME: Finance
//CLASS NAME: CHSCheckVoucher.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Chinese
{
	public class CHSCheckVoucher : ICHSCheckVoucher
	{
		readonly IApplicationDB appDB;
		
		
		public CHSCheckVoucher(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) CHSCheckVoucherSp(DateTime? trans_date,
		string CrntNmbr,
		string TypeCode,
		string UserName,
		string curr_code,
		string Infobar)
		{
			DateType _trans_date = trans_date;
			GenericMedCodeType _CrntNmbr = CrntNmbr;
			TransNatType _TypeCode = TypeCode;
			UsernameType _UserName = UserName;
			CurrCodeType _curr_code = curr_code;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CHSCheckVoucherSp";
				
				appDB.AddCommandParameter(cmd, "trans_date", _trans_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CrntNmbr", _CrntNmbr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TypeCode", _TypeCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserName", _UserName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "curr_code", _curr_code, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
