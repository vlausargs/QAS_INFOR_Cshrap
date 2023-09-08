//PROJECT NAME: Production
//CLASS NAME: SernumJ.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class SernumJ : ISernumJ
	{
		readonly IApplicationDB appDB;

		public SernumJ(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public (int? ReturnCode,
			decimal? PQtySelected,
			string Infobar) SernumJSp(
			string PWhse,
			string PActionCode,
			decimal? PTransNum,
			string PLoc,
			string PLot,
			decimal? PQty,
			string Workkey,
			decimal? PQtySelected,
			string Infobar,
			string PImportDocId = null,
			string ContainerNum = null)
		{
			WhseType _PWhse = PWhse;
			LongListType _PActionCode = PActionCode;
			HugeTransNumType _PTransNum = PTransNum;
			LocType _PLoc = PLoc;
			LotType _PLot = PLot;
			QtyUnitType _PQty = PQty;
			LongListType _Workkey = Workkey;
			QtyUnitType _PQtySelected = PQtySelected;
			InfobarType _Infobar = Infobar;
			ImportDocIdType _PImportDocId = PImportDocId;
			ContainerNumType _ContainerNum = ContainerNum;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SernumJSp";

				appDB.AddCommandParameter(cmd, "PWhse", _PWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PActionCode", _PActionCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransNum", _PTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLoc", _PLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLot", _PLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQty", _PQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Workkey", _Workkey, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtySelected", _PQtySelected, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PImportDocId", _PImportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContainerNum", _ContainerNum, ParameterDirection.Input);

				var Severity = appDB.ExecuteNonQuery(cmd);

				PQtySelected = _PQtySelected;
				Infobar = _Infobar;

				return (Severity, PQtySelected, Infobar);
			}
		}
	}
}
