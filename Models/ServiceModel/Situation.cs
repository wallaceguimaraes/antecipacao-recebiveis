using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models.ServiceModel.Interfaces;
using api.Infrastructure.Context;
using api.Models.EntityModel.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using api.Models.ResultModel;



namespace api.Models.ServiceModel
{
    public class Situation : ISituation
    {
        private readonly DataContext _context;

        public Situation(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> List()
        {
            try
            {
                var situations = await _context.Situations
                                    .OrderByDescription()
                                    .ToListAsync();

                if (situations == null) return null;

                return new SituationListJson(situations);
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}


