using Backend_HF_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_HF_1.Logic
{
    public interface IWaterLevelLogic
    {
        List<MonthlyStatistics> GetMonthlyStatistics();
        List<DunaLevel> GetDunaLevelsFromPath(string path);
        List<DunaLevel> GetDunaLevelsData(string json);
        void CreateDunaData(List<DunaLevel> data);
        void CreateDunaData(DunaLevel data);
    }
}
