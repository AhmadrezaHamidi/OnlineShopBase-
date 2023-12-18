using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public sealed class AppException : Exception
    {
        public readonly ExceptionCode Code;
        public readonly object? AdditionalData;
        public readonly object[] MessageParams;
        public readonly string? CustomMessage;

        public AppException(ExceptionCode code,
            string? customMessage = null,
            object? additionalData = null,
            Exception? innerException = null,
            params object[] messageParams)
            : base(customMessage, innerException)
        {
            Code = code;
            AdditionalData = additionalData;
            MessageParams = messageParams;
            CustomMessage = customMessage;
        }
    }
}
