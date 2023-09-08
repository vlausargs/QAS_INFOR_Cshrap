//PROJECT NAME: Data
//CLASS NAME: JobCoByBuildMatl.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class JobCoByBuildMatl : IJobCoByBuildMatl
	{
		readonly IApplicationDB appDB;
		
		public JobCoByBuildMatl(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) JobCoByBuildMatlSp(
			Guid? JobmatlRowPointer,
			string ProdMixItemItem,
			string JobrouteJob,
			int? JobrouteSuffix,
			int? JobrouteOperNum,
			decimal? ReleasedQty,
			decimal? ScrapFact,
			int? Totalize,
			int? Validate,
			int? CalcVarFromStd,
			string Infobar)
		{
			RowPointerType _JobmatlRowPointer = JobmatlRowPointer;
			ItemType _ProdMixItemItem = ProdMixItemItem;
			JobType _JobrouteJob = JobrouteJob;
			SuffixType _JobrouteSuffix = JobrouteSuffix;
			OperNumType _JobrouteOperNum = JobrouteOperNum;
			QtyTotlType _ReleasedQty = ReleasedQty;
			ScrapFactorType _ScrapFact = ScrapFact;
			ListYesNoType _Totalize = Totalize;
			ListYesNoType _Validate = Validate;
			ListYesNoType _CalcVarFromStd = CalcVarFromStd;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobCoByBuildMatlSp";
				
				appDB.AddCommandParameter(cmd, "JobmatlRowPointer", _JobmatlRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProdMixItemItem", _ProdMixItemItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobrouteJob", _JobrouteJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobrouteSuffix", _JobrouteSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobrouteOperNum", _JobrouteOperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReleasedQty", _ReleasedQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ScrapFact", _ScrapFact, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Totalize", _Totalize, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Validate", _Validate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CalcVarFromStd", _CalcVarFromStd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
