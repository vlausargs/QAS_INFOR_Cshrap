//PROJECT NAME: Data
//CLASS NAME: GenerateReplAttributesListExt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GenerateReplAttributesListExt : IGenerateReplAttributesListExt
	{
		readonly IApplicationDB appDB;
		
		public GenerateReplAttributesListExt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string GenerateReplAttributesListExtFn(
			string BODNoun,
			string BODVerb,
			string DocumentID,
			int? NodeID)
		{
			MarkupDocumentNameType _BODNoun = BODNoun;
			MarkupDocumentNameType _BODVerb = BODVerb;
			MarkupDocumentNameType _DocumentID = DocumentID;
			XMLNodeIDType _NodeID = NodeID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GenerateReplAttributesListExt](@BODNoun, @BODVerb, @DocumentID, @NodeID)";
				
				appDB.AddCommandParameter(cmd, "BODNoun", _BODNoun, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BODVerb", _BODVerb, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentID", _DocumentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NodeID", _NodeID, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
