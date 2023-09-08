//PROJECT NAME: ReportExt
//CLASS NAME: SLIndentedCostedBillOfMaterialReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.Data.RecordSets;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Report
{
    [IDOExtensionClass("SLIndentedCostedBillOfMaterialReport")]
    public class SLIndentedCostedBillOfMaterialReport : CSIExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_IndentedCostedBillofMaterialSp([Optional] string ItemStarting,
			[Optional] string ItemEnding,
			[Optional] string ProCodeStarting,
			[Optional] string ProCodeEnding,
			[Optional] string AlternateIDStarting,
			[Optional] string AlternateIDEnding,
			[Optional] string MaterialType,
			[Optional] string Source,
			[Optional] string Stocked,
			[Optional] string ABCCode,
			[Optional] DateTime? EffDate,
			[Optional] string PrBetweenLevel0,
			[Optional] int? PrLevelZero,
			[Optional] int? DisplayHeader,
			[Optional] int? PrintAlternate,
			[Optional] int? EffDateOffSet,
			[Optional] string pSite)
		{
			var iRpt_IndentedCostedBillofMaterialExt = new Rpt_IndentedCostedBillofMaterialFactory().Create(this, true);
			
			var result = iRpt_IndentedCostedBillofMaterialExt.Rpt_IndentedCostedBillofMaterialSp(ItemStarting,
				ItemEnding,
				ProCodeStarting,
				ProCodeEnding,
				AlternateIDStarting,
				AlternateIDEnding,
				MaterialType,
				Source,
				Stocked,
				ABCCode,
				EffDate,
				PrBetweenLevel0,
				PrLevelZero,
				DisplayHeader,
				PrintAlternate,
				EffDateOffSet,
				pSite);
			
			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

    }
}