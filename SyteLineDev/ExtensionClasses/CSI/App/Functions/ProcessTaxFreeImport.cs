//PROJECT NAME: Data
//CLASS NAME: ProcessTaxFreeImport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ProcessTaxFreeImport : IProcessTaxFreeImport
	{
		readonly IApplicationDB appDB;
		
		public ProcessTaxFreeImport(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ProcessTaxFreeImportSp(
			string pItem,
			string Infobar)
		{
			ItemType _pItem = pItem;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProcessTaxFreeImportSp";
				
				appDB.AddCommandParameter(cmd, "pItem", _pItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
