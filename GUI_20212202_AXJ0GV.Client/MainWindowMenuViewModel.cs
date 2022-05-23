using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUI_20212202_AXJ0GV.Client
{
    public class MainWindowMenuViewModel
    {
        //public ICommand NewGameSelect { get; set; }
        public ICommand MissionSelect { get; set; }

        public MainWindowMenuViewModel()
        {
            //NewGameSelect = new RelayCommand(() => _ = new MainWindow().ShowDialog());
            MissionSelect = new RelayCommand(() => _ = new MissionSelectMenu().ShowDialog());
        }
    }
}
