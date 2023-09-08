//PROJECT NAME: CSICustomer
//CLASS NAME: InteractionsDel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IInteractionsDel
	{
		(int? ReturnCode, int? InteractionsDeleted, string Infobar) InteractionsDelSp(string StartingVendNum,
		string EndingVendNum,
		DateTime? StartingInteractionDate,
		DateTime? EndingInteractionDate,
		DateTime? StartingFollowDate,
		DateTime? EndingFollowDate,
		string StartingTopic,
		string EndingTopic,
		int? InteractionsDeleted,
		string Infobar,
		short? StartingInteractionDateOffset = null,
		short? EndingInteractionDateOffset = null,
		short? StartingFollowDateOffset = null,
		short? EndingFollowDateOffset = null,
		string InteractionType = null,
		decimal? StartingInteractionId = null,
		decimal? EndingInteractionId = null,
		string StartingSlsman = null,
		string EndingSlsman = null);
	}
	
	public class InteractionsDel : IInteractionsDel
	{
		readonly IApplicationDB appDB;
		
		public InteractionsDel(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? InteractionsDeleted, string Infobar) InteractionsDelSp(string StartingVendNum,
		string EndingVendNum,
		DateTime? StartingInteractionDate,
		DateTime? EndingInteractionDate,
		DateTime? StartingFollowDate,
		DateTime? EndingFollowDate,
		string StartingTopic,
		string EndingTopic,
		int? InteractionsDeleted,
		string Infobar,
		short? StartingInteractionDateOffset = null,
		short? EndingInteractionDateOffset = null,
		short? StartingFollowDateOffset = null,
		short? EndingFollowDateOffset = null,
		string InteractionType = null,
		decimal? StartingInteractionId = null,
		decimal? EndingInteractionId = null,
		string StartingSlsman = null,
		string EndingSlsman = null)
		{
			VendNumType _StartingVendNum = StartingVendNum;
			VendNumType _EndingVendNum = EndingVendNum;
			DateType _StartingInteractionDate = StartingInteractionDate;
			DateType _EndingInteractionDate = EndingInteractionDate;
			DateType _StartingFollowDate = StartingFollowDate;
			DateType _EndingFollowDate = EndingFollowDate;
			CommLogTopicType _StartingTopic = StartingTopic;
			CommLogTopicType _EndingTopic = EndingTopic;
			IntType _InteractionsDeleted = InteractionsDeleted;
			InfobarType _Infobar = Infobar;
			DateOffsetType _StartingInteractionDateOffset = StartingInteractionDateOffset;
			DateOffsetType _EndingInteractionDateOffset = EndingInteractionDateOffset;
			DateOffsetType _StartingFollowDateOffset = StartingFollowDateOffset;
			DateOffsetType _EndingFollowDateOffset = EndingFollowDateOffset;
			InteractionTypeType _InteractionType = InteractionType;
			InteractionIdType _StartingInteractionId = StartingInteractionId;
			InteractionIdType _EndingInteractionId = EndingInteractionId;
			SlsmanType _StartingSlsman = StartingSlsman;
			SlsmanType _EndingSlsman = EndingSlsman;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InteractionsDelSp";
				
				appDB.AddCommandParameter(cmd, "StartingVendNum", _StartingVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingVendNum", _EndingVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingInteractionDate", _StartingInteractionDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingInteractionDate", _EndingInteractionDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingFollowDate", _StartingFollowDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingFollowDate", _EndingFollowDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingTopic", _StartingTopic, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingTopic", _EndingTopic, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InteractionsDeleted", _InteractionsDeleted, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartingInteractionDateOffset", _StartingInteractionDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingInteractionDateOffset", _EndingInteractionDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingFollowDateOffset", _StartingFollowDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingFollowDateOffset", _EndingFollowDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InteractionType", _InteractionType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingInteractionId", _StartingInteractionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingInteractionId", _EndingInteractionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingSlsman", _StartingSlsman, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingSlsman", _EndingSlsman, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InteractionsDeleted = _InteractionsDeleted;
				Infobar = _Infobar;
				
				return (Severity, InteractionsDeleted, Infobar);
			}
		}
	}
}
