//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroReSumAll.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSroReSumAll : ISSSFSSroReSumAll
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSroReSumAll(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSFSSroReSumAllSp(
			string SroNum,
			string Infobar,
			int? CalledFromInvoicing = 0)
		{
			FSSRONumType _SroNum = SroNum;
			Infobar _Infobar = Infobar;
			ListYesNoType _CalledFromInvoicing = CalledFromInvoicing;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSroReSumAllSp";
				
				appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CalledFromInvoicing", _CalledFromInvoicing, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
