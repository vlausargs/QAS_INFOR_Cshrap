//PROJECT NAME: Data
//CLASS NAME: JoblowSetSubJob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class JoblowSetSubJob : IJoblowSetSubJob
	{
		readonly IApplicationDB appDB;
		
		public JoblowSetSubJob(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? JoblowSetSubJobSp(
			string PList,
			string PJob,
			int? PSuffix,
			int? PLowLevel,
			decimal? PMatlQty,
			string PRefType,
			string PUnits,
			decimal? PScrapFact,
			string PItem)
		{
			StringType _PList = PList;
			JobType _PJob = PJob;
			SuffixType _PSuffix = PSuffix;
			LowLevelType _PLowLevel = PLowLevel;
			QtyPerType _PMatlQty = PMatlQty;
			RefTypeIJKPRTType _PRefType = PRefType;
			JobmatlUnitsType _PUnits = PUnits;
			ScrapFactorType _PScrapFact = PScrapFact;
			ItemType _PItem = PItem;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JoblowSetSubJobSp";
				
				appDB.AddCommandParameter(cmd, "PList", _PList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJob", _PJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuffix", _PSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLowLevel", _PLowLevel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMatlQty", _PMatlQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefType", _PRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUnits", _PUnits, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PScrapFact", _PScrapFact, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
