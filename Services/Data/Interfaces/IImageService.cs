﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels.Images;

namespace Services.Data.Interfaces
{
    public interface IImageService
    {
        Task InsertImage(string imageName, string projectId, bool showOnHomePage = false, bool isProjectThumbnail = false);
        Task SaveImagesToFileSystem(IEnumerable<ImageUploadViewModel> images);
        Task<string> UpdateImages(IEnumerable<ImagesInProjectUpdateModel> images);
        Task<IEnumerable<T>> GetAllHomePageImages<T>();
        Task<IEnumerable<T>> GetRandomImagesForHomePageCards<T>();
        Task<IEnumerable<T>> GetAll<T>();
    }
}
