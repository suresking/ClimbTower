using Suresking.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbTower.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        private static int curentFloor=0;
        private List<Floor> floors = new List<Floor>();
        public MainWindowViewModel()
        {
            CurrentFloor = 1;
        }
        public DelegateCommand<string> GoCommand => new DelegateCommand<string>(p => {
            if (curentFloor >= 19) return;
            int f = Convert.ToInt32(p);
            curentFloor++;
            CurrentFloor = curentFloor + 1; 
            floors.Add(new Floor() { No = curentFloor, Flag = f });
            RefreshArea();
        });
        public DelegateCommand BackCommand => new DelegateCommand(() => {
            curentFloor--;
            if (curentFloor < 0) curentFloor = 0;
            else
            {
                floors.RemoveAt(floors.Count - 1);
                RefreshArea();
            }
            CurrentFloor = curentFloor + 1;
        });

        private void RefreshArea()
        {
            AreaOne = string.Join("  ", floors.Where(t => t.Flag == 1).Select(t => t.No).ToArray());
            AreaTwo = string.Join("  ", floors.Where(t => t.Flag == 2).Select(t => t.No).ToArray());
            AreaThree = string.Join("  ", floors.Where(t => t.Flag == 3).Select(t => t.No).ToArray());
            AreaFour = string.Join("  ", floors.Where(t => t.Flag == 4).Select(t => t.No).ToArray());

        }
        private int _CurrentFloor;
        public int CurrentFloor
        {
            get { return _CurrentFloor; }
            set { SetProperty(ref _CurrentFloor, value); }
        }

        private string _AreaOne;
        public string AreaOne
        {
            get { return _AreaOne; }
            set { SetProperty(ref _AreaOne, value); }
        }
        private string _AreaTwo;
        public string AreaTwo
        {
            get { return _AreaTwo; }
            set { SetProperty(ref _AreaTwo, value); }
        }
        private string _AreaThree;
        public string AreaThree
        {
            get { return _AreaThree; }
            set { SetProperty(ref _AreaThree, value); }
        }
        private string _AreaFour;
        public string AreaFour
        {
            get { return _AreaFour; }
            set { SetProperty(ref _AreaFour, value); }
        }

    }

    class Floor
    {
        public int No { get; set; }
        public int Flag { get; set; }
    }
}
