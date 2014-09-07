using System;

namespace MetroBukkitUI.Craftbukkit {

    public class ServerStateChangedEventArgs : EventArgs {

        private readonly ServerState _serverState;

        public ServerStateChangedEventArgs() {

            _serverState = ServerState.Unknown;

        }

        public ServerStateChangedEventArgs(ServerState state) { _serverState = state; }

        public ServerState State { get { return _serverState; } }

    }

}
