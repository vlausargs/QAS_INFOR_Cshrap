//PROJECT NAME: Data
//CLASS NAME: CmpltPi.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CmpltPi : ICmpltPi
	{
		readonly IApplicationDB appDB;
		
		public CmpltPi(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CmpltPiSp(
			string CallFrom,
			string PVendNum,
			string PVendCurrency,
			int? PPlaces,
			Guid? PoitemRowPointer,
			int? PerformUpdate,
			string PPoType,
			DateTime? POrderDate,
			string PType,
			decimal? PExchRate,
			string POldStat,
			string Infobar)
		{
			LongListType _CallFrom = CallFrom;
			VendNumType _PVendNum = PVendNum;
			CurrCodeType _PVendCurrency = PVendCurrency;
			DecimalPlacesType _PPlaces = PPlaces;
			RowPointerType _PoitemRowPointer = PoitemRowPointer;
			FlagNyType _PerformUpdate = PerformUpdate;
			PoTypeType _PPoType = PPoType;
			DateType _POrderDate = POrderDate;
			LongListType _PType = PType;
			ExchRateType _PExchRate = PExchRate;
			PoitemStatType _POldStat = POldStat;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CmpltPiSp";
				
				appDB.AddCommandParameter(cmd, "CallFrom", _CallFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendCurrency", _PVendCurrency, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPlaces", _PPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoitemRowPointer", _PoitemRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerformUpdate", _PerformUpdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoType", _PPoType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POrderDate", _POrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldStat", _POldStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
