//PROJECT NAME: Logistics
//CLASS NAME: ArpmtGetDomEuroCurr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ArpmtGetDomEuroCurr : IArpmtGetDomEuroCurr
	{
		readonly IApplicationDB appDB;
		
		
		public ArpmtGetDomEuroCurr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PEuroCurr,
		int? PDomOfEuro) ArpmtGetDomEuroCurrSp(string PDomCurr,
		string PEuroCurr,
		int? PDomOfEuro)
		{
			CurrCodeType _PDomCurr = PDomCurr;
			CurrCodeType _PEuroCurr = PEuroCurr;
			FlagNyType _PDomOfEuro = PDomOfEuro;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ArpmtGetDomEuroCurrSp";
				
				appDB.AddCommandParameter(cmd, "PDomCurr", _PDomCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEuroCurr", _PEuroCurr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PDomOfEuro", _PDomOfEuro, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PEuroCurr = _PEuroCurr;
				PDomOfEuro = _PDomOfEuro;
				
				return (Severity, PEuroCurr, PDomOfEuro);
			}
		}
	}
}
