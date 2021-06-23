using BudgetApplicationV2.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetApplicationV2.MVVM.ViewModel
{
    //Code Attributtion 
    //Author/Channel = BinaryBunny 
    //Website:Youtube
    //Topic:Professional modern flat UI Tutorial
    //Link: https://youtu.be/PzP8mw7JUzI
    class MainViewModel : ObservableObject
    {
        //Creating 5 relycommands for each usercontrol 
        public RelyCommand ReportViewCommand { get; set; }
        public RelyCommand GoalViewCommand { get; set; }

        public RelyCommand HomeViewCommand { get; set; }

        public RelyCommand HouseViewCommand { get; set; }

        public RelyCommand VehicleViewCommand { get; set; }

        //Creating objects of the 5 viewmodel classes
        public HomeViewModel HomeVM { get; set; }

        public viewModelHome HouseVM { get; set; }

        public viewModelVehicle VehicleVM { get; set; }

        public viewModelGoals GoalVM { get; set; }

        public viewModelReport ReportVM { get; set; }

        private object _currentView;


       //Setting the currentView to a value and calling the onPropertyChanged method
        public object CurrentView
        {
            get { return _currentView; }
            set 
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }


        public MainViewModel()
        {
            //Instaniating the 5 viewModels
            HomeVM = new HomeViewModel();
            HouseVM = new viewModelHome();
            VehicleVM = new viewModelVehicle();
            GoalVM = new viewModelGoals();
            ReportVM = new viewModelReport();

            CurrentView = HomeVM;

            //Setting all the rely commands to the current view method and the viewmodel objects.
            HomeViewCommand = new RelyCommand(o =>
            {
                CurrentView = HomeVM;
            });

            HouseViewCommand = new RelyCommand(o =>
            {
                CurrentView = HouseVM;
            });

            VehicleViewCommand = new RelyCommand(o =>
            {
                CurrentView = VehicleVM;
            });

            GoalViewCommand = new RelyCommand(o =>
            {
                CurrentView = GoalVM;
            });

            ReportViewCommand = new RelyCommand(o =>
            {
                CurrentView = ReportVM;
            });
        }
    }
}
