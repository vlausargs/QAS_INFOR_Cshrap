using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace CSI.ExternalContracts.Portals
{
    public interface IFSSROLabors
    {
        int SSSFSPortalCreateSROLaborSp(string SroNum, int? SroLine, int? SroOper, string PartnerID, DateTime? TransDate, string CustNum, string CustSeq, string Username, string WorkCode, decimal? HrsWorked, decimal? HrsToBill, string NoteContent, [Optional][DefaultParameterValue((byte)0)] byte? Validate, ref Guid? RowPointer, ref string Infobar);

        int SSSFSPortalGetNewSROTransInfoSp(string SroNum, string CustNum, int? CustSeq, string Username, ref string SroDescription, ref string ShpToName, ref string SiteSiteName, ref int? SroLine, ref string LnSerNum, ref string LnItem, ref string LnDescription, ref int? SroOper, ref string OperCode, ref string OperDescription, ref string PartnerID, ref string PartnerName, ref string Infobar);

        int SSSFSPortalValidateSROLaborSp(string SroNum, int? SroLine, int? SroOper, string PartnerID, DateTime? TransDate, string CustNum, string CustSeq, string Username, string WorkCode, ref string Infobar);
    }
}
