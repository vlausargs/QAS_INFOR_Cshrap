//PROJECT NAME: Logistics
//CLASS NAME: CLM_ShipmentASN.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Data.SQL;
using CSI.Material;

namespace CSI.Logistics.Customer
{
	public class CLM_ShipmentASN : ICLM_ShipmentASN
	{

		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IExpandKyByType iExpandKyByType;
		readonly IScalarFunction scalarFunction;
		readonly IConvertToUtil convertToUtil;
		readonly IHighCharacter highCharacter;
		readonly ILowCharacter lowCharacter;
		readonly IStringUtil stringUtil;
		readonly IHighInt iHighInt;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ILowInt iLowInt;
		readonly ICLM_ShipmentASNCRUD iCLM_ShipmentASNCRUD;

		public CLM_ShipmentASN(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IExpandKyByType iExpandKyByType,
			IScalarFunction scalarFunction,
			IConvertToUtil convertToUtil,
			IHighCharacter highCharacter,
			ILowCharacter lowCharacter,
			IStringUtil stringUtil,
			IHighInt iHighInt,
			ISQLValueComparerUtil sQLUtil,
			ILowInt iLowInt,
			ICLM_ShipmentASNCRUD iCLM_ShipmentASNCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.iExpandKyByType = iExpandKyByType;
			this.scalarFunction = scalarFunction;
			this.convertToUtil = convertToUtil;
			this.highCharacter = highCharacter;
			this.lowCharacter = lowCharacter;
			this.stringUtil = stringUtil;
			this.iHighInt = iHighInt;
			this.sQLUtil = sQLUtil;
			this.iLowInt = iLowInt;
			this.iCLM_ShipmentASNCRUD = iCLM_ShipmentASNCRUD;
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		CLM_ShipmentASNSp(
			string StartCustNum = null,
			string EndCustNum = null,
			int? StartCustSeq = null,
			int? EndCustSeq = null,
			decimal? StartShipmentID = null,
			decimal? EndShipmentID = null)
		{

			ICollectionLoadResponse Data = null;

			int? Severity = 0;

			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			string LowCharacter = null;
			string HighCharacter = null;
			if (this.iCLM_ShipmentASNCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iCLM_ShipmentASNCRUD.Optional_Module1Select();
				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				this.iCLM_ShipmentASNCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				while (this.iCLM_ShipmentASNCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iCLM_ShipmentASNCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iCLM_ShipmentASNCRUD.AltExtGen_CLM_ShipmentASNSp(ALTGEN_SpName,
						StartCustNum,
						EndCustNum,
						StartCustSeq,
						EndCustSeq,
						StartShipmentID,
						EndShipmentID);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN.Data, ALTGEN_Severity);

					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iCLM_ShipmentASNCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iCLM_ShipmentASNCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

				}

			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_ShipmentASNSp") != null)
			{
				var EXTGEN = this.iCLM_ShipmentASNCRUD.AltExtGen_CLM_ShipmentASNSp("dbo.EXTGEN_CLM_ShipmentASNSp",
					StartCustNum,
					EndCustNum,
					StartCustSeq,
					EndCustSeq,
					StartShipmentID,
					EndShipmentID);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}

			LowCharacter = convertToUtil.ToString(lowCharacter.LowCharacterFn());
			HighCharacter = convertToUtil.ToString(highCharacter.HighCharacterFn());
			StartCustNum = (StartCustNum == null ? LowCharacter : this.iExpandKyByType.ExpandKyByTypeFn(
				"CustNumType",
				StartCustNum));
			EndCustNum = (EndCustNum == null ? HighCharacter : this.iExpandKyByType.ExpandKyByTypeFn(
				"CustNumType",
				EndCustNum));
			StartShipmentID = (decimal?)(stringUtil.IsNull(
				StartShipmentID,
				this.iLowInt.LowIntFn()));
			EndShipmentID = (decimal?)(stringUtil.IsNull(
				EndShipmentID,
				this.iHighInt.HighIntFn()));
			StartCustSeq = (int?)(stringUtil.IsNull(
				StartCustSeq,
				this.iLowInt.LowIntFn()));
			EndCustSeq = (int?)(stringUtil.IsNull(
				EndCustSeq,
				this.iHighInt.HighIntFn()));
			var shipmentLoadResponse = this.iCLM_ShipmentASNCRUD.ShipmentSelect(StartCustNum, EndCustNum, StartCustSeq, EndCustSeq, StartShipmentID, EndShipmentID);
			Data = shipmentLoadResponse;

			return (Data, Severity);

		}

	}
}