using System;

namespace PayTime.Core.Errors
{
    using static String;

    public static class Errors
    {
        public static class PayrollManagement
        {
            public static Error PayrollError(string message)
            {
                return new Error("Payroll data error", message);
            }
        }

        public static class General
        {
            public static Error ApplicationError(string message = null)
            {
                message = message != null ? $": {message}" : "";
                return new Error("general.error.processing.request", Format("An error occurred while processing the request {0}", message));
            }
        }
    }
}
