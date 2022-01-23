using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace api.Models.ServiceModel.Interfaces
{
    public interface ISituation
    {
        Task<IActionResult> List();

    }
}