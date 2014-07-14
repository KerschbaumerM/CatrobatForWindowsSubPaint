﻿using Catrobat.IDE.Core.Services;
using System.Threading.Tasks;

namespace Catrobat.IDE.Core.ViewModels.Editor.Costumes
{
    public class NewCostumeSourceSelectionViewModel : ViewModelBase
    {
        #region Private Members

        #endregion

        #region Properties



        #endregion

        #region Commands

        public AsyncRelayCommand OpenGalleryCommand { get; private set; }

        public AsyncRelayCommand OpenCameraCommand { get; private set; }

        public AsyncRelayCommand OpenPaintCommand { get; private set; }

        #endregion

        #region CommandCanExecute


        #endregion

        #region Actions

        public async Task OpenGalleryAction()
        {
            ServiceLocator.PictureService.ChoosePictureFromLibraryAsync();
            //var result = await ServiceLocator.PictureService.ChoosePictureFromLibraryAsync();
            //if (result.Status == PictureServiceStatus.Success)
            //    PictureSuccess(result.Image);
            //else if (result.Status == PictureServiceStatus.Error)
            //    PictureError();
        }

        public async Task OpenCameraAction()
        {
            ServiceLocator.PictureService.TakePictureAsync();
            //var result = await ServiceLocator.PictureService.TakePictureAsync();
            //if (result.Status == PictureServiceStatus.Success)
            //    PictureSuccess(result.Image);
            //else if (result.Status == PictureServiceStatus.Error)
            //    PictureError();
        }

        private async Task OpenPaintAction()
        {
            await ServiceLocator.PictureService.DrawPictureAsync();
            //var result = await ServiceLocator.PictureService.DrawPictureAsync();

            //ServiceLocator.DispatcherService.RunOnMainThread(() => 
            //    ServiceLocator.NavigationService.RemoveBackEntry());
            
            //if (result.Status == PictureServiceStatus.Success)
            //    PictureSuccess(result.Image);
            //else if (result.Status == PictureServiceStatus.Error)
            //    PictureError();

            
        }

        #endregion

        #region MessageActions


        #endregion

        public NewCostumeSourceSelectionViewModel()
        {
            OpenGalleryCommand = new AsyncRelayCommand(OpenGalleryAction, () => { /* no action  */ });
            OpenCameraCommand = new AsyncRelayCommand(OpenCameraAction, () => { /* no action  */ });
            OpenPaintCommand = new AsyncRelayCommand(OpenPaintAction, () => { /* no action  */ });
        }


        #region ImageFunctions

        #endregion
    }
}