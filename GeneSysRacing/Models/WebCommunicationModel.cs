using CsvHelper;
using CsvHelper.Configuration;
using GeneSysRacing.ViewModels;
using Newtonsoft.Json.Linq;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

namespace GeneSysRacing.Models
{
	public static class WebCommunicationModel
	{
		private static readonly HttpClient _client = new();
		private static readonly XmlDocument _xmlDoc = new();
		private static readonly FileInfo _xmlFilePath = new(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "GeneSys Elektronik GmbH", "GeneSysRacing", "Setups", "ApplicationData.xml"));
		
		public static string? DockerLocation { get; set; }
		public static string? APILocation { get; set; }
		public static string? Results { get; set; }

		public static void LoadXmlData()
		{
			if (!_xmlFilePath.Exists)
				CreateXmlFile();

			_xmlDoc.Load(_xmlFilePath.FullName);
			DockerLocation = _xmlDoc.SelectSingleNode("//Docker")?.InnerText;
			APILocation = _xmlDoc.SelectSingleNode("//API")?.InnerText;
		}
		public static void UpdateXmlData(string? docker, string? api)
		{
			DockerLocation = docker;
			APILocation = api;

			if (_xmlDoc.SelectSingleNode("//Docker") is XmlNode dockerNode)
				dockerNode.InnerText = docker;
			if (_xmlDoc.SelectSingleNode("//API") is XmlNode apiNode)
				apiNode.InnerText = api;

			_xmlDoc.Save(_xmlFilePath.FullName);
		}

		public static async Task<bool> ResetServer(RaceViewModel race)
		{
			try
			{
				await _client.GetAsync($"http://{race.IP}:8001/manage_game/reset/{race.ID}");
				return true;
			}
			catch
			{
				return false;
			}
		}
		public static async Task<JArray?> TryGetResponseAsync(RaceViewModel race)
		{
			try
			{
				var responseMessage = await _client.GetAsync($"http://{race.IP}:8001/game/{race.ID}/playerstatus");
				if (!responseMessage.IsSuccessStatusCode || await responseMessage.Content.ReadAsStringAsync() is not string responseString) return null;

				return JArray.Parse(responseString);
			}
			catch
			{
				return null;
			}
		}
		public static void ExportRace(RaceViewModel currentRace)
		{
			DirectoryInfo directory = new(@$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\GeneSysRacing Ergebnisse\{Results}");
			FileInfo file = new(Path.Combine(directory.FullName, "Bestzeiten.csv"));

			directory.Create();

			using StreamWriter recordsStreamWriter = new(file.FullName);
			using CsvWriter recordsCsvWriter = new(recordsStreamWriter, new CsvConfiguration(CultureInfo.InvariantCulture));
			recordsCsvWriter.WriteRecords(currentRace.AllPlayerCollection);

			foreach (var player in currentRace.AllPlayerCollection)
			{
				file = new(Path.Combine(directory.FullName, "Spielerzeiten", $"{player.Name}.csv"));

				file.Directory?.Create();

				using StreamWriter playerStewamWriter = new(file.FullName, true);
				using CsvWriter playerCsvWriter = new(playerStewamWriter, new CsvConfiguration(CultureInfo.InvariantCulture));
				playerCsvWriter.WriteRecords(player.LapTimes);
			}
		}

		private static void CreateXmlFile()
		{
			XmlDeclaration xmlDeclaration = _xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
			_xmlDoc.AppendChild(xmlDeclaration);

			XmlElement root = _xmlDoc.CreateElement("Location");
			XmlElement docker = _xmlDoc.CreateElement("Docker");
			XmlElement api = _xmlDoc.CreateElement("API");
			root.AppendChild(docker);
			root.AppendChild(api);
			_xmlDoc.AppendChild(root);

			_xmlFilePath.Directory?.Create();
			_xmlDoc.Save(_xmlFilePath.FullName);
		}
	}
}
