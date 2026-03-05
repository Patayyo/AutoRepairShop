using AutoRepairShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoRepairShop.Application.Contracts;

public record CarResponse(Guid Id, string Brand, string Model, string StateNumber, EngineTypeEnum Engine);