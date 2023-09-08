//PROJECT NAME: CSIMaterial
//CLASS NAME: CopyPortalCatalogValidation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface ICopyPortalCatalogValidation
	{
		(int? ReturnCode, string Prompt, string PromptButtons, string Infobar) CopyPortalCatalogValidationSp(string CopyToCatalogID,
		Guid? CatalogRowPointer,
		string Prompt = null,
		string PromptButtons = null,
		string Infobar = null);
	}
	
	public class CopyPortalCatalogValidation : ICopyPortalCatalogValidation
	{
		readonly IApplicationDB appDB;
		
		public CopyPortalCatalogValidation(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Prompt, string PromptButtons, string Infobar) CopyPortalCatalogValidationSp(string CopyToCatalogID,
		Guid? CatalogRowPointer,
		string Prompt = null,
		string PromptButtons = null,
		string Infobar = null)
		{
			ItemCatalogIDType _CopyToCatalogID = CopyToCatalogID;
			RowPointerType _CatalogRowPointer = CatalogRowPointer;
			InfobarType _Prompt = Prompt;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CopyPortalCatalogValidationSp";
				
				appDB.AddCommandParameter(cmd, "CopyToCatalogID", _CopyToCatalogID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CatalogRowPointer", _CatalogRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Prompt", _Prompt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Prompt = _Prompt;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return (Severity, Prompt, PromptButtons, Infobar);
			}
		}
	}
}
