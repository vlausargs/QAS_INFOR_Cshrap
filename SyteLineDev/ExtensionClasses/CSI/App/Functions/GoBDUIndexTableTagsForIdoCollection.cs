//PROJECT NAME: Data
//CLASS NAME: GoBDUIndexTableTagsForIdoCollection.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GoBDUIndexTableTagsForIdoCollection : IGoBDUIndexTableTagsForIdoCollection
	{
		readonly IApplicationDB appDB;
		
		public GoBDUIndexTableTagsForIdoCollection(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string GoBDUIndexTableTagsForIdoCollectionFn(
			DateTime? TransDateBeg,
			DateTime? TransDateEnd,
			string CollectionName)
		{
			DateType _TransDateBeg = TransDateBeg;
			DateType _TransDateEnd = TransDateEnd;
			StringType _CollectionName = CollectionName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GoBDUIndexTableTagsForIdoCollection](@TransDateBeg, @TransDateEnd, @CollectionName)";
				
				appDB.AddCommandParameter(cmd, "TransDateBeg", _TransDateBeg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDateEnd", _TransDateEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CollectionName", _CollectionName, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
