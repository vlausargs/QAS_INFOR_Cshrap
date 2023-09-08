//PROJECT NAME: Data
//CLASS NAME: TrnSsd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class TrnSsd : ITrnSsd
	{
		readonly IApplicationDB appDB;
		
		public TrnSsd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) TrnSsdSp(
			string PType,
			DateTime? PDate,
			decimal? PQty,
			decimal? PTotCost,
			string PFromCurrCode,
			string PToCurrCode,
			string PFromSite,
			string PFromWhse,
			string PToSite,
			string PToWhse,
			string PTrnNum,
			int? PTrnLine,
			string PReasonCode,
			string Infobar)
		{
			LongListType _PType = PType;
			DateType _PDate = PDate;
			QtyUnitType _PQty = PQty;
			CostPrcType _PTotCost = PTotCost;
			CurrCodeType _PFromCurrCode = PFromCurrCode;
			CurrCodeType _PToCurrCode = PToCurrCode;
			SiteType _PFromSite = PFromSite;
			WhseType _PFromWhse = PFromWhse;
			SiteType _PToSite = PToSite;
			WhseType _PToWhse = PToWhse;
			TrnNumType _PTrnNum = PTrnNum;
			TrnLineType _PTrnLine = PTrnLine;
			ReasonCodeType _PReasonCode = PReasonCode;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TrnSsdSp";
				
				appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDate", _PDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQty", _PQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTotCost", _PTotCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFromCurrCode", _PFromCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToCurrCode", _PToCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFromSite", _PFromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFromWhse", _PFromWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToSite", _PToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToWhse", _PToWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTrnNum", _PTrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTrnLine", _PTrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReasonCode", _PReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
