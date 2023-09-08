//PROJECT NAME: Production
//CLASS NAME: PsitemItemValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class PsitemItemValid : IPsitemItemValid
	{
		readonly IApplicationDB appDB;
		
		
		public PsitemItemValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Item,
		string Revision,
		string Description,
		int? StdBOMExists,
		string Infobar) PsitemItemValidSp(string PsNum,
		string Item,
		string Revision,
		string Description,
		int? StdBOMExists,
		string Infobar)
		{
			PsNumType _PsNum = PsNum;
			ItemType _Item = Item;
			RevisionType _Revision = Revision;
			DescriptionType _Description = Description;
			ListYesNoType _StdBOMExists = StdBOMExists;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PsitemItemValidSp";
				
				appDB.AddCommandParameter(cmd, "PsNum", _PsNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Revision", _Revision, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StdBOMExists", _StdBOMExists, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Item = _Item;
				Revision = _Revision;
				Description = _Description;
				StdBOMExists = _StdBOMExists;
				Infobar = _Infobar;
				
				return (Severity, Item, Revision, Description, StdBOMExists, Infobar);
			}
		}
	}
}
