//PROJECT NAME: Data
//CLASS NAME: EstSheetI.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EstSheetI : IEstSheetI
	{
		readonly IApplicationDB appDB;
		
		public EstSheetI(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? LCost1,
			decimal? LCost2,
			decimal? LCost3,
			decimal? LCost4,
			decimal? LCost5,
			decimal? LCost6,
			decimal? LCost7,
			decimal? LCost8,
			decimal? UCost1,
			decimal? UCost2,
			decimal? UCost3,
			decimal? UCost4,
			decimal? UCost5,
			decimal? UCost6,
			decimal? UCost7,
			decimal? UCost8,
			string Infobar) EstSheetISp(
			Guid? PJobRowid,
			decimal? LCost1,
			decimal? LCost2,
			decimal? LCost3,
			decimal? LCost4,
			decimal? LCost5,
			decimal? LCost6,
			decimal? LCost7,
			decimal? LCost8,
			decimal? UCost1,
			decimal? UCost2,
			decimal? UCost3,
			decimal? UCost4,
			decimal? UCost5,
			decimal? UCost6,
			decimal? UCost7,
			decimal? UCost8,
			string Infobar,
			decimal? BreakQty = 1M,
			int? UseVendorPrice = 0)
		{
			RowPointerType _PJobRowid = PJobRowid;
			GenericDecimalType _LCost1 = LCost1;
			GenericDecimalType _LCost2 = LCost2;
			GenericDecimalType _LCost3 = LCost3;
			GenericDecimalType _LCost4 = LCost4;
			GenericDecimalType _LCost5 = LCost5;
			GenericDecimalType _LCost6 = LCost6;
			GenericDecimalType _LCost7 = LCost7;
			GenericDecimalType _LCost8 = LCost8;
			GenericDecimalType _UCost1 = UCost1;
			GenericDecimalType _UCost2 = UCost2;
			GenericDecimalType _UCost3 = UCost3;
			GenericDecimalType _UCost4 = UCost4;
			GenericDecimalType _UCost5 = UCost5;
			GenericDecimalType _UCost6 = UCost6;
			GenericDecimalType _UCost7 = UCost7;
			GenericDecimalType _UCost8 = UCost8;
			InfobarType _Infobar = Infobar;
			QtyUnitType _BreakQty = BreakQty;
			ListYesNoType _UseVendorPrice = UseVendorPrice;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EstSheetISp";
				
				appDB.AddCommandParameter(cmd, "PJobRowid", _PJobRowid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LCost1", _LCost1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LCost2", _LCost2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LCost3", _LCost3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LCost4", _LCost4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LCost5", _LCost5, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LCost6", _LCost6, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LCost7", _LCost7, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LCost8", _LCost8, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UCost1", _UCost1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UCost2", _UCost2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UCost3", _UCost3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UCost4", _UCost4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UCost5", _UCost5, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UCost6", _UCost6, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UCost7", _UCost7, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UCost8", _UCost8, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BreakQty", _BreakQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseVendorPrice", _UseVendorPrice, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				LCost1 = _LCost1;
				LCost2 = _LCost2;
				LCost3 = _LCost3;
				LCost4 = _LCost4;
				LCost5 = _LCost5;
				LCost6 = _LCost6;
				LCost7 = _LCost7;
				LCost8 = _LCost8;
				UCost1 = _UCost1;
				UCost2 = _UCost2;
				UCost3 = _UCost3;
				UCost4 = _UCost4;
				UCost5 = _UCost5;
				UCost6 = _UCost6;
				UCost7 = _UCost7;
				UCost8 = _UCost8;
				Infobar = _Infobar;
				
				return (Severity, LCost1, LCost2, LCost3, LCost4, LCost5, LCost6, LCost7, LCost8, UCost1, UCost2, UCost3, UCost4, UCost5, UCost6, UCost7, UCost8, Infobar);
			}
		}
	}
}
