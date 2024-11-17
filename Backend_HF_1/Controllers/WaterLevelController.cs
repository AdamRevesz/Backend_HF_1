using Backend_HF_1.Logic;
using Backend_HF_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend_HF_1.Endpoint.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WaterLevelController : ControllerBase
    {
        private readonly IWaterLevelLogic _logic;

        public WaterLevelController(IWaterLevelLogic logic)
        {
            _logic = logic;
        }
        [HttpPost("AddWater")]
        public void AddWaterLevel([FromBody] DunaLevel entry)
        {
            _logic.CreateDunaData(entry);
        }

        [HttpPost("AddWaterList")]
        public void AddWaterLevelList([FromBody]List<DunaLevel> entries)
        {
            _logic.CreateDunaData(entries);
        }
        [HttpGet]
        public IEnumerable<MonthlyStatistics> GetMonthlyStatistics()
        {
            return _logic.GetMonthlyStatistics();
        }
    }
}
