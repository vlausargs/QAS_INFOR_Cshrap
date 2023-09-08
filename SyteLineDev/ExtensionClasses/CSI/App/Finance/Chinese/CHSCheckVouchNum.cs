//PROJECT NAME: Finance
//CLASS NAME: CHSCheckVouchNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Chinese
{
	public class CHSCheckVouchNum : ICHSCheckVouchNum
	{
		readonly IApplicationDB appDB;
		
		public CHSCheckVouchNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CHSCheckVouchNumSp(
			string TypeCode,
			DateTime? TransDate,
			string VoucherNumber,
			string Infobar)
		{
			TransNatType _TypeCode = TypeCode;
			DateType _TransDate = TransDate;
			GenericMedCodeType _VoucherNumber = VoucherNumber;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CHSCheckVouchNumSp";
				
				appDB.AddCommandParameter(cmd, "TypeCode", _TypeCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VoucherNumber", _VoucherNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
