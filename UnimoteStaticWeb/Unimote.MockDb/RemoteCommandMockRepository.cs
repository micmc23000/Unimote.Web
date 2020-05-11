namespace Unimote.MockDb
{
    using System;
    using System.Collections.Generic;
    using Unimote;

    /// <summary>
    /// Repository for RemoteCommand
    /// </summary>
    public class RemoteCommandMockRepository : RemoteCommandRepository
    {
        private RemoteCommandMockRepository()
        {
            var ledLightRemoteCommand = new RemoteCommand
            {
                Id = 1,
                Name = "LED Lights",
                SignalCode = "102",
            };
            var kettleLightRemoteCommand = new RemoteCommand
            {
                Id = 2,
                Name = "Kettle",
                SignalCode = "253",
            };
            var tvLightRemoteCommand = new RemoteCommand
            {
                Id = 3,
                Name = "TV",
                SignalCode = "156",
            };
            var selfDestructCommand = new RemoteCommand
            {
                Id = 4,
                Name = "Self Destruct",
                SignalCode = "1",
            };
            remoteCommands = new List<RemoteCommand>
            {
                ledLightRemoteCommand,
                kettleLightRemoteCommand,
                tvLightRemoteCommand,
                selfDestructCommand,
            };
        }
        public static RemoteCommandMockRepository Singleton { get; private set; } = new RemoteCommandMockRepository();

        public void DeleteRemoteCommand(RemoteCommand remoteCommand)
        {
            remoteCommands.Remove(remoteCommand);
        }
        public void DeleteRemoteCommandById(int remoteCommandId)
        {
            var remoteCommand = GetRemoteCommandById(remoteCommandId);
            remoteCommands.Remove(remoteCommand);
        }
        public IEnumerable<RemoteCommand> GetRemoteCommands()
        {
            return remoteCommands;
        }
        public RemoteCommand GetRemoteCommandById(int remoteCommandId)
        {
            foreach (var remoteCommand in remoteCommands)
            {
                if (remoteCommand.Id == remoteCommandId)
                    return remoteCommand;
            }
            return default;
        }
        public int InsertRemoteCommand(RemoteCommand remoteCommand)
        {
            remoteCommand.Id = remoteCommands.Count + 1;
            remoteCommands.Add(remoteCommand);
            return remoteCommand.Id;
        }
        public void UpdateRemoteCommand(RemoteCommand remoteCommand)
        {
            Console.WriteLine($"Update {remoteCommand.Id}");
        }
        private readonly IList<RemoteCommand> remoteCommands;

    }
}