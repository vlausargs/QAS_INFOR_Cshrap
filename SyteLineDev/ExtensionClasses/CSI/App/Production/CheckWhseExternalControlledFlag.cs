//PROJECT NAME: Production
//CLASS NAME: CheckWhseExternalControlledFlag.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class CheckWhseExternalControlledFlag : ICheckWhseExternalControlledFlag
	{
		readonly IApplicationDB appDB;

		public CheckWhseExternalControlledFlag(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public (int? ReturnCode,
			string Infobar) CheckWhseExternalControlledFlagSp(
			string PWhse,
			string PSite,
			string Infobar)
		{
			WhseType _PWhse = PWhse;
			SiteType _PSite = PSite;
			InfobarType _Infobar = Infobar;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckWhseExternalControlledFlagSp";

				appDB.AddCommandParameter(cmd, "PWhse", _PWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

				var Severity = appDB.ExecuteNonQuery(cmd);

				Infobar = _Infobar;

				return (Severity, Infobar);
			}
		}
	}
}
