//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PurchaseOrder0.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_PurchaseOrder0 : IRpt_PurchaseOrder0
	{
		readonly IApplicationDB appDB;
		
		public Rpt_PurchaseOrder0(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) Rpt_PurchaseOrder0Sp(
			string pPoType = null,
			string pPoStat = null,
			string pPoitemStat = null,
			string pStartPoNum = null,
			string pEndPoNum = null,
			int? pStartPoLine = null,
			int? pEndPoLine = null,
			int? pStartPoRElease = null,
			int? pEndPoRelease = null,
			DateTime? pStartDueDate = null,
			DateTime? pEndDueDate = null,
			string pStartvendor = null,
			string pEndVendor = null,
			DateTime? pStartorderDate = null,
			DateTime? pEndOrderDate = null,
			string SessionId = null,
			string Infobar = null)
		{
			StringType _pPoType = pPoType;
			StringType _pPoStat = pPoStat;
			StringType _pPoitemStat = pPoitemStat;
			PoNumType _pStartPoNum = pStartPoNum;
			PoNumType _pEndPoNum = pEndPoNum;
			PoLineType _pStartPoLine = pStartPoLine;
			PoLineType _pEndPoLine = pEndPoLine;
			PoReleaseType _pStartPoRElease = pStartPoRElease;
			PoReleaseType _pEndPoRelease = pEndPoRelease;
			DateType _pStartDueDate = pStartDueDate;
			DateType _pEndDueDate = pEndDueDate;
			VendNumType _pStartvendor = pStartvendor;
			VendNumType _pEndVendor = pEndVendor;
			DateType _pStartorderDate = pStartorderDate;
			DateType _pEndOrderDate = pEndOrderDate;
			StringType _SessionId = SessionId;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_PurchaseOrder0Sp";
				
				appDB.AddCommandParameter(cmd, "pPoType", _pPoType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPoStat", _pPoStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPoitemStat", _pPoitemStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartPoNum", _pStartPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndPoNum", _pEndPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartPoLine", _pStartPoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndPoLine", _pEndPoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartPoRElease", _pStartPoRElease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndPoRelease", _pEndPoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartDueDate", _pStartDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndDueDate", _pEndDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartvendor", _pStartvendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndVendor", _pEndVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartorderDate", _pStartorderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndOrderDate", _pEndOrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
