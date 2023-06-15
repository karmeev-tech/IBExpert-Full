﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Clients.UnoApp.Presentation.Registration
{
    public partial class RegistrationViewModel2 : ObservableObject
    {
        public string? Title { get; }

        [ObservableProperty]
        private string? name;

        public ICommand GoToSecond { get; }
        private async Task GoToSecondView()
        {
            await _navigator.NavigateViewModelAsync<RegistrationViewModel3>(this);
        }

        private INavigator _navigator;

        public RegistrationViewModel2(
            INavigator navigator,
            IOptions<AppConfig> appInfo)
        {
            _navigator = navigator;
            Title = $"Main - {appInfo?.Value?.Title}";
            GoToSecond = new AsyncRelayCommand(GoToSecondView);
        }
    }
}
