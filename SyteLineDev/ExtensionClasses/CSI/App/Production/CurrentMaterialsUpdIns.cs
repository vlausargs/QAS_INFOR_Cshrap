//PROJECT NAME: Production
//CLASS NAME: CurrentMaterialsUpdIns.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class CurrentMaterialsUpdIns : ICurrentMaterialsUpdIns
	{
		readonly IApplicationDB appDB;
		
		
		public CurrentMaterialsUpdIns(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? MatlLowLevel,
		string Infobar) CurrentMaterialsUpdInsSp(string Item,
		string JobJob,
		int? JobSuffix,
		string JobType,
		string ItmItem,
		int? ItmLowLevel,
		int? DerMatlExist,
		int? MatlLowLevel,
		string Infobar,
		int? Inserted,
		Guid? OldJobmatlRowPointer = null,
		Guid? NewJobmatlRowPointer = null)
		{
			ItemType _Item = Item;
			JobType _JobJob = JobJob;
			SuffixType _JobSuffix = JobSuffix;
			JobTypeType _JobType = JobType;
			ItemType _ItmItem = ItmItem;
			LowLevelType _ItmLowLevel = ItmLowLevel;
			ByteType _DerMatlExist = DerMatlExist;
			LowLevelType _MatlLowLevel = MatlLowLevel;
			Infobar _Infobar = Infobar;
			ByteType _Inserted = Inserted;
			RowPointerType _OldJobmatlRowPointer = OldJobmatlRowPointer;
			RowPointerType _NewJobmatlRowPointer = NewJobmatlRowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CurrentMaterialsUpdInsSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobJob", _JobJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobSuffix", _JobSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobType", _JobType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItmItem", _ItmItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItmLowLevel", _ItmLowLevel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerMatlExist", _DerMatlExist, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlLowLevel", _MatlLowLevel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Inserted", _Inserted, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldJobmatlRowPointer", _OldJobmatlRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewJobmatlRowPointer", _NewJobmatlRowPointer, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				MatlLowLevel = _MatlLowLevel;
				Infobar = _Infobar;
				
				return (Severity, MatlLowLevel, Infobar);
			}
		}
	}
}
