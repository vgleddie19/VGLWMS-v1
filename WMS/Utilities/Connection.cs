using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework;

namespace WMS
{
    public static class Connection
    {
        private static readonly string OMSConnectionString = "Initial Catalog=" + Utils.DBConnection["OMS"]["DBNAME"] + ";Data Source=" + Utils.DBConnection["OMS"]["SERVER"] + ";User Id = " + Utils.DBConnection["OMS"]["USERNAME"] + "; Password = " + Utils.DBConnection["OMS"]["PASSWORD"];
        private static readonly string WMSConnectionString = "Initial Catalog=" + Utils.DBConnection["WMS"]["DBNAME"] + ";Data Source=" + Utils.DBConnection["WMS"]["SERVER"] + ";User Id = " + Utils.DBConnection["WMS"]["USERNAME"] + "; Password = " + Utils.DBConnection["WMS"]["PASSWORD"];
        private static readonly string TMSConnectionString = "Initial Catalog=" + Utils.DBConnection["TMS"]["DBNAME"] + ";Data Source=" + Utils.DBConnection["TMS"]["SERVER"] + ";User Id = " + Utils.DBConnection["TMS"]["USERNAME"] + "; Password = " + Utils.DBConnection["TMS"]["PASSWORD"];
        private static readonly DataSupport oms = new DataSupport(OMSConnectionString);
        private static readonly DataSupport wms = new DataSupport(WMSConnectionString);
        private static readonly DataSupport tms = new DataSupport(TMSConnectionString);

        public static DataSupport GetOMSConnection { get => oms; }
        public static DataSupport GetWMSConnection { get => wms; }
        public static DataSupport GetTMSConnection { get => tms; }

        public static string GetTMSConnectionString()
        {
            return GetTMSConnection.ConnectionString;
        }

        public static string GetWMSConnectionString()
        {
            return WMSConnectionString;
        }

        public static string GetOMSConnectionString()
        {
            return OMSConnectionString;
        }
    }
}