using CSI.MXLOC.Interfaces;
using System;
using System.Data;

namespace CSI.MXLOC
{
    public interface IApprovedXMLCRUD
    {
        (int Count, string Infobar) UpdateDatabaseValue(IMXElectronicInv mXElectronicInv, string ApprovedXmlFileName);
        DataTable GetStatus(
            DateTime? BeginProFormaInvDate = null,
            DateTime? EndProFormaInvDate = null,
            string BeginProFormaInvNum = null,
            string EndProFormaInvNum = null);

        string GetWorkstationID(string Username);
    }
}