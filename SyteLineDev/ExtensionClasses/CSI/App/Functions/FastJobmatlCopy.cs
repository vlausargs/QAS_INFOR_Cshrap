//PROJECT NAME: Data
//CLASS NAME: FastJobmatlCopy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FastJobmatlCopy : IFastJobmatlCopy
	{
		readonly IApplicationDB appDB;
		
		public FastJobmatlCopy(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) FastJobmatlCopySp(
			Guid? SessionID,
			decimal? MatlQty,
			string Units,
			decimal? ScrapFact,
			string JobItem,
			DateTime? EffectDate,
			string ToJob,
			int? ToSuffix,
			string Infobar,
			int? ResequenceOperations = 0,
			int? OperNumOffset = 0,
			string FromJob = null,
			int? FromSuffix = 0)
		{
			RowPointerType _SessionID = SessionID;
			QtyUnitType _MatlQty = MatlQty;
			JobmatlUnitsType _Units = Units;
			ScrapFactorType _ScrapFact = ScrapFact;
			ItemType _JobItem = JobItem;
			DateType _EffectDate = EffectDate;
			JobType _ToJob = ToJob;
			SuffixType _ToSuffix = ToSuffix;
			InfobarType _Infobar = Infobar;
			ListYesNoType _ResequenceOperations = ResequenceOperations;
			OperNumType _OperNumOffset = OperNumOffset;
			JobType _FromJob = FromJob;
			SuffixType _FromSuffix = FromSuffix;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FastJobmatlCopySp";
				
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlQty", _MatlQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Units", _Units, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ScrapFact", _ScrapFact, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobItem", _JobItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EffectDate", _EffectDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToJob", _ToJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSuffix", _ToSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ResequenceOperations", _ResequenceOperations, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNumOffset", _OperNumOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromJob", _FromJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSuffix", _FromSuffix, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
