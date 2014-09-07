using System;

namespace MetroBukkitUI.Craftbukkit {

    public interface ISaveable {

        void save();

        void load();

        String data();

    }

}
