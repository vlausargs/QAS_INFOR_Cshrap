using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data
{
    public class DbException : Exception
    {
        private int _errorNumber;
        private int _errorSeverity;
        private int _errorState;
        private string _errorMessage;

        public DbException(string errorMessage)
            : base(errorMessage)
        {
            _errorNumber = -1;
            _errorSeverity = -1;
            _errorState = -1;
            _errorMessage = errorMessage;
        }

        public DbException(int errorNumber, int errorSeverity, int errorState, string errorMessage)
            : base(errorMessage)
        {
            _errorNumber = errorNumber;
            _errorSeverity = errorSeverity;
            _errorState = errorState;
            _errorMessage = errorMessage;
        }

        public DbException(int errorNumber, int errorSeverity, int errorState, string errorMessage, Exception originalException)
            : base(errorMessage, originalException)
        {
            _errorNumber = errorNumber;
            _errorSeverity = errorSeverity;
            _errorState = errorState;
            _errorMessage = errorMessage;
        }

        public DbException(string errorMessage, Exception originalException) : base(errorMessage, originalException)
        {
            _errorNumber = -1;
            _errorSeverity = -1;
            _errorState = -1;
            _errorMessage = errorMessage;
        }

        public int ErrorNumber
        {
            get { return _errorNumber; }
        }

        public int ErrorSeverity
        {
            get { return _errorSeverity; }
        }

        public int ErrorState
        {
            get { return _errorState; }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
        }
    }
}
