namespace UnimoteStaticWeb.Models
{
	using System.ComponentModel.DataAnnotations;
	using Unimote;

	public class RemoteCommandModel
	{
		public RemoteCommandModel()
		{
		}
		public RemoteCommandModel(RemoteCommand remoteCommand)
		{
			Id = remoteCommand.Id;
			Name = remoteCommand.Name;
			SignalCode = remoteCommand.SignalCode;
		}
		public int Id { get; private set; }
		[Required]
		public string Name { get; set; }
		public string SignalCode { get; set; }
	}
}
