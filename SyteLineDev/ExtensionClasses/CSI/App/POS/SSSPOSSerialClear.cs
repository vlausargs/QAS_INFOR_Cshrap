//PROJECT NAME: POS
//CLASS NAME: SSSPOSSerialClear.cs

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
using CSI.CRUD.POS;

namespace CSI.POS
{
	public class SSSPOSSerialClear : ISSSPOSSerialClear
	{

		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ISSSPOSSerialClearCRUD iSSSPOSSerialClearCRUD;

		public SSSPOSSerialClear(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			ISQLValueComparerUtil sQLUtil,
			ISSSPOSSerialClearCRUD iSSSPOSSerialClearCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.sQLUtil = sQLUtil;
			this.iSSSPOSSerialClearCRUD = iSSSPOSSerialClearCRUD;
		}

		public int? SSSPOSSerialClearSp(
			string POSNum,
			int? TransNum,
			string Item)
		{

			int? Severity = 0;

			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			if (this.iSSSPOSSerialClearCRUD.CheckOptional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iSSSPOSSerialClearCRUD.SelectOptional_Module1();
				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				this.iSSSPOSSerialClearCRUD.InsertOptional_Module1(optional_module1LoadResponse);
				while (this.iSSSPOSSerialClearCRUD.CheckTv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iSSSPOSSerialClearCRUD.LoadTv_ALTGEN1(ALTGEN_SpName);
					var ALTGEN = this.iSSSPOSSerialClearCRUD.AltExtGen_SSSPOSSerialClearSp(ALTGEN_SpName,
						POSNum,
						TransNum,
						Item);
					ALTGEN_Severity = ALTGEN;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity);

					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iSSSPOSSerialClearCRUD.SelectTv_ALTGEN2(ALTGEN_SpName);
					this.iSSSPOSSerialClearCRUD.DeleteTv_ALTGEN2(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

				}

			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_SSSPOSSerialClearSp") != null)
			{
				var EXTGEN = this.iSSSPOSSerialClearCRUD.AltExtGen_SSSPOSSerialClearSp("dbo.EXTGEN_SSSPOSSerialClearSp",
					POSNum,
					TransNum,
					Item);
				int? EXTGEN_Severity = EXTGEN;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity);
				}
			}

			/*Needs to load at least one column from the table: posm_serial for delete, Loads the record based on its where and from clause, then deletes it by record.*/
			var posm_serialLoadResponse = this.iSSSPOSSerialClearCRUD.SelectPosm_Serial(POSNum, TransNum, Item);
			this.iSSSPOSSerialClearCRUD.DeletePosm_Serial(posm_serialLoadResponse);
			return (Severity);

		}

	}
}
