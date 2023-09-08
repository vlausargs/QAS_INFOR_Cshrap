//PROJECT NAME: Production
//CLASS NAME: ProcessBOMImportBuilder.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class ProcessBOMImportBuilder : IProcessBOMImportBuilder
	{
		readonly IApplicationDB appDB;
		
		
		public ProcessBOMImportBuilder(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PrJob,
		int? PrSuffix,
		string PrItem,
		string Infobar) ProcessBOMImportBuilderSp(Guid? ProcessId,
		string ParentItem,
		string ParentItemDescription,
		string ParentUM,
		string ParentRevision,
		string ParentSource,
		string ParentProductCode,
		string ParentMatlType,
		string PrCategory,
		string PrJob,
		int? PrSuffix,
		string PrSchedId,
		string PrItem,
		DateTime? PrRelease,
		string Infobar,
		string PrAlternateID)
		{
			RowPointerType _ProcessId = ProcessId;
			ItemType _ParentItem = ParentItem;
			DescriptionType _ParentItemDescription = ParentItemDescription;
			UMType _ParentUM = ParentUM;
			RevisionType _ParentRevision = ParentRevision;
			PMTCodeType _ParentSource = ParentSource;
			ProductCodeType _ParentProductCode = ParentProductCode;
			MatlTypeType _ParentMatlType = ParentMatlType;
			JobTypeType _PrCategory = PrCategory;
			JobType _PrJob = PrJob;
			SuffixType _PrSuffix = PrSuffix;
			PsNumType _PrSchedId = PrSchedId;
			ItemType _PrItem = PrItem;
			DateType _PrRelease = PrRelease;
			InfobarType _Infobar = Infobar;
			MO_BOMAlternateType _PrAlternateID = PrAlternateID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProcessBOMImportBuilderSp";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParentItem", _ParentItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParentItemDescription", _ParentItemDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParentUM", _ParentUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParentRevision", _ParentRevision, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParentSource", _ParentSource, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParentProductCode", _ParentProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParentMatlType", _ParentMatlType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrCategory", _PrCategory, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrJob", _PrJob, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrSuffix", _PrSuffix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrSchedId", _PrSchedId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrItem", _PrItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrRelease", _PrRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrAlternateID", _PrAlternateID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PrJob = _PrJob;
				PrSuffix = _PrSuffix;
				PrItem = _PrItem;
				Infobar = _Infobar;
				
				return (Severity, PrJob, PrSuffix, PrItem, Infobar);
			}
		}
	}
}
