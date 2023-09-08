//PROJECT NAME: Production
//CLASS NAME: PP_SumPrintQuotePriceForRootJob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class PP_SumPrintQuotePriceForRootJob : IPP_SumPrintQuotePriceForRootJob
	{
		readonly IApplicationDB appDB;
		
		
		public PP_SumPrintQuotePriceForRootJob(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? PriceForRootJob,
		decimal? CoitemExtPrice,
		string Infobar) PP_SumPrintQuotePriceForRootJobSp(string RootJob,
		int? RootSuffix,
		decimal? PriceForRootJob,
		decimal? CoitemExtPrice,
		string Infobar)
		{
			JobType _RootJob = RootJob;
			SuffixType _RootSuffix = RootSuffix;
			CostPrcType _PriceForRootJob = PriceForRootJob;
			CostPrcType _CoitemExtPrice = CoitemExtPrice;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PP_SumPrintQuotePriceForRootJobSp";
				
				appDB.AddCommandParameter(cmd, "RootJob", _RootJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RootSuffix", _RootSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriceForRootJob", _PriceForRootJob, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoitemExtPrice", _CoitemExtPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PriceForRootJob = _PriceForRootJob;
				CoitemExtPrice = _CoitemExtPrice;
				Infobar = _Infobar;
				
				return (Severity, PriceForRootJob, CoitemExtPrice, Infobar);
			}
		}

		public decimal? PP_SumPrintQuotePriceForRootJobFn(
			string RefType,
			string RootJob,
			int? RootSuffix)
		{
			RefTypeIJKPRTType _RefType = RefType;
			JobType _RootJob = RootJob;
			SuffixType _RootSuffix = RootSuffix;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[PP_SumPrintQuotePriceForRootJob](@RefType, @RootJob, @RootSuffix)";

				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RootJob", _RootJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RootSuffix", _RootSuffix, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<decimal?>(cmd);

				return Output;
			}
		}
	}
}
