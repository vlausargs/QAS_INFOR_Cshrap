//PROJECT NAME: Reporting
//CLASS NAME: WBCanCoShipDtl.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting.CriticalNumber
{
	public class WBCanCoShipDtl : IWBCanCoShipDtl
	{
		readonly IApplicationDB appDB;
		
		public WBCanCoShipDtl(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? WBCanCoShipDtlSp(
			DateTime? AsOfDate,
			int? DrillNum,
			int? KPINum,
			string Id,
			string Parm1 = null,
			string Parm2 = null,
			string Parm3 = null,
			string Parm4 = null,
			string Parm5 = null,
			string Parm6 = null,
			string Parm7 = null,
			string Parm8 = null,
			string Parm9 = null,
			string Parm10 = null,
			string Parm11 = null,
			string Parm12 = null,
			string Parm13 = null,
			string Parm14 = null,
			string Parm15 = null,
			string Parm16 = null,
			string Parm17 = null,
			string Parm18 = null,
			string Parm19 = null,
			string Parm20 = null,
			string Parm21 = null,
			string Parm22 = null,
			string Parm23 = null,
			string Parm24 = null,
			string Parm25 = null,
			string Parm26 = null,
			string Parm27 = null,
			string Parm28 = null,
			string Parm29 = null,
			string Parm30 = null,
			string Parm31 = null,
			string Parm32 = null,
			string Parm33 = null,
			string Parm34 = null,
			string Parm35 = null,
			string Parm36 = null,
			string Parm37 = null,
			string Parm38 = null,
			string Parm39 = null,
			string Parm40 = null,
			string Parm41 = null,
			string Parm42 = null,
			string Parm43 = null,
			string Parm44 = null,
			string Parm45 = null,
			string Parm46 = null,
			string Parm47 = null,
			string Parm48 = null,
			string Parm49 = null,
			string Parm50 = null)
		{
			DateType _AsOfDate = AsOfDate;
			WBDrillNumType _DrillNum = DrillNum;
			WBKPINumType _KPINum = KPINum;
			WBSourceNameType _Id = Id;
			WBSourceNameType _Parm1 = Parm1;
			WBSourceNameType _Parm2 = Parm2;
			WBSourceNameType _Parm3 = Parm3;
			WBSourceNameType _Parm4 = Parm4;
			WBSourceNameType _Parm5 = Parm5;
			WBSourceNameType _Parm6 = Parm6;
			WBSourceNameType _Parm7 = Parm7;
			WBSourceNameType _Parm8 = Parm8;
			WBSourceNameType _Parm9 = Parm9;
			WBSourceNameType _Parm10 = Parm10;
			WBSourceNameType _Parm11 = Parm11;
			WBSourceNameType _Parm12 = Parm12;
			WBSourceNameType _Parm13 = Parm13;
			WBSourceNameType _Parm14 = Parm14;
			WBSourceNameType _Parm15 = Parm15;
			WBSourceNameType _Parm16 = Parm16;
			WBSourceNameType _Parm17 = Parm17;
			WBSourceNameType _Parm18 = Parm18;
			WBSourceNameType _Parm19 = Parm19;
			WBSourceNameType _Parm20 = Parm20;
			WBSourceNameType _Parm21 = Parm21;
			WBSourceNameType _Parm22 = Parm22;
			WBSourceNameType _Parm23 = Parm23;
			WBSourceNameType _Parm24 = Parm24;
			WBSourceNameType _Parm25 = Parm25;
			WBSourceNameType _Parm26 = Parm26;
			WBSourceNameType _Parm27 = Parm27;
			WBSourceNameType _Parm28 = Parm28;
			WBSourceNameType _Parm29 = Parm29;
			WBSourceNameType _Parm30 = Parm30;
			WBSourceNameType _Parm31 = Parm31;
			WBSourceNameType _Parm32 = Parm32;
			WBSourceNameType _Parm33 = Parm33;
			WBSourceNameType _Parm34 = Parm34;
			WBSourceNameType _Parm35 = Parm35;
			WBSourceNameType _Parm36 = Parm36;
			WBSourceNameType _Parm37 = Parm37;
			WBSourceNameType _Parm38 = Parm38;
			WBSourceNameType _Parm39 = Parm39;
			WBSourceNameType _Parm40 = Parm40;
			WBSourceNameType _Parm41 = Parm41;
			WBSourceNameType _Parm42 = Parm42;
			WBSourceNameType _Parm43 = Parm43;
			WBSourceNameType _Parm44 = Parm44;
			WBSourceNameType _Parm45 = Parm45;
			WBSourceNameType _Parm46 = Parm46;
			WBSourceNameType _Parm47 = Parm47;
			WBSourceNameType _Parm48 = Parm48;
			WBSourceNameType _Parm49 = Parm49;
			WBSourceNameType _Parm50 = Parm50;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "WBCanCoShipDtlSp";
				
				appDB.AddCommandParameter(cmd, "AsOfDate", _AsOfDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DrillNum", _DrillNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "KPINum", _KPINum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Id", _Id, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm1", _Parm1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm2", _Parm2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm3", _Parm3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm4", _Parm4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm5", _Parm5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm6", _Parm6, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm7", _Parm7, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm8", _Parm8, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm9", _Parm9, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm10", _Parm10, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm11", _Parm11, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm12", _Parm12, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm13", _Parm13, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm14", _Parm14, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm15", _Parm15, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm16", _Parm16, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm17", _Parm17, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm18", _Parm18, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm19", _Parm19, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm20", _Parm20, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm21", _Parm21, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm22", _Parm22, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm23", _Parm23, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm24", _Parm24, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm25", _Parm25, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm26", _Parm26, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm27", _Parm27, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm28", _Parm28, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm29", _Parm29, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm30", _Parm30, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm31", _Parm31, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm32", _Parm32, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm33", _Parm33, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm34", _Parm34, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm35", _Parm35, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm36", _Parm36, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm37", _Parm37, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm38", _Parm38, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm39", _Parm39, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm40", _Parm40, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm41", _Parm41, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm42", _Parm42, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm43", _Parm43, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm44", _Parm44, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm45", _Parm45, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm46", _Parm46, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm47", _Parm47, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm48", _Parm48, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm49", _Parm49, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm50", _Parm50, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
