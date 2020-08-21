using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using UpLiftCurse.Models;

namespace UpLiftCurse.AccessData.Data.Repository.IRepository
{
    public interface IServiceRepository : IRepository<Service>
    {
        //IEnumerable<SelectListItem> GetCategoryListForDropDown();

        void Update(Service service);
    }
}
