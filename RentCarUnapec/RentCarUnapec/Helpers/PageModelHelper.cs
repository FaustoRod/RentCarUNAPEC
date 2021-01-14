using Microsoft.AspNetCore.Mvc.Rendering;
using RentCarUnapec.Core.Models;
using System.Collections.Generic;

namespace RentCarUnapec.Helpers
{
    public static class PageModelHelper
    {
        public static SelectList GetSelectList<T>(List<T> modelList)
        {
            return new SelectList(modelList,nameof(CommonModel.Id), nameof(CommonModel.Description));
        }
    }
}
