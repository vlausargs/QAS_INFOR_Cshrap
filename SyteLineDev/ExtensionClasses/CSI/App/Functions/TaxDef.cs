//PROJECT NAME: Data
//CLASS NAME: TaxDef.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class TaxDef : ITaxDef
	{
		readonly IApplicationDB appDB;
		
		public TaxDef(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar,
			int? PActiveForPurch1,
			int? PActiveForPurch2,
			int? PPromptOnline1,
			int? PPromptOnline2,
			string PPromptWhere1,
			string PPromptWhere2,
			string PDefTaxcode1,
			string PDefTaxcode2,
			string PDefFrtTaxcode1,
			string PDefFrtTaxcode2,
			string PDefMscTaxcode1,
			string PDefMscTaxcode2,
			string PItemTaxcode1,
			string PItemTaxcode2,
			string PMode1,
			string PMode2,
			string PTaxamtLabel_1,
			string PTaxamtLabel_2,
			string PTaxcodeLabel_1,
			string PTaxcodeLabel_2,
			string PTaxitemLabel_1,
			string PTaxitemLabel_2,
			string PTaxidLabel_1,
			string PTaxidLabel_2,
			string PTaxdesc_1,
			string PTaxdesc_2,
			string PFrtdesc_1,
			string PFrtdesc_2,
			string PMscdesc_1,
			string PMscdesc_2) TaxDefSp(
			int? PNoColon = 1,
			string Infobar = null,
			int? PActiveForPurch1 = 0,
			int? PActiveForPurch2 = 0,
			int? PPromptOnline1 = 0,
			int? PPromptOnline2 = 0,
			string PPromptWhere1 = "",
			string PPromptWhere2 = "",
			string PDefTaxcode1 = "",
			string PDefTaxcode2 = "",
			string PDefFrtTaxcode1 = "",
			string PDefFrtTaxcode2 = "",
			string PDefMscTaxcode1 = "",
			string PDefMscTaxcode2 = "",
			string PItemTaxcode1 = "",
			string PItemTaxcode2 = "",
			string PMode1 = "",
			string PMode2 = "",
			string PTaxamtLabel_1 = "",
			string PTaxamtLabel_2 = "",
			string PTaxcodeLabel_1 = "",
			string PTaxcodeLabel_2 = "",
			string PTaxitemLabel_1 = "",
			string PTaxitemLabel_2 = "",
			string PTaxidLabel_1 = "",
			string PTaxidLabel_2 = "",
			string PTaxdesc_1 = "",
			string PTaxdesc_2 = "",
			string PFrtdesc_1 = "",
			string PFrtdesc_2 = "",
			string PMscdesc_1 = "",
			string PMscdesc_2 = "")
		{
			ListYesNoType _PNoColon = PNoColon;
			InfobarType _Infobar = Infobar;
			ListYesNoType _PActiveForPurch1 = PActiveForPurch1;
			ListYesNoType _PActiveForPurch2 = PActiveForPurch2;
			ListYesNoType _PPromptOnline1 = PPromptOnline1;
			ListYesNoType _PPromptOnline2 = PPromptOnline2;
			TaxIdPromptType _PPromptWhere1 = PPromptWhere1;
			TaxIdPromptType _PPromptWhere2 = PPromptWhere2;
			TaxCodeType _PDefTaxcode1 = PDefTaxcode1;
			TaxCodeType _PDefTaxcode2 = PDefTaxcode2;
			TaxCodeType _PDefFrtTaxcode1 = PDefFrtTaxcode1;
			TaxCodeType _PDefFrtTaxcode2 = PDefFrtTaxcode2;
			TaxCodeType _PDefMscTaxcode1 = PDefMscTaxcode1;
			TaxCodeType _PDefMscTaxcode2 = PDefMscTaxcode2;
			TaxCodeType _PItemTaxcode1 = PItemTaxcode1;
			TaxCodeType _PItemTaxcode2 = PItemTaxcode2;
			TaxModeType _PMode1 = PMode1;
			TaxModeType _PMode2 = PMode2;
			LongListType _PTaxamtLabel_1 = PTaxamtLabel_1;
			LongListType _PTaxamtLabel_2 = PTaxamtLabel_2;
			LongListType _PTaxcodeLabel_1 = PTaxcodeLabel_1;
			LongListType _PTaxcodeLabel_2 = PTaxcodeLabel_2;
			LongListType _PTaxitemLabel_1 = PTaxitemLabel_1;
			LongListType _PTaxitemLabel_2 = PTaxitemLabel_2;
			LongListType _PTaxidLabel_1 = PTaxidLabel_1;
			LongListType _PTaxidLabel_2 = PTaxidLabel_2;
			LongListType _PTaxdesc_1 = PTaxdesc_1;
			LongListType _PTaxdesc_2 = PTaxdesc_2;
			LongListType _PFrtdesc_1 = PFrtdesc_1;
			LongListType _PFrtdesc_2 = PFrtdesc_2;
			LongListType _PMscdesc_1 = PMscdesc_1;
			LongListType _PMscdesc_2 = PMscdesc_2;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TaxDefSp";
				
				appDB.AddCommandParameter(cmd, "PNoColon", _PNoColon, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PActiveForPurch1", _PActiveForPurch1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PActiveForPurch2", _PActiveForPurch2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPromptOnline1", _PPromptOnline1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPromptOnline2", _PPromptOnline2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPromptWhere1", _PPromptWhere1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPromptWhere2", _PPromptWhere2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PDefTaxcode1", _PDefTaxcode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PDefTaxcode2", _PDefTaxcode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PDefFrtTaxcode1", _PDefFrtTaxcode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PDefFrtTaxcode2", _PDefFrtTaxcode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PDefMscTaxcode1", _PDefMscTaxcode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PDefMscTaxcode2", _PDefMscTaxcode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PItemTaxcode1", _PItemTaxcode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PItemTaxcode2", _PItemTaxcode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PMode1", _PMode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PMode2", _PMode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTaxamtLabel_1", _PTaxamtLabel_1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTaxamtLabel_2", _PTaxamtLabel_2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTaxcodeLabel_1", _PTaxcodeLabel_1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTaxcodeLabel_2", _PTaxcodeLabel_2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTaxitemLabel_1", _PTaxitemLabel_1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTaxitemLabel_2", _PTaxitemLabel_2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTaxidLabel_1", _PTaxidLabel_1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTaxidLabel_2", _PTaxidLabel_2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTaxdesc_1", _PTaxdesc_1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTaxdesc_2", _PTaxdesc_2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PFrtdesc_1", _PFrtdesc_1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PFrtdesc_2", _PFrtdesc_2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PMscdesc_1", _PMscdesc_1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PMscdesc_2", _PMscdesc_2, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				PActiveForPurch1 = _PActiveForPurch1;
				PActiveForPurch2 = _PActiveForPurch2;
				PPromptOnline1 = _PPromptOnline1;
				PPromptOnline2 = _PPromptOnline2;
				PPromptWhere1 = _PPromptWhere1;
				PPromptWhere2 = _PPromptWhere2;
				PDefTaxcode1 = _PDefTaxcode1;
				PDefTaxcode2 = _PDefTaxcode2;
				PDefFrtTaxcode1 = _PDefFrtTaxcode1;
				PDefFrtTaxcode2 = _PDefFrtTaxcode2;
				PDefMscTaxcode1 = _PDefMscTaxcode1;
				PDefMscTaxcode2 = _PDefMscTaxcode2;
				PItemTaxcode1 = _PItemTaxcode1;
				PItemTaxcode2 = _PItemTaxcode2;
				PMode1 = _PMode1;
				PMode2 = _PMode2;
				PTaxamtLabel_1 = _PTaxamtLabel_1;
				PTaxamtLabel_2 = _PTaxamtLabel_2;
				PTaxcodeLabel_1 = _PTaxcodeLabel_1;
				PTaxcodeLabel_2 = _PTaxcodeLabel_2;
				PTaxitemLabel_1 = _PTaxitemLabel_1;
				PTaxitemLabel_2 = _PTaxitemLabel_2;
				PTaxidLabel_1 = _PTaxidLabel_1;
				PTaxidLabel_2 = _PTaxidLabel_2;
				PTaxdesc_1 = _PTaxdesc_1;
				PTaxdesc_2 = _PTaxdesc_2;
				PFrtdesc_1 = _PFrtdesc_1;
				PFrtdesc_2 = _PFrtdesc_2;
				PMscdesc_1 = _PMscdesc_1;
				PMscdesc_2 = _PMscdesc_2;
				
				return (Severity, Infobar, PActiveForPurch1, PActiveForPurch2, PPromptOnline1, PPromptOnline2, PPromptWhere1, PPromptWhere2, PDefTaxcode1, PDefTaxcode2, PDefFrtTaxcode1, PDefFrtTaxcode2, PDefMscTaxcode1, PDefMscTaxcode2, PItemTaxcode1, PItemTaxcode2, PMode1, PMode2, PTaxamtLabel_1, PTaxamtLabel_2, PTaxcodeLabel_1, PTaxcodeLabel_2, PTaxitemLabel_1, PTaxitemLabel_2, PTaxidLabel_1, PTaxidLabel_2, PTaxdesc_1, PTaxdesc_2, PFrtdesc_1, PFrtdesc_2, PMscdesc_1, PMscdesc_2);
			}
		}
	}
}
