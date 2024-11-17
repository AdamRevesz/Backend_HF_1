using Backend_HF_1.Database;
using Backend_HF_1.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend_HF_1.Repository;
using System.Text.Json;

namespace Backend_HF_1.Logic
{
    public class WaterLevelLogic : IWaterLevelLogic
    {
        private readonly IDunaLevelRepository _repository;
        public WaterLevelLogic(IDunaLevelRepository repository)
        {
            _repository = repository;
        }

        public List<MonthlyStatistics> GetMonthlyStatistics()
        {
            var data = _repository.GetAll();

            return data
                .GroupBy(w => new { w.Date.Year, w.Date.Month })
                .Select(g => new MonthlyStatistics
                {
                    Month = $"{g.Key.Year}.{g.Key.Month:D2}",
                    AverageValue = g.Average(w => w.WaterLevel),
                    MinimalValue = g.Min(w => w.WaterLevel),
                    MaximalValue = g.Max(w => w.WaterLevel)
                })
                .OrderBy(m => m.Month)
                .ToList();
        }

        public List<DunaLevel> GetDunaLevelsFromPath(string path)
        {
            if (!path.EndsWith(".json") || !path.EndsWith(".txt"))
            {
                throw new ArgumentException("Not supported file format");
            }

            var extractedData = File.ReadAllText(path);
            return GetDunaLevelsData(extractedData);
        }

        public List<DunaLevel> GetDunaLevelsData(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                throw new ArgumentException("Json data is empty");
            }
            return JsonSerializer.Deserialize<List<DunaLevel>>(json) ?? [];
        }

        public void CreateDunaData(List<DunaLevel> data)
        {
            if (data is null)
            {
                throw new ArgumentException("No data found");
            }
            foreach (var item in data)
            {
                CreateDunaData(item);
            }
        }

        public void CreateDunaData(DunaLevel data)
        {
            if (data is null)
            {
                throw new ArgumentException("No data found");
            }
            _repository.Create(data);
        }



    }


}
