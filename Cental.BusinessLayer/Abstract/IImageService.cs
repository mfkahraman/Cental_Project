﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Abstract
{
    public interface IImageService
    {
        /// <summary>
        /// Saves an image file from the computer to projects wwwroot/images folder
        /// </summary>
        /// <param name="file"></param>
        /// <returns> Returns a strings value for the model's ImageUrl property </returns>
        Task<string> SaveImageAsync(IFormFile file);
    }
}
