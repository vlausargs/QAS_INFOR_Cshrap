//PROJECT NAME: Logistics
//CLASS NAME: ChangeVendorContractPriceStatus.cs

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

namespace CSI.Logistics.Vendor
{
	public class ChangeVendorContractPriceStatus : IChangeVendorContractPriceStatus
	{

		readonly ICLM_ChangeVendorContractPriceStatus iCLM_ChangeVendorContractPriceStatus;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IMsgApp iMsgApp;
		readonly IChangeVendorContractPriceStatusCRUD iChangeVendorContractPriceStatusCRUD;

		public ChangeVendorContractPriceStatus(ICLM_ChangeVendorContractPriceStatus iCLM_ChangeVendorContractPriceStatus,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			ISQLValueComparerUtil sQLUtil,
			IMsgApp iMsgApp,
			IChangeVendorContractPriceStatusCRUD iChangeVendorContractPriceStatusCRUD)
		{
			this.iCLM_ChangeVendorContractPriceStatus = iCLM_ChangeVendorContractPriceStatus;
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.sQLUtil = sQLUtil;
			this.iMsgApp = iMsgApp;
			this.iChangeVendorContractPriceStatusCRUD = iChangeVendorContractPriceStatusCRUD;
		}

		public (
			int? ReturnCode,
			string Infobar)
		ChangeVendorContractPriceStatusSp(
			string Item,
			string VendNum,
			DateTime? EffectDate,
			string Stat,
			string Infobar)
		{

			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			if (this.iChangeVendorContractPriceStatusCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iChangeVendorContractPriceStatusCRUD.Optional_Module1Select();
				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				this.iChangeVendorContractPriceStatusCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				while (this.iChangeVendorContractPriceStatusCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iChangeVendorContractPriceStatusCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iChangeVendorContractPriceStatusCRUD.AltExtGen_ChangeVendorContractPriceStatusSp(ALTGEN_SpName,
						Item,
						VendNum,
						EffectDate,
						Stat,
						Infobar);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, Infobar);

					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iChangeVendorContractPriceStatusCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iChangeVendorContractPriceStatusCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

				}

			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_ChangeVendorContractPriceStatusSp") != null)
			{
				var EXTGEN = this.iChangeVendorContractPriceStatusCRUD.AltExtGen_ChangeVendorContractPriceStatusSp("dbo.EXTGEN_ChangeVendorContractPriceStatusSp",
					Item,
					VendNum,
					EffectDate,
					Stat,
					Infobar);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.Infobar);
				}
			}

			Severity = 0;
			if (sQLUtil.SQLBool(sQLUtil.SQLOr(sQLUtil.SQLEqual(Stat, "A"), sQLUtil.SQLNot(this.iChangeVendorContractPriceStatusCRUD.ItemvendpriceForExists(Stat, Item, VendNum, EffectDate)))))
			{

				#region CRUD ExecuteMethodCall

				var MsgApp = this.iMsgApp.MsgAppSp(
					Infobar: Infobar,
					BaseMsg: "E=NoExist0",
					Parm1: "@itemvendprice");
				Severity = MsgApp.ReturnCode;
				Infobar = MsgApp.Infobar;

				#endregion ExecuteMethodCall

				return (Severity, Infobar);
			}

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: CLM_ChangeVendorContractPriceStatusSp
			var CLM_ChangeVendorContractPriceStatus = this.iCLM_ChangeVendorContractPriceStatus.CLM_ChangeVendorContractPriceStatusSp(
				Process: "P",
				StartingVendor: VendNum,
				EndingVendor: VendNum,
				StartingItem: Item,
				EndingItem: Item,
				StartingDate: EffectDate,
				EndingDate: EffectDate,
				StartingEffectDateOffset: null,
				EndingEffectDateOffset: null,
				Infobar: Infobar);
			Severity = CLM_ChangeVendorContractPriceStatus.ReturnCode;
			Infobar = CLM_ChangeVendorContractPriceStatus.Infobar;

			#endregion ExecuteMethodCall

			if (sQLUtil.SQLNotEqual(Severity, 0) == true)
			{
				return (Severity, Infobar);
			}
			return (Severity, Infobar);

		}

	}
}
