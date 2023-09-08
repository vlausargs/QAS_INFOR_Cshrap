//PROJECT NAME: Data
//CLASS NAME: ESumCoh.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ESumCoh : IESumCoh
	{
		readonly IApplicationDB appDB;
		
		public ESumCoh(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? CohCost,
			decimal? CohLbrCostT,
			decimal? CohMatlCostT,
			decimal? CohFovhdCostT,
			decimal? CohVovhdCostT,
			decimal? CohOutCostT,
			string Infobar) ESumCohSp(
			string CohCoNum,
			int? ConvPlaces,
			decimal? CohCost,
			decimal? CohLbrCostT,
			decimal? CohMatlCostT,
			decimal? CohFovhdCostT,
			decimal? CohVovhdCostT,
			decimal? CohOutCostT,
			string Infobar)
		{
			CoNumType _CohCoNum = CohCoNum;
			DecimalPlacesType _ConvPlaces = ConvPlaces;
			AmountType _CohCost = CohCost;
			AmountType _CohLbrCostT = CohLbrCostT;
			AmountType _CohMatlCostT = CohMatlCostT;
			AmountType _CohFovhdCostT = CohFovhdCostT;
			AmountType _CohVovhdCostT = CohVovhdCostT;
			AmountType _CohOutCostT = CohOutCostT;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ESumCohSp";
				
				appDB.AddCommandParameter(cmd, "CohCoNum", _CohCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConvPlaces", _ConvPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CohCost", _CohCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CohLbrCostT", _CohLbrCostT, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CohMatlCostT", _CohMatlCostT, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CohFovhdCostT", _CohFovhdCostT, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CohVovhdCostT", _CohVovhdCostT, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CohOutCostT", _CohOutCostT, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CohCost = _CohCost;
				CohLbrCostT = _CohLbrCostT;
				CohMatlCostT = _CohMatlCostT;
				CohFovhdCostT = _CohFovhdCostT;
				CohVovhdCostT = _CohVovhdCostT;
				CohOutCostT = _CohOutCostT;
				Infobar = _Infobar;
				
				return (Severity, CohCost, CohLbrCostT, CohMatlCostT, CohFovhdCostT, CohVovhdCostT, CohOutCostT, Infobar);
			}
		}
	}
}
