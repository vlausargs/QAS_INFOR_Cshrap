//PROJECT NAME: Production
//CLASS NAME: PSSingleReleaseJobCopy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class PSSingleReleaseJobCopy : IPSSingleReleaseJobCopy
	{
		readonly IApplicationDB appDB;
		
		
		public PSSingleReleaseJobCopy(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) PSSingleReleaseJobCopySp(string RJob,
		int? RSuffix,
		string Item,
		string Revision,
		int? FromMRP = 0,
		string PLN_Ref_Type = null,
		string PLN_Ref_Num = null,
		int? PLN_Ref_suf = null,
		string Infobar = null)
		{
			JobType _RJob = RJob;
			SuffixType _RSuffix = RSuffix;
			ItemType _Item = Item;
			RevisionType _Revision = Revision;
			ListYesNoType _FromMRP = FromMRP;
			MrpOrderTypeType _PLN_Ref_Type = PLN_Ref_Type;
			MrpOrderType _PLN_Ref_Num = PLN_Ref_Num;
			MrpOrderLineType _PLN_Ref_suf = PLN_Ref_suf;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PSSingleReleaseJobCopySp";
				
				appDB.AddCommandParameter(cmd, "RJob", _RJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RSuffix", _RSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Revision", _Revision, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromMRP", _FromMRP, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLN_Ref_Type", _PLN_Ref_Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLN_Ref_Num", _PLN_Ref_Num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLN_Ref_suf", _PLN_Ref_suf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
