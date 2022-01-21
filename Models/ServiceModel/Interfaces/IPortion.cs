using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models.EntityModel;
using Microsoft.AspNetCore.Mvc;

namespace api.Models.ServiceModel.Interfaces
{
    public interface IPortion
    {
        Task<IActionResult> List();
        Task<IActionResult> SavePortion(Transfer transfer);
    }
}