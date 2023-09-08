//PROJECT NAME: Finance
//CLASS NAME: SSSCCIARPayFromTrans.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public class SSSCCIARPayFromTrans : ISSSCCIARPayFromTrans
	{
		readonly IApplicationDB appDB;


		public SSSCCIARPayFromTrans(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public (int? ReturnCode,
			string Infobar) SSSCCIARPayFromTransSp(
			Guid? CCIRowPointer,
			string Infobar)
		{
			RowPointer _CCIRowPointer = CCIRowPointer;
			Infobar _Infobar = Infobar;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSCCIARPayFromTransSp";

				appDB.AddCommandParameter(cmd, "CCIRowPointer", _CCIRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

				var Severity = appDB.ExecuteNonQuery(cmd);

				Infobar = _Infobar;

				return (Severity, Infobar);
			}
		}
	}
}
