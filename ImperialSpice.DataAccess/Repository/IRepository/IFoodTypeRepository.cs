﻿using ImperialSpice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImperialSpice.DataAccess.Repository.IRepository
{
    public interface IFoodTypeRepository:IRepository<FoodType>
    {
        void Update(FoodType obj);
    }
}
