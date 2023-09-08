//PROJECT NAME: Finance
//CLASS NAME: ExtFinGetIGFData.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.ExtFin
{
	public class ExtFinGetIGFData : IExtFinGetIGFData
	{
		readonly IApplicationDB appDB;
		
		public ExtFinGetIGFData(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ExtFinGetIGFDataSp(
			string Request,
			string StartingCustNum,
			string EndingCustNum,
			string Infobar)
		{
			StringType _Request = Request;
			CustNumType _StartingCustNum = StartingCustNum;
			CustNumType _EndingCustNum = EndingCustNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ExtFinGetIGFDataSp";
				
				appDB.AddCommandParameter(cmd, "Request", _Request, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingCustNum", _StartingCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingCustNum", _EndingCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
