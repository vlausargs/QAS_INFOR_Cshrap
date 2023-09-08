//PROJECT NAME: Finance
//CLASS NAME: CHSGetVouchNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Chinese
{
	public class CHSGetVouchNum : ICHSGetVouchNum
	{
		readonly IApplicationDB appDB;
		
		public CHSGetVouchNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string VoucherNumber,
			string Infobar) CHSGetVouchNumSp(
			string TypeCode,
			string blnNew,
			DateTime? TransDate,
			string VoucherNumber,
			string Infobar)
		{
			TransNatType _TypeCode = TypeCode;
			DeTypeType _blnNew = blnNew;
			DateType _TransDate = TransDate;
			GenericMedCodeType _VoucherNumber = VoucherNumber;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CHSGetVouchNumSp";
				
				appDB.AddCommandParameter(cmd, "TypeCode", _TypeCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "blnNew", _blnNew, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
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
