//PROJECT NAME: CSICustomer
//CLASS NAME: AddToPortalInteraction.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IAddToPortalInteraction
	{
		(int? ReturnCode, decimal? InteractionId, string IntHeaderText, string Infobar) AddToPortalInteractionSp(decimal? InteractionId,
		string Note,
		string InteractionType,
		string Description,
		string Topic,
		string RefType,
		Guid? RefRowPointer,
		int? CustSeq = 0,
		string IntHeaderText = null,
		string Infobar = null);
	}
	
	public class AddToPortalInteraction : IAddToPortalInteraction
	{
		readonly IApplicationDB appDB;
		
		public AddToPortalInteraction(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? InteractionId, string IntHeaderText, string Infobar) AddToPortalInteractionSp(decimal? InteractionId,
		string Note,
		string InteractionType,
		string Description,
		string Topic,
		string RefType,
		Guid? RefRowPointer,
		int? CustSeq = 0,
		string IntHeaderText = null,
		string Infobar = null)
		{
			InteractionIdType _InteractionId = InteractionId;
			CommLogNotesType _Note = Note;
			InteractionTypeType _InteractionType = InteractionType;
			DescriptionType _Description = Description;
			CommLogTopicType _Topic = Topic;
			InteractionRefTypeType _RefType = RefType;
			RowPointerType _RefRowPointer = RefRowPointer;
			CustSeqType _CustSeq = CustSeq;
			DescriptionType _IntHeaderText = IntHeaderText;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AddToPortalInteractionSp";
				
				appDB.AddCommandParameter(cmd, "InteractionId", _InteractionId, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Note", _Note, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InteractionType", _InteractionType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Topic", _Topic, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRowPointer", _RefRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IntHeaderText", _IntHeaderText, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InteractionId = _InteractionId;
				IntHeaderText = _IntHeaderText;
				Infobar = _Infobar;
				
				return (Severity, InteractionId, IntHeaderText, Infobar);
			}
		}
	}
}
