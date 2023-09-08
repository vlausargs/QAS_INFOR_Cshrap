//PROJECT NAME: Logistics
//CLASS NAME: SSSFSGetCustDef.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class SSSFSGetCustDef : ISSSFSGetCustDef
	{
		readonly IApplicationDB appDB;
		
		
		public SSSFSGetCustDef(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string TransNat,
		string Delterm,
		string ProcessInd,
		string Infobar) SSSFSGetCustDefSp(string CustNum,
		string TransNat,
		string Delterm,
		string ProcessInd,
		string Infobar)
		{
			CustNumType _CustNum = CustNum;
			TransNatType _TransNat = TransNat;
			DeltermType _Delterm = Delterm;
			ProcessIndType _ProcessInd = ProcessInd;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSGetCustDefSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransNat", _TransNat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Delterm", _Delterm, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProcessInd", _ProcessInd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TransNat = _TransNat;
				Delterm = _Delterm;
				ProcessInd = _ProcessInd;
				Infobar = _Infobar;
				
				return (Severity, TransNat, Delterm, ProcessInd, Infobar);
			}
		}
	}
}
