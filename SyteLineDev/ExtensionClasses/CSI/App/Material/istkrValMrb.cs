//PROJECT NAME: Material
//CLASS NAME: istkrValMrb.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IistkrValMrb
	{
		(int? ReturnCode, string Infobar) istkrValMrbSp(string PItem,
		                                                byte? PMrbFlag,
		                                                string PLoc,
		                                                string PWhse,
		                                                string Infobar);
	}
	
	public class istkrValMrb : IistkrValMrb
	{
		readonly IApplicationDB appDB;
		
		public istkrValMrb(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) istkrValMrbSp(string PItem,
		                                                       byte? PMrbFlag,
		                                                       string PLoc,
		                                                       string PWhse,
		                                                       string Infobar)
		{
			ItemType _PItem = PItem;
			ListYesNoType _PMrbFlag = PMrbFlag;
			LocType _PLoc = PLoc;
			WhseType _PWhse = PWhse;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "istkrValMrbSp";
				
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMrbFlag", _PMrbFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLoc", _PLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PWhse", _PWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
