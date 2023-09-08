//PROJECT NAME: Data
//CLASS NAME: CurrPer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public interface ICurrPer
	{
		int? CurrPerSP(DateTime? Date);
	}

	public class CurrPer : ICurrPer
	{
		readonly IApplicationDB appDB;


		public CurrPer(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public int? CurrPerSP(DateTime? Date)
		{
			DateType _Date = Date;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[CurrPerSP](@Date)";

				appDB.AddCommandParameter(cmd, "Date", _Date, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<int?>(cmd);

				return Output;
			}
		}
	}
}
