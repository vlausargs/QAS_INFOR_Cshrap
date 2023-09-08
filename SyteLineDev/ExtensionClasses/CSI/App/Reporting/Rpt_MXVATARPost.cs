//PROJECT NAME: Reporting
//CLASS NAME: Rpt_MXVATARPost.cs

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

namespace CSI.Reporting
{
	public class Rpt_MXVATARPost : IRpt_MXVATARPost
	{

		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IRpt_MXVATARPostCRUD iRpt_MXVATARPostCRUD;

		public Rpt_MXVATARPost(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			ISQLValueComparerUtil sQLUtil,
			IRpt_MXVATARPostCRUD iRpt_MXVATARPostCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.sQLUtil = sQLUtil;
			this.iRpt_MXVATARPostCRUD = iRpt_MXVATARPostCRUD;
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		Rpt_MXVATARPostSp()
		{

			ICollectionLoadResponse Data = null;

			int? Severity = 0;

			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			if (this.iRpt_MXVATARPostCRUD.CheckOptional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iRpt_MXVATARPostCRUD.SelectOptional_Module();
				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				this.iRpt_MXVATARPostCRUD.InsertOptional_Module(optional_module1LoadResponse);
				while (this.iRpt_MXVATARPostCRUD.CheckTv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iRpt_MXVATARPostCRUD.LoadTv_ALTGEN(ALTGEN_SpName);
					var ALTGEN = this.iRpt_MXVATARPostCRUD.AltExtGen_Rpt_MXVATARPostSp(ALTGEN_SpName);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN.Data, ALTGEN_Severity);

					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iRpt_MXVATARPostCRUD.SelectTv_ALTGEN(ALTGEN_SpName);
					this.iRpt_MXVATARPostCRUD.DeleteTv_ALTGEN(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

				}

			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Rpt_MXVATARPostSp") != null)
			{
				var EXTGEN = this.iRpt_MXVATARPostCRUD.AltExtGen_Rpt_MXVATARPostSp("dbo.EXTGEN_Rpt_MXVATARPostSp");
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}

			var MX_tt_vat_postLoadResponse = this.iRpt_MXVATARPostCRUD.SelectMX_Tt_Vat_Post();
			Data = MX_tt_vat_postLoadResponse;

			var MX_tt_vat_postRowPointerLoadResponse = this.iRpt_MXVATARPostCRUD.SelectMX_Tt_Vat_Post_RowPointer();
			this.iRpt_MXVATARPostCRUD.DeleteMX_Tt_Vat_Post(MX_tt_vat_postRowPointerLoadResponse);

			return (Data, Severity);
		}

	}
}
