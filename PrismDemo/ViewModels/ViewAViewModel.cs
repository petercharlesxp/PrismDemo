﻿using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PrismDemo.ViewModels
{
    public class ViewAViewModel: BindableBase
    {
        private string _firstName = "Brian";

        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set 
            { 
                SetProperty(ref _lastName, value);
                //UpdateCommand.RaiseCanExecuteChanged(); 
            }
        }

        private DateTime? _lastUpdated;

        public DateTime? LastUpdated
        {
            get { return _lastUpdated; }
            set 
            { 
                SetProperty(ref _lastUpdated, value); 
                //UpdateCommand.RaiseCanExecuteChanged(); 
            }
        }

        public DelegateCommand UpdateCommand { get; set; }

        public ViewAViewModel()
        {
            UpdateCommand = new DelegateCommand(Execute, CanExecute)
                .ObservesProperty(() => FirstName)
                .ObservesProperty(() => LastName);
            //UpdateCommand = new DelegateCommand(Execute).ObservesCanExecute(p => CanExecute);
        }

        private bool CanExecute()
        {
            return !String.IsNullOrWhiteSpace(FirstName) && !String.IsNullOrWhiteSpace(LastName);
        }

        private void Execute()
        {
            LastUpdated = DateTime.Now;
        }
    }
}
