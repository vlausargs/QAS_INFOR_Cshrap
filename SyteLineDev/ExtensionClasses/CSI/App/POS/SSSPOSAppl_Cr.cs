//PROJECT NAME: POS
//CLASS NAME: SSSPOSAppl_Cr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.POS
{
	public class SSSPOSAppl_Cr : ISSSPOSAppl_Cr
	{
		readonly IApplicationDB appDB;
		
		public SSSPOSAppl_Cr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSPOSAppl_CrSp(
			string POSMCredInvNum,
			string CoNum,
			string ParmCurrCode,
			string Infobar,
			string POSNum)
		{
			InvNumType _POSMCredInvNum = POSMCredInvNum;
			CoNumType _CoNum = CoNum;
			CurrCodeType _ParmCurrCode = ParmCurrCode;
			InfobarType _Infobar = Infobar;
			POSMNumType _POSNum = POSNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSPOSAppl_CrSp";
				
				appDB.AddCommandParameter(cmd, "POSMCredInvNum", _POSMCredInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmCurrCode", _ParmCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "POSNum", _POSNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
