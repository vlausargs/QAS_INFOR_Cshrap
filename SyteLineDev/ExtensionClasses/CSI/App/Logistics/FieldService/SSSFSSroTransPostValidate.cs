//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroTransPostValidate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSroTransPostValidate : ISSSFSSroTransPostValidate
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSroTransPostValidate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSFSSroTransPostValidateSp(
			string iMode,
			string iTable,
			string iPriceField,
			string iSroNum,
			int? iSroLine,
			int? iSroOper,
			DateTime? iTransDate,
			DateTime? iPostDate,
			string iWhse,
			decimal? iPrice,
			string iPartnerID,
			string iDept,
			string iBillCode,
			string Infobar)
		{
			StringType _iMode = iMode;
			StringType _iTable = iTable;
			StringType _iPriceField = iPriceField;
			FSSRONumType _iSroNum = iSroNum;
			FSSROLineType _iSroLine = iSroLine;
			FSSROOperType _iSroOper = iSroOper;
			DateTimeType _iTransDate = iTransDate;
			DateTimeType _iPostDate = iPostDate;
			WhseType _iWhse = iWhse;
			CostPrcType _iPrice = iPrice;
			FSPartnerType _iPartnerID = iPartnerID;
			DeptType _iDept = iDept;
			FSSROBillCodeType _iBillCode = iBillCode;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSroTransPostValidateSp";
				
				appDB.AddCommandParameter(cmd, "iMode", _iMode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iTable", _iTable, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iPriceField", _iPriceField, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSroNum", _iSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSroLine", _iSroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSroOper", _iSroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iTransDate", _iTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iPostDate", _iPostDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iWhse", _iWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iPrice", _iPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iPartnerID", _iPartnerID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iDept", _iDept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iBillCode", _iBillCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
