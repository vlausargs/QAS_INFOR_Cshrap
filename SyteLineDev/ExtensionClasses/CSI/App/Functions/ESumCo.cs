//PROJECT NAME: Data
//CLASS NAME: ESumCo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ESumCo : IESumCo
	{
		readonly IApplicationDB appDB;
		
		public ESumCo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? CoCost,
			decimal? CoLbrCostT,
			decimal? CoMatlCostT,
			decimal? CoFovhdCostT,
			decimal? CoVovhdCostT,
			decimal? CoOutCostT,
			string Infobar) ESumCoSp(
			string CoCoNum,
			int? ConvPlaces,
			decimal? CoCost,
			decimal? CoLbrCostT,
			decimal? CoMatlCostT,
			decimal? CoFovhdCostT,
			decimal? CoVovhdCostT,
			decimal? CoOutCostT,
			string Infobar)
		{
			CoNumType _CoCoNum = CoCoNum;
			DecimalPlacesType _ConvPlaces = ConvPlaces;
			AmountType _CoCost = CoCost;
			AmountType _CoLbrCostT = CoLbrCostT;
			AmountType _CoMatlCostT = CoMatlCostT;
			AmountType _CoFovhdCostT = CoFovhdCostT;
			AmountType _CoVovhdCostT = CoVovhdCostT;
			AmountType _CoOutCostT = CoOutCostT;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ESumCoSp";
				
				appDB.AddCommandParameter(cmd, "CoCoNum", _CoCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConvPlaces", _ConvPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoCost", _CoCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoLbrCostT", _CoLbrCostT, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoMatlCostT", _CoMatlCostT, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoFovhdCostT", _CoFovhdCostT, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoVovhdCostT", _CoVovhdCostT, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoOutCostT", _CoOutCostT, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CoCost = _CoCost;
				CoLbrCostT = _CoLbrCostT;
				CoMatlCostT = _CoMatlCostT;
				CoFovhdCostT = _CoFovhdCostT;
				CoVovhdCostT = _CoVovhdCostT;
				CoOutCostT = _CoOutCostT;
				Infobar = _Infobar;
				
				return (Severity, CoCost, CoLbrCostT, CoMatlCostT, CoFovhdCostT, CoVovhdCostT, CoOutCostT, Infobar);
			}
		}
	}
}
