//PROJECT NAME: Material
//CLASS NAME: NextSjb.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class NextSjb : INextSjb
	{
		readonly IApplicationDB appDB;

		public NextSjb(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public (int? ReturnCode,
			string PKey,
			string Infobar) NextSjbSp(
			string PContext,
			string PPrefix,
			int? PKeyLength,
			string PKey,
			string Infobar)
		{
			LongListType _PContext = PContext;
			LongListType _PPrefix = PPrefix;
			GenericIntType _PKeyLength = PKeyLength;
			JobType _PKey = PKey;
			InfobarType _Infobar = Infobar;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "NextSjbSp";

				appDB.AddCommandParameter(cmd, "PContext", _PContext, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrefix", _PPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PKeyLength", _PKeyLength, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PKey", _PKey, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

				var Severity = appDB.ExecuteNonQuery(cmd);

				PKey = _PKey;
				Infobar = _Infobar;

				return (Severity, PKey, Infobar);
			}
		}
	}
}
