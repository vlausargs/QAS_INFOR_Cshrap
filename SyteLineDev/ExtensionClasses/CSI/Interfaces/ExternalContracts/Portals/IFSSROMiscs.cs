using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace CSI.ExternalContracts.Portals
{
    public interface IFSSROMiscs
    {
        int SSSFSPortalCreateSROMiscSp(string SroNum, int? SroLine, int? SroOper, string PartnerID, DateTime? TransDate, string CustNum, string CustSeq, string Username, string MiscCode, string MiscCodeDesc, decimal? QtyConv, decimal? CostConv, string NoteContent, [Optional][DefaultParameterValue((byte)0)] byte? Validate, ref Guid? RowPointer, ref string Infobar);

        int SSSFSPortalValidateSROMiscSp(string SroNum, int? SroLine, int? SroOper, string PartnerID, DateTime? TransDate, string CustNum, string CustSeq, string Username, string MiscCode, ref string Infobar);
    }
}
