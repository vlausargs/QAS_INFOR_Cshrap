//PROJECT NAME: Material
//CLASS NAME: CheckItemAllsForSite.cs

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

namespace CSI.Material
{
	public class CheckItemAllsForSite : ICheckItemAllsForSite
	{

		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IMsgApp iMsgApp;
		readonly ICheckItemAllsForSiteCRUD iCheckItemAllsForSiteCRUD;

		public CheckItemAllsForSite(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			IStringUtil stringUtil,
			ISQLValueComparerUtil sQLUtil,
			IMsgApp iMsgApp,
			ICheckItemAllsForSiteCRUD iCheckItemAllsForSiteCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
			this.iMsgApp = iMsgApp;
			this.iCheckItemAllsForSiteCRUD = iCheckItemAllsForSiteCRUD;
		}

		public (
			int? ReturnCode,
			string Infobar)
		CheckItemAllsForSiteSp(
			string Site,
			string SupplySite,
			string Item,
			string Infobar)
		{

			SiteType _Site = Site;

			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			if (this.iCheckItemAllsForSiteCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iCheckItemAllsForSiteCRUD.SelectOptional_Module();
				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				this.iCheckItemAllsForSiteCRUD.InsertOptional_Module(optional_module1LoadResponse);
				while (this.iCheckItemAllsForSiteCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iCheckItemAllsForSiteCRUD.LoadTv_ALTGEN(ALTGEN_SpName);
					var ALTGEN = this.iCheckItemAllsForSiteCRUD.AltExtGen_CheckItemAllsForSiteSp(ALTGEN_SpName,
						Site,
						SupplySite,
						Item,
						Infobar);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, Infobar);

					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iCheckItemAllsForSiteCRUD.SelectTv_ALTGENForDelete(ALTGEN_SpName);
					this.iCheckItemAllsForSiteCRUD.DeleteTv_ALTGEN(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

				}

			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CheckItemAllsForSiteSp") != null)
			{
				var EXTGEN = this.iCheckItemAllsForSiteCRUD.AltExtGen_CheckItemAllsForSiteSp("dbo.EXTGEN_CheckItemAllsForSiteSp",
					Site,
					SupplySite,
					Item,
					Infobar);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.Infobar);
				}
			}

			Severity = 0;
			if (Site == null)
			{
				(Site, rowCount) = this.iCheckItemAllsForSiteCRUD.LoadParms(Site);

			}
			if (sQLUtil.SQLEqual(stringUtil.IsNull(
					Site,
					""), stringUtil.IsNull(
					SupplySite,
					"")) == true)
			{
				Infobar = null;

				#region CRUD ExecuteMethodCall

				var MsgApp = this.iMsgApp.MsgAppSp(
					Infobar: Infobar,
					BaseMsg: "E=NotUsedIn",
					Parm1: SupplySite,
					Parm2: "@item_all.supply_site");
				Severity = MsgApp.ReturnCode;
				Infobar = MsgApp.Infobar;

				#endregion ExecuteMethodCall

				return (Severity = 0, Infobar);

			}
			if (sQLUtil.SQLBool(sQLUtil.SQLAnd((sQLUtil.SQLNotEqual(Site, SupplySite)), (sQLUtil.SQLNot(this.iCheckItemAllsForSiteCRUD.Item_AllForExists(Site, SupplySite, Item))))))
			{
				Infobar = null;

				#region CRUD ExecuteMethodCall

				var MsgApp1 = this.iMsgApp.MsgAppSp(
					Infobar: Infobar,
					BaseMsg: "I=NoExist2",
					Parm1: "@item",
					Parm2: "@item.item",
					Parm3: Item,
					Parm4: "@item_all.supply_site",
					Parm5: SupplySite);
				Severity = MsgApp1.ReturnCode;
				Infobar = MsgApp1.Infobar;

				#endregion ExecuteMethodCall

				return (Severity = 0, Infobar);

			}
			return (Severity, Infobar);

		}

	}
}
