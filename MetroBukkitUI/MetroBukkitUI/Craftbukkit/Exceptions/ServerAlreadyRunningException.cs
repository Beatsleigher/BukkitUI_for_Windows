using System;

namespace MetroBukkitUI.Craftbukkit.Exceptions {

    public class ServerAlreadyRunningException : Exception {

        public ServerAlreadyRunningException() : base() {}

        public ServerAlreadyRunningException(String msg) : base(msg) {}

    }

}
