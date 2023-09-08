//PROJECT NAME: LoadProcessQuoteCopyToOrder
//CLASS NAME: LoadProcessQuoteCopyToOrder.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.LoadProcessQuoteCopyToOrder
{
	public class LoadProcessQuoteCopyToOrder : ILoadProcessQuoteCopyToOrder
	{
		readonly IApplicationDB appDB;
		
		public LoadProcessQuoteCopyToOrder(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string NewCoNum,
			string Infobar) LoadProcessQuoteCopyToOrderSp(
			string pEstNum,
			string pQuoteStatus,
			string NewCoNum,
			string Infobar)
		{
			StringType _pEstNum = pEstNum;
			StringType _pQuoteStatus = pQuoteStatus;
			CoNumType _NewCoNum = NewCoNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadProcessQuoteCopyToOrderSp";
				
				appDB.AddCommandParameter(cmd, "pEstNum", _pEstNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pQuoteStatus", _pQuoteStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewCoNum", _NewCoNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NewCoNum = _NewCoNum;
				Infobar = _Infobar;
				
				return (Severity, NewCoNum, Infobar);
			}
		}
	}
}
