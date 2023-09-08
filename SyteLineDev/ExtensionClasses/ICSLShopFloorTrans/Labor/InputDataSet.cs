using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InforCollect.ERP.SL.ICSLShopFloorTrans.Labor
{
    public class InputDataSet
    {
        private bool _postOffSets = false;
        private string _userInitials = "";
        private string _deviceId = "";
        private bool _StopPostJobs = false;

        public List<QtyLine> JobQtyLines = null;
        public List<MasterLine> MasterLines = null;
        public List<AttendanceLine> AttendanceLines = null;

        public InputDataSet()
        {
            JobQtyLines = new List<QtyLine>();
            MasterLines = new List<MasterLine>();
            AttendanceLines = new List<AttendanceLine>();
            _postOffSets = false;
        }

        public class MasterLine
        {
            private Dictionary<string, string> _masterData = null;
            private Field _inputField = null;
            private string _errorMessage = "";

            public List<HoursLine> JobHrsLines = null;
            public List<HoursLine> ProjectHrsLines = null;
            public List<HoursLine> SROHrsLines = null;
            public List<AttendanceLine> AttendanceLines = null;

            public MasterLine()
            {
                _masterData = new Dictionary<string, string>();
                JobHrsLines = new List<HoursLine>();
                ProjectHrsLines = new List<HoursLine>();
                SROHrsLines = new List<HoursLine>();
                AttendanceLines = new List<AttendanceLine>();

                _errorMessage = "";
            }

            public void SetDataDictionary(Dictionary<string, string> dataDictionary)
            {
                _masterData = dataDictionary;
            }

            public string GetValue(string key)
            {
                if (! _masterData.ContainsKey(key))
                {
                    return "";
                }
                return _masterData[key];
            }

            public Field InputField
            {
                get { return _inputField; }
                set { _inputField = value; }
            }

            public string ErrorMessage
            {
                get { return _errorMessage; }
                set { _errorMessage = value; }
            }
        }

        public class HoursLine
        {
            private Dictionary<string, string> _hoursData = null;
            private Field _inputField = null;
            private string _errorMessage = "";
            private bool _jobLine = false;
            private bool _projectLine = false;
            private bool _SROLine = false;

            public HoursLine()
            {
                _hoursData = new Dictionary<string, string>();
                _errorMessage = "";
                _jobLine = false;
                _projectLine = false;
                _SROLine = false;
            }

            public void SetDataDictionary(Dictionary<string, string> dataDictionary)
            {
                _hoursData = dataDictionary;
            }

            public string GetValue(string key)
            {
                if (!_hoursData.ContainsKey(key))
                {
                    return "";
                }
                return _hoursData[key];
            }

            public Field InputField
            {
                get { return _inputField; }
                set { _inputField = value; }
            }

            public string ErrorMessage
            {
                get { return _errorMessage; }
                set { _errorMessage = value; }
            }
            public bool IsJobLine
            {
                get { return _jobLine; }
                set { _jobLine = value; }
            }

            public bool IsProjectLine
            {
                get { return _projectLine; }
                set { _projectLine = value; }
            }

            public bool IsSROLine
            {
                get { return _SROLine; }
                set { _SROLine = value; }
            }
        }

        public class QtyLine
        {
            private Dictionary<string, string> _qtyData = null;
            private Field _inputField = null;
            private string _errorMessage = "";

            public QtyLine()
            {
                _qtyData = new Dictionary<string, string>();
                _errorMessage = "";
            }

            public void SetDataDictionary(Dictionary<string, string> dataDictionary)
            {
                _qtyData = dataDictionary;
            }

            public string GetValue(string key)
            {
                if (!_qtyData.ContainsKey(key))
                {
                    return "";
                }
                return _qtyData[key];
            }

            public Field InputField
            {
                get { return _inputField; }
                set { _inputField = value; }
            }

            public string ErrorMessage
            {
                get { return _errorMessage; }
                set { _errorMessage = value; }
            }
        }

        public class AttendanceLine 
        {
            private Dictionary<string, string> _attendanceData = null;
            private Field _inputField = null;
            private string _errorMessage = "";

            public AttendanceLine()
            {
                _attendanceData =new Dictionary<string,string>() ;
                _errorMessage = "";

            }
            public void SetDataDictionary(Dictionary<string, string> dataDictionary)
            {
                _attendanceData = dataDictionary;

            }
            public Field InputField
            {
                get { return _inputField; }
                set{_inputField =value;} 
            }
            public string ErrorMessage
            {
                get { return _errorMessage; }
                set { _errorMessage = value; }
            }
            public string GetValue(string key)
            {
                if (!_attendanceData.ContainsKey(key))
                {
                    return "";
                }
                return _attendanceData[key];
            }
        }

        public bool PostOffSets
        {
            get { return _postOffSets; }
            set { _postOffSets = value; }
        }

        public string UserInitials
        {
            get { return _userInitials; }
            set { _userInitials = value; }
        }

        public string DeviceId
        {
            get { return _deviceId; }
            set { _deviceId = value; }
        }

        public bool StopPostJobs
        {
            get { return _StopPostJobs; }
            set { _StopPostJobs = value; }
        }
    }
}
