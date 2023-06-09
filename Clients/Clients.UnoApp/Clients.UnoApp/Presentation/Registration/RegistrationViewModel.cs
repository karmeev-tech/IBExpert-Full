﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using System.Xml.Linq;
using Uno.Extensions.Navigation;

namespace Clients.UnoApp.Presentation.Registration
{
    public partial class RegistrationViewModel : ObservableObject
    {
        public string? Title { get; }

        [ObservableProperty]
        private string? name;

        public ICommand GoToSecond { get; }
        private async Task GoToSecondView()
        {
            await _navigator.NavigateViewModelAsync<RegistrationViewModel2>(this);
        }

        private INavigator _navigator;

        public RegistrationViewModel(
            INavigator navigator,
            IOptions<AppConfig> appInfo)
        {
            _navigator = navigator;
            Title = $"Main - {appInfo?.Value?.Title}";
            GoToSecond = new AsyncRelayCommand(GoToSecondView);
        }
    }
}
