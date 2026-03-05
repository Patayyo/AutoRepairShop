using AutoRepairShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoRepairShop.Application.Contracts;

public record TypeOfWorkResponse(Guid Id, string Name, EngineTypeEnum Engine);