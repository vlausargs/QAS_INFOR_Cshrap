//PROJECT NAME: CSICustomer
//CLASS NAME: GetMaxInteractionDetailsSequence.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IGetMaxInteractionDetailsSequence
	{
		int GetMaxInteractionDetailsSequenceSp(decimal? InteractionId,
		                                       ref decimal? MaxSequence,
		                                       ref string InfobarType);
	}
	
	public class GetMaxInteractionDetailsSequence : IGetMaxInteractionDetailsSequence
	{
		readonly IApplicationDB appDB;
		
		public GetMaxInteractionDetailsSequence(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetMaxInteractionDetailsSequenceSp(decimal? InteractionId,
		                                              ref decimal? MaxSequence,
		                                              ref string InfobarType)
		{
			InteractionIdType _InteractionId = InteractionId;
			SequenceType _MaxSequence = MaxSequence;
			InfobarType _InfobarType = InfobarType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetMaxInteractionDetailsSequenceSp";
				
				appDB.AddCommandParameter(cmd, "InteractionId", _InteractionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MaxSequence", _MaxSequence, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InfobarType", _InfobarType, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				MaxSequence = _MaxSequence;
				InfobarType = _InfobarType;
				
				return Severity;
			}
		}
	}
}
