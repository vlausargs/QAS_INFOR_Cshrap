//PROJECT NAME: Logistics
//CLASS NAME: CpSoCpSoCb2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CpSoCpSoCb2 : ICpSoCpSoCb2
	{
		readonly IApplicationDB appDB;
		
		public CpSoCpSoCb2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CpSoCpSoCb2Sp(
			string pCoNum,
			int? pCoLine,
			decimal? pContPriceConv,
			decimal? pContPrice,
			string Infobar)
		{
			CoNumType _pCoNum = pCoNum;
			CoLineType _pCoLine = pCoLine;
			CostPrcType _pContPriceConv = pContPriceConv;
			CostPrcType _pContPrice = pContPrice;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CpSoCpSoCb2Sp";
				
				appDB.AddCommandParameter(cmd, "pCoNum", _pCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoLine", _pCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pContPriceConv", _pContPriceConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pContPrice", _pContPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
