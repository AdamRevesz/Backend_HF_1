using Backend_HF_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_HF_1.Repository
{
    public interface IDunaLevelRepository
    {
        void Create(DunaLevel entity);
        IQueryable<DunaLevel> GetAll();
    }
}
