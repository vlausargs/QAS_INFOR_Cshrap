//PROJECT NAME: Production
//CLASS NAME: JobOrdersValidateItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class JobOrdersValidateItem : IJobOrdersValidateItem
	{
		readonly IApplicationDB appDB;
		
		
		public JobOrdersValidateItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) JobOrdersValidateItemSp(string PItem,
		string PJob,
		int? PSuffix,
		string PJobType,
		int? PCoProductMix,
		string Infobar)
		{
			ItemType _PItem = PItem;
			JobType _PJob = PJob;
			SuffixType _PSuffix = PSuffix;
			JobTypeType _PJobType = PJobType;
			ListYesNoType _PCoProductMix = PCoProductMix;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobOrdersValidateItemSp";
				
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJob", _PJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuffix", _PSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJobType", _PJobType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoProductMix", _PCoProductMix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
