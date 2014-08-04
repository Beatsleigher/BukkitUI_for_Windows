using System;
using System.Windows.Controls;
using System.Linq;

namespace BukkitUI_WPF {
    public static class PageSwitcher {

        public static BukkitUI instance;

        public static void switchPage(UserControl nextPage) { instance.navigate(nextPage);  }

        public static void switchPage(UserControl nextPage, object state) { instance.navigate(nextPage, state); }

    }
}
