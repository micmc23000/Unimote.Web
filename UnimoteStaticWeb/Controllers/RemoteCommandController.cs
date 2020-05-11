using ConsoleAppTest;
using Microsoft.AspNetCore.Mvc;
using Unimote;
using Unimote.MockDb;
using UnimoteStaticWeb.Models;

namespace UnimoteStaticWeb.Controllers
{
	public class RemoteCommandController : Controller
	{
		// GET: RemoteCommand
		public ActionResult Index()
		{
			var remoteCommands = RemoteCommandMockRepository.Singleton.GetRemoteCommands();
			return View(remoteCommands);
		}

		// GET: RemoteCommand/Details/5
		public ActionResult Details(int id)
		{
			var remoteCommand = RemoteCommandMockRepository.Singleton.GetRemoteCommandById(id);
			return View(new RemoteCommandModel(remoteCommand));
		}

		// GET: RemoteCommand/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: RemoteCommand/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(RemoteCommandModel remoteCommandModel)
		{
			try
			{
				var remoteCommand = new RemoteCommand
				{
					Name = remoteCommandModel.Name,
					SignalCode = remoteCommandModel.SignalCode
				};

				RemoteCommandMockRepository.Singleton.InsertRemoteCommand(remoteCommand);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View(remoteCommandModel);
			}
		}

		// GET: RemoteCommand/Edit/5
		public ActionResult Edit(int id)
		{
			var remoteCommand = RemoteCommandMockRepository.Singleton.GetRemoteCommandById(id);
			return View(new RemoteCommandModel(remoteCommand));
		}

		// POST: RemoteCommand/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, RemoteCommandModel remoteCommandModel)
		{
			try
			{
				var remoteCommand = RemoteCommandMockRepository.Singleton.GetRemoteCommandById(id);

				remoteCommand.Name = remoteCommandModel.Name;
				remoteCommand.SignalCode = remoteCommandModel.SignalCode;

				RemoteCommandMockRepository.Singleton.UpdateRemoteCommand(remoteCommand);

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View(remoteCommandModel);
			}
		}

		// GET: RemoteCommand/Delete/5
		public ActionResult Delete(int id)
		{
			var remoteCommand = RemoteCommandMockRepository.Singleton.GetRemoteCommandById(id);
			return View(new RemoteCommandModel(remoteCommand));
		}

		// POST: RemoteCommand/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, RemoteCommandModel remoteCommandModel)
		{
			try
			{
				RemoteCommandMockRepository.Singleton.DeleteRemoteCommandById(id);

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// POST: RemoteCommand/Active/5
		public ActionResult Activate(int id)
		{
			try
			{
				var remoteCommand = RemoteCommandMockRepository.Singleton.GetRemoteCommandById(id);
				var pythonCaller = new PythonCaller();

				pythonCaller.Execute(remoteCommand.SignalCode);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View("Error");
			}
		}
	}
}