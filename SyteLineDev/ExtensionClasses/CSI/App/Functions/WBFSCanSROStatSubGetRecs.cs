//PROJECT NAME: Data
//CLASS NAME: WBFSCanSROStatSubGetRecs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class WBFSCanSROStatSubGetRecs : IWBFSCanSROStatSubGetRecs
	{
		readonly IApplicationDB appDB;
		
		public WBFSCanSROStatSubGetRecs(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string CrType) WBFSCanSROStatSubGetRecsSp(
			int? KPINum,
			DateTime? AsOfDate,
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
			string CrType = null)
		{
			WBKPINumType _KPINum = KPINum;
			DateType _AsOfDate = AsOfDate;
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
			StringType _CrType = CrType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "WBFSCanSROStatSubGetRecsSp";
				
				appDB.AddCommandParameter(cmd, "KPINum", _KPINum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AsOfDate", _AsOfDate, ParameterDirection.Input);
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
				appDB.AddCommandParameter(cmd, "CrType", _CrType, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CrType = _CrType;
				
				return (Severity, CrType);
			}
		}
	}
}
