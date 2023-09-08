//PROJECT NAME: Finance
//CLASS NAME: CHSGetDigitsOfMainAcct.cs

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

namespace CSI.Finance.Chinese
{
	public class CHSGetDigitsOfMainAcct : ICHSGetDigitsOfMainAcct
	{

		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ICHSGetDigitsOfMainAcctCRUD iCHSGetDigitsOfMainAcctCRUD;

		public CHSGetDigitsOfMainAcct(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			ISQLValueComparerUtil sQLUtil,
			ICHSGetDigitsOfMainAcctCRUD iCHSGetDigitsOfMainAcctCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.sQLUtil = sQLUtil;
			this.iCHSGetDigitsOfMainAcctCRUD = iCHSGetDigitsOfMainAcctCRUD;
		}

		public (
			int? ReturnCode,
			int? DigitsOfMainAcct)
		CHSGetDigitsOfMainAcctSp(
			int? DigitsOfMainAcct)
		{
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity;
			int? rowCount;
			int? Severity;
			IntType _DigitsOfMainAcct = DigitsOfMainAcct;

			if (this.iCHSGetDigitsOfMainAcctCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iCHSGetDigitsOfMainAcctCRUD.Optional_Module1Select();
				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				this.iCHSGetDigitsOfMainAcctCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				while (this.iCHSGetDigitsOfMainAcctCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, _) = this.iCHSGetDigitsOfMainAcctCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					(ALTGEN_SpName, rowCount) = this.iCHSGetDigitsOfMainAcctCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iCHSGetDigitsOfMainAcctCRUD.AltExtGen_CHSGetDigitsOfMainAcctSp(ALTGEN_SpName,
						DigitsOfMainAcct);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, DigitsOfMainAcct);
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iCHSGetDigitsOfMainAcctCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iCHSGetDigitsOfMainAcctCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

				}

			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CHSGetDigitsOfMainAcctSp") != null)
			{
				var EXTGEN = this.iCHSGetDigitsOfMainAcctCRUD.AltExtGen_CHSGetDigitsOfMainAcctSp("dbo.EXTGEN_CHSGetDigitsOfMainAcctSp",
					DigitsOfMainAcct);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.DigitsOfMainAcct);
				}
			}

			Severity = 0;
			DigitsOfMainAcct = 0;
			(DigitsOfMainAcct, _) = this.iCHSGetDigitsOfMainAcctCRUD.CN_SysprmLoad(DigitsOfMainAcct);
			(DigitsOfMainAcct, rowCount) = this.iCHSGetDigitsOfMainAcctCRUD.CN_SysprmLoad(DigitsOfMainAcct);
			return (Severity, DigitsOfMainAcct);

		}

	}

}