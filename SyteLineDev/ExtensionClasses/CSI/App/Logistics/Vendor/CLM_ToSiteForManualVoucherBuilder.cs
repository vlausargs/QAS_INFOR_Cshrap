//PROJECT NAME: Logistics
//CLASS NAME: CLM_ToSiteForManualVoucherBuilder.cs

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
using CSI.Data.Utilities;

namespace CSI.Logistics.Vendor
{
	public class CLM_ToSiteForManualVoucherBuilder : ICLM_ToSiteForManualVoucherBuilder
	{

		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IUnionUtil unionUtil;
		readonly ICLM_ToSiteForManualVoucherBuilderCRUD iCLM_ToSiteForManualVoucherBuilderCRUD;

		public CLM_ToSiteForManualVoucherBuilder(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			ISQLValueComparerUtil sQLUtil,
			IUnionUtil unionUtil,
			ICLM_ToSiteForManualVoucherBuilderCRUD iCLM_ToSiteForManualVoucherBuilderCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.sQLUtil = sQLUtil;
			this.unionUtil = unionUtil;
			this.iCLM_ToSiteForManualVoucherBuilderCRUD = iCLM_ToSiteForManualVoucherBuilderCRUD;
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		CLM_ToSiteForManualVoucherBuilderSp(
			string PVendNum)
		{

			ICollectionLoadResponse Data = null;

			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			string CurrparmsCurrCode = null;
			string ParmsSite = null;
			if (this.iCLM_ToSiteForManualVoucherBuilderCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iCLM_ToSiteForManualVoucherBuilderCRUD.SelectOptional_ModuleForInsert();
				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				this.iCLM_ToSiteForManualVoucherBuilderCRUD.InsertOptional_Module(optional_module1LoadResponse);
				while (this.iCLM_ToSiteForManualVoucherBuilderCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iCLM_ToSiteForManualVoucherBuilderCRUD.LoadTv_ALTGEN(ALTGEN_SpName);
					var ALTGEN = this.iCLM_ToSiteForManualVoucherBuilderCRUD.AltExtGen_CLM_ToSiteForManualVoucherBuilderSp(ALTGEN_SpName,
						PVendNum);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN.Data, ALTGEN_Severity);

					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iCLM_ToSiteForManualVoucherBuilderCRUD.SelectTv_ALTGENForDelete(ALTGEN_SpName);
					this.iCLM_ToSiteForManualVoucherBuilderCRUD.DeleteTv_ALTGEN(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

				}

			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_ToSiteForManualVoucherBuilderSp") != null)
			{
				var EXTGEN = this.iCLM_ToSiteForManualVoucherBuilderCRUD.AltExtGen_CLM_ToSiteForManualVoucherBuilderSp("dbo.EXTGEN_CLM_ToSiteForManualVoucherBuilderSp",
					PVendNum);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}

			Severity = 0;
			(CurrparmsCurrCode, rowCount) = this.iCLM_ToSiteForManualVoucherBuilderCRUD.LoadCurrparms(CurrparmsCurrCode);
			(ParmsSite, rowCount) = this.iCLM_ToSiteForManualVoucherBuilderCRUD.LoadParms(ParmsSite);
			var nonTableLoadResponse = this.iCLM_ToSiteForManualVoucherBuilderCRUD.SelectParmsSite(ParmsSite);
			unionUtil.Add(nonTableLoadResponse);

			var tmp_mvbLoadResponse = this.iCLM_ToSiteForManualVoucherBuilderCRUD.SelectTmp_Mvb(PVendNum, CurrparmsCurrCode, ParmsSite);
			unionUtil.Add(tmp_mvbLoadResponse);

			Data = unionUtil.Process(UnionType.UnionAll, "to_site");

			return (Data, Severity);

		}

	}
}
