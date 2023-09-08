//PROJECT NAME: Finance
//CLASS NAME: SSSVTXPostRegisterTXW.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.TaxInterface
{
	public class SSSVTXPostRegisterTXW : ISSSVTXPostRegisterTXW
	{
		readonly IApplicationDB appDB;
		
		public SSSVTXPostRegisterTXW(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSVTXPostRegisterTXWSp(
			string FormCaption,
			int? BGTaskID,
			string Infobar)
		{
			LongListType _FormCaption = FormCaption;
			GenericNoType _BGTaskID = BGTaskID;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSVTXPostRegisterTXWSp";
				
				appDB.AddCommandParameter(cmd, "FormCaption", _FormCaption, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGTaskID", _BGTaskID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
