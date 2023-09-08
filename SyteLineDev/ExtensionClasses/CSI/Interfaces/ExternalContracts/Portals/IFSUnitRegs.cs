using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace CSI.ExternalContracts.Portals
{
    public interface IFSUnitRegs
    {
        int SSSFSPortalCreateUnitRegSp(string SerNum, string Item, string Name, string Addr1, string Addr2, string Addr3, string Addr4, string City, string State, string Zip, string Country, string Phone, string Email, string RegNotes, [Optional][DefaultParameterValue((byte)0)] byte? Validate, ref string TransNum, ref string Infobar);

        int SSSFSPortalValidateUnitRegSp(string SerNum, string Item, string Name, string Addr1, string City, string State, string Zip, string Country, string Phone, string Email, ref string Infobar);
    }
}
