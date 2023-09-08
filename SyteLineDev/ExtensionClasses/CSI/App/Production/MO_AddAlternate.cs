//PROJECT NAME: CSIProduct
//CLASS NAME: MO_AddAlternate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public interface IMO_AddAlternate
	{
		(int? ReturnCode, short? JobSuffix, string Infobar, int? OperNum) MO_AddAlternateSp(string JobItem,
		string AlternateID = null,
		string AlternateDescription = null,
		short? JobSuffix = null,
		string Infobar = null,
		int? OperNum = null);
	}
	
	public class MO_AddAlternate : IMO_AddAlternate
	{
		readonly IApplicationDB appDB;
		
		public MO_AddAlternate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, short? JobSuffix, string Infobar, int? OperNum) MO_AddAlternateSp(string JobItem,
		string AlternateID = null,
		string AlternateDescription = null,
		short? JobSuffix = null,
		string Infobar = null,
		int? OperNum = null)
		{
			ItemType _JobItem = JobItem;
			MO_BOMAlternateType _AlternateID = AlternateID;
			DescriptionType _AlternateDescription = AlternateDescription;
			SuffixType _JobSuffix = JobSuffix;
			InfobarType _Infobar = Infobar;
			OperNumType _OperNum = OperNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MO_AddAlternateSp";
				
				appDB.AddCommandParameter(cmd, "JobItem", _JobItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlternateID", _AlternateID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlternateDescription", _AlternateDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobSuffix", _JobSuffix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				JobSuffix = _JobSuffix;
				Infobar = _Infobar;
				OperNum = _OperNum;
				
				return (Severity, JobSuffix, Infobar, OperNum);
			}
		}
	}
}
