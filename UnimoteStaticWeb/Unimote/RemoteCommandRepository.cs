namespace Unimote
{
	using System;
	using System.Collections.Generic;

	/// <summary>
	/// Repository for RemoteCommand
	/// </summary>
	public partial interface RemoteCommandRepository
	{
		void DeleteRemoteCommand(RemoteCommand remoteCommand);
		void DeleteRemoteCommandById(int remoteCommandId);
		IEnumerable<RemoteCommand> GetRemoteCommands();
		RemoteCommand GetRemoteCommandById(int remoteCommandId);
		int InsertRemoteCommand(RemoteCommand remoteCommand);
		void UpdateRemoteCommand(RemoteCommand remoteCommand);
	}
}