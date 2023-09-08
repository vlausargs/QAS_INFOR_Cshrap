//PROJECT NAME: Logistics
//CLASS NAME: CustGlobal.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CustGlobal : ICustGlobal
	{
		readonly IApplicationDB appDB;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly IConvertToUtil convertToUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ICustGlobalCRUD iCustGlobalCRUD;

		public CustGlobal(IApplicationDB appDB,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			IConvertToUtil convertToUtil,
			ISQLValueComparerUtil sQLUtil,
			ICustGlobalCRUD iCustGlobalCRUD)
		{
			this.appDB = appDB;
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.convertToUtil = convertToUtil;
			this.sQLUtil = sQLUtil;
			this.iCustGlobalCRUD = iCustGlobalCRUD;
		}

		public (
			int? ReturnCode,
			int? rGlobal)
		CustGlobalSp(
			string pCustNum,
			int? rGlobal)
		{

			int? Severity = 0;

			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			if (this.iCustGlobalCRUD.CheckOptional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iCustGlobalCRUD.SelectOptional_Module();
				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				this.iCustGlobalCRUD.InsertOptional_Module(optional_module1LoadResponse);
				while (this.iCustGlobalCRUD.CheckTv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iCustGlobalCRUD.LoadTv_ALTGEN(ALTGEN_SpName);
					var ALTGEN = this.iCustGlobalCRUD.AltExtGen_CustGlobalSp(ALTGEN_SpName,
						pCustNum,
						rGlobal);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, rGlobal);

					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iCustGlobalCRUD.SelectTv_ALTGEN(ALTGEN_SpName);
					this.iCustGlobalCRUD.DeleteTv_ALTGEN(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

				}

			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CustGlobalSp") != null)
			{
				var EXTGEN = this.iCustGlobalCRUD.AltExtGen_CustGlobalSp("dbo.EXTGEN_CustGlobalSp",
					pCustNum,
					rGlobal);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.rGlobal);
				}
			}

			rGlobal = convertToUtil.ToInt32(this.CustGlobalFn(pCustNum));
			return (Severity, rGlobal);

		}

		public int? CustGlobalFn(
			string pCustNum)
		{
			CustNumType _pCustNum = pCustNum;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[CustGlobal](@pCustNum)";

				appDB.AddCommandParameter(cmd, "pCustNum", _pCustNum, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<int?>(cmd);

				return Output;
			}
		}

	}
}
