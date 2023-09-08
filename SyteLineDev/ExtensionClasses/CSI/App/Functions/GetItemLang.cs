//PROJECT NAME: Data
//CLASS NAME: GetItemLang.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetItemLang : IGetItemLang
	{
		readonly IApplicationDB appDB;
		
		public GetItemLang(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Description,
			string Overview,
			Guid? RowPointer,
			string Infobar) GetItemLangSp(
			string PItem,
			string PLangCode,
			string Description,
			string Overview,
			Guid? RowPointer,
			string Infobar)
		{
			ItemType _PItem = PItem;
			LangCodeType _PLangCode = PLangCode;
			DescriptionType _Description = Description;
			ProductOverviewType _Overview = Overview;
			RowPointerType _RowPointer = RowPointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetItemLangSp";
				
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLangCode", _PLangCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Overview", _Overview, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Description = _Description;
				Overview = _Overview;
				RowPointer = _RowPointer;
				Infobar = _Infobar;
				
				return (Severity, Description, Overview, RowPointer, Infobar);
			}
		}
	}
}
