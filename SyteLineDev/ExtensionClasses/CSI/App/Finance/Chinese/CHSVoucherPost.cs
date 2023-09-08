//PROJECT NAME: Finance
//CLASS NAME: CHSVoucherPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Chinese
{
	public class CHSVoucherPost : ICHSVoucherPost
	{
		readonly IApplicationDB appDB;
		
		
		public CHSVoucherPost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) CHSVoucherPostSp(DateTime? trans_dateP,
		string CrntNmbr,
		string TypeCode,
		string UserName,
		string CalledFrom = null,
		string Infobar = null)
		{
			DateType _trans_dateP = trans_dateP;
			GenericMedCodeType _CrntNmbr = CrntNmbr;
			TransNatType _TypeCode = TypeCode;
			UsernameType _UserName = UserName;
			StringType _CalledFrom = CalledFrom;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CHSVoucherPostSp";
				
				appDB.AddCommandParameter(cmd, "trans_dateP", _trans_dateP, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CrntNmbr", _CrntNmbr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TypeCode", _TypeCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserName", _UserName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CalledFrom", _CalledFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
