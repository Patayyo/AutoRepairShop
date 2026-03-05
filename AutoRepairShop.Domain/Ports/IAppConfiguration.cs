using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace AutoRepairShop.Domain.Ports;

public interface IAppConfiguration
{
    public string ConnectionString { get; }
}
