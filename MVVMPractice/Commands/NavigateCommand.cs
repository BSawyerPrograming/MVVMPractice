using MVVMPractice.Services;
using MVVMPractice.Stores;
using MVVMPractice.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMPractice.Commands;

public class NavigateCommand : CommandBase
{
    private readonly NavigationService _navigationService;

    public NavigateCommand(NavigationService navigationService) => 
        _navigationService = navigationService;

    public override void Execute(object? parameter)
    {
        _navigationService.Navigate();
    }
}
