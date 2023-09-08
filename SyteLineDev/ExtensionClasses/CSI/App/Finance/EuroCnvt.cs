//PROJECT NAME: Data
//CLASS NAME: EuroCnvt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{

	public interface IEuroCnvt
	{
		decimal? EuroCnvtFn(decimal? PAmount,
		string PCurrCode,
		int? PFromEuro,
		int? PRoundResult);
	}

	public class EuroCnvt : IEuroCnvt
	{
		readonly IApplicationDB appDB;


		public EuroCnvt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public decimal? EuroCnvtFn(decimal? PAmount,
		string PCurrCode,
		int? PFromEuro,
		int? PRoundResult)
		{
			GenericDecimalType _PAmount = PAmount;
			CurrCodeType _PCurrCode = PCurrCode;
			FlagNyType _PFromEuro = PFromEuro;
			FlagNyType _PRoundResult = PRoundResult;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[EuroCnvt](@PAmount, @PCurrCode, @PFromEuro, @PRoundResult)";

				appDB.AddCommandParameter(cmd, "PAmount", _PAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurrCode", _PCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFromEuro", _PFromEuro, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRoundResult", _PRoundResult, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<decimal?>(cmd);

				return Output;
			}
		}
	}
}
