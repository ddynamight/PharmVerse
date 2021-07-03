﻿using MediatR;
using PharmVerse.Presentation.Patients.Models.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmVerse.Presentation.Patients.Queries
{
    public class GetPatientQuery : IRequest<GetPatientQueryResult>
    {
        public Guid Id { get; set; }
    }
}
