//PROJECT NAME: Codes
//CLASS NAME: CustSpecificUnitPriceExists.cs

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
using CSI.CRUD.Codes;

namespace CSI.Codes
{
	public class CustSpecificUnitPriceExists : ICustSpecificUnitPriceExists
	{
		readonly ICustomerSpecificUnitPriceExists iCustomerSpecificUnitPriceExists;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly IConvertToUtil convertToUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ICustSpecificUnitPriceExistsCRUD iCustSpecificUnitPriceExistsCRUD;

		public CustSpecificUnitPriceExists(ICustomerSpecificUnitPriceExists iCustomerSpecificUnitPriceExists,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			IConvertToUtil convertToUtil,
			ISQLValueComparerUtil sQLUtil,
			ICustSpecificUnitPriceExistsCRUD iCustSpecificUnitPriceExistsCRUD)
		{
			this.iCustomerSpecificUnitPriceExists = iCustomerSpecificUnitPriceExists;
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.convertToUtil = convertToUtil;
			this.sQLUtil = sQLUtil;
			this.iCustSpecificUnitPriceExistsCRUD = iCustSpecificUnitPriceExistsCRUD;
		}

		public (
			int? ReturnCode,
			int? CustSpecificUnitPriceExists,
			string Infobar)
		CustSpecificUnitPriceExistsSp(
			string CurrCode,
			string CustNum,
			string Item,
			int? CustSpecificUnitPriceExists,
			string Infobar)
		{

			int? Severity = 0;

			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			if (this.iCustSpecificUnitPriceExistsCRUD.CheckOptional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iCustSpecificUnitPriceExistsCRUD.SelectOptional_Module();
				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				this.iCustSpecificUnitPriceExistsCRUD.InsertOptional_Module(optional_module1LoadResponse);
				while (this.iCustSpecificUnitPriceExistsCRUD.CheckTv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iCustSpecificUnitPriceExistsCRUD.LoadTv_ALTGEN(ALTGEN_SpName);
					var ALTGEN = this.iCustSpecificUnitPriceExistsCRUD.AltExtGen_CustSpecificUnitPriceExistsSp(ALTGEN_SpName,
						CurrCode,
						CustNum,
						Item,
						CustSpecificUnitPriceExists,
						Infobar);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, CustSpecificUnitPriceExists, Infobar);

					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iCustSpecificUnitPriceExistsCRUD.SelectTv_ALTGEN(ALTGEN_SpName);
					this.iCustSpecificUnitPriceExistsCRUD.DeleteTv_ALTGEN(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

				}

			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CustSpecificUnitPriceExistsSp") != null)
			{
				var EXTGEN = this.iCustSpecificUnitPriceExistsCRUD.AltExtGen_CustSpecificUnitPriceExistsSp("dbo.EXTGEN_CustSpecificUnitPriceExistsSp",
					CurrCode,
					CustNum,
					Item,
					CustSpecificUnitPriceExists,
					Infobar);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.CustSpecificUnitPriceExists, EXTGEN.Infobar);
				}
			}

			if (CustNum != null && Item != null && CurrCode != null)
			{
				CustSpecificUnitPriceExists = convertToUtil.ToInt32(this.iCustomerSpecificUnitPriceExists.CustomerSpecificUnitPriceExistsFn(
					CustNum,
					Item,
					CurrCode));

			}
			else
			{
				CustSpecificUnitPriceExists = 0;

			}
			return (Severity, CustSpecificUnitPriceExists, Infobar);

		}
	}
}
