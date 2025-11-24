using System;

namespace ODataWebApplication2.Models
{
    [Flags]
    public enum CustomerType
    {
        None = 1,
        Premium = 2,
        VIP = 4
    }
}
