using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using BukkitUI_WPF.Interfaces;

namespace BukkitUI_WPF {
    
    public partial class BukkitUI : Window {

        public BukkitUI() {
            InitializeComponent();
        }

        #region Page Switching Stuff
        public void navigate(UserControl nextPage) { windowContent.Content = nextPage; }

        public void navigate(UserControl nextPage, object state) {
            windowContent.Content = nextPage;

            ISwitchable switchable = nextPage as ISwitchable;

            if (switchable != null)
                switchable.utilizeState(state);
            else
                throw new ArgumentException("Next page is not switchable!");

        }
        #endregion

    }

}
