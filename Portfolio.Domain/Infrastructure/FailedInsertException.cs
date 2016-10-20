using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.Domain.Infrastructure
{
    public class FailedInsertException : Exception
    {

        public FailedInsertException()
        {
        }

        public FailedInsertException(string message)
        : base(message)
        {
        }

        public FailedInsertException(string message, Exception inner)
        : base(message, inner)
         {
         }
    }
}