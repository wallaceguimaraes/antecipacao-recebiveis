using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Infrastructure.Context;
using api.Models.EntityModel.Queries;
using api.Models.ServiceModel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models.ResultModel;


namespace api.Models.ServiceModel.Services
{
    public class PortionService : IPortionService
    {
        private readonly DataContext _context;

        public PortionService(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> List()
        {
            try
            {
                var portions = await _context.Portions
                                    .OrderById()
                                    .ToListAsync();

                if (portions == null) return null;

                return new PortionListJson(portions);
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
    }
}