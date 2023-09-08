//PROJECT NAME: Production
//CLASS NAME: MO_ValAlternate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class MO_ValAlternate : IMO_ValAlternate
	{
		readonly IApplicationDB appDB;
		
		
		public MO_ValAlternate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string AlternateDescription,
		int? JobSuffix,
		string Infobar) MO_ValAlternateSp(string JobItem,
		string AlternateID,
		string AlternateDescription,
		int? JobSuffix,
		string Infobar)
		{
			ItemType _JobItem = JobItem;
			MO_BOMAlternateType _AlternateID = AlternateID;
			DescriptionType _AlternateDescription = AlternateDescription;
			SuffixType _JobSuffix = JobSuffix;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MO_ValAlternateSp";
				
				appDB.AddCommandParameter(cmd, "JobItem", _JobItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlternateID", _AlternateID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlternateDescription", _AlternateDescription, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobSuffix", _JobSuffix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				AlternateDescription = _AlternateDescription;
				JobSuffix = _JobSuffix;
				Infobar = _Infobar;
				
				return (Severity, AlternateDescription, JobSuffix, Infobar);
			}
		}
	}
}
