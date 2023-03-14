using System;
using ReactiveUI;
using System.IO;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Linq;
using System.Net.Sockets;
using System.ComponentModel.DataAnnotations;
using Avalonia.Threading;
using static System.Net.WebRequestMethods;

namespace DemoApp.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private double _zoom = 1.0;

    public double Zoom
    {
        get => _zoom;
        set => this.RaiseAndSetIfChanged(ref _zoom, value);
    }

    public MainWindowViewModel()
    {
        if(!Avalonia.Controls.Design.IsDesignMode)
        {
        }
    }
}
