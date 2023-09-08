//PROJECT NAME: Production
//CLASS NAME: ApsMATLDELVSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsMATLDELVSave : IApsMATLDELVSave
	{
		readonly IApplicationDB appDB;
		
		
		public ApsMATLDELVSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsMATLDELVSaveSp(int? InsertFlag,
		int? AltNo,
		string ORDERID,
		string DESCR,
		DateTime? DELVDATE,
		string MATERIALID,
		string AMOUNT,
		int? CATEGORY,
		int? FLAGS,
		string CUSTOMER)
		{
			ListYesNoType _InsertFlag = InsertFlag;
			ApsAltNoType _AltNo = AltNo;
			ApsOrderType _ORDERID = ORDERID;
			ApsDescriptType _DESCR = DESCR;
			DateTimeType _DELVDATE = DELVDATE;
			ApsMaterialType _MATERIALID = MATERIALID;
			ApsExprType _AMOUNT = AMOUNT;
			ApsCategoryType _CATEGORY = CATEGORY;
			ApsBitFlagsType _FLAGS = FLAGS;
			ApsCustomerType _CUSTOMER = CUSTOMER;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsMATLDELVSaveSp";
				
				appDB.AddCommandParameter(cmd, "InsertFlag", _InsertFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ORDERID", _ORDERID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DESCR", _DESCR, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DELVDATE", _DELVDATE, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MATERIALID", _MATERIALID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AMOUNT", _AMOUNT, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CATEGORY", _CATEGORY, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FLAGS", _FLAGS, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CUSTOMER", _CUSTOMER, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
