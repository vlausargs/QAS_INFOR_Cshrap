//PROJECT NAME: CSIBusInterface
//CLASS NAME: ReplDocumentExtPivot.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface IReplDocumentExtPivot
	{
		int ReplDocumentExtPivotSp(string BODNoun,
		                           string BODVerb,
		                           string DocumentID,
		                           string IDOCollection,
		                           string TextPrefix,
		                           ref string InfoBar);
	}
	
	public class ReplDocumentExtPivot : IReplDocumentExtPivot
	{
		readonly IApplicationDB appDB;
		
		public ReplDocumentExtPivot(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ReplDocumentExtPivotSp(string BODNoun,
		                                  string BODVerb,
		                                  string DocumentID,
		                                  string IDOCollection,
		                                  string TextPrefix,
		                                  ref string InfoBar)
		{
			MarkupDocumentNameType _BODNoun = BODNoun;
			MarkupDocumentNameType _BODVerb = BODVerb;
			MarkupDocumentNameType _DocumentID = DocumentID;
			MarkupDocumentNameType _IDOCollection = IDOCollection;
			MarkupDocumentNameType _TextPrefix = TextPrefix;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ReplDocumentExtPivotSp";
				
				appDB.AddCommandParameter(cmd, "BODNoun", _BODNoun, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BODVerb", _BODVerb, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentID", _DocumentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IDOCollection", _IDOCollection, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TextPrefix", _TextPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return Severity;
			}
		}
	}
}
