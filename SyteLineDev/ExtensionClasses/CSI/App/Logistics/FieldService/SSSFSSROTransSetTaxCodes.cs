//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROTransSetTaxCodes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSROTransSetTaxCodes : ISSSFSSROTransSetTaxCodes
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROTransSetTaxCodes(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string TaxCode1,
			string TaxCode2,
			int? PromptFor1,
			int? PromptFor2,
			string Infobar) SSSFSSROTransSetTaxCodesSp(
			string Table,
			string SroNum,
			string Item,
			string TaxCode1,
			string TaxCode2,
			int? PromptFor1,
			int? PromptFor2,
			string Infobar)
		{
			StringType _Table = Table;
			FSSRONumType _SroNum = SroNum;
			ItemType _Item = Item;
			TaxCodeType _TaxCode1 = TaxCode1;
			TaxCodeType _TaxCode2 = TaxCode2;
			ListYesNoType _PromptFor1 = PromptFor1;
			ListYesNoType _PromptFor2 = PromptFor2;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROTransSetTaxCodesSp";
				
				appDB.AddCommandParameter(cmd, "Table", _Table, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode2", _TaxCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptFor1", _PromptFor1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptFor2", _PromptFor2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TaxCode1 = _TaxCode1;
				TaxCode2 = _TaxCode2;
				PromptFor1 = _PromptFor1;
				PromptFor2 = _PromptFor2;
				Infobar = _Infobar;
				
				return (Severity, TaxCode1, TaxCode2, PromptFor1, PromptFor2, Infobar);
			}
		}
	}
}
