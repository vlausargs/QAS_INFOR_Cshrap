//PROJECT NAME: Finance
//CLASS NAME: CHSSumDorCAmtForCHVucher.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Chinese
{
	public class CHSSumDorCAmtForCHVucher : ICHSSumDorCAmtForCHVucher
	{
		readonly IApplicationDB appDB;
		
		public CHSSumDorCAmtForCHVucher(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CHSSumDorCAmtForCHVucherSp(
			string TypeCode,
			string CrntNmbr,
			DateTime? Trans_Date,
			string Infobar)
		{
			TransNatType _TypeCode = TypeCode;
			GenericMedCodeType _CrntNmbr = CrntNmbr;
			DateType _Trans_Date = Trans_Date;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CHSSumDorCAmtForCHVucherSp";
				
				appDB.AddCommandParameter(cmd, "TypeCode", _TypeCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CrntNmbr", _CrntNmbr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Trans_Date", _Trans_Date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
