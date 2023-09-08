//PROJECT NAME: Data
//CLASS NAME: DeleteMpsRcpts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DeleteMpsRcpts : IDeleteMpsRcpts
	{
		readonly IApplicationDB appDB;
		
		public DeleteMpsRcpts(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) DeleteMpsRcptsSp(
			string Item,
			int? MpsFlag,
			string Infobar)
		{
			ItemType _Item = Item;
			ListYesNoType _MpsFlag = MpsFlag;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DeleteMpsRcptsSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MpsFlag", _MpsFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
