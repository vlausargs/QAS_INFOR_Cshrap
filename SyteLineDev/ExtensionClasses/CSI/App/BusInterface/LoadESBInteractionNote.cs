//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBInteractionNote.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBInteractionNote
	{
		int LoadESBInteractionNoteSp(string Note,
		                             string noteID,
		                             string InternalExternal,
		                             string Author,
		                             DateTime? entryDateTime,
		                             string InteractionType,
		                             decimal? InteractionID,
		                             string InteractionRefNum,
		                             int? InteractionRefSeq,
		                             int? InteractionSeq,
		                             ref string Infobar);
	}
	
	public class LoadESBInteractionNote : ILoadESBInteractionNote
	{
		readonly IApplicationDB appDB;
		
		public LoadESBInteractionNote(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBInteractionNoteSp(string Note,
		                                    string noteID,
		                                    string InternalExternal,
		                                    string Author,
		                                    DateTime? entryDateTime,
		                                    string InteractionType,
		                                    decimal? InteractionID,
		                                    string InteractionRefNum,
		                                    int? InteractionRefSeq,
		                                    int? InteractionSeq,
		                                    ref string Infobar)
		{
			CommLogNotesType _Note = Note;
			StringType _noteID = noteID;
			StringType _InternalExternal = InternalExternal;
			NameType _Author = Author;
			DateTimeType _entryDateTime = entryDateTime;
			InteractionTypeType _InteractionType = InteractionType;
			InteractionIdType _InteractionID = InteractionID;
			RefNumIdType _InteractionRefNum = InteractionRefNum;
			IntType _InteractionRefSeq = InteractionRefSeq;
			RefSeqType _InteractionSeq = InteractionSeq;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBInteractionNoteSp";
				
				appDB.AddCommandParameter(cmd, "Note", _Note, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "noteID", _noteID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InternalExternal", _InternalExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Author", _Author, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "entryDateTime", _entryDateTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InteractionType", _InteractionType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InteractionID", _InteractionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InteractionRefNum", _InteractionRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InteractionRefSeq", _InteractionRefSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InteractionSeq", _InteractionSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
