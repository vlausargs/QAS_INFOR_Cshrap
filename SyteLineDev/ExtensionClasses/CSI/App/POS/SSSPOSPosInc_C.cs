//PROJECT NAME: POS
//CLASS NAME: SSSPOSPosInc_C.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.POS
{
	public class SSSPOSPosInc_C : ISSSPOSPosInc_C
	{
		readonly IApplicationDB appDB;
		
		public SSSPOSPosInc_C(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string InvNum,
			string Infobar) SSSPOSPosInc_CSp(
			string CoNum,
			string CustNum,
			string InvCred,
			DateTime? InvDate,
			string InvNum,
			string Infobar,
			int? PackNum = 0)
		{
			CoNumType _CoNum = CoNum;
			CustNumType _CustNum = CustNum;
			StringType _InvCred = InvCred;
			DateType _InvDate = InvDate;
			InvNumType _InvNum = InvNum;
			InfobarType _Infobar = Infobar;
			PackNumType _PackNum = PackNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSPOSPosInc_CSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvCred", _InvCred, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvDate", _InvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PackNum", _PackNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InvNum = _InvNum;
				Infobar = _Infobar;
				
				return (Severity, InvNum, Infobar);
			}
		}
	}
}
