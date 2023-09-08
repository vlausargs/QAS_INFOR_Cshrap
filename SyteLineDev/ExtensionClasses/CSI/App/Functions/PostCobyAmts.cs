//PROJECT NAME: Data
//CLASS NAME: PostCobyAmts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PostCobyAmts : IPostCobyAmts
	{
		readonly IApplicationDB appDB;
		
		public PostCobyAmts(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) PostCobyAmtsSp(
			string SJobProdMix,
			string SJobrouteJob,
			int? SJobrouteSuffix,
			int? SJobrouteOperNum,
			decimal? SJobtranTransNum,
			decimal? SJobtranFixovhd,
			decimal? SJobtranVarovhd,
			string Infobar)
		{
			ProdMixType _SJobProdMix = SJobProdMix;
			JobType _SJobrouteJob = SJobrouteJob;
			SuffixType _SJobrouteSuffix = SJobrouteSuffix;
			OperNumType _SJobrouteOperNum = SJobrouteOperNum;
			HugeTransNumType _SJobtranTransNum = SJobtranTransNum;
			CostPrcType _SJobtranFixovhd = SJobtranFixovhd;
			CostPrcType _SJobtranVarovhd = SJobtranVarovhd;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PostCobyAmtsSp";
				
				appDB.AddCommandParameter(cmd, "SJobProdMix", _SJobProdMix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SJobrouteJob", _SJobrouteJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SJobrouteSuffix", _SJobrouteSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SJobrouteOperNum", _SJobrouteOperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SJobtranTransNum", _SJobtranTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SJobtranFixovhd", _SJobtranFixovhd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SJobtranVarovhd", _SJobtranVarovhd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
