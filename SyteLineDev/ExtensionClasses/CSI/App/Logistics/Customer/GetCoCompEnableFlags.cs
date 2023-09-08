//PROJECT NAME: Logistics
//CLASS NAME: GetCoCompEnableFlags.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetCoCompEnableFlags : IGetCoCompEnableFlags
	{
		readonly IApplicationDB appDB;
		
		
		public GetCoCompEnableFlags(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? EdiOrder,
		int? LcrRequired,
		int? EnableOrderType,
		int? EnableConsolidate,
		int? EnableEffExpDate,
		string Infobar) GetCoCompEnableFlagsSp(string CoNum,
		string CustNum,
		int? UseExchRate,
		int? EdiOrder,
		int? LcrRequired,
		int? EnableOrderType,
		int? EnableConsolidate,
		int? EnableEffExpDate,
		string Infobar)
		{
			CoNumType _CoNum = CoNum;
			CustNumType _CustNum = CustNum;
			ListYesNoType _UseExchRate = UseExchRate;
			ListYesNoType _EdiOrder = EdiOrder;
			ListYesNoType _LcrRequired = LcrRequired;
			ListYesNoType _EnableOrderType = EnableOrderType;
			ListYesNoType _EnableConsolidate = EnableConsolidate;
			ListYesNoType _EnableEffExpDate = EnableEffExpDate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetCoCompEnableFlagsSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseExchRate", _UseExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EdiOrder", _EdiOrder, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LcrRequired", _LcrRequired, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EnableOrderType", _EnableOrderType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EnableConsolidate", _EnableConsolidate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EnableEffExpDate", _EnableEffExpDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				EdiOrder = _EdiOrder;
				LcrRequired = _LcrRequired;
				EnableOrderType = _EnableOrderType;
				EnableConsolidate = _EnableConsolidate;
				EnableEffExpDate = _EnableEffExpDate;
				Infobar = _Infobar;
				
				return (Severity, EdiOrder, LcrRequired, EnableOrderType, EnableConsolidate, EnableEffExpDate, Infobar);
			}
		}
	}
}
