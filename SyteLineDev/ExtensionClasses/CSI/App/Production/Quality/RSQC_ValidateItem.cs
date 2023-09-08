//PROJECT NAME: Production
//CLASS NAME: RSQC_ValidateIt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_ValidateIt : IRSQC_ValidateIt
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_ValidateIt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Description,
		string Infobar) RSQC_ValidateItem(string SiteRef,
		int? ValidateOk,
		string ItemNum,
		string Description,
		string Infobar)
		{
			SiteType _SiteRef = SiteRef;
			ListYesNoType _ValidateOk = ValidateOk;
			ItemType _ItemNum = ItemNum;
			DescriptionType _Description = Description;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_ValidateItem";
				
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ValidateOk", _ValidateOk, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemNum", _ItemNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Description = _Description;
				Infobar = _Infobar;
				
				return (Severity, Description, Infobar);
			}
		}
	}
}
