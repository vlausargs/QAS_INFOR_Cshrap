//PROJECT NAME: Material
//CLASS NAME: CombineXferDateValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class CombineXferDateValid : ICombineXferDateValid
	{
		readonly IApplicationDB appDB;
		
		
		public CombineXferDateValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar,
		string PromptMsg1,
		string PromptButtons1,
		string PromptMsg2,
		string PromptButtons2) CombineXferDateValidSp(string FromSite,
		string ToSite,
		DateTime? InDate,
		string Infobar,
		string PromptMsg1,
		string PromptButtons1,
		string PromptMsg2,
		string PromptButtons2)
		{
			SiteType _FromSite = FromSite;
			SiteType _ToSite = ToSite;
			DateType _InDate = InDate;
			InfobarType _Infobar = Infobar;
			InfobarType _PromptMsg1 = PromptMsg1;
			Infobar _PromptButtons1 = PromptButtons1;
			InfobarType _PromptMsg2 = PromptMsg2;
			Infobar _PromptButtons2 = PromptButtons2;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CombineXferDateValidSp";
				
				appDB.AddCommandParameter(cmd, "FromSite", _FromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InDate", _InDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg1", _PromptMsg1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons1", _PromptButtons1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg2", _PromptMsg2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons2", _PromptButtons2, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				PromptMsg1 = _PromptMsg1;
				PromptButtons1 = _PromptButtons1;
				PromptMsg2 = _PromptMsg2;
				PromptButtons2 = _PromptButtons2;
				
				return (Severity, Infobar, PromptMsg1, PromptButtons1, PromptMsg2, PromptButtons2);
			}
		}
	}
}
