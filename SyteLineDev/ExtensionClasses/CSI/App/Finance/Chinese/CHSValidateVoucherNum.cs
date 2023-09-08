//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSValidateVoucherNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Chinese
{
	public interface ICHSValidateVoucherNum
	{
		(int? ReturnCode, string Infobar) CHSValidateVoucherNumSP(string Prefix,
		string CrntNmbr,
		string TypeCode,
		DateTime? TransDate = null,
		string Infobar = null);
	}
	
	public class CHSValidateVoucherNum : ICHSValidateVoucherNum
	{
		readonly IApplicationDB appDB;
		
		public CHSValidateVoucherNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) CHSValidateVoucherNumSP(string Prefix,
		string CrntNmbr,
		string TypeCode,
		DateTime? TransDate = null,
		string Infobar = null)
		{
			TransNatType _Prefix = Prefix;
			GenericMedCodeType _CrntNmbr = CrntNmbr;
			TransNatType _TypeCode = TypeCode;
			GenericDateType _TransDate = TransDate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CHSValidateVoucherNumSP";
				
				appDB.AddCommandParameter(cmd, "Prefix", _Prefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CrntNmbr", _CrntNmbr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TypeCode", _TypeCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
