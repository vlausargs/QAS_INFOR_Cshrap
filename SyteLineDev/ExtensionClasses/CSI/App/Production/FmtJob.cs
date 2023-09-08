//PROJECT NAME: Data
//CLASS NAME: FmtJob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class FmtJob : IFmtJob
	{
		readonly IApplicationDB appDB;


		public FmtJob(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public string FmtJobSp(
			string RefNum,
			int? Suffix)
		{
			AnyRefNumType _RefNum = RefNum;
			SuffixType _Suffix = Suffix;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[FmtJobSp](@RefNum, @Suffix)";

				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<string>(cmd);

				return Output;
			}
		}
	}
}
