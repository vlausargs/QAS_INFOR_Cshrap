//PROJECT NAME: CSICustomer
//CLASS NAME: InsertInteractionTopic.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IInsertInteractionTopic
	{
		int InsertInteractionTopicSp(string InteractionType,
		                             string Topic);
	}
	
	public class InsertInteractionTopic : IInsertInteractionTopic
	{
		readonly IApplicationDB appDB;
		
		public InsertInteractionTopic(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int InsertInteractionTopicSp(string InteractionType,
		                                    string Topic)
		{
			InteractionTypeType _InteractionType = InteractionType;
			CommLogTopicType _Topic = Topic;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InsertInteractionTopicSp";
				
				appDB.AddCommandParameter(cmd, "InteractionType", _InteractionType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Topic", _Topic, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return Severity;
			}
		}
	}
}
