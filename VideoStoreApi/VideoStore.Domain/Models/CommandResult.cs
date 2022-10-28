using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace VideoStore.Domain.Models
{
    public class CommandResult : ObjectResult
    {
        public bool Error { get; set; } = false;
        public List<string> Messages { get; set; }
        public CommandResult(object value)
            : base(value)
        { }
    }
}
