using api.Models.EntityModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace api.Models.ServiceModel.Interfaces
{
    public interface IPortion
    {
        Task<IActionResult> List();
        Task<IActionResult> SavePortion(Transfer transfer);
        Task<IActionResult> UpdatePortion(int transferId, decimal netValue);

        Task<IActionResult> EndDate(int transferId);


    }
}