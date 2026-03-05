using System;
using System.Collections.Generic;
using System.Text;

public record CarWorkHistoryResponse(Guid Id, Guid CarId, Guid TypeOfWorkId, DateTimeOffset InWork, DateTimeOffset OutWork);
