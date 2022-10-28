using System;
using System.Collections.Generic;
using System.Text;
using VideoStore.Domain.Base;

namespace VideoStore.Application.Helpers
{
    public static class ResultHelper
    {
        public static Result GetErrorResult(string message) => new Result(null).ValidationError(message);
    }
}
