//PROJECT NAME: Data
//CLASS NAME: JobValMixPhantom.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class JobValMixPhantom : IJobValMixPhantom
	{
		readonly IApplicationDB appDB;
		
		public JobValMixPhantom(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) JobValMixPhantomSp(
			int? PCalcVarFromStd,
			int? PTotalize,
			decimal? PJobQtyReleased,
			string PJob,
			int? PSuffix,
			string PItem,
			decimal? PScrapFact,
			int? POperNum,
			string Infobar)
		{
			FlagNyType _PCalcVarFromStd = PCalcVarFromStd;
			FlagNyType _PTotalize = PTotalize;
			QtyUnitType _PJobQtyReleased = PJobQtyReleased;
			JobType _PJob = PJob;
			SuffixType _PSuffix = PSuffix;
			ItemType _PItem = PItem;
			ScrapFactorType _PScrapFact = PScrapFact;
			OperNumType _POperNum = POperNum;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobValMixPhantomSp";
				
				appDB.AddCommandParameter(cmd, "PCalcVarFromStd", _PCalcVarFromStd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTotalize", _PTotalize, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJobQtyReleased", _PJobQtyReleased, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJob", _PJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuffix", _PSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PScrapFact", _PScrapFact, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POperNum", _POperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
