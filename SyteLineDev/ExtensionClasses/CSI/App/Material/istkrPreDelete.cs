//PROJECT NAME: Material
//CLASS NAME: istkrPreDelete.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IistkrPreDelete
	{
		(int? ReturnCode, string Infobar, string Prompt, string Buttons) istkrPreDeleteSp(string PWhse,
		string PItem,
		short? PRank,
		string Infobar = null,
		string Prompt = null,
		string Buttons = null);
	}
	
	public class istkrPreDelete : IistkrPreDelete
	{
		readonly IApplicationDB appDB;
		
		public istkrPreDelete(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar, string Prompt, string Buttons) istkrPreDeleteSp(string PWhse,
		string PItem,
		short? PRank,
		string Infobar = null,
		string Prompt = null,
		string Buttons = null)
		{
			WhseType _PWhse = PWhse;
			ItemType _PItem = PItem;
			ItemlocRankType _PRank = PRank;
			InfobarType _Infobar = Infobar;
			Infobar _Prompt = Prompt;
			Infobar _Buttons = Buttons;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "istkrPreDeleteSp";
				
				appDB.AddCommandParameter(cmd, "PWhse", _PWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRank", _PRank, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Prompt", _Prompt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Buttons", _Buttons, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				Prompt = _Prompt;
				Buttons = _Buttons;
				
				return (Severity, Infobar, Prompt, Buttons);
			}
		}
	}
}
