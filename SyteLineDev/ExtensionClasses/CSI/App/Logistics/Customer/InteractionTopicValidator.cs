//PROJECT NAME: CSICustomer
//CLASS NAME: InteractionTopicValidator.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IInteractionTopicValidator
	{
		int InteractionTopicValidatorSp(string InteractionType,
		                                string Topic,
		                                ref string Infobar);
	}
	
	public class InteractionTopicValidator : IInteractionTopicValidator
	{
		readonly IApplicationDB appDB;
		
		public InteractionTopicValidator(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int InteractionTopicValidatorSp(string InteractionType,
		                                       string Topic,
		                                       ref string Infobar)
		{
			InteractionTypeType _InteractionType = InteractionType;
			CommLogTopicType _Topic = Topic;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InteractionTopicValidatorSp";
				
				appDB.AddCommandParameter(cmd, "InteractionType", _InteractionType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Topic", _Topic, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
