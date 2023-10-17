using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Reactive;
using System.Diagnostics;
using Avalonia.Media;
using Templates;
using GeneSysRacing.Models;
using GeneSysRacing.Windows;
using Avalonia.Controls;
using System.IO;
using Avalonia.Platform.Storage;
using GeneSysRacing.BaseViewModel;
using GeneSysRacing.Views;

namespace GeneSysRacing.ViewModels.Views
{
    public class DriftServerViewModel : RaceBaseViewModel
    {
        #region Private Members
        private string? _dockerLocation;
        private string? _apiLocation;
        private IEnumerable<IPAddress>? _availableIPsCollection;
        private IPAddress? _selectedIPAdress;
        #endregion

        #region Public Members
        public IEnumerable<IPAddress>? AvailableIPsCollection
        {
            get => _availableIPsCollection;
            set => this.RaiseAndSetIfChanged(ref _availableIPsCollection, value);
        }

        public IPAddress? SelectedIPAdress
        {
            get => _selectedIPAdress;
            set => this.RaiseAndSetIfChanged(ref _selectedIPAdress, value);
        }

        public string? DockerLocation
        {
            get => _dockerLocation;
            set
            {
                this.RaiseAndSetIfChanged(ref _dockerLocation, value);
                WebCommunicationModel.UpdateXmlData(value, APILocation);
            }
        }
        public string? APILocation
        {
            get => _apiLocation;
            set
            {
                this.RaiseAndSetIfChanged(ref _apiLocation, value);
                WebCommunicationModel.UpdateXmlData(DockerLocation, value);
            }
        }

        public Geometry BrowseIcon { get; } = GeometryPathData.GetIconPath(IconKey.Browse);
        #endregion

        #region Commands
        public ReactiveCommand<Unit, Task> BrowseDockerCommand { get; }
        public ReactiveCommand<Unit, Task> BrowseAPICommand { get; }
        public ReactiveCommand<Unit, Task> RunServerCommand { get; }
        #endregion

        #region Constructor
        public DriftServerViewModel()
        {
            BrowseDockerCommand = ReactiveCommand.Create(BrowseDockerAsync);
            BrowseAPICommand = ReactiveCommand.Create(BrowseAPIAsync);
            RunServerCommand = ReactiveCommand.Create(RunServer);

            _dockerLocation = WebCommunicationModel.DockerLocation;
            _apiLocation = WebCommunicationModel.APILocation;

            ActiveHeader = "Server";
            ActiveControl = new DriftServerView() { DataContext = this };
        }
        #endregion

        #region Private Methods
        private async Task BrowseDockerAsync()
        {
            if (Activator.CreateInstance(typeof(MainWindow)) is not Window mainWindow) return;

            var startLocation = await mainWindow.StorageProvider.TryGetFolderFromPathAsync(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Docker", "Docker"));
            var pickedFiles = await mainWindow.StorageProvider.OpenFilePickerAsync(new() { SuggestedStartLocation = startLocation, FileTypeFilter = new List<FilePickerFileType>() { new FilePickerFileType("Docker Desktop") { Patterns = new List<string>() { "*.exe" } } } });
            DockerLocation = pickedFiles?[0].TryGetLocalPath();
        }
        private async Task BrowseAPIAsync()
        {
            if (Activator.CreateInstance(typeof(MainWindow)) is not Window mainWindow) return;

            var startLocation = await mainWindow.StorageProvider.TryGetFolderFromPathAsync(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            var pickedFolders = await mainWindow.StorageProvider.OpenFolderPickerAsync(new() { SuggestedStartLocation = startLocation });
            APILocation = pickedFolders?[0].TryGetLocalPath();
        }
        private async Task RunServer()
        {
            if (DockerLocation == null || APILocation == null) return;

            Process.Start(DockerLocation);

            await Task.Delay(TimeSpan.FromMinutes(1));

            ProcessStartInfo startInfo = new()
            {
                FileName = "powershell.exe",
                Arguments = @"-ExecutionPolicy Bypass -NoProfile -Command ""docker compose --profile racedisplay up""",
                WorkingDirectory = APILocation
            };

            Process.Start(startInfo);
        }
        #endregion
    }
}
