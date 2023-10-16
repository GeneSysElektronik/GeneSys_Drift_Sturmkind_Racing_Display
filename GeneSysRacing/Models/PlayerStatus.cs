using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneSysRacing.Models
{
	public class PlayerStatus
	{
		public string GameId { get; set; }
		public string UserId { get; set; }
		public string UserName { get; set; }
		public int LapsCompleted { get; set; }
		public Dictionary<string, int> TargetCodeCounter { get; set; }
		public int TotalScore { get; set; }
		public string TotalTime { get; set; }
		public object BestLap { get; set; } // You can use a more specific type here if needed
		public object LastLap { get; set; } // You can use a more specific type here if needed
		public DateTime? LastLapTimestamp { get; set; } // Nullable DateTime
		public object LastRecognizedTarget { get; set; } // You can use a more specific type here if needed
		public int JokerLapsCounter { get; set; }
		public EnterData EnterData { get; set; }
		public StartData StartData { get; set; }
		public object EndData { get; set; } // You can use a more specific type here if needed
	}

	public class EnterData
	{
		public string GameMode { get; set; }
		public DateTime? StartTime { get; set; } // Nullable DateTime
		public int LapCount { get; set; }
		public string TrackCondition { get; set; }
		public string TrackBundle { get; set; }
		public string Wheels { get; set; }
		public string SetupMode { get; set; }
		public string EngineType { get; set; }
		public string TuningType { get; set; }
		public int SteeringAngle { get; set; }
		public object SoftSteering { get; set; } // You can use a more specific type here if needed
		public object DriftAssist { get; set; } // You can use a more specific type here if needed
		public string CarName { get; set; }
	}

	public class StartData
	{
		public DateTime SignalTime { get; set; }
	}
}
