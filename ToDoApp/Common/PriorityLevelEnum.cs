using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Common
{
    public enum PriorityLevelEnum
    {
        [Description("High")] HIGH,
        [Description("Medium")] MEDIUM,
        [Description("Low")] LOW,
        [Description("Undefined")] UNDEFINED,
        [Description("All")] ALL
    }
}
