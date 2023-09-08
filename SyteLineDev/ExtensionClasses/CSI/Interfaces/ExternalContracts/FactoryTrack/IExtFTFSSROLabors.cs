
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTFSSROLabors
    {

        int SSSFSSROLaborCostSp(string iTransType,
                string iSroNum,
                int? iSroLine,
                int? iSroOper,
                string iPartnerId,
                string iWorkCode,
                DateTime? iTransDate,
                ref decimal? oUnitCost,
                ref string Infobar); 

        int SSSFSSROLaborDCCheckSp(string PartnerId,
                ref string SroNum,
                ref int? SroLine,
                ref int? SroOper,
                ref DateTime? StartDate,
                [Optional] ref string Infobar); 

        int SSSFSSROLaborDCFinishSp(string PartnerId,
                string SroNum,
                int? SroLine,
                int? SroOper,
                string WorkCode,
                decimal? HrsWorked,
                decimal? HrsToBill,
                DateTime? EndDate,
                string NoteContent,
                [Optional] ref string Infobar,
                [Optional] string BillCode,
                [Optional] decimal? UnitCost,
                [Optional] decimal? UnitRate,
                [Optional, DefaultParameterValue(0)] int? LogTran,
                [Optional] Guid? DcRowPointer); 

        int SSSFSSROLaborDCStartSp(string PartnerId,
                string Type,
                Guid? RowPointer,
                [Optional] ref string Infobar,
                [Optional] string SroNum,
                [Optional] int? SroLine,
                [Optional] int? SroOper,
                DateTime? StartDate); 

        int SSSFSSROLaborDCValidSp(string Level,
                string PartnerID,
                string WorkCode,
                DateTime? TransDate,
                string SRONum,
                ref int? SROLine,
                ref int? SROOper,
                ref string SroDesc,
                ref string LineItem,
                ref string OperDesc,
                ref string BillCode,
                ref decimal? UnitCost,
                ref decimal? UnitRate,
                ref string Infobar); 

        int SSSFSSroLaborRateSp(string iTransType,
                string iSroNum,
                int? iSroLine,
                int? iSroOper,
                string iBillCode,
                DateTime? iTransDate,
                string iPartnerId,
                string iWorkCode,
                decimal? iUnitCost,
                decimal? iHrsWorked,
                decimal? iHrsBilled,
                ref decimal? oUnitPrice,
                ref string Infobar); 

    }
}
    
